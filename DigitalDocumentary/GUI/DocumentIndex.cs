using DigitalDocumentary.BLL;
using DigitalDocumentary.DLL;
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
    public partial class DocumentIndex : Form
    {
        DocumentIndexBLL diBll = new DocumentIndexBLL();
        List<DocumentIndexDTO> list = new List<DocumentIndexDTO>();
        bool isAdd;
        int id;
        public DocumentIndex(int id)
        {
            InitializeComponent();
            this.id = id;
        }

        private void DocumentIndex_Load(object sender, EventArgs e)
        {
            LoadDocI();
        }

        private void LoadDocI()
        {
            dataGridViewDocIndex.Columns.Clear();
            dataGridViewDocIndex.DataSource = null;

            dataGridViewDocIndex.AutoGenerateColumns = false;
            list = diBll.Load(id);
            dataGridViewDocIndex.DataSource = list;
            DataGridViewColumn[] columns =
            {
                new DataGridViewTextBoxColumn(){Name = "id", Visible = false, DataPropertyName = "Id", AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells },
                new DataGridViewTextBoxColumn(){Name = "stt", HeaderText = "STT", DataPropertyName = "Level", AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells },
                new DataGridViewTextBoxColumn(){Name = "menu", HeaderText = "Mục lục", DataPropertyName = "Title", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill },
                new DataGridViewTextBoxColumn(){Name = "author", HeaderText = "Tác giả", DataPropertyName = "Author", AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells},
                new DataGridViewTextBoxColumn(){Name = "page", HeaderText = "Trang", DataPropertyName = "PageNumber", AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells },
                
                //new DataGridViewTextBoxColumn(){Name = "page", HeaderText = "Cấp", DataPropertyName = "Level", AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells },
                //new DataGridViewButtonColumn{Text = "Edit", UseColumnTextForButtonValue = true, FlatStyle = FlatStyle.Flat, AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells},
                new DataGridViewButtonColumn{Text = "Remove",UseColumnTextForButtonValue = true, FlatStyle = FlatStyle.Flat, AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells},
            };
            dataGridViewDocIndex.Columns.AddRange(columns);
        }

        private void btnAddIndex_Click(object sender, EventArgs e)
        {
            AddDocumentIndex docI = new AddDocumentIndex(id);
            docI.ShowDialog();
            LoadDocI();
        }

        private void dataGridViewDocIndex_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow row = (DataGridViewRow)dataGridViewDocIndex.Rows[e.RowIndex];
                DataGridViewButtonCell cell = (DataGridViewButtonCell)row.Cells[e.ColumnIndex];
                if (cell.Value.ToString().Equals("Remove"))
                {
                    if (Notification.ConfirmDelete() == DialogResult.OK)
                    {

                        int id = int.Parse(row.Cells[0].Value.ToString());
                        if (diBll.Remove(id))
                        {
                            Notification.Success();
                            LoadDocI();
                        }
                        else
                        {
                            Notification.Fail();
                        }
                    }
                }
            }catch(Exception ex) { }
        }

        private void dataGridViewDocIndex_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            DataGridViewRow row = (DataGridViewRow)dataGridViewDocIndex.Rows[e.RowIndex];
            int docIndexId = int.Parse(row.Cells[0].Value.ToString());
            AddDocumentIndex documentIndex = new AddDocumentIndex(id, docIndexId);
            documentIndex.ShowDialog();
            LoadDocI();
        }
    }
}
