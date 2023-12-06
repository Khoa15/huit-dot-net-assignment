using DigitalDocumentary.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DigitalDocumentary.DLL
{
    internal class DatabaseContextDAL
    {
        DatabaseContextDTO db = new DatabaseContextDTO();

        internal DatabaseContextDTO DbContext { get => db; set => db = value; }

        public DatabaseContextDAL() { }
        public SqlDataReader Reader(string query)
        {
            db.Conn.Open();
            SqlCommand cmd = new SqlCommand(query, db.Conn);
            SqlDataReader rd = cmd.ExecuteReader();
            db.Conn.Close();
            return rd;
        }
        public int NonQuery(string query)
        {
            db.Conn.Open();
            SqlCommand cmd = new SqlCommand(query, db.Conn);
            int result = cmd.ExecuteNonQuery();
            db.Conn.Close();
            return result;
        }

        public int NonQueryBySP(string nameStoredProcedure, string[] param, object[] value)
        {
            try
            {
                if (param.Length != value.Length) return 0;
                db.Conn.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = db.Conn;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = nameStoredProcedure;
                if(param != null)
                {
                    for(int i = 0; i <  param.Length; i++)
                    {
                        command.Parameters.AddWithValue(param[i], value[i]);
                    }
                }
                int result = command.ExecuteNonQuery();
                db.Conn.Close();
                return result;
            }catch(Exception ex)
            {
                return 0;
            }
            finally{
                if(db.Conn.State == ConnectionState.Open) db.Conn.Close();
            }
        }
        public int NonQueryBySP(string nameStoredProcedure, string param, object value)
        {
            try
            {
                db.Conn.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = db.Conn;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = nameStoredProcedure;
                if(param != null || param.Length != 0)
                {
                    command.Parameters.AddWithValue(param, value);
                }
                int result = command.ExecuteNonQuery();
                db.Conn.Close();
                return result;
            }catch(Exception ex)
            {
                return 0;
            }
            finally
            {
                if (db.Conn.State == ConnectionState.Open) db.Conn.Close();
            }
        }

        //public SqlDataReader Select(string table, string where=null, int limit=1000)
        //{
        //    string sql = $"SELECT TOP({limit}) * FROM {table} ";
        //    if (where != null)
        //    {
        //        sql += where;
        //    }
        //    db.Conn.Open();
        //    SqlCommand cmd = new SqlCommand(sql, db.Conn);
        //    SqlDataReader rd = cmd.ExecuteReader();
        //    // Create a copy of the data before closing the connection
        //    List<DataRow> data = new List<DataRow>();
        //    while (rd.Read())
        //    {
        //        DataRow row = new DataRow();
        //        for (int i = 0; i < rd.FieldCount; i++)
        //        {
        //            row[rd.GetName(i)] = rd[i];
        //        }
        //        data.Add(row);
        //    }

        //    // Close the database connection
        //    db.Conn.Close();

        //    // Return a new SqlDataReader from the copied data
        //    return new SqlDataReader(data);
        //}
        //public List<DataRow> Select(string table, string where = null, int limit = 1000)
        //{
        //    string sql = $"SELECT TOP({limit}) * FROM {table} ";
        //    if (where != null)
        //    {
        //        sql += "WHERE " + where;
        //    }

        //    db.Conn.Open();
        //    SqlCommand cmd = new SqlCommand(sql, db.Conn);
        //    SqlDataReader rd = cmd.ExecuteReader();

        //    // Create a DataTable to hold the data
        //    DataTable dt = new DataTable();
        //    dt.Load(rd);

        //    // Close the database connection
        //    rd.Close();
        //    db.Conn.Close();

        //    // Return the rows from the DataTable
        //    var x = dt.AsEnumerable();
        //    var y = dt.AsEnumerable().ToList();
        //    return dt.AsEnumerable().ToList();
        //}
        //public List<DataRow> Select(string[] tables, string where = null, int limit = 1000)
        //{
        //    string sql = $"SELECT TOP({limit}) * FROM {string.Join(", ", tables)} ";
        //    if (where != null)
        //    {
        //        sql += "WHERE " + where;
        //    }

        //    db.Conn.Open();
        //    SqlCommand cmd = new SqlCommand(sql, db.Conn);
        //    SqlDataReader rd = cmd.ExecuteReader();

        //    // Create a DataTable to hold the data
        //    DataTable dt = new DataTable();
        //    dt.Load(rd);

        //    // Close the database connection
        //    rd.Close();
        //    db.Conn.Close();

        //    // Return the rows from the DataTable
        //    var x = dt.AsEnumerable();
        //    var y = dt.AsEnumerable().ToList();
        //    return dt.AsEnumerable().ToList();
        //}

        public DataSet Select(string nameStoredProcedure = null, string param=null, string value = null)
        {
            DataSet ds = new DataSet();
            try
            {
                db.Conn.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = db.Conn;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = nameStoredProcedure;
                if(param != null)
                {
                    command.Parameters.Add(param, value);
                }
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(ds);
                db.Conn.Close();

            }catch(Exception ex)
            {

            }
            finally
            {
                if (db.Conn.State == ConnectionState.Open) db.Conn.Close();
            }

            return ds;
        }


        //public SqlDataReader Select(string[] tables, string where = null, int limit = 1000)
        //{
        //    string sql = $"SELECT TOP({limit}) * FROM {string.Join(", ", tables)} ";

        //    if (where != null)
        //    {
        //        sql += "WHERE "+where;
        //    }
        //    db.Conn.Open();
        //    SqlCommand cmd = new SqlCommand(sql, db.Conn);
        //    SqlDataReader rd = cmd.ExecuteReader();
        //    db.Conn.Close();
        //    return rd;
        //}

        public int Update(string query)
        {
            string sql = "UPDATE [table] SET";
            db.Conn.Open();
            SqlCommand cmd = new SqlCommand(query, db.Conn);
            int result = cmd.ExecuteNonQuery();
            db.Conn.Close();
            return result;
        }
        public int Update(string table, string fields, string where)
        {
            string sql = $"UPDATE {table} SET";
            sql += " " + fields;
            sql += " " + where;
            db.Conn.Open();
            SqlCommand cmd = new SqlCommand(sql, db.Conn);
            int result = cmd.ExecuteNonQuery();
            db.Conn.Close();
            return result;
        }
        public int Delete(string query)
        {
            string sql = "DELETE [table] WHERE";
            db.Conn.Open();
            SqlCommand cmd = new SqlCommand(query, db.Conn);
            int result = cmd.ExecuteNonQuery();
            db.Conn.Close();
            return result;
        }
    }
}
