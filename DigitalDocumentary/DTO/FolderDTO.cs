using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalDocumentary.DTO
{
    internal class FolderDTO
    {
        private int id;
        private string nameId;
        private string name;
        private DateTime createdDate;
        private string createdBy;
        private FolderDTO parent;

        public FolderDTO() { }

        public FolderDTO(int id, string nameId, string name, DateTime createdDate, string createdBy, FolderDTO parent)
        {
            this.Id             = id;
            this.NameId         = nameId;
            this.Name           = name;
            this.CreatedDate    = createdDate;
            this.CreatedBy      = createdBy;
            this.Parent         = parent;
        }

        public int Id { get => id; set => id = value; }
        public string NameId { get => nameId; set => nameId = value; }
        public string Name { get => name; set => name = value; }
        public DateTime CreatedDate { get => createdDate; set => createdDate = value; }
        public string CreatedBy { get => createdBy; set => createdBy = value; }
        internal FolderDTO Parent { get => parent; set => parent = value; }
    }
}
