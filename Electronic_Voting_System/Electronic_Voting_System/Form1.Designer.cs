
namespace Electronic_Voting_System
{
    partial class Form1
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
            this.loginButton = new System.Windows.Forms.Button();
            this.registerButton = new System.Windows.Forms.Button();
            this.electionInfoButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.VoteButton = new System.Windows.Forms.Button();
            this.adminPortalButton = new System.Windows.Forms.Button();
            this.logoutButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(Form1_FormClosing);
            
            // 
            // loginButton
            // 
            this.loginButton.BackColor = System.Drawing.Color.LightSlateGray;
            this.loginButton.CausesValidation = false;
            this.loginButton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.loginButton.FlatAppearance.BorderSize = 2;
            this.loginButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.loginButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loginButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.loginButton.Location = new System.Drawing.Point(608, 110);
            this.loginButton.Name = "loginButton";
            this.loginButton.Size = new System.Drawing.Size(142, 57);
            this.loginButton.TabIndex = 0;
            this.loginButton.Text = "Login";
            this.loginButton.UseVisualStyleBackColor = false;
            this.loginButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // registerButton
            // 
            this.registerButton.BackColor = System.Drawing.Color.LightSlateGray;
            this.registerButton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.registerButton.FlatAppearance.BorderSize = 2;
            this.registerButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.registerButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.registerButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.registerButton.Location = new System.Drawing.Point(608, 179);
            this.registerButton.Name = "registerButton";
            this.registerButton.Size = new System.Drawing.Size(142, 61);
            this.registerButton.TabIndex = 1;
            this.registerButton.Text = "Register";
            this.registerButton.UseVisualStyleBackColor = false;
            this.registerButton.Click += new System.EventHandler(this.button2_Click);
            // 
            // electionInfoButton
            // 
            this.electionInfoButton.BackColor = System.Drawing.Color.LightSlateGray;
            this.electionInfoButton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.electionInfoButton.FlatAppearance.BorderSize = 2;
            this.electionInfoButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.electionInfoButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.electionInfoButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.electionInfoButton.Location = new System.Drawing.Point(35, 223);
            this.electionInfoButton.Name = "electionInfoButton";
            this.electionInfoButton.Size = new System.Drawing.Size(413, 93);
            this.electionInfoButton.TabIndex = 2;
            this.electionInfoButton.Text = "Election Info";
            this.electionInfoButton.UseVisualStyleBackColor = false;
            this.electionInfoButton.Click += new System.EventHandler(this.button3_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("Yu Gothic UI Light", 25.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(25, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(467, 59);
            this.label1.TabIndex = 3;
            this.label1.Text = "Electronic Voting System";
            // 
            // VoteButton
            // 
            this.VoteButton.BackColor = System.Drawing.Color.LightSlateGray;
            this.VoteButton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.VoteButton.FlatAppearance.BorderSize = 2;
            this.VoteButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.VoteButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.VoteButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.VoteButton.Location = new System.Drawing.Point(34, 342);
            this.VoteButton.Name = "VoteButton";
            this.VoteButton.Size = new System.Drawing.Size(413, 87);
            this.VoteButton.TabIndex = 4;
            this.VoteButton.Text = "Vote";
            this.VoteButton.UseVisualStyleBackColor = false;
            this.VoteButton.Click += new System.EventHandler(this.VoteButton_Click);
            // 
            // adminPortalButton
            // 
            this.adminPortalButton.BackColor = System.Drawing.Color.LightSlateGray;
            this.adminPortalButton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.adminPortalButton.FlatAppearance.BorderSize = 2;
            this.adminPortalButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.adminPortalButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.adminPortalButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.adminPortalButton.Location = new System.Drawing.Point(35, 110);
            this.adminPortalButton.Name = "adminPortalButton";
            this.adminPortalButton.Size = new System.Drawing.Size(413, 87);
            this.adminPortalButton.TabIndex = 5;
            this.adminPortalButton.Text = "Admin Portal";
            this.adminPortalButton.UseVisualStyleBackColor = false;
            this.adminPortalButton.Click += new System.EventHandler(this.adminPortalButton_Click);
            // 
            // logoutButton
            // 
            this.logoutButton.BackColor = System.Drawing.Color.LightSlateGray;
            this.logoutButton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.logoutButton.FlatAppearance.BorderSize = 2;
            this.logoutButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.logoutButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.logoutButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.logoutButton.Location = new System.Drawing.Point(608, 359);
            this.logoutButton.Name = "logoutButton";
            this.logoutButton.Size = new System.Drawing.Size(142, 53);
            this.logoutButton.TabIndex = 6;
            this.logoutButton.Text = "Logout";
            this.logoutButton.UseVisualStyleBackColor = false;
            this.logoutButton.Click += new System.EventHandler(this.logoutButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label2.Location = new System.Drawing.Point(603, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 25);
            this.label2.TabIndex = 7;
            this.label2.Text = "Hi, ";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.logoutButton);
            this.Controls.Add(this.adminPortalButton);
            this.Controls.Add(this.VoteButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.electionInfoButton);
            this.Controls.Add(this.registerButton);
            this.Controls.Add(this.loginButton);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button loginButton;
        private System.Windows.Forms.Button registerButton;
        private System.Windows.Forms.Button electionInfoButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button VoteButton;
        private System.Windows.Forms.Button adminPortalButton;
        private System.Windows.Forms.Button logoutButton;
        private System.Windows.Forms.Label label2;
    }
}

