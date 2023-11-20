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
    public partial class Document : Form
    {
        FolderBLL f = new FolderBLL();
        DocumentBLL documentBLL = new DocumentBLL();
        public Document()
        {
            InitializeComponent();
            dataGridViewDocuments.AutoGenerateColumns = false;
            dataGridViewDocuments.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewDocuments.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            LoadFolder();
            LoadDocument(documentBLL.Load());
            LoadSelectionFilter();
        }

        private void LoadFolder()
        {
            treeViewFolders.Nodes.Add("TLS", "TÀI LIỆU SỐ");
            TreeNode root = treeViewFolders.Nodes[0];
            List<FolderDTO> folders = f.Load();
            foreach (FolderDTO folder in folders)
            {
                if (folder.Parent == null)
                {
                    root.Nodes.Add(folder.Id.ToString(), folder.Name);
                }
            }
            foreach (FolderDTO folder in folders)
            {
                TreeNode parentNode = null;

                if (folder.Parent != null)
                {
                    parentNode = root.Nodes.Find(folder.Parent.Id.ToString(), false).First();
                }

                if (parentNode != null)
                {
                    parentNode.Nodes.Add(folder.Id.ToString(), folder.Name);
                }
            }
            root.Expand();
        }
        private void LoadDocument(List<DocumentDTO> docs)
        {
            if(dataGridViewDocuments.Rows.Count > 0)
            {
                dataGridViewDocuments.CancelEdit();
                dataGridViewDocuments.Columns.Clear();
                dataGridViewDocuments.DataSource = null;
            }
            dataGridViewDocuments.DataSource = docs;
            DataGridViewColumn[] columns = 
            {
                new DataGridViewTextBoxColumn { Name = "Id", DataPropertyName = "Id", HeaderText = "Mã số", AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells },
                new DataGridViewTextBoxColumn { Name = "Title", DataPropertyName = "Title", HeaderText = "Tiêu đề", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill, MinimumWidth=150 },
                new DataGridViewTextBoxColumn { Name = "Author", DataPropertyName = "AuthorName", HeaderText = "Tác giả", AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells, MinimumWidth=100 },
                new DataGridViewTextBoxColumn { Name = "Type", DataPropertyName = "Type", HeaderText = "Loại tài liệu", AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells },
                new DataGridViewTextBoxColumn { Name = "Updated_by", DataPropertyName = "Updated_by", HeaderText = "Người cập nhật", AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells },
                new DataGridViewTextBoxColumn { Name = "Updated_date", DataPropertyName = "Updated_at", HeaderText = "Ngày cập nhật", AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells },
                new DataGridViewTextBoxColumn { Name = "Status", DataPropertyName = "Status", HeaderText = "Tình trạng", AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells },
            };

            dataGridViewDocuments.Columns.AddRange(columns);
        }
        private void LoadSelectionFilter()
        {
            cbBoxFilterSearch.Items.Add("Mã số");
            cbBoxFilterSearch.Items.Add("Tiêu đề");
            cbBoxFilterSearch.Items.Add("Tác giả");
            cbBoxFilterSearch.SelectedIndex = 0;
        }
        private void QL_TaiLieuSo_Load(object sender, EventArgs e)
        {
            btn_IcTable.Enabled = false;
            pnBottom.Visible = false;
        }

        private void QL_TaiLieuSo_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult r;
            r = MessageBox.Show("Bạn có muốn thoát?", "Thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (r == DialogResult.No)
                e.Cancel = true;

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Folder a = new Folder();
            a.ShowDialog();
        }

        private void toolStripComboBox1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripLimitRecord_Click(object sender, EventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            int selection = cbBoxFilterSearch.SelectedIndex;
            string keyword = txtBoxSearch.Text;

            LoadDocument(documentBLL.Find(selection, keyword));
        }

        private void treeViewFolders_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            pnBottom.Visible = true;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            int id = int.Parse(treeViewFolders.SelectedNode.Name);
            Folder a = new Folder(id);
            a.ShowDialog();
        }
    }
}
