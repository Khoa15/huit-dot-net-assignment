using DigitalDocumentary.DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace DigitalDocumentary.DLL
{
    internal class FolderDLL
    {
        private List<FolderDTO> folders = new List<FolderDTO>();
        private DatabaseContextDLL db = new DatabaseContextDLL();

        internal List<FolderDTO> Folders { get => folders; set => folders = value; }

        public FolderDLL()
        {
        }
        public List<FolderDTO> Load(string where=null)
        {
            Folders.Clear();
            SqlDataReader rd = db.Select(FolderDTO.Table, where);
            while (rd.Read())
            {
                FolderDTO f = new FolderDTO();
                f.Id = rd.GetInt32(0);
                f.NameId = rd.GetString(1);
                f.Name = rd.GetString(2);
                f.Created_at = rd.GetDateTime(3);
                f.Status = rd.GetBoolean(7);

                // Foreign key ... waiting

                //
                Folders.Add(f);
            }
            return Folders;
        }
        public FolderDTO LoadById(int id)
        {
            return this.Load($"id = {id}").First();
        }
        public int Add(FolderDTO fol)
        {
            FolderDTO parent = null;
            if(fol.Parent != null)
            {
                parent = fol.Parent;
            }
            string sql = $"INSERT INTO {FolderDTO.Table} (name_id, name, created_by, parent_id, status) VALUES ('{fol.NameId}', '{fol.Name}', '{fol.CreatedBy}', '{parent.Id}', {fol.Status})";
            return db.NonQuery(sql);
        }
        public int Update(FolderDTO fol)
        {
            FolderDTO parent = null;
            if (fol.Parent != null)
            {
                parent = fol.Parent;
            }
            string sql = $"UPDATE {FolderDTO.Table} SET name_id = '{fol.NameId}', name = '{fol.Name}', created_by = '{fol.CreatedBy}', parent_id = {parent.Id}, status = {fol.Status} WHERE id = {fol.Id}";
            return db.NonQuery(sql);
        }
        public int UpdateParent(FolderDTO fol, int? pId)
        {
            string sql = $"UPDATE {FolderDTO.Table} SET parent_id = {pId} WHERE id = {fol.Id}";
            return db.NonQuery(sql);
        }
        //public int Delete(FolderDTO fol)
        //{
        //    string sql = $"DELETE FROM {FolderDTO.Table} WHERE id = {fol.Id}";
        //    return db.NonQuery(sql);
        //}
        public int Delete(int id)
        {
            string sql = $"DELETE FROM {FolderDTO.Table} WHERE id = {id}";
            return db.NonQuery(sql);
        }
        public int Delete(int[] id)
        {
            string sql = $"DELETE FROM {FolderDTO.Table} WHERE id = {string.Join(", id=", id)}";
            return db.NonQuery(sql);
        }
    }
}
