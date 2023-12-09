using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalDocumentary.DTO
{
    internal class UserAccessDTO
    {
        private static string table = "UserAccess";
        private string id;
        private string name;
        private bool display;
        private bool trialRead;
        private bool canRead;
        private bool canDownload;

        private int numberPageRead;
        private int numberPageDownload;
        // UserType linked from system management
        public UserAccessDTO() { }

        public UserAccessDTO(string id, bool display, bool trialRead, bool canRead, bool canDownload, int numberPageRead, int numberPageDownload, string name)
        {
            this.id = id;
            this.display = display;
            this.trialRead = trialRead;
            this.canRead = canRead;
            this.canDownload = canDownload;
            this.numberPageRead = numberPageRead;
            this.numberPageDownload = numberPageDownload;
            this.Name = name;
        }

        public static string Table { get => table; set => table = value; }
        public string Id { get => id; set => id = value; }
        public bool Display { get => display; set => display = value; }
        public bool TrialRead { get => trialRead; set => trialRead = value; }
        public bool CanRead { get => canRead; set => canRead = value; }
        public bool CanDownload { get => canDownload; set => canDownload = value; }
        public int NumberPageRead { get => numberPageRead; set => numberPageRead = value; }
        public int NumberPageDownload { get => numberPageDownload; set => numberPageDownload = value; }
        public string Name { get => name; set => name = value; }
    }
}
