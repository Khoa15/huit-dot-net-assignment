using DigitalDocumentary.BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DigitalDocumentary.GUI
{
    public partial class Policy : Form
    {
        UserAccessBLL userAccessBLL = new UserAccessBLL();
        public Policy()
        {
            InitializeComponent();
        }

        private void Policy_Load(object sender, EventArgs e)
        {
            dataGridViewDocPolicy.AutoGenerateColumns = false;
            DataGridViewColumn[] columns =
            {
                new DataGridViewTextBoxColumn{Name = "number", HeaderText = "#", DataPropertyName = ""},
                new DataGridViewTextBoxColumn{Name = "person", HeaderText = "Độc giả", DataPropertyName = "Id"},
                new DataGridViewCheckBoxColumn{Name = "display", HeaderText = "Hiển thị", DataPropertyName = "Display"},
                new DataGridViewCheckBoxColumn{Name = "read_trial", HeaderText = "Đọc thử", DataPropertyName = "TrialRead"},
                new DataGridViewCheckBoxColumn{Name = "read", HeaderText = "Đọc", DataPropertyName = "CanRead"},
                new DataGridViewCheckBoxColumn{Name = "isDownload", HeaderText = "Tải", DataPropertyName = "CanDownload"},
                new DataGridViewTextBoxColumn{Name = "numPageRead", HeaderText = "Số trang đọc thử", DataPropertyName = "NumberPageRead"},
                new DataGridViewTextBoxColumn{Name = "numPageDown", HeaderText = "Số trang tải", DataPropertyName = "NumberPageDownload"},
            };
            dataGridViewDocPolicy.Columns.AddRange(columns);
            dataGridViewDocPolicy.DataSource = userAccessBLL.Load();
        }
    }
}
