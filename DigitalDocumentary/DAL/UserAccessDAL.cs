using DigitalDocumentary.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalDocumentary.DLL
{
    internal class UserAccessDAL
    {
        private List<UserAccessDTO> userAccesses = new List<UserAccessDTO>();
        private DatabaseContextDAL db = new DatabaseContextDAL();
        public UserAccessDAL()
        {
        }
        public List<UserAccessDTO> Load(string where=null)
        {
            userAccesses.Clear();
            DataSet ds = db.Select("SelectAllUserAccess");
            foreach(DataRow row in ds.Tables[0].Rows)
            {
                UserAccessDTO ua = new UserAccessDTO();
                ua.Id = row["patron_type_id"].ToString();
                ua.Name = row["Name"].ToString();
                ua.Display = Convert.ToBoolean(row["display"]);
                ua.TrialRead = Convert.ToBoolean(row["read_limit"]);
                ua.CanRead = Convert.ToBoolean(row["read_full"]);
                ua.CanDownload = Convert.ToBoolean(row["download"]);
                ua.NumberPageRead = Convert.ToInt32(row["page_read"]);
                ua.NumberPageDownload = Convert.ToInt32(row["page_download"]);
                userAccesses.Add(ua);
            }
            return userAccesses;
        }
        public UserAccessDTO Get(int id)
        {
            return this.Load($"id = {id}").First();
        }
        public int Add(UserAccessDTO ua)
        {
            string sql =    $"INSERT INTO {UserAccessDTO.Table} (display, read_limit, read_full, download, page_read, page_download)" +
                            $"VALUES ({ua.Display}, {ua.TrialRead}, {ua.CanRead}, {ua.CanDownload}, {ua.NumberPageRead}, {ua.NumberPageDownload})";
            return db.NonQuery(sql);
        }
        public int Update(UserAccessDTO ua)
        {
            string sql = $"UPDATE {UserAccessDTO.Table} SET display = {ua.Display}, read_limit = {ua.TrialRead}, read_full={ua.CanRead}, download={ua.CanDownload}, page_read={ua.NumberPageRead}, page_download ={ua.NumberPageDownload} WHERE user_type_id = {ua.Id}";
            return db.NonQuery(sql);
        }
        public int Delete(UserAccessDTO ua)
        {
            string sql = $"DELETE FROM {UserAccessDTO.Table} WHERE user_type_id = {ua.Id}";
            return db.NonQuery(sql);
        }
        public int Delete(int id)
        {
            string sql = $"DELETE FROM {UserAccessDTO.Table} WHERE user_type_id = {id}";
            return db.NonQuery(sql);
        }
    }
}
