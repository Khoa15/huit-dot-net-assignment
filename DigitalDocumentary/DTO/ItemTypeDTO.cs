using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalDocumentary.DTO
{
    internal class ItemTypeDTO
    {
        private string itemTypeId;
        private string typeName;
        public ItemTypeDTO()
        {
        }

        public ItemTypeDTO(string itemTypeId, string typeName)
        {
            this.itemTypeId = itemTypeId;
            this.typeName = typeName;
        }

        public string ItemTypeId { get => itemTypeId; set => itemTypeId = value; }
        public string TypeName { get => typeName; set => typeName = value; }
    }
}
