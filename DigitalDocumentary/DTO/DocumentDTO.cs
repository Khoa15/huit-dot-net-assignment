using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalDocumentary.DTO
{
    internal class DocumentDTO
    {
        private static string table = "Document";
        private int id;
        private string title;
        private string description;
        private string file_path;
        private string link_to_image;
        private string type;
        private bool status;
        private AuthorDTO author;
        private FolderDTO folder;
        // Type document linked from system management
        // ...
        private DateTime created_at;
        private DateTime updated_at;

        public DocumentDTO() { }

        public DocumentDTO(int id, string title, string description, string file_path, DateTime created_at, string link_to_image, string type, bool status, AuthorDTO author, DateTime updated_at, FolderDTO folder = null)
        {
            this.id = id;
            this.title = title;
            this.description = description;
            this.file_path = file_path;
            this.link_to_image = link_to_image;
            this.type = type;
            this.Status = status;
            this.author = author;
            this.created_at = created_at;
            this.updated_at = updated_at;
            this.Folder = folder;
        }

        public static string Table { get => table; set => table = value; }
        public int Id { get => id; set => id = value; }
        public string Title { get => title; set => title = value; }
        public string Description { get => description; set => description = value; }
        public string File_path { get => file_path; set => file_path = value; }
        public string Link_to_image { get => link_to_image; set => link_to_image = value; }
        public string Type { get => type; set => type = value; }
        internal AuthorDTO Author { get => author; set => author = value; }
        public DateTime Created_at { get => created_at; set => created_at = value; }
        public DateTime Updated_at { get => updated_at; set => updated_at = value; }
        internal FolderDTO Folder { get => folder; set => folder = value; }
        public bool Status { get => status; set => status = value; }

        public string GetStatus()
        {
            string sts = String.Empty;
            if (status)
            {
                sts = "Đã ban hành";
            }
            else
            {
                sts = "Chưa ban hành";
            }
            return sts;
        }
        public string GetFormattedCreatedAt()
        {
            return created_at.ToString("dd/mm/yyyy");
        }
        public string GetFormattedUpdatedAt()
        {
            return updated_at.ToString("dd/mm/yyyy");
        }
    }
}
