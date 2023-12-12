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
        DocumentDTO doc;
        bool isEdit = false;
        public AddDocument()
        {
            InitializeComponent();
            LoadDocumentType();
        }
        public AddDocument(int id)
        {
            InitializeComponent();
            LoadDocumentType();
            doc = documentBll.Load(id);
            txtBoxTitle.Text = doc.Title;
            txtBoxDescription.Text = doc.Description;
            picBoxAvatar.ImageLocation = doc.Link_to_image;
            txtBoxFilePath.Text = doc.File_path;
            isEdit = true;
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
                if (documentBll.Update(doc) > 0)
                {
                    MessageBox.Show("Updated successfully!");
                }
                else
                {
                    MessageBox.Show("Failure!");
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
                };

                if (documentBll.Add(doc) > 0)
                {
                    MessageBox.Show("Added successfully!");
                }
                else
                {
                    MessageBox.Show("Failure!");
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
