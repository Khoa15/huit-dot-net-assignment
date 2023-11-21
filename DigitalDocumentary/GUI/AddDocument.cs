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
        public AddDocument()
        {
            InitializeComponent();
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
            if(openFile.ShowDialog() == DialogResult.OK)
            {
                txtBoxFilePath.Text = openFile.FileName;
            }
        }

        private void btnCam_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            if(openFile.ShowDialog() == DialogResult.OK)
            {
                picBoxAvatar.Image = new Bitmap(openFile.OpenFile());
            }
        }

        private void btnClearImage_Click(object sender, EventArgs e)
        {
            picBoxAvatar.Image = null;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            List<AuthorDTO> authorDTOs = new List<AuthorDTO>();
            var x = txtBoxAuthor.Text.Split(';');
            DocumentDTO document = new DocumentDTO()
            {
                Title = txtBoxTitle.Text,
                Description = txtBoxDescription.Text,
            };
        }

        private void txtBoxAuthor_KeyPress(object sender, KeyPressEventArgs e)
        {

        }
    }
}
