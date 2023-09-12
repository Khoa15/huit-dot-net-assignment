using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalDocumentary.DTO
{
    internal class AccessPolicyDTO
    {
        private int _id;
        private string _name;
        private string _description;
        private string _accessRights;

        public AccessPolicyDTO()
        {
        }

        public AccessPolicyDTO(int id, string name, string description, string accessRights)
        {
            _id = id;
            _name = name;
            _description = description;
            _accessRights = accessRights;
        }

        public int Id { get => _id; set => _id = value; }
        public string Name { get => _name; set => _name = value; }
        public string Description { get => _description; set => _description = value; }
        public string AccessRights { get => _accessRights; set => _accessRights = value; }
    }
}
