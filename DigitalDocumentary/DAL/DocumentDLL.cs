using DigitalDocumentary.DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalDocumentary.DLL
{
    internal class DocumentDLL
    {
        private List<DocumentDTO> documents = new List<DocumentDTO>();
        private static DatabaseContextDLL db = new DatabaseContextDLL();

        internal List<DocumentDTO> Documents { get => documents; set => documents = value; }

        public DocumentDLL()
        {

        }
        public List<DocumentDTO> Load(string where = null)
        {
            Documents.Clear();
            string[] tables = { DocumentDTO.Table, AuthorDTO.Table };
            where += $" AND {DocumentDTO.Table}.author_id = {AuthorDTO.Table}.id";
            SqlDataReader rd = db.Select(tables, where);
            while (rd.Read())
            {
                DocumentDTO document = new DocumentDTO();
                document.Id = int.Parse(rd["document_id"].ToString());
                document.Title = rd["title"].ToString();
                document.Description = rd["description"].ToString();
                document.File_path = rd["file_path"].ToString();
                document.Link_to_image = rd["link_to_image"].ToString();
                document.Created_at = Convert.ToDateTime(rd["created_at"].ToString());
                document.Updated_at = Convert.ToDateTime(rd["updated_at"].ToString());

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
            string sql = $"INSERT INTO {DocumentDTO.Table} (folder_id, author_id, title, description, type, file_path, link_to_image, document_status) VALUES ({doc.Folder.Id}, {doc.Author.Id}, '{doc.Title}', '{doc.Description}', '{doc.Type}', '{doc.File_path}', '{doc.Link_to_image}', {doc.Status})";
            return db.NonQuery(sql);
        }
        public int Update(DocumentDTO doc)
        {
            string sql = $"UPDATE {DocumentDTO.Table} SET folder_id = {doc.Folder.Id}, author_id = {doc.Author.Id}, title = '{doc.Title}', description='{doc.Description}', type='{doc.Type}', file_path='{doc.File_path}', link_to_image='{doc.Link_to_image}', document_status={doc.Status}  WHERE document_id = {doc.Id}";
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
            string sql = $"DELETE FROM {DocumentDTO.Table} WHERE document_id = {id}";
            return db.NonQuery(sql);
        }

        public List<DocumentDTO> FindByTitle(string title)
        {
            List<DocumentDTO> result = this.Load($"title LIKE '%{title}%'");
                //new List<DocumentDTO>();
            //SqlDataReader rd = db.Select(DocumentDTO.Table, $"title LIKE '%{title}%'");
            //while (rd.Read())
            //{
            //    DocumentDTO document = new DocumentDTO();
            //    document.Id = int.Parse(rd["document_id"].ToString());
            //    document.Title = rd["title"].ToString();
            //    document.Description = rd["description"].ToString();
            //    document.File_path = rd["file_path"].ToString();
            //    document.Link_to_image = rd["link_to_image"].ToString();
            //    document.Created_at = Convert.ToDateTime(rd["created_at"].ToString());
            //    document.Updated_at = Convert.ToDateTime(rd["updated_at"].ToString());

            //    // Foreign Key .... waiting

            //    //
            //    result.Add(document);
            //}
            return result;
        }

        public List<DocumentDTO> FindByAuthorName(string authorName)
        {
            List<DocumentDTO> result = this.Load($"{AuthorDTO.Table}.name LIKE '%{authorName}%'");
            //new List<DocumentDTO>();
            //SqlDataReader rd = db.Select(DocumentDTO.Table, $"author LIKE '%{authorName}%'");
            //while (rd.Read())
            //{
            //    DocumentDTO document = new DocumentDTO();
            //    document.Id = int.Parse(rd["document_id"].ToString());
            //    document.Title = rd["title"].ToString();
            //    document.Description = rd["description"].ToString();
            //    document.File_path = rd["file_path"].ToString();
            //    document.Link_to_image = rd["link_to_image"].ToString();
            //    document.Created_at = Convert.ToDateTime(rd["created_at"].ToString());
            //    document.Updated_at = Convert.ToDateTime(rd["updated_at"].ToString());

            //    // Foreign Key .... waiting

            //    //
            //    result.Add(document);
            //}
            return result;
        }
    }
}
