namespace sysinfo
{
    partial class main
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
            this.buttonUpload = new System.Windows.Forms.Button();
            outputStatus = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // buttonUpload
            // 
            this.buttonUpload.Location = new System.Drawing.Point(12, 12);
            this.buttonUpload.Name = "buttonUpload";
            this.buttonUpload.Size = new System.Drawing.Size(75, 23);
            this.buttonUpload.TabIndex = 0;
            this.buttonUpload.Text = "Upload";
            this.buttonUpload.UseVisualStyleBackColor = true;
            this.buttonUpload.Click += new System.EventHandler(this.buttonUpload_Click);
            // 
            // outputStatus
            // 
            outputStatus.HideSelection = false;
            outputStatus.Location = new System.Drawing.Point(109, 15);
            outputStatus.Multiline = true;
            outputStatus.Name = "outputStatus";
            outputStatus.Size = new System.Drawing.Size(270, 221);
            outputStatus.TabIndex = 1;
            outputStatus.Text = "Status:";
            outputStatus.ReadOnly = true;

            //this.outputStatus.HideSelection = false;
            //this.outputStatus.Location = new System.Drawing.Point(109, 15);
            //this.outputStatus.Multiline = true;
            //this.outputStatus.Name = "outputStatus";
            //this.outputStatus.ReadOnly = true;
            //this.outputStatus.Size = new System.Drawing.Size(270, 221);
            //this.outputStatus.TabIndex = 1;
            //this.outputStatus.Text = "Status:";
            // 
            // main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(391, 248);
            this.Controls.Add(outputStatus);
            this.Controls.Add(this.buttonUpload);
            this.Name = "main";
            this.Text = "SysInfo 0.1.1b";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonUpload;
        private static System.Windows.Forms.TextBox outputStatus;

    }
}

