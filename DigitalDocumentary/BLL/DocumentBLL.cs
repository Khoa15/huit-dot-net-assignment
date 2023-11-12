using DigitalDocumentary.DLL;
using DigitalDocumentary.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
        public DocumentDTO Get(int id)
        {
            return docDll.Get(id);
        }
        #region Find
        public DocumentDTO Find(DocumentDTO doc)
        {
            return docDll.Documents.Find(o => o == doc);
        }
        public DocumentDTO FindById(int id)
        {
            return docDll.Documents.Find(d => d.Id == id);
        }
        public List<DocumentDTO> FindByTitleDB(string title)
        {
            //return docDll.Load($"title LIKE '%{title}%'");
            return docDll.FindByTitle(title);
        }
        public List<DocumentDTO> FindByTitle(string title)
        {
            return docDll.Documents.Where(d => d.Title.Like(title)).ToList();
        }
        public List<DocumentDTO> FindByAuthorName(string authorName)
        {
            return docDll.Documents.Where(d => d.Author.Name.Like(authorName) == true).ToList();
        }
        public List<DocumentDTO> FindByAuthorNameDB(string authorName)
        {
            return docDll.Load($" author = {authorName}");
        }
        #endregion Find
        #region Update

        #endregion Update
    }
}
