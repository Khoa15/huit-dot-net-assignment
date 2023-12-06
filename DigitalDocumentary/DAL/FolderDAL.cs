using DigitalDocumentary.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace DigitalDocumentary.DLL
{
    internal class FolderDAL
    {
        private List<FolderDTO> folders = new List<FolderDTO>();
        private DatabaseContextDAL db = new DatabaseContextDAL();

        internal List<FolderDTO> Folders { get => folders; set => folders = value; }

        public FolderDAL()
        {
        }
        public List<FolderDTO> Load(string where=null)
        {
            Folders.Clear();
            //List<DataRow> dataRows = db.Select(FolderDTO.Table, where, 100);
            DataSet set = db.Select("SelectAllFolder");
            foreach (DataRow rd in set.Tables[0].Rows)
            {
                FolderDTO f = new FolderDTO();
                f.Id = int.Parse(rd["id"].ToString());
                f.NameId = rd["name_id"].ToString();
                f.Name = rd["name"].ToString();
                f.Created_at = Convert.ToDateTime(rd["created_date"]);
                f.Status = Convert.ToBoolean(rd["status"]);
                object x = rd["parent_id"];
                if (x != DBNull.Value)
                {
                    f.Parent = new FolderDTO() { Id = int.Parse(rd["parent_id"].ToString()) };
                }
                Folders.Add(f);
            }
            foreach (FolderDTO fol in Folders)
            {
                if (fol.Parent != null)
                {
                    fol.Parent = Folders.Find(f => f.Id == fol.Parent.Id);
                }
            }
            return Folders;
        }
        public FolderDTO LoadById(int id)
        {
            return this.Load($"id = {id}").First();
        }
        public int Add(FolderDTO fol)
        {
            string parent = "NULL";
            if(fol.Parent != null)
            {
                parent = $"{fol.Parent.Id}";
            }
            string sql = $"INSERT INTO {FolderDTO.Table} (name_id, name, created_by, parent_id, status) VALUES ('{fol.NameId}', N'{fol.Name}', N'{fol.CreatedBy}', {parent}, {Convert.ToInt16(fol.Status)})";
            return db.NonQuery(sql);
        }
        public int Update(FolderDTO fol)
        {
            FolderDTO parent = null;
            if (fol.Parent != null)
            {
                parent = fol.Parent;
            }
            string sql = $"UPDATE {FolderDTO.Table} SET name_id = '{fol.NameId}', name = N'{fol.Name}', created_by = '{fol.CreatedBy}', parent_id = {parent.Id}, status = {fol.Status} WHERE id = {fol.Id}";
            return db.NonQuery(sql);
        }
        public int UpdateParent(FolderDTO fol, int? pId)
        {
            string sql = $"UPDATE {FolderDTO.Table} SET parent_id = {pId} WHERE id = {fol.Id}";
            return db.NonQuery(sql);
        }
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

        public int MoveFolder(int id, int? desId)
        {
            string[] keys = { "@id", "@desId"};
            object[] values = { id.ToString(), desId.ToString() };
            if(desId == null)
            {
                values[1] = DBNull.Value;
            }
            return db.NonQueryBySP("MoveFolder", keys, values);
        }
    }
}
