using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalDocumentary.DTO
{
    public class UserAccessDTO
    {
        public int Id { get; set; }
        public int Display { get; set; }
        public int ReadLimit { get; set; }
        public int ReadFull { get; set;}
        public int Download { get; set;}
        public int PageRead { get; set;}
        public int PageDownload { get; set;}
        public int UserTypeId { get; set; }

        public UserAccessDTO()
        {
        }
    }
}
