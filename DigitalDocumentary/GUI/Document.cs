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
        bool isDocOrFolder = false;
        public Document()
        {
            InitializeComponent();
            dataGridViewDocuments.AutoGenerateColumns = false;
            dataGridViewDocuments.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewDocuments.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            LoadDocument(documentBLL.Load());
            LoadSelectionFilter();
            treeViewFolders.Nodes.Add("TLS", "TÀI LIỆU SỐ");
            TreeNode root = treeViewFolders.Nodes[0];
            List<FolderDTO> folders = f.Load();
            LoadFolder(folders, root, null);
        }

        private void LoadFolder(List<FolderDTO> folders, TreeNode root, FolderDTO folder = null)
        {
            if (folders.Count == 0) return;
            if(folder == null)
            {
                folders.FindAll(fol => fol.Parent == null).ForEach(fol =>
                {
                    TreeNode tmp = root.Nodes.Add(fol.Id.ToString(), fol.Name);
                    LoadFolder(folders, tmp, fol);
                });
                root.Expand();
            }
            else
            {
                folders.FindAll(fol => fol.Parent == folder).ForEach(fol =>
                {
                    TreeNode tmp = root.Nodes.Add(fol.Id.ToString(), fol.Name);
                    LoadFolder(folders, tmp, fol);
                });
            }
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
            isDocOrFolder = false;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            int id = int.Parse(treeViewFolders.SelectedNode.Name);
            Folder a = new Folder(id);
            a.ShowDialog();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int id = int.Parse(treeViewFolders.SelectedNode.Name);
            if (MessageBox.Show("Bạn có chắc muốn xóa bản ghi này?", "Thông báo", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                FolderBLL.Delete(id);
            }
        }

        private void btnAddDoc_Click(object sender, EventArgs e)
        {
            AddDocument addDocument = new AddDocument();
            addDocument.ShowDialog();
        }

        private void btnDeleteDoc_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Are your sure?", "", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                return;
            }
            List<int> ids = IdDocumentSelected();
            if (documentBLL.Delete(ids))
            {
                MessageBox.Show("Deleted!");
            }
        }

        private void btnDocIndex_Click(object sender, EventArgs e)
        {
            int id = 0;
            for(int i = 0; i < dataGridViewDocuments.Rows.Count; i++)
            {
                if (Convert.ToBoolean(dataGridViewDocuments.Rows[i].Cells[0].Value))
                {
                    id = Convert.ToInt32(dataGridViewDocuments.Rows[i].Cells[1].Value);
                }
            }
            DocumentIndex index = new DocumentIndex(id);
            index.ShowDialog();
        }

        private void btnPublic_Click(object sender, EventArgs e)
        {
            int x = int.Parse(treeViewFolders.SelectedNode.Name);
            if(MessageBox.Show("Bạn có chắc chắn ban hành tất cả các tài liệu trong thư mục này?", "Thông báo", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                FolderBLL.PublicDoc(x);
            }
        }

        private void btnMvDocToNewFolder_Click(object sender, EventArgs e)
        {
            List<int> ids = IdDocumentSelected();
            if(ids.Count == 0 && isDocOrFolder)
            {
                MessageBox.Show("You need choose at least one document to move another folder!");
                return;
            }
            else
            {
                ids = new List<int>();
                ids.Add(int.Parse(treeViewFolders.SelectedNode.Name));
            }
            MoveDocOrFolder mvDoc = new MoveDocOrFolder(ids, isDocOrFolder);
            mvDoc.ShowDialog();
        }

        private List<int> IdDocumentSelected()
        {
            List<int> ids = new List<int>();
            for (int i = 0; i < dataGridViewDocuments.RowCount; i++)
            {
                if (Convert.ToBoolean(dataGridViewDocuments.Rows[i].Cells[0].Value) == true)
                {
                    ids.Add(Convert.ToInt32(dataGridViewDocuments.Rows[i].Cells[1].Value));
                }
            }
            return ids;
        }

        private void dataGridViewDocuments_MouseClick(object sender, MouseEventArgs e)
        {
            isDocOrFolder = true;
        }
    }
}
