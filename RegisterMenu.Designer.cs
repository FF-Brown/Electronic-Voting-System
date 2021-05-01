namespace WindowsFormsApplication1
{
    partial class RegisterMenu
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
            this.LeaveButtonR = new System.Windows.Forms.Button();
            this.RegisterButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // LeaveButtonR
            // 
            this.LeaveButtonR.Location = new System.Drawing.Point(119, 47);
            this.LeaveButtonR.Name = "LeaveButtonR";
            this.LeaveButtonR.Size = new System.Drawing.Size(145, 56);
            this.LeaveButtonR.TabIndex = 0;
            this.LeaveButtonR.Text = "Go To EMS Menu";
            this.LeaveButtonR.UseVisualStyleBackColor = true;
            this.LeaveButtonR.Click += new System.EventHandler(this.LeaveButtonR_Click);
            // 
            // RegisterButton
            // 
            this.RegisterButton.Location = new System.Drawing.Point(119, 163);
            this.RegisterButton.Name = "RegisterButton";
            this.RegisterButton.Size = new System.Drawing.Size(145, 59);
            this.RegisterButton.TabIndex = 1;
            this.RegisterButton.Text = "Register";
            this.RegisterButton.UseVisualStyleBackColor = true;
            this.RegisterButton.Click += new System.EventHandler(this.RegisterButton_Click);
            // 
            // RegisterMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(397, 331);
            this.Controls.Add(this.RegisterButton);
            this.Controls.Add(this.LeaveButtonR);
            this.Name = "RegisterMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Register Menu";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button LeaveButtonR;
        private System.Windows.Forms.Button RegisterButton;
    }
}