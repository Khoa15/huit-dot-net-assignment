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
    public partial class AddDocumentIndex : Form
    {
        DocumentIndexBLL documentBll = new DocumentIndexBLL();
        DocumentIndexDTO docIndex;
        int docId;
        public AddDocumentIndex(int id)
        {
            InitializeComponent();
            docId= id;
        }
        public AddDocumentIndex(int id, int docIndexId)
        {
            InitializeComponent();
            btnSubmit.Text = "Cập Nhật";
            docId = id;
            docIndex = documentBll.Load(id, docIndexId);

            txtBxAuthor.Text = docIndex.Author;
            txtBoxPage.Text = docIndex.PageNumber.ToString();
            txtBxTitle.Text = docIndex.Title;
            treeViewDocI.ExpandAll();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DocumentIndexDTO docI = new DocumentIndexDTO();
            docI.Author = txtBxAuthor.Text;
            docI.Title = txtBxTitle.Text;
            docI.PageNumber = int.Parse(txtBoxPage.Text);
            docI.Document = new DocumentDTO();
            docI.Document.Id = docId;
            if(treeViewDocI.SelectedNode != null && treeViewDocI.SelectedNode.Name.Equals("root") == false)
            {
                docI.Parent = new DocumentIndexDTO();
                docI.Parent.Id = int.Parse(treeViewDocI.SelectedNode.Name);
            }

            if (documentBll.Add(docI))
            {
                Notification.Success();
            }
            else
            {
                Notification.Fail();
            }
        }

        private void txtBoxPage_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        private void AddDocumentIndex_Load(object sender, EventArgs e)
        {
            List<DocumentIndexDTO> list = documentBll.Load(docId);
            treeViewDocI.Nodes.Clear();
            treeViewDocI.Nodes.Add("root", "ROOT");
            TreeNode root = treeViewDocI.Nodes[0];
            LoadFolder(list, root, null);
        }
        private void LoadFolder(List<DocumentIndexDTO> docsI, TreeNode root, DocumentIndexDTO docI = null)
        {
            if (docsI.Count == 0) return;
            if (docI == null)
            {
                docsI.FindAll(fol => fol.Parent == null).ForEach(fol =>
                {
                    TreeNode tmp = root.Nodes.Add(fol.Id.ToString(), fol.Title);
                    LoadFolder(docsI, tmp, fol);
                });
                root.Expand();
            }
            else
            {
                docsI.FindAll(fol => fol.Parent == docI).ForEach(fol =>
                {
                    TreeNode tmp = root.Nodes.Add(fol.Id.ToString(), fol.Title);
                    LoadFolder(docsI, tmp, fol);
                });
            }
        }
    }
}
