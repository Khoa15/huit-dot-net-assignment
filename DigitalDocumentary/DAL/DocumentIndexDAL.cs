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
            DataSet ds = db.Select("SelectDocumentIndexByDocId", "docId", id.ToString());
            foreach(DataRow row in ds.Tables[0].Rows)
            {
                DocumentIndexDTO di = SetData(row);
                documentIndices.Add(di);
            }

            return this.documentIndices;
        }
        public DocumentIndexDTO Load(int id, int docIndexId)
        {
            DataSet ds = db.Select("SelectDocumentIndex", "@docIndexId", docIndexId);
            DocumentIndexDTO doc = SetData(ds.Tables[0].Rows[0]);
            return doc;
        }
        public int Add(DocumentIndexDTO docI)
        {
            object parent = DBNull.Value;
            if(docI.Parent != null)
            {
                parent = docI.Parent.Id;
            }
            string[] keys = { "@document_id", "@page_number", "@parent_index_id", "@author", "@title" };
            object[] values = { docI.Document.Id, docI.PageNumber, parent, docI.Author, docI.Title };
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
        public int Count(int docI)
        {
            DataSet rd = db.Select("SelectAllDocumentIndex", "@docIndexId", docI);
            int i = Convert.ToInt16(rd.Tables[0].Rows[0]["Level"]);
            return i;
        }

        private DocumentIndexDTO SetData(DataRow row)
        {
            DocumentIndexDTO di = new DocumentIndexDTO()
            {
                Id = Convert.ToInt32(row["index_id"]),
                Title = Convert.ToString(row["title"]),
                PageNumber = Convert.ToInt32(row["page_number"]),
                Author = row["author"].ToString(),
                Parent = null,
            };
            try
            {
                di.Level = int.Parse(row["Level"].ToString());
            }catch(Exception ex) { }
            if (row["parent_index_id"] != DBNull.Value)
            {
                int pid = Convert.ToInt32(row["parent_index_id"]);
                di.Parent = documentIndices.Find(d => d.Id == pid);
            }
            return di;
        }

        public int Remove(int id)
        {
            return db.NonQueryBySP("RemoveDocumentIndex", "@docIndexId", id);
        }
    }
}
