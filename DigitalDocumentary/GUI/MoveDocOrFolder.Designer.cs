namespace DigitalDocumentary.GUI
{
    partial class MoveDocOrFolder
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
            this.treeViewFolders = new System.Windows.Forms.TreeView();
            this.btnMove = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(154, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Chọn thư mục cần chuyển đến";
            // 
            // treeViewFolders
            // 
            this.treeViewFolders.Location = new System.Drawing.Point(16, 40);
            this.treeViewFolders.Name = "treeViewFolders";
            this.treeViewFolders.Size = new System.Drawing.Size(208, 180);
            this.treeViewFolders.TabIndex = 1;
            // 
            // btnMove
            // 
            this.btnMove.Location = new System.Drawing.Point(149, 226);
            this.btnMove.Name = "btnMove";
            this.btnMove.Size = new System.Drawing.Size(75, 23);
            this.btnMove.TabIndex = 2;
            this.btnMove.Text = "Di chuyển";
            this.btnMove.UseVisualStyleBackColor = true;
            this.btnMove.Click += new System.EventHandler(this.btnMove_Click);
            // 
            // MoveDoc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(236, 256);
            this.Controls.Add(this.btnMove);
            this.Controls.Add(this.treeViewFolders);
            this.Controls.Add(this.label1);
            this.Name = "MoveDoc";
            this.Text = "Di chuyển tài liệu";
            this.Load += new System.EventHandler(this.MoveDoc_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TreeView treeViewFolders;
        private System.Windows.Forms.Button btnMove;
    }
}