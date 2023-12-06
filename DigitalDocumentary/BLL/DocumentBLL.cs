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
        static DocumentDAL docDll = new DocumentDAL();
        public DocumentBLL()
        {
        }
        public List<DocumentDTO> Load()
        {
            return docDll.Load();
        }
        public DocumentDTO Load(int id)
        {
            return docDll.Get(id);
        }
        //public DocumentDTO GetById(int id)
        //{
        //    return docDll.Get(id);
        //}
        public int Add(DocumentDTO document)
        {
            // Move file, image to this project's path
            //MoveFile(document.Link_to_image);
            Helper.MoveFile(document.Link_to_image);
            return docDll.Add(document);
        }
        public int Update(DocumentDTO document)
        {
            return docDll.Update(document);
        }
        public int Update(DocumentDTO[] documents)
        {
            int excuted = 0;
            for(int i = 0; i < documents.Length; i++)
            {
                if(docDll.Update(documents[i]) == 1)
                {
                    excuted += 1;
                }
            }
            return excuted;
        }
        public int UpdateStatus(DocumentDTO document)
        {
            return docDll.UpdateStatus(document);
        }
        public int UpdateStatus(DocumentDTO[] documents)
        {
            return docDll.UpdateStatus(documents);
        }
        public static int UpdateStatus(bool status, int[] ids)
        {
            return docDll.UpdateStatus(status, ids);
        }
        public int Delete(int id)
        {
            return DocumentDAL.Delete(id);
        }
        public int[] Delete(int[] id)
        {
            int[] status = Enumerable.Repeat(0, id.Length).ToArray();            
            try
            {
                for (int i = 0; i < id.Length; i++)
                {
                    if (DocumentDAL.Delete(id[i]) == 1)
                    {
                        status[i] = 1;
                    }
                }
                return status;
            }
            catch(Exception ex)
            {
                var x = ex.Message;
                return status;
            }
        }
        public bool Delete(List<int> ids)
        {
            try
            {
                for (int i = 0; i < ids.Count; i++)
                {
                    if (DocumentDAL.Delete(ids[i]) == 0)
                    {
                        return false;
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                var x = ex.Message;
                return false;
            }
        }
        #region Find
        public DocumentDTO Find(DocumentDTO doc)
        {
            return docDll.Documents.Find(o => o == doc);
        }
        public List<DocumentDTO> Find(int areaSelected, string keyword)
        {
            List<DocumentDTO> result = null;
            switch (areaSelected)
            {
                case 0:// Id
                    result = docDll.Documents.FindAll(d => d.Id == Convert.ToInt32(keyword));
                    break;
                case 1:// Title
                    result = docDll.Documents.FindAll(d => d.Title.Contains(keyword));
                    break;
                case 2:// Author Name
                    result = docDll.Documents.FindAll(d => d.AuthorName.Contains(keyword));
                    break;
            }
            return result;
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
        public bool MoveDoc(List<int> docIds, int? desfid)
        {
            if(docIds.Count == 0)
            {
                return false;
            }
            return DocumentDAL.MoveDoc(docIds, desfid);
        }
        public bool MoveFile(string srcPath)
        {
            return Helper.MoveFile(srcPath);
        }
    }
}
