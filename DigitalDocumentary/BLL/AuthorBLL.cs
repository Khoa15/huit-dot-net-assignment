using DigitalDocumentary.DLL;
using DigitalDocumentary.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalDocumentary.BLL
{
    internal class AuthorBLL
    {
        AuthorDLL authorDll;
        public AuthorBLL()
        {
        }
        public List<AuthorDTO> Load()
        {
            return authorDll.Load();
        }
        public AuthorDTO GetById(int id)
        {
            return authorDll.Load($"id = {id}").First();
        }
        public int Update()
        {
            return 1;
        }
        public int Delete()
        {
            return 0;
        }
        #region Sort
        #endregion Sort
        #region Find
        #endregion Find
    }
}
