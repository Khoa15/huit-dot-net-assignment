using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalDocumentary.DTO
{
    public class DocumentDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string FilePath { get; set; }
        public int FolderId { get; set; }
        public DateTime Created { get; set; }
        public int UserAccessId { get; set; }
        public string Image { get; set; }
        public string Type { get; set; }
        public int Status { get; set; }
        public int AuthorId { get; set; }
        public DocumentDTO() { }
    }
}
