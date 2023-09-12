using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalDocumentary.DTO
{
    internal class FolderDTO
    {
        private int _id;
        private string _name;
        private string _description;
        private DateTime _created;
        private DateTime _createdBy;

        public FolderDTO() { }

        public FolderDTO(int id, string name, string description, DateTime created, DateTime createdBy)
        {
            Id = id;
            Name = name;
            Description = description;
            Created = created;
            CreatedBy = createdBy;
        }

        public int Id { get => _id; set => _id = value; }
        public string Name { get => _name; set => _name = value; }
        public string Description { get => _description; set => _description = value; }
        public DateTime Created { get => _created; set => _created = value; }
        public DateTime CreatedBy { get => _createdBy; set => _createdBy = value; }
    }
}
