using DigitalDocumentary.BLL;
using DigitalDocumentary.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
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
        PatronTypesBLL patronTypesBll = new PatronTypesBLL();
        bool isAdd = false;
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
            DataGridViewComboBoxColumn combobox = new DataGridViewComboBoxColumn { Name = "listperson", HeaderText = "asdf", DisplayMember = "Name", ValueMember="Id", DataPropertyName = "Id" };
            combobox.DataSource = patronTypesBll.Load();
            dataGridViewDocPolicy.Columns.Insert(1, combobox);
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
                    if (x.Value.Equals("Edit") && isAdd == false)
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
                        DataGridViewComboBoxCell comboBoxCell = (DataGridViewComboBoxCell)row.Cells[1];
                        ua.Id = comboBoxCell.Value.ToString().Trim();
                        ua.Display = Convert.ToBoolean(row.Cells[2].Value.ToString());
                        ua.TrialRead = Convert.ToBoolean(row.Cells[3].Value.ToString());
                        ua.CanRead = Convert.ToBoolean(row.Cells[4].Value.ToString());
                        ua.CanDownload = Convert.ToBoolean(row.Cells[5].Value.ToString());
                        ua.NumberPageRead = int.Parse(row.Cells[6].Value.ToString());
                        ua.NumberPageDownload = int.Parse(row.Cells[7].Value.ToString());

                        if (isAdd)
                        {
                            try
                            {
                                userAccessBLL.Add(ua);

                            }catch(SqlException ex)
                            {
                                if(ex.Number == 2627)
                                {
                                    Notification.Notify("Hãy chọn đối tượng khác!");
                                }
                            }
                        }
                        else
                        {
                            userAccessBLL.Save(ua);

                        }
                    }
                }
                else
                {
                    if (isAdd == false)
                    {
                        if(Notification.ConfirmDelete() == DialogResult.OK)
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
                    }else if (e.RowIndex == 0)
                    {
                        List<UserAccessDTO> userList = (List<UserAccessDTO>)dataGridViewDocPolicy.DataSource;
                        userList.RemoveAt(0);
                        dataGridViewDocPolicy.DataSource = null;
                        dataGridViewDocPolicy.DataSource = userList;
                        isAdd = false;
                    }
                }
            }
        }

        private void btnAddPolicy_Click(object sender, EventArgs e)
        {
            if (isAdd) return;
            List<UserAccessDTO> userList = (List<UserAccessDTO>)dataGridViewDocPolicy.DataSource;

            isAdd = true;
            UserAccessDTO newUser = new UserAccessDTO
            {
                Display = true,
                TrialRead = false,
                CanRead = true,
                CanDownload = false,
                NumberPageRead = 10,
                NumberPageDownload = 20,
                Id = String.Empty,
            };

            userList.Insert(0, newUser);

            dataGridViewDocPolicy.DataSource = null;
            dataGridViewDocPolicy.DataSource = userList;
            foreach (DataGridViewRow row in dataGridViewDocPolicy.Rows)
            {
                if (row.Index == 0)
                {
                    DataGridViewButtonCell btn = (DataGridViewButtonCell)row.Cells[8];
                    btn.UseColumnTextForButtonValue = false;
                    btn.Value = "Save";
                    continue;
                }
                foreach (DataGridViewCell cell in row.Cells)
                {
                    cell.ReadOnly = true;
                }
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
