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
        private int id;
        private bool display;
        private bool trialRead;
        private bool canRead;
        private bool canDownload;

        private int numberPageRead;
        private int numberPageDownload;
        // UserType linked from system management
        public UserAccessDTO() { }

        public UserAccessDTO(int id, bool display, bool trialRead, bool canRead, bool canDownload, int numberPageRead, int numberPageDownload)
        {
            this.id = id;
            this.display = display;
            this.trialRead = trialRead;
            this.canRead = canRead;
            this.canDownload = canDownload;
            this.numberPageRead = numberPageRead;
            this.numberPageDownload = numberPageDownload;
        }

        public static string Table { get => table; set => table = value; }
        public int Id { get => id; set => id = value; }
        public bool Display { get => display; set => display = value; }
        public bool TrialRead { get => trialRead; set => trialRead = value; }
        public bool CanRead { get => canRead; set => canRead = value; }
        public bool CanDownload { get => canDownload; set => canDownload = value; }
        public int NumberPageRead { get => numberPageRead; set => numberPageRead = value; }
        public int NumberPageDownload { get => numberPageDownload; set => numberPageDownload = value; }
    }
}
