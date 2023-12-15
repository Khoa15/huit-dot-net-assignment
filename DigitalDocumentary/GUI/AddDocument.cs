using DigitalDocumentary.BLL;
using DigitalDocumentary.DAL;
using DigitalDocumentary.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace DigitalDocumentary.GUI
{
    public partial class AddDocument : Form
    {
        ItemTypeBLL itemTypeBLL = new ItemTypeBLL();
        DocumentBLL documentBll = new DocumentBLL();
        FolderDTO folder;
        DocumentDTO doc;
        bool isEdit = false;
        public AddDocument()
        {
            InitializeComponent();
            LoadDocumentType();
            label1.Text = "THÊM TÀI LIỆU";
        }
        public AddDocument(int id, bool isEdit)
        {
            InitializeComponent();
            LoadDocumentType();
            label1.Text = "CẬP NHẬT TÀI LIỆU";
            if (isEdit)
            {
                doc = documentBll.Load(id);
                txtBoxTitle.Text = doc.Title;
                txtBoxDescription.Text = doc.Description;
                picBoxAvatar.ImageLocation = doc.Link_to_image;
                txtBoxFilePath.Text = doc.File_path;
                txtBoxAuthor.Text = doc.Author;
                this.isEdit = true;
            }
            else
            {
                if(id > 0)
                {
                    folder = FolderBLL.Get(id);
                    txtBoxFolder.Text = folder.Name;

                }
            }
        }
        private void LoadDocumentType()
        {
            itemTypeBLL.Load().ForEach(item =>
            {
                cbBoxTypeDoc.Items.Add(item.TypeName);
            });
            cbBoxTypeDoc.SelectedIndex = 0;
        }

        private void panel11_Paint(object sender, PaintEventArgs e)
        {

        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "Document|*.pdf;*.doc;*.docx;*.txt|All Files|*.*";
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                txtBoxFilePath.Text = openFile.FileName;
            }
        }

        private void btnCam_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "Image|*.png;*.jpg;*.jpeg|All Files|*.*";
            if(openFile.ShowDialog() == DialogResult.OK)
            {
                picBoxAvatar.Image = new Bitmap(openFile.OpenFile());
                picBoxAvatar.ImageLocation = openFile.FileName;
            }
        }

        private void btnClearImage_Click(object sender, EventArgs e)
        {
            picBoxAvatar.Image = null;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(txtBoxFilePath.Text.Length == 0 || txtBoxTitle.Text.Length == 0 || cbBoxTypeDoc.SelectedIndex == -1)
            {
                MessageBox.Show("Some fields can't be empty");
                return;
            }
            string typeName = cbBoxTypeDoc.SelectedItem.ToString();
            ItemTypeDTO TypeId = itemTypeBLL.Load(typeName);
            Button clicked = (Button)sender;
            if(isEdit)
            {
                doc.Title = txtBoxTitle.Text;
                doc.Description = txtBoxDescription.Text;
                doc.Link_to_image = picBoxAvatar.ImageLocation;
                doc.File_path = txtBoxFilePath.Text;
                doc.Author = txtBoxAuthor.Text;
                doc.ItemType = TypeId;
                doc.Status = clicked.Tag.ToString().Equals("save");
                doc.Updated_by = "admin";
                doc.Folder = folder;
                if (documentBll.Update(doc) > 0)
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
                doc = new DocumentDTO()
                {
                    Title = txtBoxTitle.Text,
                    Description = txtBoxDescription.Text,
                    Link_to_image = picBoxAvatar.ImageLocation,
                    File_path = txtBoxFilePath.Text,
                    Author = txtBoxAuthor.Text,
                    ItemType = TypeId,
                    Status = clicked.Tag.ToString().Equals("save"),
                    Updated_by = "admin",
                    Folder = folder
                };

                if (documentBll.Add(doc) > 0)
                { 
                    Notification.Success();
                }
                else
                {
                    Notification.Fail();
                }

            }
        }

        private void txtBoxAuthor_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void btnPublic_Click(object sender, EventArgs e)
        {
            btnSave_Click(sender, e);
        }
    }
}
