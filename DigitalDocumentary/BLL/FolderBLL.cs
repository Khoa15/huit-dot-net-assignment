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
        FolderDLL folderDll;
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
        public int Delete(int id)
        {
            //FolderDTO folder = this.Load(id);
            //return folderDll.Delete(folder);
            return folderDll.Delete(id);
        }
        public int DeleteAllDocument()
        {
            try
            {
                folderDll.Folders.ForEach(fol => folderDll.Delete(fol.Id));
                return 1;
            }catch (Exception ex)
            {
                return 0;
            }
        }
    }
}
