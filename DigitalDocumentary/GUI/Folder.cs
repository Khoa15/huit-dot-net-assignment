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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DigitalDocumentary.GUI
{
    public partial class Folder : Form
    {
        FolderBLL folderBll = new FolderBLL();
        FolderDTO fol;
        private bool isEdit = false;
        public Folder()
        {
            InitializeComponent();
        }
        public Folder(int id)
        {
            InitializeComponent();
            LoadFolder(id);
            isEdit = true;
        }
        private void LoadFolder(int id)
        {
            fol = folderBll.Load(id);
            if (fol == null)
            {
                MessageBox.Show("Can't load this folder");
                this.Close();
                return;
            }
            txtBoxFolderNameId.Text = fol.NameId;
            txtBoxFolderName.Text = fol.Name;
            ckBoxFolderStatus.Checked = fol.Status;
            isEdit = true;
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
            if (isEdit)
            {
                fol.NameId = txtBoxFolderNameId.Text;
                fol.Name = txtBoxFolderName.Text;
                fol.Status = ckBoxFolderStatus.Checked;
                if (folderBll.Update(fol))
                {
                    MessageBox.Show("Updated Successfully!");
                }
                else
                {
                    MessageBox.Show("Failure!");
                }
            }
            else
            {
                fol = new FolderDTO()
                {
                    NameId = txtBoxFolderNameId.Text,
                    Name = txtBoxFolderName.Text,
                    Status = ckBoxFolderStatus.Checked,
                    CreatedBy = "admin",
                    Parent = null,
                };
                if (folderBll.Add(fol))
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
}
