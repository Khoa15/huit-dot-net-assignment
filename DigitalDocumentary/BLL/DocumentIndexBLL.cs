using DigitalDocumentary.DLL;
using DigitalDocumentary.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalDocumentary.BLL
{
    internal class DocumentIndexBLL
    {
        DocumentIndexDAL docIndexDLL = new DocumentIndexDAL();
        public DocumentIndexBLL() { }
        public List<DocumentIndexDTO> Load(int id)
        {
            return docIndexDLL.Load(id);
        }
        public DocumentIndexDTO Load(int id, int docIndexId)
        {
            return docIndexDLL.Load(id, docIndexId);
        }

        public bool Add(DocumentIndexDTO docI)
        {
            return docIndexDLL.Add(docI) > 0;
        }

        public bool Remove(int id)
        {
            return docIndexDLL.Remove(id) > 0;
        }
    }
}
