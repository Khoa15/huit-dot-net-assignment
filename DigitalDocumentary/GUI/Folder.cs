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
    public partial class Folder : Form
    {
        FolderBLL folderBll = new FolderBLL();
        public Folder()
        {
            InitializeComponent();
        }
        public Folder(int id)
        {
            InitializeComponent();
            LoadFolder(id);
        }
        private void LoadFolder(int id)
        {
            FolderDTO fol = folderBll.Load(id);
            if (fol == null)
            {
                MessageBox.Show("Can't load this folder");
                this.Close();
                return;
            }
            txtBoxFolderNameId.Text = fol.NameId;
            txtBoxFolderName.Text = fol.Name;
            ckBoxFolderStatus.Checked = fol.Status;
        }

        private void CP_ThuMuc_Load(object sender, EventArgs e)
        {
            btnTB.Enabled = false;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            FolderDTO folder = new FolderDTO()
            {
                NameId = txtBoxFolderNameId.Text,
                Name = txtBoxFolderName.Text,
                Status = ckBoxFolderStatus.Checked,
                Parent = null,
            };
            if (folderBll.Add(folder))
            {
                MessageBox.Show("Added Successfully!");
            }
            else
            {
                MessageBox.Show("Failure!");
            }
        }
    }
}
