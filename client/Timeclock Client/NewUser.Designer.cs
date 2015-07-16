namespace Timeclock_Client
{
    partial class NewUser
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.bSaveNewUser = new DevExpress.XtraEditors.SimpleButton();
            this.tEmail = new DevExpress.XtraEditors.TextEdit();
            this.tPassword = new DevExpress.XtraEditors.TextEdit();
            this.tPassword2 = new DevExpress.XtraEditors.TextEdit();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.rNewUser = new DevExpress.XtraEditors.CheckEdit();
            this.rExistingUser = new DevExpress.XtraEditors.CheckEdit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tEmail.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tPassword.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tPassword2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rNewUser.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rExistingUser.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Timeclock_Client.Properties.Resources._1435311804_user_id;
            this.pictureBox1.Location = new System.Drawing.Point(2, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(106, 92);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.bSaveNewUser);
            this.panel1.Controls.Add(this.tEmail);
            this.panel1.Controls.Add(this.tPassword);
            this.panel1.Controls.Add(this.tPassword2);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(2, 41);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(435, 231);
            this.panel1.TabIndex = 13;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(94, 181);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(46, 18);
            this.label6.TabIndex = 19;
            this.label6.Text = "label6";
            this.label6.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(7, 181);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(86, 18);
            this.label5.TabIndex = 18;
            this.label5.Text = "Organisation";
            this.label5.Visible = false;
            // 
            // bSaveNewUser
            // 
            this.bSaveNewUser.Appearance.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bSaveNewUser.Appearance.Options.UseFont = true;
            this.bSaveNewUser.Location = new System.Drawing.Point(332, 190);
            this.bSaveNewUser.Name = "bSaveNewUser";
            this.bSaveNewUser.Size = new System.Drawing.Size(96, 35);
            this.bSaveNewUser.TabIndex = 17;
            this.bSaveNewUser.Text = "Get Started";
            this.bSaveNewUser.Click += new System.EventHandler(this.bSaveNewUser_Click);
            // 
            // tEmail
            // 
            this.tEmail.Location = new System.Drawing.Point(112, 55);
            this.tEmail.Name = "tEmail";
            this.tEmail.Properties.Appearance.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tEmail.Properties.Appearance.Options.UseFont = true;
            this.tEmail.Size = new System.Drawing.Size(316, 30);
            this.tEmail.TabIndex = 1;
            // 
            // tPassword
            // 
            this.tPassword.Location = new System.Drawing.Point(112, 92);
            this.tPassword.Name = "tPassword";
            this.tPassword.Properties.Appearance.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tPassword.Properties.Appearance.Options.UseFont = true;
            this.tPassword.Properties.PasswordChar = '•';
            this.tPassword.Size = new System.Drawing.Size(316, 30);
            this.tPassword.TabIndex = 2;
            // 
            // tPassword2
            // 
            this.tPassword2.Location = new System.Drawing.Point(112, 129);
            this.tPassword2.Name = "tPassword2";
            this.tPassword2.Properties.Appearance.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tPassword2.Properties.Appearance.Options.UseFont = true;
            this.tPassword2.Properties.PasswordChar = '•';
            this.tPassword2.Size = new System.Drawing.Size(316, 30);
            this.tPassword2.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(7, 136);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 18);
            this.label4.TabIndex = 13;
            this.label4.Text = "Confirm:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(7, 99);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 18);
            this.label3.TabIndex = 12;
            this.label3.Text = "Password:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(7, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 18);
            this.label2.TabIndex = 11;
            this.label2.Text = "Email Address:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(105, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(181, 39);
            this.label1.TabIndex = 10;
            this.label1.Text = "Hi new user!";
            // 
            // rNewUser
            // 
            this.rNewUser.EditValue = true;
            this.rNewUser.Location = new System.Drawing.Point(278, 12);
            this.rNewUser.Name = "rNewUser";
            this.rNewUser.Properties.Caption = "New User";
            this.rNewUser.Properties.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.Radio;
            this.rNewUser.Properties.RadioGroupIndex = 1;
            this.rNewUser.Size = new System.Drawing.Size(75, 19);
            this.rNewUser.TabIndex = 14;
            this.rNewUser.CheckedChanged += new System.EventHandler(this.rNewUser_CheckedChanged);
            // 
            // rExistingUser
            // 
            this.rExistingUser.Location = new System.Drawing.Point(360, 12);
            this.rExistingUser.Name = "rExistingUser";
            this.rExistingUser.Properties.Caption = "Existing User";
            this.rExistingUser.Properties.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.Radio;
            this.rExistingUser.Properties.RadioGroupIndex = 1;
            this.rExistingUser.Size = new System.Drawing.Size(79, 19);
            this.rExistingUser.TabIndex = 15;
            this.rExistingUser.CheckedChanged += new System.EventHandler(this.rExistingUser_CheckedChanged);
            // 
            // NewUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(449, 284);
            this.Controls.Add(this.rExistingUser);
            this.Controls.Add(this.rNewUser);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.panel1);
            this.LookAndFeel.SkinName = "Visual Studio 2013 Light";
            this.LookAndFeel.UseDefaultLookAndFeel = false;
            this.Name = "NewUser";
            this.Text = "Create User";
            this.Load += new System.EventHandler(this.NewUser_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tEmail.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tPassword.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tPassword2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rNewUser.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rExistingUser.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private DevExpress.XtraEditors.SimpleButton bSaveNewUser;
        private DevExpress.XtraEditors.TextEdit tEmail;
        private DevExpress.XtraEditors.TextEdit tPassword;
        private DevExpress.XtraEditors.TextEdit tPassword2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.CheckEdit rNewUser;
        private DevExpress.XtraEditors.CheckEdit rExistingUser;
    }
}