using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalDocumentary.DTO
{
    internal class PatronTypeDTO
    {
        private string id;
        private string name;
        private string note;
        public PatronTypeDTO() { }

        public string Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Note { get => note; set => note = value; }
    }
}
