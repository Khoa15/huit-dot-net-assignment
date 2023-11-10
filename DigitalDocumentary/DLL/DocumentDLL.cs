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
        private DatabaseContextDLL db = new DatabaseContextDLL();
        public DocumentDLL()
        {

        }
        public List<DocumentDTO> Load()
        {
            documents.Clear();
            SqlDataReader rd = db.Select(DocumentDTO.Table);
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
                documents.Add(document);
            }
            return documents;
        }
    }
}
