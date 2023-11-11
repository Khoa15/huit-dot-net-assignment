using DigitalDocumentary.DLL;
using DigitalDocumentary.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalDocumentary.BLL
{
    internal class DocumentBLL
    {
        DocumentDLL docDll = new DocumentDLL();
        public DocumentBLL()
        {
        }
        public List<DocumentDTO> Load()
        {
            return docDll.Load();
        }
        public DocumentDTO Find(DocumentDTO doc)
        {
            return docDll.Documents.Find(o => o == doc);
        }
        public DocumentDTO FindById(int id)
        {
            return docDll.Documents.Find(d => d.Id == id);
        }
        public List<DocumentDTO> FindByTitle(string title)
        {
            return docDll.FindByTitle(title);
        }
        public List<DocumentDTO> FindByAuthorName(string authorName)
        {
            return docDll.Documents.Where(d => d.Author.Name.Like(authorName) == true).ToList();
        }
    }
}
