using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalDocumentary.DTO
{
    internal class DocumentIndexDTO
    {
        private int id;
        private string name;
        private DocumentDTO document;
        private int pageNumber;
        private DocumentIndexDTO parent;
        private AuthorDTO author;
        public DocumentIndexDTO() { }

        public DocumentIndexDTO(int id, string name, DocumentDTO document, int pageNumber, DocumentIndexDTO parent, AuthorDTO author)
        {
            this.Id = id;
            this.Name = name;
            this.Document = document;
            this.PageNumber = pageNumber;
            this.Parent = parent;
            this.Author = author;
        }

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public int PageNumber { get => pageNumber; set => pageNumber = value; }
        internal DocumentDTO Document { get => document; set => document = value; }
        internal DocumentIndexDTO Parent { get => parent; set => parent = value; }
        internal AuthorDTO Author { get => author; set => author = value; }
    }
}
