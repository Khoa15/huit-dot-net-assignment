using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalDocumentary.DTO
{
    internal class DatabaseContextDTO
    {
        private string strCon = @"Data Source=MUN\SQLEXPRESS;Initial Catalog=TaiLieuSo;Integrated Security=True";
        private SqlConnection sqlCon;
        public DatabaseContextDTO()
        {
            sqlCon = new SqlConnection(strCon);
        }

        public SqlConnection Conn { get => sqlCon; set => sqlCon = value; }
    }
}
