using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalDocumentary.DTO
{
    internal class UserTypeDTO
    {
        private int id;
        private string name;
        private string description;
        private bool canCreateFolder;
        private bool canUploadDocument;
        private bool canDeleteDocument;
        private bool canEditDocument;
        private bool canViewDocument;
        public UserTypeDTO() { }

        public UserTypeDTO(int id, string name, string description, bool canCreateFolder, bool canUploadDocument, bool canDeleteDocument, bool canEditDocument, bool canViewDocument)
        {
            this.id = id;
            this.name = name;
            this.description = description;
            this.canCreateFolder = canCreateFolder;
            this.canUploadDocument = canUploadDocument;
            this.canDeleteDocument = canDeleteDocument;
            this.canEditDocument = canEditDocument;
            this.canViewDocument = canViewDocument;
        }

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Description { get => description; set => description = value; }
        public bool CanCreateFolder { get => canCreateFolder; set => canCreateFolder = value; }
        public bool CanUploadDocument { get => canUploadDocument; set => canUploadDocument = value; }
        public bool CanDeleteDocument { get => canDeleteDocument; set => canDeleteDocument = value; }
        public bool CanEditDocument { get => canEditDocument; set => canEditDocument = value; }
        public bool CanViewDocument { get => canViewDocument; set => canViewDocument = value; }
    }
}
