using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalDocumentary.DTO
{
    internal class UserAccessDTO
    {
        private int _id;
        private int _userId;
        DocumentDTO _document;
        FolderDTO _folder;
        AccessPolicyDTO _accessPolicy;

        public UserAccessDTO()
        {
        }

        public UserAccessDTO(int id, int userId, DocumentDTO document, FolderDTO folder, AccessPolicyDTO accessPolicy)
        {
            _id = id;
            _userId = userId;
            _document = document;
            _folder = folder;
            _accessPolicy = accessPolicy;
        }

        public int Id { get => _id; set => _id = value; }
        public int UserId { get => _userId; set => _userId = value; }
        internal DocumentDTO Document { get => _document; set => _document = value; }
        internal FolderDTO Folder { get => _folder; set => _folder = value; }
        internal AccessPolicyDTO AccessPolicy { get => _accessPolicy; set => _accessPolicy = value; }
    }
}
