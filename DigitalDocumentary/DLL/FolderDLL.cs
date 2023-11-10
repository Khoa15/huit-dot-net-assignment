using DigitalDocumentary.DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalDocumentary.DLL
{
    internal class FolderDLL
    {
        private List<FolderDTO> folders = new List<FolderDTO>();
        private DatabaseContextDLL db = new DatabaseContextDLL();
        public FolderDLL()
        {
        }
        public List<FolderDTO> Load()
        {
            folders.Clear();
            SqlDataReader rd = db.Select(FolderDTO.Table);
            while (rd.Read())
            {
                FolderDTO f = new FolderDTO();
                f.Id = rd.GetInt32(0);
                f.NameId = rd.GetString(1);
                f.Name = rd.GetString(2);
                f.Created_at = rd.GetDateTime(3);
                f.Status = rd.GetBoolean(7);

                // Foreign key ... waiting

                //
                folders.Add(f);
            }
            return folders;
        }
    }
}
