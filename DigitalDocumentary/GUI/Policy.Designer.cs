namespace DigitalDocumentary.GUI
{
    partial class Policy
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
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridViewDocPolicy = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btn_IcTable = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnAsk = new System.Windows.Forms.Button();
            this.btnAddPolicy = new System.Windows.Forms.Button();
            this.pnBottom = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDocPolicy)).BeginInit();
            this.panel2.SuspendLayout();
            this.pnBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(56, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(197, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "BIÊN TẬP CHÍNH SÁCH";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Location = new System.Drawing.Point(12, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1068, 585);
            this.panel1.TabIndex = 7;
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.dataGridViewDocPolicy);
            this.panel3.Location = new System.Drawing.Point(3, 46);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1062, 536);
            this.panel3.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(33, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Áp dụng cho tài liệu số";
            // 
            // dataGridViewDocPolicy
            // 
            this.dataGridViewDocPolicy.AllowUserToAddRows = false;
            this.dataGridViewDocPolicy.AllowUserToDeleteRows = false;
            this.dataGridViewDocPolicy.AllowUserToResizeColumns = false;
            this.dataGridViewDocPolicy.AllowUserToResizeRows = false;
            this.dataGridViewDocPolicy.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewDocPolicy.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewDocPolicy.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dataGridViewDocPolicy.Location = new System.Drawing.Point(36, 51);
            this.dataGridViewDocPolicy.MultiSelect = false;
            this.dataGridViewDocPolicy.Name = "dataGridViewDocPolicy";
            this.dataGridViewDocPolicy.RowHeadersWidth = 62;
            this.dataGridViewDocPolicy.Size = new System.Drawing.Size(971, 472);
            this.dataGridViewDocPolicy.TabIndex = 0;
            this.dataGridViewDocPolicy.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewDocPolicy_CellContentClick);
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
            // btnAddPolicy
            // 
            this.btnAddPolicy.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnAddPolicy.Image = global::DigitalDocumentary.Properties.Resources.add;
            this.btnAddPolicy.Location = new System.Drawing.Point(12, 9);
            this.btnAddPolicy.Name = "btnAddPolicy";
            this.btnAddPolicy.Size = new System.Drawing.Size(58, 42);
            this.btnAddPolicy.TabIndex = 1;
            this.btnAddPolicy.UseVisualStyleBackColor = false;
            // 
            // pnBottom
            // 
            this.pnBottom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.pnBottom.Controls.Add(this.btnAddPolicy);
            this.pnBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnBottom.Location = new System.Drawing.Point(0, 541);
            this.pnBottom.Name = "pnBottom";
            this.pnBottom.Size = new System.Drawing.Size(1093, 69);
            this.pnBottom.TabIndex = 8;
            // 
            // Policy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1093, 610);
            this.Controls.Add(this.pnBottom);
            this.Controls.Add(this.panel1);
            this.Name = "Policy";
            this.Text = "Policy";
            this.Load += new System.EventHandler(this.Policy_Load);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDocPolicy)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.pnBottom.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridView dataGridViewDocPolicy;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btn_IcTable;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnAsk;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnAddPolicy;
        private System.Windows.Forms.Panel pnBottom;
    }
}