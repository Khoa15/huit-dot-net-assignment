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
                db.Conn.Open();
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
        public DataSet Select(string nameStoredProcedure = null, string param=null, object value = null)
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
                    command.Parameters.AddWithValue(param, value);
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

        public int QueryByFunction(string function)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = db.Conn;
                cmd.CommandText = $"SELECT dbo.{function}() As Result";
                db.Conn.Open();
                int result = Convert.ToInt32(cmd.ExecuteScalar());
                db.Conn.Close();
                return result;
            }catch(Exception ex) {
                return -1;
            }
            finally
            {
                db.Conn.Close();
            }
        }
        public int QueryByFunction(string function, string key, object value)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = db.Conn;
                cmd.CommandText = $"SELECT dbo.{function}({key}) As Result";
                cmd.Parameters.AddWithValue(key, value);
                db.Conn.Open();
                int result = Convert.ToInt32(cmd.ExecuteScalar());
                db.Conn.Close();
                return result;
            }
            catch (Exception ex)
            {
                return -1;
            }
            finally
            {
                db.Conn.Close();
            }
        }

    }
}
