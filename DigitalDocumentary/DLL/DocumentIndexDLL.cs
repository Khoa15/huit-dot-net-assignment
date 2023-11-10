using DigitalDocumentary.DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalDocumentary.DLL
{
    internal class DocumentIndexDLL
    {
        private List<DocumentIndexDTO> documentIndices = new List<DocumentIndexDTO>();
        private DatabaseContextDLL db = new DatabaseContextDLL();

        public DocumentIndexDLL()
        {
        }
        public List<DocumentIndexDTO> Load()
        {
            documentIndices.Clear();
            SqlDataReader rd = db.Select(DocumentIndexDTO.Table);
            while (rd.Read())
            {
                DocumentIndexDTO di = new DocumentIndexDTO();
                di.Id = int.Parse(rd["index_id"].ToString());
                di.Name = rd["Name"].ToString();
                di.PageNumber = int.Parse(rd["page_number"].ToString());

                // Foreign key ... waiting

                //
                documentIndices.Add(di);

            }
            return this.documentIndices;
        }
    }
}
