using DigitalDocumentary.DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalDocumentary.DLL
{
    internal class DatabaseContextDLL
    {
        DatabaseContextDTO db = new DatabaseContextDTO();
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

        public SqlDataReader Select(string table, string where)
        {
            string sql = $"SELECT * FROM {table}";

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
