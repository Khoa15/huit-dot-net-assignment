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
                new DataGridViewTextBoxColumn{Name = "person", HeaderText = "Độc giả", DataPropertyName = "Name"},
                new DataGridViewCheckBoxColumn{Name = "display", HeaderText = "Hiển thị", DataPropertyName = "Display"},
                new DataGridViewCheckBoxColumn{Name = "read_trial", HeaderText = "Đọc thử", DataPropertyName = "TrialRead"},
                new DataGridViewCheckBoxColumn{Name = "read", HeaderText = "Đọc", DataPropertyName = "CanRead"},
                new DataGridViewCheckBoxColumn{Name = "isDownload", HeaderText = "Tải", DataPropertyName = "CanDownload"},
                new DataGridViewTextBoxColumn{Name = "numPageRead", HeaderText = "Số trang đọc thử", DataPropertyName = "NumberPageRead"},
                new DataGridViewTextBoxColumn{Name = "numPageDown", HeaderText = "Số trang tải", DataPropertyName = "NumberPageDownload"},
                new DataGridViewButtonColumn{Text = "Edit", UseColumnTextForButtonValue = true, FlatStyle = FlatStyle.Flat, AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells},//index=8
                new DataGridViewButtonColumn{Text = "Remove", UseColumnTextForButtonValue = true, FlatStyle = FlatStyle.Flat, AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells},//index=9
            };
            dataGridViewDocPolicy.Columns.AddRange(columns);
            dataGridViewDocPolicy.DataSource = userAccessBLL.Load();


            foreach (DataGridViewRow row in dataGridViewDocPolicy.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    cell.ReadOnly = true;
                }
            }
        }

        private void dataGridViewDocPolicy_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {
                if(dataGridViewDocPolicy.Rows[e.RowIndex].Cells[8].Value == "Edit")
                {
                    dataGridViewDocPolicy.Rows[e.RowIndex].ReadOnly = false;
                    dataGridViewDocPolicy.Columns[8].ReadOnly = false;
                    dataGridViewDocPolicy.Rows[e.RowIndex].Cells[8].Value = "Save";
                    dataGridViewDocPolicy.Rows[e.RowIndex].Cells[1].Selected = true;
                }
                else
                {
                    dataGridViewDocPolicy.Rows[e.RowIndex].ReadOnly = true;
                    var x = dataGridViewDocPolicy.Rows[e.RowIndex].Cells[0].Value;
                    UserAccessDTO ua = new UserAccessDTO()
                    {
                        
                    };
                }
            }
        }
    }
}
