using DigitalDocumentary.DTO;
using DigitalDocumentary.GUI;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalDocumentary.DLL
{
    internal class DocumentDAL
    {
        private List<DocumentDTO> documents = new List<DocumentDTO>();
        private static DatabaseContextDAL db = new DatabaseContextDAL();

        internal List<DocumentDTO> Documents { get => documents; set => documents = value; }

        public DocumentDAL()
        {

        }
        public List<DocumentDTO> Load(string where = null)
        {
            Documents.Clear();
            DataSet ds = db.Select("SelectAllDocuments");
            
            foreach(DataRow rd in ds.Tables[0].Rows)
            {
                DocumentDTO document = SetData(rd);

                // Foreign Key .... waiting

                //
                Documents.Add(document);
            }
            return Documents;
        }
        public DocumentDTO Get(int id)
        {
            DocumentDTO document;
            DataSet result = db.Select("SelectDocument", "@docId", id);
            document = SetData(result.Tables[0].Rows[0]);
            return document;
        }
        public int Add(DocumentDTO doc)
        {
            object link_to_image = DBNull.Value;
            if (doc.Link_to_image != null)
            {
                link_to_image = doc.Link_to_image;
            }
            //string sql = $"INSERT INTO {DocumentDTO.Table} (folder_id, author_id, title, description, type, file_path, link_to_image, document_status) VALUES ({doc.Folder.Id}, NULL, N'{doc.Title}', N'{doc.Description}', N'{doc.Type}', '{doc.File_path}', '{doc.Link_to_image}', {doc.iStatus})";

            string[] keys = {  "@itemTypeID", "@file_path", "@title", "@link_to_image", "@description", "@status", "@updated_by" };
            object[] values = {doc.ItemType.ItemTypeId, doc.File_path, doc.Title, link_to_image, doc.Description, doc.bStatus, doc.Updated_by};
            return db.NonQueryBySP("InsertDocument", keys, values);
        }
        public int Update(DocumentDTO doc)
        {
            object link_to_image = DBNull.Value;
            if(doc.Link_to_image!= null)
            {
                link_to_image = doc.Link_to_image;
            }
            //string sql = $"UPDATE {DocumentDTO.Table} SET folder_id = {doc.Folder.Id}, author_id = {doc.Author.Id}, title = '{doc.Title}', description='{doc.Description}', type='{doc.Type}', file_path='{doc.File_path}', link_to_image='{doc.Link_to_image}', document_status={doc.iStatus}  WHERE document_id = {doc.Id}";
            string[] keys = {"@docId", "@itemTypeID", "@file_path", "@title", "@link_to_image", "@description", "@status", "@updated_by" };
            object[] values = { doc.Id, doc.ItemType.ItemTypeId, doc.File_path, doc.Title, link_to_image, doc.Description, doc.bStatus, doc.Updated_by};
            return db.NonQueryBySP("UpdateDocument", keys,values);
        }
        public int UpdateStatus(DocumentDTO doc)
        {
            string sql = $"UPDATE {DocumentDTO.Table} SET document_status = ${doc.Status} Where id = {doc.Id}";
            return db.NonQuery(sql);
        }
        public int UpdateStatus(DocumentDTO[] docs)
        {
            string sql = string.Empty;
            foreach(DocumentDTO doc in docs)
            {
                sql += $"UPDATE {DocumentDTO.Table} SET document_status = ${doc.Status} Where id = {doc.Id}";
            }
            return db.NonQuery(sql);
        }
        public int UpdateStatus(bool status, int[] ids)
        {
            string sql = $"UPDATE {DocumentDTO.Table} SET document_status = ${status} Where id IN ({string.Join(", ", ids)})";
            return db.NonQuery(sql);
        }
        //public int Delete(DocumentDTO doc)
        //{
        //    string sql = $"DELETE FROM {DocumentDTO.Table} WHERE document_id = {doc.Id}";
        //    return db.NonQuery(sql);
        //}
        public static int Delete(int id)
        {
            return db.NonQueryBySP("DeleteDocument", "@documentID", id);
        }
        public static int DeleteByFolder(int id)
        {
            return db.NonQueryBySP("DeleteDocumentsInFolder", "@folderID", id);
        }

        public List<DocumentDTO> FindByTitle(string title)
        {
            List<DocumentDTO> result = this.Load($"title LIKE '%{title}%'");
            return result;
        }

        public List<DocumentDTO> FindByAuthorName(string authorName)
        {
            //List<DocumentDTO> result = this.Load($"{AuthorDTO.Table}.name LIKE '%{authorName}%'");
            return null;
        }

        public static bool PublicAllDocumentByIdFolder(int fid)
        {
            return db.NonQueryBySP("PublicDocumentByIdFolder", "@fid", fid) > 0;
        }
        public static bool PrivateAllDocumentByIdFolder(int fid)
        {
            return db.NonQueryBySP("PrivateDocumentByIdFolder", "@fid", fid) > 0;
        }

        public static bool MoveDoc(List<int> docIds, int? desFid)
        {
            string[] param = { "@docId", "@fid" };
            for(int i  = 0; i < docIds.Count; i++)
            {
                object[] value = { docIds[i], desFid };
                if(db.NonQueryBySP("MoveDocToFolder", param, value) == 0)
                {
                    return false;
                }
            }
            return true;
        }
        private DocumentDTO SetData(DataRow row)
        {
            DocumentDTO document = new DocumentDTO();
            document.Id = int.Parse(row["id"].ToString());
            document.Title = row["title"].ToString();
            document.Description = row["description"].ToString();
            document.File_path = row["file_path"].ToString();
            document.Link_to_image = row["link_to_image"].ToString();
            document.ItemType = new ItemTypeDTO();
            document.ItemType.ItemTypeId = row["ItemTypeID"].ToString();
            document.ItemType.TypeName = row["TypeName"].ToString();
            document.Updated_by = row["updated_by"].ToString();
            document.Created_at = Convert.ToDateTime(row["created_date"].ToString());
            document.Updated_at = Convert.ToDateTime(row["updated_date"].ToString());
            document.Status = Convert.ToBoolean(row["document_status"].ToString());

            document.Author = row["author"].ToString();
            return document;
        }
    }
}
