using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalDocumentary.DTO
{
    internal class DocumentDTO
    {
        private int id;
        private string name;
        private string description;
        private string file_path;
        private DateTime created_date;
        private string link_to_image;
        private string type;
        private bool status; // Change int from database to bool

        private AuthorDTO author;
        private UserAccessDTO userAccess;
        public DocumentDTO() { }

        public DocumentDTO(int id, string name, string description, string file_path, DateTime created_date, string link_to_image, string type, bool status, AuthorDTO author, UserAccessDTO userAccess)
        {
            this.id = id;
            this.name = name;
            this.description = description;
            this.file_path = file_path;
            this.created_date = created_date;
            this.link_to_image = link_to_image;
            this.type = type;
            this.status = status;
            this.author = author;
            this.userAccess = userAccess;
        }

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Description { get => description; set => description = value; }
        public string File_path { get => file_path; set => file_path = value; }
        public DateTime Created_date { get => created_date; set => created_date = value; }
        public string Link_to_image { get => link_to_image; set => link_to_image = value; }
        public string Type { get => type; set => type = value; }
        internal AuthorDTO Author { get => author; set => author = value; }
        internal UserAccessDTO UserAccess { get => userAccess; set => userAccess = value; }

        public string Status()
        {
            string sts = String.Empty;
            if(status)
            {
                sts = "Đã ban hành";
            }
            else
            {
                sts = "Chưa ban hành";
            }
            return sts;
        }
    }
}
