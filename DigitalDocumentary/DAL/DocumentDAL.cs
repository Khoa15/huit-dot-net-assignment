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
            string[] tables = { DocumentDTO.Table, AuthorDTO.Table };
            if(where != null)
            {
                where += $" AND {DocumentDTO.Table}.author_id = {AuthorDTO.Table}.id";
            }
            else
            {
                where = $"{DocumentDTO.Table}.author_id = {AuthorDTO.Table}.id OR {DocumentDTO.Table}.author_id = NULL";
            }
            //List<DataRow> dataRows = db.Select(tables, where);
            DataSet ds = db.Select("SelectAllDocumentsWithAuthorName");
            
            foreach(DataRow rd in ds.Tables[0].Rows)
            {
                DocumentDTO document = new DocumentDTO();
                document.Id = int.Parse(rd["id"].ToString());
                document.Title = rd["title"].ToString();
                document.Description = rd["description"].ToString();
                document.File_path = rd["file_path"].ToString();
                document.Link_to_image = rd["link_to_image"].ToString();
                document.Type = rd["type"].ToString();
                document.Updated_by = rd["updated_by"].ToString();
                document.Created_at = Convert.ToDateTime(rd["created_date"].ToString());
                document.Updated_at = Convert.ToDateTime(rd["updated_date"].ToString());

                document.Author = new AuthorDTO();
                document.Author.Name = rd["name"].ToString();
                // Foreign Key .... waiting

                //
                Documents.Add(document);
            }
            return Documents;
        }
        public DocumentDTO Get(int id)
        {
            return this.Load($"id = {id}").First();
        }
        public int Add(DocumentDTO doc)
        {
            if(doc.Author == null)
            {

            }
            string sql = $"INSERT INTO {DocumentDTO.Table} (folder_id, author_id, title, description, type, file_path, link_to_image, document_status) VALUES ({doc.Folder.Id}, NULL, N'{doc.Title}', N'{doc.Description}', N'{doc.Type}', '{doc.File_path}', '{doc.Link_to_image}', {doc.iStatus})";
            return db.NonQuery(sql);
        }
        public int Update(DocumentDTO doc)
        {
            string sql = $"UPDATE {DocumentDTO.Table} SET folder_id = {doc.Folder.Id}, author_id = {doc.Author.Id}, title = '{doc.Title}', description='{doc.Description}', type='{doc.Type}', file_path='{doc.File_path}', link_to_image='{doc.Link_to_image}', document_status={doc.iStatus}  WHERE document_id = {doc.Id}";
            return db.NonQuery(sql);
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

        public List<DocumentDTO> FindByTitle(string title)
        {
            List<DocumentDTO> result = this.Load($"title LIKE '%{title}%'");
            return result;
        }

        public List<DocumentDTO> FindByAuthorName(string authorName)
        {
            List<DocumentDTO> result = this.Load($"{AuthorDTO.Table}.name LIKE '%{authorName}%'");
            return result;
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
            for(int i  = 0; i < param.Length; i++)
            {
                object[] value = { docIds[i], desFid };
                if(db.NonQueryBySP("MoveDocToFolder", param, value) == 0)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
