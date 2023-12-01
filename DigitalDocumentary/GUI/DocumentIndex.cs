using DigitalDocumentary.BLL;
using DigitalDocumentary.DTO;
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
    public partial class DocumentIndex : Form
    {
        DocumentIndexBLL diBll = new DocumentIndexBLL();
        List<DocumentIndexDTO> list = new List<DocumentIndexDTO>();
        public DocumentIndex(int id)
        {
            InitializeComponent();
            dataGridViewDocIndex.AutoGenerateColumns = false;
            dataGridViewDocIndex.DataSource = diBll.Load(id);
            DataGridViewColumn[] columns =
            {
                new DataGridViewTextBoxColumn(){Name = "id", HeaderText = "STT", DataPropertyName = "Id", AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells },
                new DataGridViewTextBoxColumn(){Name = "menu", HeaderText = "Mục lục", DataPropertyName = "Title", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill },
                new DataGridViewTextBoxColumn(){Name = "author", HeaderText = "Tác giả", DataPropertyName = "", AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells},
                new DataGridViewTextBoxColumn(){Name = "page", HeaderText = "Trang", DataPropertyName = "PageNumber", AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells },
                new DataGridViewTextBoxColumn(){Name = "level", HeaderText = "Cấp", DataPropertyName = "", AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells},
            };
            dataGridViewDocIndex.Columns.AddRange(columns);
        }

        private void DocumentIndex_Load(object sender, EventArgs e)
        {

        }

        private void btnAddIndex_Click(object sender, EventArgs e)
        {
// No description
        }
    }
}
