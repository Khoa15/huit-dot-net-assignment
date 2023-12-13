using DigitalDocumentary.DLL;
using DigitalDocumentary.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalDocumentary.DAL
{
    internal class PatronTypeDAL
    {
        private List<PatronTypeDTO> patronTypes = new List<PatronTypeDTO>();
        private DatabaseContextDAL db;
        public PatronTypeDAL()
        {
            db = new DatabaseContextDAL();
        }
        public List<PatronTypeDTO> Load()
        {
            patronTypes.Clear();
            DataSet sets = db.Select("SelectAllPatronTypes");
            foreach(DataRow row in sets.Tables[0].Rows)
            {
                PatronTypeDTO pat = new PatronTypeDTO();
                pat.Id = row["PatronTypeID"].ToString();
                pat.Name = row["TypeName"].ToString();
                pat.Note = row["Note"].ToString();

                patronTypes.Add(pat);
            }
            
            return patronTypes;
        }
    }
}
