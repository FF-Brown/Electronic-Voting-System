
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
            this.SuspendLayout();
            // 
            // loginButton
            // 
            this.loginButton.BackColor = System.Drawing.Color.LightSlateGray;
            this.loginButton.CausesValidation = false;
            this.loginButton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.loginButton.FlatAppearance.BorderSize = 5;
            this.loginButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.loginButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.loginButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.loginButton.Location = new System.Drawing.Point(52, 79);
            this.loginButton.Name = "loginButton";
            this.loginButton.Size = new System.Drawing.Size(158, 90);
            this.loginButton.TabIndex = 0;
            this.loginButton.Text = "Login";
            this.loginButton.UseVisualStyleBackColor = false;
            this.loginButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // registerButton
            // 
            this.registerButton.BackColor = System.Drawing.Color.LightSlateGray;
            this.registerButton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.registerButton.FlatAppearance.BorderSize = 5;
            this.registerButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.registerButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.registerButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.registerButton.Location = new System.Drawing.Point(52, 192);
            this.registerButton.Name = "registerButton";
            this.registerButton.Size = new System.Drawing.Size(158, 88);
            this.registerButton.TabIndex = 1;
            this.registerButton.Text = "Register";
            this.registerButton.UseVisualStyleBackColor = false;
            this.registerButton.Click += new System.EventHandler(this.button2_Click);
            // 
            // electionInfoButton
            // 
            this.electionInfoButton.BackColor = System.Drawing.Color.LightSlateGray;
            this.electionInfoButton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.electionInfoButton.FlatAppearance.BorderSize = 5;
            this.electionInfoButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.electionInfoButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.electionInfoButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.electionInfoButton.Location = new System.Drawing.Point(52, 311);
            this.electionInfoButton.Name = "electionInfoButton";
            this.electionInfoButton.Size = new System.Drawing.Size(158, 111);
            this.electionInfoButton.TabIndex = 2;
            this.electionInfoButton.Text = "Election Info";
            this.electionInfoButton.UseVisualStyleBackColor = false;
            this.electionInfoButton.Click += new System.EventHandler(this.button3_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 25.2F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(289, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(235, 51);
            this.label1.TabIndex = 3;
            this.label1.Text = "EMS Menu";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(800, 450);
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
    }
}

