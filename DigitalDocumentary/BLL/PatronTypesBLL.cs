using DigitalDocumentary.DAL;
using DigitalDocumentary.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalDocumentary.BLL
{
    internal class PatronTypesBLL
    {
        private PatronTypeDAL patronTypeDAL;
        public PatronTypesBLL()
        {
            patronTypeDAL = new PatronTypeDAL();
        }
        public List<PatronTypeDTO> Load()
        {
            return patronTypeDAL.Load();
        }
    }
}
