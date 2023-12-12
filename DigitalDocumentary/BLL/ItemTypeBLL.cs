using DigitalDocumentary.DAL;
using DigitalDocumentary.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalDocumentary.BLL
{
    internal class ItemTypeBLL
    {
        private ItemTypeDAL typeDAL;
        public ItemTypeBLL()
        { 
            typeDAL = new ItemTypeDAL();
        }
        public List<ItemTypeDTO> Load()
        {
            return typeDAL.Load();
        }
        public ItemTypeDTO Load(string TypeName)
        {
            return typeDAL.Load(TypeName);
        }
    }
}
