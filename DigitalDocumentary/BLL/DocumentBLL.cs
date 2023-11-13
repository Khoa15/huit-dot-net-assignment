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
        static DocumentDLL docDll = new DocumentDLL();
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
            return DocumentDLL.Delete(id);
        }
        //public bool Delete(int[] id)
        //{
        //    try
        //    {
        //        for (int i = 0; i < id.Length; i++)
        //        {
        //            if (DocumentDLL.Delete(id[i]) == 0)
        //            {
        //                return false;
        //            }
        //        }
        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        return false;
        //    }
        //}
        public int[] Delete(int[] id)
        {
            // Initialize default value's array is 0
            int[] status = Enumerable.Repeat(0, id.Length).ToArray();            
            try
            {
                for (int i = 0; i < id.Length; i++)
                {
                    if (DocumentDLL.Delete(id[i]) == 1)
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
        public bool MoveFile(string srcPath)
        {
            return Helper.MoveFile(srcPath);
        }
    }
}
