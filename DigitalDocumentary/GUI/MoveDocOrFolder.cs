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
    public partial class MoveDocOrFolder : Form
    {
        FolderBLL folderBLL = new FolderBLL();
        DocumentBLL docBll = new DocumentBLL();
        List<FolderDTO> folders;
        List<int> ids;
        bool isDocOrFolder;
        public MoveDocOrFolder(List<int> ids, bool isDocOrFolder)
        {
            InitializeComponent();
            this.ids = ids;
            this.isDocOrFolder = isDocOrFolder;
        }

        private void MoveDoc_Load(object sender, EventArgs e)
        {
            treeViewFolders.Nodes.Add("TLS", "TÀI LIỆU SỐ");
            TreeNode root = treeViewFolders.Nodes[0];
            List<FolderDTO> folders = folderBLL.Load();
            LoadFolder(folders, root, null);
        }

        private void LoadFolder(List<FolderDTO> folders, TreeNode root, FolderDTO folder = null)
        {

            if (folders.Count == 0) return;
            if (folder == null)
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

        private void btnMove_Click(object sender, EventArgs e)
        {
            int? desId = null;
            if(treeViewFolders.SelectedNode.Index != 0)
            {
                desId = int.Parse(treeViewFolders.SelectedNode.Name);
            }
            bool result;
            if (isDocOrFolder)
            {
                result = docBll.MoveDoc(ids, desId);
            }
            else
            {
                result = folderBLL.MoveFolder(ids[0], desId);
            }
            if (result)
            {
                MessageBox.Show("Successfully!");
                this.Close();
            }
            else
            {
                MessageBox.Show("Failed!");
            }
        }
    }
}
