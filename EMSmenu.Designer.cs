namespace WindowsFormsApplication1
{
    partial class EMSmenu
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
            this.GoToRegister = new System.Windows.Forms.Button();
            this.GoToLogin = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // GoToRegister
            // 
            this.GoToRegister.Location = new System.Drawing.Point(127, 64);
            this.GoToRegister.Name = "GoToRegister";
            this.GoToRegister.Size = new System.Drawing.Size(139, 67);
            this.GoToRegister.TabIndex = 0;
            this.GoToRegister.Text = "Go To Register menu";
            this.GoToRegister.UseVisualStyleBackColor = true;
            this.GoToRegister.Click += new System.EventHandler(this.GoToRegister_Click);
            // 
            // GoToLogin
            // 
            this.GoToLogin.Location = new System.Drawing.Point(127, 177);
            this.GoToLogin.Name = "GoToLogin";
            this.GoToLogin.Size = new System.Drawing.Size(139, 66);
            this.GoToLogin.TabIndex = 1;
            this.GoToLogin.Text = "Go To Login Menu";
            this.GoToLogin.UseVisualStyleBackColor = true;
            this.GoToLogin.Click += new System.EventHandler(this.GoToLogin_Click);
            // 
            // EMSmenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(405, 315);
            this.Controls.Add(this.GoToLogin);
            this.Controls.Add(this.GoToRegister);
            this.Name = "EMSmenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EMSmenu";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button GoToRegister;
        private System.Windows.Forms.Button GoToLogin;
    }
}