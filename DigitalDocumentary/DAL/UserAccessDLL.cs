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
    internal class UserAccessDLL
    {
        private List<UserAccessDTO> userAccesses = new List<UserAccessDTO>();
        private DatabaseContextDLL db = new DatabaseContextDLL();
        public UserAccessDLL()
        {
        }
        public List<UserAccessDTO> Load(string where=null)
        {
            userAccesses.Clear();
            List<DataRow> rd = db.Select(UserAccessDTO.Table, where);
            //while (rd.Read())
            //{
            //    UserAccessDTO ua = new UserAccessDTO();
            //    ua.Id = rd.GetInt32(0);
            //    ua.Display = rd.GetBoolean(1);
            //    ua.TrialRead = rd.GetBoolean(2);
            //    ua.CanRead = rd.GetBoolean(3);
            //    ua.NumberPageRead = rd.GetInt32(4);
            //    ua.NumberPageDownload = rd.GetInt32(5);

            //    userAccesses.Add(ua);
            //}
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
