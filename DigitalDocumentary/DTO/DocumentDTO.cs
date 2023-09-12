using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalDocumentary.DTO
{
    internal class DocumentDTO
    {
        private int _id;
        private string _name;
        private string _description;
        private string _filePath;
        private DateTime _created;
        private DateTime _updated;
        public DocumentDTO() { }
        public DocumentDTO(int id, string name, string description, string filePath, DateTime created, DateTime updated)
        {
            Id = id;
            Name = name;
            Description = description;
            FilePath = filePath;
            Created = created;
            Updated = updated;
        }

        public int Id { get => _id; set => _id = value; }
        public string Name { get => _name; set => _name = value; }
        public string Description { get => _description; set => _description = value; }
        public string FilePath { get => _filePath; set => _filePath = value; }
        public DateTime Created { get => _created; set => _created = value; }
        public DateTime Updated { get => _updated; set => _updated = value; }
    }
}
