using DigitalDocumentary.DLL;
using DigitalDocumentary.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalDocumentary.BLL
{
    internal class FolderBLL
    {
        FolderDLL folderDll = new FolderDLL();
        public FolderBLL()
        {
        }

        public List<FolderDTO> Load()
        {
            return folderDll.Load();
        }
        public FolderDTO Load(int id)
        {
            //return folderDll.LoadById(id);
            return folderDll.Folders.Find(f => f.Id == id);
        }
        public int Update(FolderDTO folder)
        {
            return folderDll.Update(folder);
        }
        public int UpdateStatusAllDocuments(bool status, int[] docIds)
        {
            return DocumentBLL.UpdateStatus(status, docIds);
        }
        public int UpdateParent(FolderDTO src, int destId)
        {
            if(src.Id == destId) return 0;
            return folderDll.UpdateParent(src, destId);
        }
        public int UpdateParent(FolderDTO[] src, int destId)
        {
            if (src.Length == 0) return 0;
            int excuted = 0;
            for(int i = 0; i < src.Length; i++)
            {
                if (folderDll.UpdateParent(src[i], destId) == 1) excuted += 1;
            }
            return excuted;
        }
        public int Delete(int id)
        {
            //FolderDTO folder = this.Load(id);
            //return folderDll.Delete(folder);
            return folderDll.Delete(id);
        }
        public int DeleteAllDocument(int id)
        {
            try
            {
                folderDll.Folders.Find(fol => fol.Id == id).Documents.ForEach(doc => DocumentDLL.Delete(doc.Id));
                return 1;
            }catch (Exception ex)
            {
                var x = ex.Message;
                return 0;
            }
        }
    }
}
