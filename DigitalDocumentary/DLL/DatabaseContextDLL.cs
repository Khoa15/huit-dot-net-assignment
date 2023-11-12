using DigitalDocumentary.DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DigitalDocumentary.DLL
{
    internal class DatabaseContextDLL
    {
        DatabaseContextDTO db = new DatabaseContextDTO();

        internal DatabaseContextDTO DbContext { get => db; set => db = value; }

        public DatabaseContextDLL() { }
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

        public SqlDataReader Select(string table, string where=null, int limit=1000)
        {
            string sql = $"SELECT TOP({limit}) * FROM {table} ";
            if (where != null)
            {
                sql += where;
            }
            db.Conn.Open();
            SqlCommand cmd = new SqlCommand(sql, db.Conn);
            SqlDataReader rd = cmd.ExecuteReader();
            db.Conn.Close();
            return rd;
        }

        public SqlDataReader Select(string[] tables, string where = null, int limit = 1000)
        {
            string sql = $"SELECT TOP({limit}) * FROM {string.Join(", ", tables)} ";
            
            if (where != null)
            {
                sql += where;
            }
            db.Conn.Open();
            SqlCommand cmd = new SqlCommand(sql, db.Conn);
            SqlDataReader rd = cmd.ExecuteReader();
            db.Conn.Close();
            return rd;
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
    }
}
