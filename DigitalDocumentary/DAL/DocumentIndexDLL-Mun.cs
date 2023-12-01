using DigitalDocumentary.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalDocumentary.DLL
{
    internal class DocumentIndexDLL
    {
        private List<DocumentIndexDTO> documentIndices = new List<DocumentIndexDTO>();
        private static DatabaseContextDLL db = new DatabaseContextDLL();

        public DocumentIndexDLL()
        {
        }
        public List<DocumentIndexDTO> Load()
        {
            documentIndices.Clear();
            List<DataRow> rd = db.Select(DocumentIndexDTO.Table, null);
            //DataSet ds = db.Select("");
            while (rd.Read())
            {
                DocumentIndexDTO di = new DocumentIndexDTO();
                di.Id = int.Parse(rd["index_id"].ToString());
                di.Title = rd["Name"].ToString();
                di.PageNumber = int.Parse(rd["page_number"].ToString());

                // Foreign key ... waiting

                //
                documentIndices.Add(di);

            }
            return this.documentIndices;
        }
        public int Add(DocumentIndexDTO docI)
        {
            DocumentIndexDTO parent = null;
            if(docI.Parent != null)
            {
                parent = docI.Parent;
            }
            string sql = $"INSERT INTO {DocumentIndexDTO.Table} (document_id, page_number, parent_index_id, author_id, title) VALUES ({docI.Document.Id}, {docI.PageNumber}, {parent.Id}, {docI.Author.Id}, '{docI.Title}')";
            return db.NonQuery(sql);
        }
        public int Update(DocumentIndexDTO docI)
        {
            DocumentIndexDTO parent = null;
            if (docI.Parent != null)
            {
                parent = docI.Parent;
            }
            string sql = $"UPDATE {DocumentIndexDTO.Table} SET document_id = {docI.Document.Id}, page_number = {docI.PageNumber}, parent_index_id = {parent.Id}, author_id = {docI.Author.Id}, title = '{docI.Title}' WHERE id = {docI.Id}";
            return db.NonQuery(sql);
        }
        //public static int Delete(DocumentIndexDTO docI)
        //{
        //    string sql = $"DELETE FROM {DocumentIndexDTO.Table} WHERE id = {docI.Id}";
        //    return db.NonQuery(sql);
        //}
        public static int Delete(int id)
        {
            string sql = $"DELETE FROM {DocumentIndexDTO.Table} WHERE id = {id}";
            return db.NonQuery(sql);
        }
    }
}
