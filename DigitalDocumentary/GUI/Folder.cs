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
            label1.Text = "THÊM THƯ MỤC";
        }
        public Folder(int id)
        {
            InitializeComponent();
            LoadFolder(id);
            isEdit = true;
            label1.Text = "CẬP NHẬT THƯ MỤC";
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
                    Notification.Success();
                }
                else
                {
                    Notification.Fail();
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
                try
                {
                    if (folderBll.Add(fol))
                    {
                        Notification.Success();
                    }
                    else
                    {
                        Notification.Fail();
                    }
                }catch(SqlException ex)
                {
                    if (ex.Number == 2627)
                    {
                        Notification.Notify("Hãy đổi \"Mã thư mục\"");
                    }
                }
                catch(Exception ex) { }
            }
        }
    }
}
