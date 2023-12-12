using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalDocumentary.DTO
{
    internal class FolderDTO
    {
        private static string table = "Folder";
        private int id;
        private string nameId;
        private string name;
        private string createdBy;
        private bool status;
        private FolderDTO parent;
        private List<DocumentDTO> documents;
        private FolderDTO next;
        private DateTime created_at;
        private int numOfDoc;
        public FolderDTO() { }

        public FolderDTO(int id, string nameId, string name, DateTime created_at, string createdBy, FolderDTO parent, bool status, List<DocumentDTO> documents)
        {
            this.Id = id;
            this.NameId = nameId;
            this.Name = name;
            this.Created_at = created_at;
            this.CreatedBy = createdBy;
            this.Parent = parent;
            this.status = status;
            this.Documents = documents;
        }

        public static string Table { get => table; set => table = value; }
        public int Id { get => id; set => id = value; }
        public string NameId { get => nameId; set => nameId = value; }
        public string Name { get => name; set => name = value; }
        public string CreatedBy { get => createdBy; set => createdBy = value; }
        public bool Status { get => status; set => status = value; }
        internal FolderDTO Parent { get => parent; set => parent = value; }
        internal List<DocumentDTO> Documents { get => documents; set => documents = value; }
        public DateTime Created_at { get => created_at; set => created_at = value; }
        internal FolderDTO Next { get => next; set => next = value; }
        public int NumOfDoc { get => numOfDoc; set => numOfDoc = value; }
    }
}
