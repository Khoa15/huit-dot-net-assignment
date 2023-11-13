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
        private string strCon = "";
        private SqlConnection sqlCon;
        public DatabaseContextDTO() { }
        public DatabaseContextDTO(string sqlCon)
        {
            this.strCon = sqlCon;
        }

        public SqlConnection Conn { get => sqlCon; set => sqlCon = value; }
    }
}
