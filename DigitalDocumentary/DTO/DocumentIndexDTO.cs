using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalDocumentary.DTO
{
    internal class DocumentIndexDTO
    {
        private static string table = "DocumentIndex";
        private int id;
        private string title;
        private DocumentDTO document;
        private int pageNumber;
        private DocumentIndexDTO parent;
        private int level;
        private string author;
        public DocumentIndexDTO() { }

        public DocumentIndexDTO(int id, string title, DocumentDTO document, int pageNumber, DocumentIndexDTO parent, string author)
        {
            this.Id = id;
            this.Title = title;
            this.Document = document;
            this.PageNumber = pageNumber;
            this.Parent = parent;
            this.Author = author;
        }

        public static string Table { get => table; set => table = value; }
        public int Id { get => id; set => id = value; }
        public string Title { get => title; set => title = value; }
        public int PageNumber { get => pageNumber; set => pageNumber = value; }
        public int Level { get => level; set => level = value; }
        internal DocumentDTO Document { get => document; set => document = value; }
        internal DocumentIndexDTO Parent { get => parent; set => parent = value; }
        internal string Author { get => author; set => author = value; }
        public int? ParentId {
            get {
                if (parent == null) return null;
                return Parent.Id;
            }
        }
    }
}
