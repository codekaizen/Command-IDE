namespace Command___IDE
{
    partial class CreateProj
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
            this.projName = new System.Windows.Forms.TextBox();
            this.projPath = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.create = new System.Windows.Forms.Button();
            this.cancel = new System.Windows.Forms.Button();
            this.selPath = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Project Name";
            // 
            // projName
            // 
            this.projName.Location = new System.Drawing.Point(12, 25);
            this.projName.Name = "projName";
            this.projName.Size = new System.Drawing.Size(260, 20);
            this.projName.TabIndex = 1;
            // 
            // projPath
            // 
            this.projPath.Location = new System.Drawing.Point(12, 69);
            this.projPath.Name = "projPath";
            this.projPath.Size = new System.Drawing.Size(260, 20);
            this.projPath.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Project Path";
            // 
            // create
            // 
            this.create.Location = new System.Drawing.Point(12, 130);
            this.create.Name = "create";
            this.create.Size = new System.Drawing.Size(121, 23);
            this.create.TabIndex = 4;
            this.create.Text = "Create";
            this.create.UseVisualStyleBackColor = true;
            this.create.Click += new System.EventHandler(this.create_Click);
            // 
            // cancel
            // 
            this.cancel.Location = new System.Drawing.Point(151, 130);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(121, 23);
            this.cancel.TabIndex = 5;
            this.cancel.Text = "Cancel";
            this.cancel.UseVisualStyleBackColor = true;
            this.cancel.Click += new System.EventHandler(this.cancel_Click);
            // 
            // selPath
            // 
            this.selPath.Location = new System.Drawing.Point(186, 97);
            this.selPath.Name = "selPath";
            this.selPath.Size = new System.Drawing.Size(85, 21);
            this.selPath.TabIndex = 6;
            this.selPath.Text = "Select Path...";
            this.selPath.UseVisualStyleBackColor = true;
            this.selPath.Click += new System.EventHandler(this.selPath_Click);
            // 
            // CreateProj
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 166);
            this.Controls.Add(this.selPath);
            this.Controls.Add(this.cancel);
            this.Controls.Add(this.create);
            this.Controls.Add(this.projPath);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.projName);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CreateProj";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "New Project";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox projName;
        private System.Windows.Forms.TextBox projPath;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button create;
        private System.Windows.Forms.Button cancel;
        private System.Windows.Forms.Button selPath;
    }
}