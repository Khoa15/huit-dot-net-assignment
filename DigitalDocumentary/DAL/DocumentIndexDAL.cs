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
    internal class DocumentIndexDAL
    {
        private List<DocumentIndexDTO> documentIndices = new List<DocumentIndexDTO>();
        private static DatabaseContextDAL db = new DatabaseContextDAL();

        public DocumentIndexDAL()
        {
        }
        public List<DocumentIndexDTO> Load(int id)
        {
            documentIndices.Clear();
            //List<DataRow> rd = db.Select(DocumentIndexDTO.Table, null);
            //foreach (DataRow row in rd)
            //{
            //    DocumentIndexDTO di = new DocumentIndexDTO()
            //    {
            //        Id = Convert.ToInt32(row["index_id"]),
            //        Title = Convert.ToString(row["name"]),
            //        PageNumber = Convert.ToInt32(row["page_number"])
            //    };
            //}
            DataSet ds = db.Select("SelectDocumentIndexByDocId", "docId", id.ToString());
            foreach(DataRow row in ds.Tables[0].Rows)
            {
                DocumentIndexDTO di = new DocumentIndexDTO()
                {
                    Id = Convert.ToInt32(row["index_id"]),
                    Title = Convert.ToString(row["title"]),
                    PageNumber = Convert.ToInt32(row["page_number"]),
                    Parent = null,
                };
                if (row["parent_index_id"] != DBNull.Value)
                {
                    int pid = Convert.ToInt32(row["parent_index_id"]);
                    di.Parent = documentIndices.Find(d => d.Id == pid);
                }
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
            string[] keys = { "@document_id", "@page_number", "@parent_index_id", "@author", "@title" };
            object[] values = { docI.Document.Id, docI.PageNumber, parent.Id, docI.Author, docI.Title };
            return db.NonQueryBySP("InsertDocumentIndex", keys, values);
        }
        public int Update(DocumentIndexDTO docI)
        {
            DocumentIndexDTO parent = null;
            if (docI.Parent != null)
            {
                parent = docI.Parent;
            }
            string[] keys = {"@id", "@document_id", "@page_number", "@parent_index_id", "@author", "@title" };
            object[] values = { docI.Id, docI.Document.Id, docI.PageNumber, parent.Id, docI.Author, docI.Title };
            return db.NonQueryBySP("UpdateDocumentIndex", keys, values);
        }
        public static int Delete(int id)
        {
            string sql = $"DELETE FROM {DocumentIndexDTO.Table} WHERE id = {id}";
            return db.NonQuery(sql);
        }
    }
}
