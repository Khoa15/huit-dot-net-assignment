
namespace DigitalDocumentary.GUI
{
    partial class Document
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.cbBoxFilterSearch = new System.Windows.Forms.ComboBox();
            this.txtBoxSearch = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.dataGridViewDocuments = new System.Windows.Forms.DataGridView();
            this.ColSelectRow = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.label2 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.treeViewFolders = new System.Windows.Forms.TreeView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btn_IcTable = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnAsk = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.pnBottom = new System.Windows.Forms.Panel();
            this.button11 = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.btnDelFolder = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnAddDoc = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnDown = new System.Windows.Forms.Button();
            this.btnPeople = new System.Windows.Forms.Button();
            this.pnMain = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDocuments)).BeginInit();
            this.panel5.SuspendLayout();
            this.panel2.SuspendLayout();
            this.pnBottom.SuspendLayout();
            this.pnMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Location = new System.Drawing.Point(13, 13);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1068, 585);
            this.panel1.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Controls.Add(this.panel5);
            this.panel3.Location = new System.Drawing.Point(3, 46);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1062, 536);
            this.panel3.TabIndex = 1;
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel4.Controls.Add(this.cbBoxFilterSearch);
            this.panel4.Controls.Add(this.txtBoxSearch);
            this.panel4.Controls.Add(this.btnSearch);
            this.panel4.Controls.Add(this.dataGridViewDocuments);
            this.panel4.Controls.Add(this.label2);
            this.panel4.Location = new System.Drawing.Point(307, 3);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(752, 530);
            this.panel4.TabIndex = 1;
            // 
            // cbBoxFilterSearch
            // 
            this.cbBoxFilterSearch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbBoxFilterSearch.FormattingEnabled = true;
            this.cbBoxFilterSearch.Location = new System.Drawing.Point(8, 3);
            this.cbBoxFilterSearch.Name = "cbBoxFilterSearch";
            this.cbBoxFilterSearch.Size = new System.Drawing.Size(119, 37);
            this.cbBoxFilterSearch.TabIndex = 1;
            // 
            // txtBoxSearch
            // 
            this.txtBoxSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBoxSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBoxSearch.Font = new System.Drawing.Font("Tahoma", 12F);
            this.txtBoxSearch.Location = new System.Drawing.Point(133, 3);
            this.txtBoxSearch.Name = "txtBoxSearch";
            this.txtBoxSearch.Size = new System.Drawing.Size(530, 36);
            this.txtBoxSearch.TabIndex = 2;
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.BackColor = System.Drawing.Color.SteelBlue;
            this.btnSearch.FlatAppearance.BorderSize = 0;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Image = global::DigitalDocumentary.Properties.Resources.ser;
            this.btnSearch.Location = new System.Drawing.Point(662, 3);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(72, 27);
            this.btnSearch.TabIndex = 3;
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // dataGridViewDocuments
            // 
            this.dataGridViewDocuments.AllowUserToAddRows = false;
            this.dataGridViewDocuments.AllowUserToDeleteRows = false;
            this.dataGridViewDocuments.AllowUserToResizeColumns = false;
            this.dataGridViewDocuments.AllowUserToResizeRows = false;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dataGridViewDocuments.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewDocuments.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewDocuments.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewDocuments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewDocuments.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColSelectRow});
            this.dataGridViewDocuments.Location = new System.Drawing.Point(8, 81);
            this.dataGridViewDocuments.MultiSelect = false;
            this.dataGridViewDocuments.Name = "dataGridViewDocuments";
            this.dataGridViewDocuments.RowHeadersVisible = false;
            this.dataGridViewDocuments.RowHeadersWidth = 62;
            this.dataGridViewDocuments.RowTemplate.Height = 30;
            this.dataGridViewDocuments.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewDocuments.Size = new System.Drawing.Size(726, 398);
            this.dataGridViewDocuments.TabIndex = 3;
            // 
            // ColSelectRow
            // 
            this.ColSelectRow.HeaderText = "Checkbox";
            this.ColSelectRow.MinimumWidth = 8;
            this.ColSelectRow.Name = "ColSelectRow";
            this.ColSelectRow.Width = 150;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.SteelBlue;
            this.label2.Location = new System.Drawing.Point(4, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(327, 29);
            this.label2.TabIndex = 2;
            this.label2.Text = "Tìm được tất cả ... kết quả";
            // 
            // panel5
            // 
            this.panel5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panel5.Controls.Add(this.treeViewFolders);
            this.panel5.Location = new System.Drawing.Point(4, 4);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(297, 529);
            this.panel5.TabIndex = 0;
            // 
            // treeViewFolders
            // 
            this.treeViewFolders.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeViewFolders.Location = new System.Drawing.Point(0, 0);
            this.treeViewFolders.Name = "treeViewFolders";
            this.treeViewFolders.Size = new System.Drawing.Size(297, 529);
            this.treeViewFolders.TabIndex = 0;
            this.treeViewFolders.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeViewFolders_NodeMouseClick);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.SteelBlue;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.btn_IcTable);
            this.panel2.Controls.Add(this.btnExit);
            this.panel2.Controls.Add(this.btnAsk);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1062, 46);
            this.panel2.TabIndex = 0;
            // 
            // btn_IcTable
            // 
            this.btn_IcTable.Image = global::DigitalDocumentary.Properties.Resources.table1;
            this.btn_IcTable.Location = new System.Drawing.Point(12, 6);
            this.btn_IcTable.Name = "btn_IcTable";
            this.btn_IcTable.Size = new System.Drawing.Size(41, 28);
            this.btn_IcTable.TabIndex = 3;
            this.btn_IcTable.UseVisualStyleBackColor = true;
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.Image = global::DigitalDocumentary.Properties.Resources.exit1;
            this.btnExit.Location = new System.Drawing.Point(1011, 6);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(29, 29);
            this.btnExit.TabIndex = 2;
            this.btnExit.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnAsk
            // 
            this.btnAsk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAsk.Image = global::DigitalDocumentary.Properties.Resources.question;
            this.btnAsk.Location = new System.Drawing.Point(977, 6);
            this.btnAsk.Name = "btnAsk";
            this.btnAsk.Size = new System.Drawing.Size(29, 29);
            this.btnAsk.TabIndex = 0;
            this.btnAsk.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(56, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(277, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "QUẢN LÝ TÀI LIỆU SỐ";
            // 
            // pnBottom
            // 
            this.pnBottom.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnBottom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.pnBottom.Controls.Add(this.button11);
            this.pnBottom.Controls.Add(this.button10);
            this.pnBottom.Controls.Add(this.button9);
            this.pnBottom.Controls.Add(this.button8);
            this.pnBottom.Controls.Add(this.button7);
            this.pnBottom.Controls.Add(this.btnDelFolder);
            this.pnBottom.Controls.Add(this.btnEdit);
            this.pnBottom.Controls.Add(this.btnAddDoc);
            this.pnBottom.Controls.Add(this.button1);
            this.pnBottom.Controls.Add(this.button2);
            this.pnBottom.Controls.Add(this.button3);
            this.pnBottom.Location = new System.Drawing.Point(1, 544);
            this.pnBottom.Name = "pnBottom";
            this.pnBottom.Size = new System.Drawing.Size(1093, 69);
            this.pnBottom.TabIndex = 4;
            // 
            // button11
            // 
            this.button11.Image = global::DigitalDocumentary.Properties.Resources.block;
            this.button11.Location = new System.Drawing.Point(771, 9);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(58, 42);
            this.button11.TabIndex = 11;
            this.button11.UseVisualStyleBackColor = true;
            // 
            // button10
            // 
            this.button10.Image = global::DigitalDocumentary.Properties.Resources.tick;
            this.button10.Location = new System.Drawing.Point(697, 9);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(58, 42);
            this.button10.TabIndex = 10;
            this.button10.UseVisualStyleBackColor = true;
            // 
            // button9
            // 
            this.button9.Image = global::DigitalDocumentary.Properties.Resources.share;
            this.button9.Location = new System.Drawing.Point(620, 9);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(58, 42);
            this.button9.TabIndex = 9;
            this.button9.UseVisualStyleBackColor = true;
            // 
            // button8
            // 
            this.button8.Image = global::DigitalDocumentary.Properties.Resources.up1;
            this.button8.Location = new System.Drawing.Point(393, 9);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(58, 42);
            this.button8.TabIndex = 8;
            this.button8.UseVisualStyleBackColor = true;
            // 
            // button7
            // 
            this.button7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.button7.Image = global::DigitalDocumentary.Properties.Resources.del;
            this.button7.Location = new System.Drawing.Point(241, 9);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(58, 42);
            this.button7.TabIndex = 7;
            this.button7.UseVisualStyleBackColor = false;
            // 
            // btnDelFolder
            // 
            this.btnDelFolder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnDelFolder.Image = global::DigitalDocumentary.Properties.Resources.del;
            this.btnDelFolder.Location = new System.Drawing.Point(164, 9);
            this.btnDelFolder.Name = "btnDelFolder";
            this.btnDelFolder.Size = new System.Drawing.Size(58, 42);
            this.btnDelFolder.TabIndex = 6;
            this.btnDelFolder.UseVisualStyleBackColor = false;
            this.btnDelFolder.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnEdit.Image = global::DigitalDocumentary.Properties.Resources.Sua;
            this.btnEdit.Location = new System.Drawing.Point(88, 9);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(58, 42);
            this.btnEdit.TabIndex = 5;
            this.btnEdit.UseVisualStyleBackColor = false;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnAddDoc
            // 
            this.btnAddDoc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnAddDoc.Image = global::DigitalDocumentary.Properties.Resources.add;
            this.btnAddDoc.Location = new System.Drawing.Point(317, 9);
            this.btnAddDoc.Name = "btnAddDoc";
            this.btnAddDoc.Size = new System.Drawing.Size(58, 42);
            this.btnAddDoc.TabIndex = 4;
            this.btnAddDoc.UseVisualStyleBackColor = false;
            this.btnAddDoc.Click += new System.EventHandler(this.btnAddDoc_Click);
            // 
            // button1
            // 
            this.button1.Image = global::DigitalDocumentary.Properties.Resources.people;
            this.button1.Location = new System.Drawing.Point(545, 9);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(58, 42);
            this.button1.TabIndex = 3;
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Image = global::DigitalDocumentary.Properties.Resources.down;
            this.button2.Location = new System.Drawing.Point(469, 9);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(58, 42);
            this.button2.TabIndex = 2;
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.button3.Image = global::DigitalDocumentary.Properties.Resources.add;
            this.button3.Location = new System.Drawing.Point(12, 9);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(58, 42);
            this.button3.TabIndex = 1;
            this.button3.UseVisualStyleBackColor = false;
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnAdd.Image = global::DigitalDocumentary.Properties.Resources.add;
            this.btnAdd.Location = new System.Drawing.Point(12, 9);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(58, 42);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnDown
            // 
            this.btnDown.Image = global::DigitalDocumentary.Properties.Resources.down;
            this.btnDown.Location = new System.Drawing.Point(89, 9);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(58, 42);
            this.btnDown.TabIndex = 2;
            this.btnDown.UseVisualStyleBackColor = true;
            // 
            // btnPeople
            // 
            this.btnPeople.Image = global::DigitalDocumentary.Properties.Resources.people;
            this.btnPeople.Location = new System.Drawing.Point(164, 9);
            this.btnPeople.Name = "btnPeople";
            this.btnPeople.Size = new System.Drawing.Size(58, 42);
            this.btnPeople.TabIndex = 3;
            this.btnPeople.UseVisualStyleBackColor = true;
            // 
            // pnMain
            // 
            this.pnMain.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.pnMain.Controls.Add(this.btnPeople);
            this.pnMain.Controls.Add(this.btnDown);
            this.pnMain.Controls.Add(this.btnAdd);
            this.pnMain.Location = new System.Drawing.Point(1, 547);
            this.pnMain.Name = "pnMain";
            this.pnMain.Size = new System.Drawing.Size(1093, 69);
            this.pnMain.TabIndex = 1;
            // 
            // Document
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(1093, 610);
            this.Controls.Add(this.pnBottom);
            this.Controls.Add(this.pnMain);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Document";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PHÂN HỆ TÀI LIỆU SỐ";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.QL_TaiLieuSo_FormClosing);
            this.Load += new System.EventHandler(this.QL_TaiLieuSo_Load);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDocuments)).EndInit();
            this.panel5.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.pnBottom.ResumeLayout(false);
            this.pnMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.TreeView treeViewFolders;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.DataGridView dataGridViewDocuments;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnAsk;
        private System.Windows.Forms.Button btn_IcTable;
        private System.Windows.Forms.Panel pnBottom;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnAddDoc;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button btnDelFolder;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.ComboBox cbBoxFilterSearch;
        private System.Windows.Forms.TextBox txtBoxSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnDown;
        private System.Windows.Forms.Button btnPeople;
        private System.Windows.Forms.Panel pnMain;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColSelectRow;
    }
}