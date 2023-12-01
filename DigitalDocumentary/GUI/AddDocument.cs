using DigitalDocumentary.BLL;
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

namespace DigitalDocumentary.GUI
{
    public partial class AddDocument : Form
    {
        DocumentBLL documentBll = new DocumentBLL();
        public AddDocument()
        {
            InitializeComponent();
            LoadDocumentType();
        }
        private void LoadDocumentType()
        {
            cbBoxTypeDoc.Items.Add("Books - Sách");
            cbBoxTypeDoc.Items.Add("Computer file - Tập tin");
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
            List<AuthorDTO> authorDTOs = new List<AuthorDTO>();
            var x = txtBoxAuthor.Text.Split(';');
            DocumentDTO document = new DocumentDTO()
            {
                Title = txtBoxTitle.Text,
                Description = txtBoxDescription.Text,
                Link_to_image = picBoxAvatar.ImageLocation,
                File_path = txtBoxFilePath.Text,
                Folder = new FolderDTO()
                {
                    Id = 1,
                }
            };

            if (documentBll.Add(document) > 0)
            {
                MessageBox.Show("Added successfully!");
            }
        }

        private void txtBoxAuthor_KeyPress(object sender, KeyPressEventArgs e)
        {

        }
    }
}
