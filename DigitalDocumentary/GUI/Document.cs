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
            LoadFolder();
            LoadDocument();
        }

        private void LoadFolder()
        {
            List<FolderDTO> folders = f.Load();
            foreach (FolderDTO folder in folders)
            {
                if (folder.Parent == null)
                {
                    treeViewFolders.Nodes.Add(folder.Id.ToString(), folder.Name);
                }
            }
            foreach (FolderDTO folder in folders)
            {
                TreeNode parentNode = null;

                if (folder.Parent != null)
                {
                    parentNode = treeViewFolders.Nodes.Find(folder.Parent.Id.ToString(), false).First();
                }

                if (parentNode != null)
                {
                    parentNode.Nodes.Add(folder.Id.ToString(), folder.Name);
                }
            }
        }
        private void LoadDocument()
        {
            dataGridViewDocuments.AutoGenerateColumns = false;
            dataGridViewDocuments.DataSource = documentBLL.Load();
            DataGridViewColumn[] columns = 
            {
                new DataGridViewTextBoxColumn { Name = "Id", DataPropertyName = "Id", HeaderText = "Mã số" },
                new DataGridViewTextBoxColumn { Name = "Title", DataPropertyName = "Title", HeaderText = "Tiêu đề" },
                new DataGridViewTextBoxColumn { Name = "Author", DataPropertyName = "AuthorName", HeaderText = "Tác giả" },
                new DataGridViewTextBoxColumn { Name = "Type", DataPropertyName = "Type", HeaderText = "Loại tài liệu" },
                new DataGridViewTextBoxColumn { Name = "Updated_by", DataPropertyName = "Updated_by", HeaderText = "Người cập nhật" },
                new DataGridViewTextBoxColumn { Name = "Updated_date", DataPropertyName = "Updated_date", HeaderText = "Ngày cập nhật" },
                new DataGridViewTextBoxColumn { Name = "Status", DataPropertyName = "Status", HeaderText = "Tình trạng" },
            };

            dataGridViewDocuments.Columns.AddRange(columns);
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

        }
    }
}
