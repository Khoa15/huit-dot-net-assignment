using DigitalDocumentary.DLL;
using DigitalDocumentary.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalDocumentary.BLL
{
    internal class UserAccessBLL
    {
        UserAccessDAL userAccessDll;
        public UserAccessBLL()
        {
        }
        public List<UserAccessDTO> Load()
        {
            return userAccessDll.Load();
        }
        public UserAccessDTO Load(int id)
        {
            return userAccessDll.Get(id);
        }
        public int Update(UserAccessDTO userAccess)
        {
            return userAccessDll.Update(userAccess);
        }
        public int Delete(UserAccessDTO userAccess)
        {
            return userAccessDll.Delete(userAccess);
        }
        public int Delete(int id)
        {
            return userAccessDll.Delete(id);
        }
    }
}
