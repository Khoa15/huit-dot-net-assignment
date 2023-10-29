using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalDocumentary.DTO
{
    internal class AuthorDTO
    {
        private int id;
        private string name;
        private string email;
        private string phone;
        private string description;
        public AuthorDTO() { }

        public AuthorDTO(int id, string name, string email, string phone, string description)
        {
            this.id = id;
            this.name = name;
            this.email = email;
            this.phone = phone;
            this.description = description;
        }

        public AuthorDTO(AuthorDTO authorDTO)
        {
            this.id             = authorDTO.id;
            this.name           = authorDTO.name;
            this.email          = authorDTO.email;
            this.phone          = authorDTO.phone;
            this.description    = authorDTO.description;
        }

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Email { get => email; set => email = value; }
        public string Phone { get => phone; set => phone = value; }
        public string Description { get => description; set => description = value; }
    }
}
