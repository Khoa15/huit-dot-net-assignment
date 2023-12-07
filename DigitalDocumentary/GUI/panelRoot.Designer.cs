namespace DigitalDocumentary.GUI
{
    partial class panelRoot
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnMain = new System.Windows.Forms.Panel();
            this.btnPeople = new System.Windows.Forms.Button();
            this.btnDown = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.pnMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnMain
            // 
            this.pnMain.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pnMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.pnMain.Controls.Add(this.btnPeople);
            this.pnMain.Controls.Add(this.btnDown);
            this.pnMain.Controls.Add(this.btnAdd);
            this.pnMain.Location = new System.Drawing.Point(-5, 2);
            this.pnMain.Name = "pnMain";
            this.pnMain.Size = new System.Drawing.Size(997, 69);
            this.pnMain.TabIndex = 2;
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
            // btnDown
            // 
            this.btnDown.Image = global::DigitalDocumentary.Properties.Resources.down;
            this.btnDown.Location = new System.Drawing.Point(89, 9);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(58, 42);
            this.btnDown.TabIndex = 2;
            this.btnDown.UseVisualStyleBackColor = true;
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
            // 
            // panelRoot
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.pnMain);
            this.Name = "panelRoot";
            this.Size = new System.Drawing.Size(1001, 74);
            this.pnMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnMain;
        private System.Windows.Forms.Button btnPeople;
        private System.Windows.Forms.Button btnDown;
        private System.Windows.Forms.Button btnAdd;
    }
}
