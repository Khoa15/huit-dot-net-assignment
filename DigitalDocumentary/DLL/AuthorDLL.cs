using DigitalDocumentary.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalDocumentary.DLL
{
    internal class AuthorDLL
    {
        private List<AuthorDTO> authors = new List<AuthorDTO>();
        public AuthorDLL()
        {

        }
        public List<AuthorDTO> Load()
        {
            authors.Clear();

            return authors;
        }
    }
}
