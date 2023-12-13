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
        UserAccessDAL userAccessDll = new UserAccessDAL();
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
        public int Add(UserAccessDTO userAccess)
        {
            return userAccessDll.Add(userAccess);
        }
        public int Update(UserAccessDTO userAccess)
        {
            return userAccessDll.Update(userAccess);
        }
        public int Save(UserAccessDTO userAccess)
        {
            return this.Update(userAccess);
        }
        public int Delete(UserAccessDTO userAccess)
        {
            return userAccessDll.Delete(userAccess);
        }
        public bool Delete(string id)
        {
            return userAccessDll.Delete(id) > 0;
        }
    }
}
