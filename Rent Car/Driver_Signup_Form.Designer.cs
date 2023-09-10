
namespace Rent_Car
{
    partial class Driver_Signup_Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Driver_Signup_Form));
            this.panel_Login = new System.Windows.Forms.Panel();
            this.dtp_birthday = new Bunifu.Framework.UI.BunifuDatepicker();
            this.txt_phoneNum = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.txt_email = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.txt_password = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.txt_username = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.btn_register = new Bunifu.Framework.UI.BunifuThinButton2();
            this.btn_back = new Bunifu.Framework.UI.BunifuThinButton2();
            this.lbl_clear2 = new System.Windows.Forms.Label();
            this.lbl_clear1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.panel_Login.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel_Login
            // 
            this.panel_Login.BackColor = System.Drawing.Color.White;
            this.panel_Login.Controls.Add(this.dtp_birthday);
            this.panel_Login.Controls.Add(this.txt_phoneNum);
            this.panel_Login.Controls.Add(this.txt_email);
            this.panel_Login.Controls.Add(this.txt_password);
            this.panel_Login.Controls.Add(this.txt_username);
            this.panel_Login.Controls.Add(this.btn_register);
            this.panel_Login.Controls.Add(this.btn_back);
            this.panel_Login.Controls.Add(this.lbl_clear2);
            this.panel_Login.Controls.Add(this.lbl_clear1);
            this.panel_Login.Controls.Add(this.label6);
            this.panel_Login.Controls.Add(this.label2);
            this.panel_Login.Controls.Add(this.label5);
            this.panel_Login.Controls.Add(this.label4);
            this.panel_Login.Controls.Add(this.label3);
            this.panel_Login.Controls.Add(this.label1);
            this.panel_Login.Location = new System.Drawing.Point(47, 28);
            this.panel_Login.Name = "panel_Login";
            this.panel_Login.Size = new System.Drawing.Size(627, 729);
            this.panel_Login.TabIndex = 11;
            // 
            // dtp_birthday
            // 
            this.dtp_birthday.BackColor = System.Drawing.Color.Black;
            this.dtp_birthday.BorderRadius = 0;
            this.dtp_birthday.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtp_birthday.ForeColor = System.Drawing.Color.White;
            this.dtp_birthday.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_birthday.FormatCustom = null;
            this.dtp_birthday.Location = new System.Drawing.Point(183, 501);
            this.dtp_birthday.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dtp_birthday.Name = "dtp_birthday";
            this.dtp_birthday.Size = new System.Drawing.Size(208, 27);
            this.dtp_birthday.TabIndex = 37;
            this.dtp_birthday.Value = new System.DateTime(2022, 1, 7, 0, 0, 0, 0);
            // 
            // txt_phoneNum
            // 
            this.txt_phoneNum.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_phoneNum.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_phoneNum.ForeColor = System.Drawing.Color.Gray;
            this.txt_phoneNum.HintForeColor = System.Drawing.Color.Empty;
            this.txt_phoneNum.HintText = "";
            this.txt_phoneNum.isPassword = false;
            this.txt_phoneNum.LineFocusedColor = System.Drawing.Color.DarkOrange;
            this.txt_phoneNum.LineIdleColor = System.Drawing.Color.Gray;
            this.txt_phoneNum.LineMouseHoverColor = System.Drawing.Color.DarkOrange;
            this.txt_phoneNum.LineThickness = 5;
            this.txt_phoneNum.Location = new System.Drawing.Point(183, 423);
            this.txt_phoneNum.Margin = new System.Windows.Forms.Padding(4);
            this.txt_phoneNum.Name = "txt_phoneNum";
            this.txt_phoneNum.Size = new System.Drawing.Size(291, 39);
            this.txt_phoneNum.TabIndex = 36;
            this.txt_phoneNum.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // txt_email
            // 
            this.txt_email.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_email.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_email.ForeColor = System.Drawing.Color.Gray;
            this.txt_email.HintForeColor = System.Drawing.Color.Empty;
            this.txt_email.HintText = "";
            this.txt_email.isPassword = false;
            this.txt_email.LineFocusedColor = System.Drawing.Color.DarkOrange;
            this.txt_email.LineIdleColor = System.Drawing.Color.Gray;
            this.txt_email.LineMouseHoverColor = System.Drawing.Color.DarkOrange;
            this.txt_email.LineThickness = 5;
            this.txt_email.Location = new System.Drawing.Point(183, 353);
            this.txt_email.Margin = new System.Windows.Forms.Padding(4);
            this.txt_email.Name = "txt_email";
            this.txt_email.Size = new System.Drawing.Size(291, 39);
            this.txt_email.TabIndex = 36;
            this.txt_email.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // txt_password
            // 
            this.txt_password.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_password.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_password.ForeColor = System.Drawing.Color.Gray;
            this.txt_password.HintForeColor = System.Drawing.Color.Empty;
            this.txt_password.HintText = "";
            this.txt_password.isPassword = false;
            this.txt_password.LineFocusedColor = System.Drawing.Color.DarkOrange;
            this.txt_password.LineIdleColor = System.Drawing.Color.Gray;
            this.txt_password.LineMouseHoverColor = System.Drawing.Color.DarkOrange;
            this.txt_password.LineThickness = 5;
            this.txt_password.Location = new System.Drawing.Point(183, 236);
            this.txt_password.Margin = new System.Windows.Forms.Padding(4);
            this.txt_password.Name = "txt_password";
            this.txt_password.Size = new System.Drawing.Size(291, 39);
            this.txt_password.TabIndex = 36;
            this.txt_password.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // txt_username
            // 
            this.txt_username.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_username.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_username.ForeColor = System.Drawing.Color.Gray;
            this.txt_username.HintForeColor = System.Drawing.Color.Empty;
            this.txt_username.HintText = "";
            this.txt_username.isPassword = false;
            this.txt_username.LineFocusedColor = System.Drawing.Color.DarkOrange;
            this.txt_username.LineIdleColor = System.Drawing.Color.Gray;
            this.txt_username.LineMouseHoverColor = System.Drawing.Color.DarkOrange;
            this.txt_username.LineThickness = 5;
            this.txt_username.Location = new System.Drawing.Point(183, 166);
            this.txt_username.Margin = new System.Windows.Forms.Padding(4);
            this.txt_username.Name = "txt_username";
            this.txt_username.Size = new System.Drawing.Size(291, 39);
            this.txt_username.TabIndex = 36;
            this.txt_username.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // btn_register
            // 
            this.btn_register.ActiveBorderThickness = 1;
            this.btn_register.ActiveCornerRadius = 20;
            this.btn_register.ActiveFillColor = System.Drawing.Color.SeaGreen;
            this.btn_register.ActiveForecolor = System.Drawing.Color.White;
            this.btn_register.ActiveLineColor = System.Drawing.Color.SeaGreen;
            this.btn_register.BackColor = System.Drawing.Color.White;
            this.btn_register.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_register.BackgroundImage")));
            this.btn_register.ButtonText = "REGISTER";
            this.btn_register.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_register.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_register.ForeColor = System.Drawing.Color.SeaGreen;
            this.btn_register.IdleBorderThickness = 5;
            this.btn_register.IdleCornerRadius = 20;
            this.btn_register.IdleFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btn_register.IdleForecolor = System.Drawing.Color.OrangeRed;
            this.btn_register.IdleLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btn_register.Location = new System.Drawing.Point(210, 588);
            this.btn_register.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btn_register.Name = "btn_register";
            this.btn_register.Size = new System.Drawing.Size(222, 57);
            this.btn_register.TabIndex = 35;
            this.btn_register.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btn_register.Click += new System.EventHandler(this.btn_register_Click);
            // 
            // btn_back
            // 
            this.btn_back.ActiveBorderThickness = 1;
            this.btn_back.ActiveCornerRadius = 20;
            this.btn_back.ActiveFillColor = System.Drawing.Color.SeaGreen;
            this.btn_back.ActiveForecolor = System.Drawing.Color.White;
            this.btn_back.ActiveLineColor = System.Drawing.Color.SeaGreen;
            this.btn_back.BackColor = System.Drawing.Color.White;
            this.btn_back.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_back.BackgroundImage")));
            this.btn_back.ButtonText = "BACK";
            this.btn_back.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_back.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_back.ForeColor = System.Drawing.Color.SeaGreen;
            this.btn_back.IdleBorderThickness = 5;
            this.btn_back.IdleCornerRadius = 20;
            this.btn_back.IdleFillColor = System.Drawing.Color.Transparent;
            this.btn_back.IdleForecolor = System.Drawing.Color.OrangeRed;
            this.btn_back.IdleLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btn_back.Location = new System.Drawing.Point(210, 650);
            this.btn_back.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btn_back.Name = "btn_back";
            this.btn_back.Size = new System.Drawing.Size(222, 57);
            this.btn_back.TabIndex = 33;
            this.btn_back.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btn_back.Click += new System.EventHandler(this.btn_back_Click);
            // 
            // lbl_clear2
            // 
            this.lbl_clear2.AutoSize = true;
            this.lbl_clear2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_clear2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.lbl_clear2.Location = new System.Drawing.Point(518, 516);
            this.lbl_clear2.Name = "lbl_clear2";
            this.lbl_clear2.Size = new System.Drawing.Size(54, 24);
            this.lbl_clear2.TabIndex = 32;
            this.lbl_clear2.Text = "Clear";
            this.lbl_clear2.Click += new System.EventHandler(this.lbl_clear2_Click);
            // 
            // lbl_clear1
            // 
            this.lbl_clear1.AutoSize = true;
            this.lbl_clear1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_clear1.ForeColor = System.Drawing.Color.Gray;
            this.lbl_clear1.Location = new System.Drawing.Point(518, 251);
            this.lbl_clear1.Name = "lbl_clear1";
            this.lbl_clear1.Size = new System.Drawing.Size(54, 24);
            this.lbl_clear1.TabIndex = 31;
            this.lbl_clear1.Text = "Clear";
            this.lbl_clear1.Click += new System.EventHandler(this.lbl_clear1_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.LimeGreen;
            this.label6.Location = new System.Drawing.Point(26, 504);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(87, 24);
            this.label6.TabIndex = 30;
            this.label6.Text = "BirthDay";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.LimeGreen;
            this.label2.Location = new System.Drawing.Point(26, 368);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 24);
            this.label2.TabIndex = 27;
            this.label2.Text = "Email";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.LimeGreen;
            this.label5.Location = new System.Drawing.Point(26, 438);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(152, 24);
            this.label5.TabIndex = 28;
            this.label5.Text = "Phone Number";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(54, 181);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(125, 24);
            this.label4.TabIndex = 24;
            this.label4.Text = "USERNAME";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(54, 251);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(126, 24);
            this.label3.TabIndex = 25;
            this.label3.Text = "PASSWORD";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MV Boli", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(216, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(216, 63);
            this.label1.TabIndex = 21;
            this.label1.Text = "Register";
            // 
            // Driver_Signup_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(721, 788);
            this.Controls.Add(this.panel_Login);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Driver_Signup_Form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Driver_Signup_Form";
            this.Load += new System.EventHandler(this.Driver_Signup_Form_Load);
            this.panel_Login.ResumeLayout(false);
            this.panel_Login.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel_Login;
        private Bunifu.Framework.UI.BunifuThinButton2 btn_register;
        private Bunifu.Framework.UI.BunifuThinButton2 btn_back;
        private System.Windows.Forms.Label lbl_clear2;
        private System.Windows.Forms.Label lbl_clear1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private Bunifu.Framework.UI.BunifuMaterialTextbox txt_phoneNum;
        private Bunifu.Framework.UI.BunifuMaterialTextbox txt_email;
        private Bunifu.Framework.UI.BunifuMaterialTextbox txt_password;
        private Bunifu.Framework.UI.BunifuMaterialTextbox txt_username;
        private Bunifu.Framework.UI.BunifuDatepicker dtp_birthday;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}