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
                new DataGridViewButtonColumn{Text = "Remove",UseColumnTextForButtonValue = true, FlatStyle = FlatStyle.Flat, AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells},//index=9
                new DataGridViewTextBoxColumn{DataPropertyName = "Id", Visible = false},
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
                DataGridViewRow row = dataGridViewDocPolicy.Rows[e.RowIndex];
                DataGridViewButtonCell x = (DataGridViewButtonCell)row.Cells[e.ColumnIndex];
                if (x.Value.Equals("Edit") || x.Value.Equals("Save"))
                {
                    if (x.Value.Equals("Edit"))
                    {
                        row.ReadOnly = false;
                        var z = row.Cells[0];
                        row.Cells[1].Selected = true;
                        x.UseColumnTextForButtonValue = false;
                        x.Value = "Save";
                    }
                    else
                    {
                        row.ReadOnly = true;
                        x.Value = "Edit";
                        x.UseColumnTextForButtonValue = true;
                        UserAccessDTO ua = new UserAccessDTO();
                        ua.Id = row.Cells[10].Value.ToString();
                        ua.Display = Convert.ToBoolean(row.Cells[2].Value.ToString());
                        ua.TrialRead = Convert.ToBoolean(row.Cells[3].Value.ToString());
                        ua.CanRead = Convert.ToBoolean(row.Cells[4].Value.ToString());
                        ua.CanDownload = Convert.ToBoolean(row.Cells[5].Value.ToString());
                        ua.NumberPageRead = int.Parse(row.Cells[6].Value.ToString());
                        ua.NumberPageDownload = int.Parse(row.Cells[7].Value.ToString());

                        userAccessBLL.Save(ua);
                    }
                }
                else
                {
                    if (MessageBox.Show("Hey diu! Are you sure?") == DialogResult.OK)
                    {
                        string id = row.Cells[10].Value.ToString();
                        if (userAccessBLL.Delete(id))
                        {
                            MessageBox.Show("Successfully!");
                            CurrencyManager currencyManager1 = (CurrencyManager)BindingContext[dataGridViewDocPolicy.DataSource];
                            currencyManager1.SuspendBinding();
                            row.Visible = false;
                            currencyManager1.ResumeBinding();
                        }
                    }
                }
            }
        }
    }
}
