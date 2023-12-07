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
        static FolderDAL folderDll = new FolderDAL();
        public FolderBLL()
        {
        }

        public List<FolderDTO> Load()
        {
            List<FolderDTO> listFolder = folderDll.Load();
            foreach(FolderDTO fol in listFolder)
            {
                if(fol.Parent != null)
                {
                    listFolder.Find(f => f.Id == fol.Parent.Id);
                }
            }
            return listFolder;
        }
        public FolderDTO Load(int id)
        {
            //return folderDll.LoadById(id);
            if(folderDll.Folders.Count == 0)
            {
                return folderDll.LoadById(id);
            }
            return folderDll.Folders.Find(f => f.Id == id);
        }
        public bool Add(FolderDTO folder)
        {
            return folderDll.Add(folder) > 0;
        }
        public bool Update(FolderDTO folder)
        {
            return folderDll.Update(folder) > 0;
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
        public static int Delete(int id)
        {
            return folderDll.Delete(id);
        }
        public int DeleteAllDocument(int id)
        {
            try
            {
                folderDll.Folders.Find(fol => fol.Id == id).Documents.ForEach(doc => DocumentDAL.Delete(doc.Id));
                return 1;
            }catch (Exception ex)
            {
                var x = ex.Message;
                return 0;
            }
        }

        public static bool PublicDoc(int fid)
        {
            return DocumentDAL.PublicAllDocumentByIdFolder(fid);
        }

        public static bool PrivateDoc(int fid)
        {
            return DocumentDAL.PrivateAllDocumentByIdFolder(fid);
        }

        public bool MoveFolder(int id, int? desId)
        {
            return folderDll.MoveFolder(id, desId) > 0;
        }
    }
}
