using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalDocumentary.DTO
{
    public class DocumentIndexDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int DocumentId { get; set; }
        public int PageNumber { get; set; }
        public int ParentId { get; set; }
        public int AuthorId { get; set; }
        public DocumentIndexDTO() { }
    }
}
