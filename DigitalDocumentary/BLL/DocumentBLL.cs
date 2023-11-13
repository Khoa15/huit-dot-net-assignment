using DigitalDocumentary.DLL;
using DigitalDocumentary.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
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
        public DocumentDTO GetById(int id)
        {
            return docDll.Get(id);
        }
        public int Add(DocumentDTO document)
        {
            // Move file, image to this project's path
            return docDll.Add(document);
        }
        public int Update(DocumentDTO document)
        {
            return docDll.Update(document);
        }
        public int Delete(int id)
        {
            return docDll.Delete(id);
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
        #region Sort
        public List<DocumentDTO> SortById()
        {
            if (docDll.Documents.Count == 0)
            {
                docDll.Load();
            }
            return docDll.Documents.OrderBy(d => d.Id).ToList();
        }
        public List<DocumentDTO> SortByTitle()
        {
            if(docDll.Documents.Count == 0)
            {
                docDll.Load();
            }
            return docDll.Documents.OrderBy(d => d.Title).ToList();
        }
        public List<DocumentDTO> SortByAuthorName()
        {
            if (docDll.Documents.Count == 0)
            {
                docDll.Load();
            }
            return docDll.Documents.OrderBy(d => d.Author.Name).ToList();
        }
        public List<DocumentDTO> SortByUpdated()
        {
            if (docDll.Documents.Count == 0)
            {
                docDll.Load();
            }
            return docDll.Documents.OrderBy(d => d.Updated_at).ToList();
        }
        public List<DocumentDTO> SortByStatus()
        {
            if (docDll.Documents.Count == 0)
            {
                docDll.Load();
            }
            return docDll.Documents.OrderBy(d => d.Status).ToList();
        }
        #endregion Sort
        #region Update

        #endregion Update
    }
}
