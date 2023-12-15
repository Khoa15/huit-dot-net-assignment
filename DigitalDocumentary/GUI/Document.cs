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
    public partial class Document : Form
    {
        FolderBLL folderBLL = new FolderBLL();
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
            InitLoadFolder();
        }
        private void QL_TaiLieuSo_Load(object sender, EventArgs e)
        {
            panel6.Dock = DockStyle.Bottom;
            pnMain.Visible = false;
            btn_IcTable.Enabled = false;
            pnFolDoc.Visible = false;
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
            if(keyword.Length == 0)
            {
                LoadDocument(documentBLL.Load());
            }
            else
            {
                LoadDocument(documentBLL.Find(selection, keyword));
            }
        }
        private void treeViewFolders_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            isDocOrFolder = false;
            TreeNode current = (TreeNode)e.Node;
            if(current.Level == 0 && current.Name.Equals("TLS"))
            {
                panel6.Visible = true;
                pnFolDoc.Visible = false;
                LoadDocument(documentBLL.Load());
                InitLoadFolder();
            }
            else
            {
                pnFolDoc.Visible = true;
                pnFolDoc.Dock = DockStyle.Bottom;
                panel6.Visible = false;
                LoadDocumentByFolder(current);
            }
        }
        private void LoadDocumentByFolder(TreeNode current)
        {
            if (current.Name.Equals("unPublic"))
            {
                LoadDocument(documentBLL.LoadByStatus(false));
            }
            else if (current.Name.Equals("isPublic"))
            {
                LoadDocument(documentBLL.LoadByStatus(true));
            }
            else
            {
                int id = int.Parse(current.Name);
                LoadDocument(documentBLL.LoadByFolderId(id));
            }
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                int id = SelectedFolder;
                Folder a = new Folder(id);
                a.ShowDialog();
                InitLoadFolder();
            }catch(Exception ex)
            {
                
            }
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                int id = SelectedFolder;
                if (MessageBox.Show("Bạn có chắc muốn xóa bản ghi này?", "Thông báo", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    if (FolderBLL.Delete(id))
                    {
                        MessageBox.Show("Successfully");
                    }
                    else
                    {
                        MessageBox.Show("Failure!");
                    }
                }
                InitLoadFolder();
            }catch(SqlException ex)
            {
                if(ex.Number == 547)
                {
                    Notification.Notify("Thư mục không rỗng để thực hiện!");
                }
            }
            catch
            {

            }
        }
        private void btnAddDoc_Click(object sender, EventArgs e)
        {
            try
            {
                int id = SelectedFolder;
                if(id == -99)
                {
                    throw new Exception();
                }
                folderBLL.Find(SelectedFolder);
                AddDocument addDocument = new AddDocument(SelectedFolder, false);
                addDocument.ShowDialog();
                LoadDocumentByFolder(treeViewFolders.SelectedNode);
                InitLoadFolder();
            }catch(Exception ex) { }
        }
        private void btnDeleteDoc_Click(object sender, EventArgs e)
        {
            if(Notification.ConfirmDelete() == DialogResult.Cancel)
            {
                return;
            }
            List<int> ids = IdDocumentSelected();
            try
            {
                if (documentBLL.Delete(ids))
                {
                    Notification.Success();
                    LoadDocument(documentBLL.Load());
                    InitLoadFolder();
                }
            }catch(SqlException ex)
            {
                if(ex.Number == 547)
                {
                    Notification.Notify("Không thể xóa!");
                }
            }catch(Exception ex)
            {
                Notification.Notify("Có lỗi đã xảy ra!");
            }
        }
        private void btnDocIndex_Click(object sender, EventArgs e)
        {
            int id = IdDocumentSelected().First();
            DocumentIndex index = new DocumentIndex(id);
            index.ShowDialog();
        }
        private void btnPublic_Click(object sender, EventArgs e)
        {
            try
            {
                if (isDocOrFolder)
                {
                    //Public Doc is selected
                    List<int> ids = IdDocumentSelected();
                    if (documentBLL.Public(ids))
                    {
                        Notification.Success();
                    }
                    else
                    {
                        Notification.Fail();
                    }
                }
                else
                {
                    int x = SelectedFolder;
                    if(Notification.ConfirmPublicAllDocs() == DialogResult.OK)
                    {
                        if (FolderBLL.PublicDoc(x))
                        {
                            Notification.Success();
                        }
                    }
                }
                LoadDocument(documentBLL.Load());
                InitLoadFolder();
            }
            catch (Exception ex) { }
        }
        private void btnPrivateDocument_Click(object sender, EventArgs e)
        {
            try
            {
                if (isDocOrFolder)
                {
                    //Private Doc is selected
                    List<int> ids = IdDocumentSelected();
                    if (documentBLL.Private(ids))
                    {
                        Notification.Success();
                    }
                    else
                    {
                        Notification.Fail();
                    }
                }
                else
                {
                    int x = SelectedFolder;
                    if (Notification.ConfirmUnPublicAllDocs() == DialogResult.OK)
                    {
                        if (FolderBLL.PrivateDoc(x))
                        {
                            Notification.Success();
                        }
                    }
                }
                LoadDocument(documentBLL.Load());
                InitLoadFolder();
            }
            catch(Exception ex) { }
        }
        private void btnMvDocToNewFolder_Click(object sender, EventArgs e)
        {
            List<int> ids = IdDocumentSelected();
            if(ids.Count == 0 && isDocOrFolder)
            {
                MessageBox.Show("Cần chọn ít nhất một tài liệu hoặc một thư mục để di chuyển!");
                return;
            }
            else if(isDocOrFolder == false)
            {
                ids.Clear();
                ids.Add(SelectedFolder);
            }
            MoveDocOrFolder mvDoc = new MoveDocOrFolder(ids, isDocOrFolder);
            mvDoc.ShowDialog();
            InitLoadFolder();
        }
        private void dataGridViewDocuments_MouseClick(object sender, MouseEventArgs e)
        {
            isDocOrFolder = true;
        }
        private void InitLoadFolder()
        {
            List<FolderDTO> folders = folderBLL.Load();
            treeViewFolders.Nodes.Clear();
            treeViewFolders.Nodes.Add("TLS", "TÀI LIỆU SỐ");
            TreeNode root = treeViewFolders.Nodes[0];
            root.Nodes.Add("isPublic", "Đã ban hành" + " - " + folderBLL.CountDocIsPublic());
            root.Nodes.Add("unPublic", "Chưa ban hành" + " - " + folderBLL.CountDocUnPublic());
            LoadFolder(folders, root, null);
        }
        private void LoadFolder(List<FolderDTO> folders, TreeNode root, FolderDTO folder = null)
        {
            if (folders.Count == 0) return;
            if(folder == null)
            {
                folders.FindAll(fol => fol.Parent == null).ForEach(fol =>
                {
                    TreeNode tmp = root.Nodes.Add(fol.Id.ToString(), fol.Name + " - " + fol.NumOfDoc);
                    LoadFolder(folders, tmp, fol);
                });
                root.Expand();
            }
            else
            {
                folders.FindAll(fol => fol.Parent == folder).ForEach(fol =>
                {
                    TreeNode tmp = root.Nodes.Add(fol.Id.ToString(), fol.Name + " - " + fol.NumOfDoc);
                    LoadFolder(folders, tmp, fol);
                });
            }
        }
        private void LoadDocument(List<DocumentDTO> docs)
        {
            dataGridViewDocuments.DataSource = null;
            dataGridViewDocuments.Columns.Clear();
            if(dataGridViewDocuments.Rows.Count > 0)
            {
                dataGridViewDocuments.CancelEdit();
                dataGridViewDocuments.Columns.Clear();
                dataGridViewDocuments.DataSource = null;
            }
            dataGridViewDocuments.DataSource = docs;
            DataGridViewColumn[] columns =
            {
                new DataGridViewCheckBoxColumn {HeaderText = "Unchecked", ValueType = typeof(bool)},
                new DataGridViewTextBoxColumn { Name = "Id", DataPropertyName = "Id", HeaderText = "Mã số", ReadOnly = true, AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells },
                new DataGridViewTextBoxColumn { Name = "Title", DataPropertyName = "Title", HeaderText = "Tiêu đề", ReadOnly = true, AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill, MinimumWidth=150 },
                new DataGridViewTextBoxColumn { Name = "Author", DataPropertyName = "Author", HeaderText = "Tác giả", ReadOnly = true,AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells, MinimumWidth=100 },
                new DataGridViewTextBoxColumn { Name = "Type", DataPropertyName = "Type", HeaderText = "Loại tài liệu", ReadOnly = true,AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells },
                new DataGridViewTextBoxColumn { Name = "Updated_by", DataPropertyName = "Updated_by", HeaderText = "Người cập nhật", ReadOnly = true,AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells },
                new DataGridViewTextBoxColumn { Name = "Updated_date", DataPropertyName = "Updated_at", HeaderText = "Ngày cập nhật", ReadOnly = true,AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells },
                new DataGridViewTextBoxColumn { Name = "Status", DataPropertyName = "GetStatus", HeaderText = "Tình trạng", AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells },
            };

            dataGridViewDocuments.Columns.AddRange(columns);

            //for(int i = 0; i <  dataGridViewDocuments.Rows.Count; i++)
            //{
            //    DataGridViewTextBoxCell cell = (DataGridViewTextBoxCell)dataGridViewDocuments.Rows[i].Cells[7];
            //    if (cell.Value.Equals("Chưa ban hành"))
            //    {
            //        cell.ReadOnly = false;
            //        cell.Style.BackColor = Color.Red;
            //        cell.Style.ForeColor = Color.Blue;
            //        cell.Value = "Haskdfkasldf";
            //    }
            //}
            //dataGridViewDocuments.Refresh();
        }
        private void LoadSelectionFilter()
        {
            cbBoxFilterSearch.Items.Add("Mã số");
            cbBoxFilterSearch.Items.Add("Tiêu đề");
            cbBoxFilterSearch.Items.Add("Tác giả");
            cbBoxFilterSearch.SelectedIndex = 0;
        }

        private void treeViewFolders_AfterSelect(object sender, TreeViewEventArgs e)
        {

            var x = treeViewFolders.SelectedNode;
            if (treeViewFolders.SelectedNode.Name == "TLS")
            {
                panel6.Dock = DockStyle.Bottom;
                pnMain.Hide();
                pnFolDoc.Hide();
            }
        }

        private void btnPolicy_Click(object sender, EventArgs e)
        {
            Policy policy = new Policy();
            policy.ShowDialog();
            this.Update();
        }

        private void dataGridViewDocuments_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            var senderGrid = (DataGridView)sender;
            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewCheckBoxColumn && e.RowIndex > 0)
            {
                DataGridViewRow row = senderGrid.Rows[e.RowIndex];
            }
        }

        private void dataGridViewDocuments_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewCheckBoxColumn && e.ColumnIndex == 0)
            {
                DataGridViewCheckBoxColumn column= (DataGridViewCheckBoxColumn)senderGrid.Columns[e.ColumnIndex];
                
                if(column.HeaderText.Equals("Unchecked"))
                {
                    column.HeaderText = "Checked";
                    ToggleCheckBox(true);
                }
                else
                {
                    column.HeaderText = "Unchecked";
                    ToggleCheckBox(false);
                }
            }
        }
        private void ToggleCheckBox(bool check)
        {
            for (int i = 0; i < dataGridViewDocuments.RowCount; i++)
            {
                DataGridViewCheckBoxCell checkBoxCell = (DataGridViewCheckBoxCell)dataGridViewDocuments.Rows[i].Cells[0];
                checkBoxCell.Value = check;
            }
        }

        private void btnAddFolder_Click(object sender, EventArgs e)
        {
            Folder a = new Folder();
            a.ShowDialog();
            InitLoadFolder();
        }

        private void dataGridViewDocuments_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(pnFolDoc.Visible == false)
            {
                pnFolDoc.Visible = true;
                pnFolDoc.Dock = DockStyle.Bottom;
                panel6.Visible = false;
                pnMain.Visible = false;
            }
        }

        private void btnEditDoc_Click(object sender, EventArgs e)
        {
            List<int> id = IdDocumentSelected();
            if(id.Count!=1)
            {
                return;
            }

            AddDocument updateDoc = new AddDocument(id.First(), true);
            updateDoc.ShowDialog();
            LoadDocument(documentBLL.Load());
        }

        private int GetIdDocSelected()
        {
            for (int i = 0; i < dataGridViewDocuments.Rows.Count; i++)
            {
                if (Convert.ToBoolean(dataGridViewDocuments.Rows[i].Cells[0].Value))
                {
                    return Convert.ToInt32(dataGridViewDocuments.Rows[i].Cells[1].Value);
                }
            }
            return -1;
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

        private void btnDeleteDocInFolder_Click(object sender, EventArgs e)
        {
            try
            {
                int id = SelectedFolder;
                
                if (Notification.ConfirmDelete("Bạn có muốn xóa tất cả tài liệu của thư mục này?") == DialogResult.OK)
                {
                    if (id > 0)
                    {
                        if (documentBLL.DeleteByFolder(id))
                        {
                            Notification.Success();
                            LoadDocument(documentBLL.Load());
                            InitLoadFolder();
                        }
                    }
                    else
                    {
                        if (documentBLL.DeleteByStatus(id != -2))
                        {
                            Notification.Success();
                            LoadDocument(documentBLL.Load());
                            InitLoadFolder();
                        }
                        else
                        {

                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }
        private int SelectedFolder
        {
            get
            {
                try
                {
                    string name = treeViewFolders.SelectedNode.Name;
                    switch (name)
                    {
                        case "unPublic":
                            return -2;
                        case "isPublic":
                            return -1;
                        default:
                            return int.Parse(name);
                    }
                    //return int.Parse(name)l;
                }
                catch (NullReferenceException)
                {
                    Notification.Notify("Bạn chưa chọn thư mục!");
                    return -99;
                }
                catch
                {
                    Notification.Notify("Không thể chọn thư mục!");
                    return -99;
                }
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {

        }

        private void dataGridViewDocuments_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dataGridViewDocuments.Columns[e.ColumnIndex].Name == "Status" && e.Value != null)
            {
                if (e.Value.Equals("Chưa ban hành"))
                {
                    e.CellStyle.BackColor = Color.OrangeRed;
                    e.CellStyle.ForeColor = Color.White;
                }
                else
                {
                    e.CellStyle.BackColor = Color.Blue;
                    e.CellStyle.ForeColor = Color.White;
                }
            }
        }
    }
}
