using DigitalDocumentary.DLL;
using DigitalDocumentary.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalDocumentary.DAL
{
    internal class ItemTypeDAL
    {
        private List<ItemTypeDTO> itemTypes;
        private DatabaseContextDAL db = new DatabaseContextDAL();
        public ItemTypeDAL()
        {
        }
        public List<ItemTypeDTO> Load()
        {
            itemTypes = new List<ItemTypeDTO>();
            DataSet sets = db.Select("SelectAllItemTypes");
            foreach(DataRow row in sets.Tables[0].Rows)
            {
                ItemTypeDTO itemType = new ItemTypeDTO();
                itemType.ItemTypeId = row["ItemTypeId"].ToString();
                itemType.TypeName = row["TypeName"].ToString();

                itemTypes.Add(itemType);
            }
            return itemTypes;
        }
        public ItemTypeDTO Load(string TypeName)
        {
            try
            {
                DataSet sets = db.Select("SelectItemTypeByTypeName", "@typeName", TypeName);
            
                return SetData(sets.Tables[0].Rows[0]);

            }catch(Exception ex)
            {
                return null;
            }
        }
        private ItemTypeDTO SetData(DataRow row)
        {
            ItemTypeDTO itemType = new ItemTypeDTO();
            itemType.ItemTypeId = row["ItemTypeId"].ToString();
            itemType.TypeName = row["TypeName"].ToString();
            return itemType;
        }
    }
}
