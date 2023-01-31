namespace PlanetScale_DB
{
    partial class Registracija
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
            this.tbx_ime = new System.Windows.Forms.TextBox();
            this.tbx_priimek = new System.Windows.Forms.TextBox();
            this.tbx_uporabnisko = new System.Windows.Forms.TextBox();
            this.tbx_geslo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tbx_email = new System.Windows.Forms.TextBox();
            this.btn_registracija = new System.Windows.Forms.Button();
            this.lbl_status_update = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(93, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ime";
            // 
            // tbx_ime
            // 
            this.tbx_ime.Location = new System.Drawing.Point(131, 12);
            this.tbx_ime.Name = "tbx_ime";
            this.tbx_ime.Size = new System.Drawing.Size(270, 26);
            this.tbx_ime.TabIndex = 1;
            // 
            // tbx_priimek
            // 
            this.tbx_priimek.Location = new System.Drawing.Point(131, 44);
            this.tbx_priimek.Name = "tbx_priimek";
            this.tbx_priimek.Size = new System.Drawing.Size(270, 26);
            this.tbx_priimek.TabIndex = 2;
            // 
            // tbx_uporabnisko
            // 
            this.tbx_uporabnisko.Location = new System.Drawing.Point(131, 108);
            this.tbx_uporabnisko.Name = "tbx_uporabnisko";
            this.tbx_uporabnisko.Size = new System.Drawing.Size(270, 26);
            this.tbx_uporabnisko.TabIndex = 3;
            this.tbx_uporabnisko.TextChanged += new System.EventHandler(this.tbx_uporabnisko_TextChanged);
            // 
            // tbx_geslo
            // 
            this.tbx_geslo.Location = new System.Drawing.Point(131, 140);
            this.tbx_geslo.Name = "tbx_geslo";
            this.tbx_geslo.PasswordChar = '*';
            this.tbx_geslo.Size = new System.Drawing.Size(270, 26);
            this.tbx_geslo.TabIndex = 4;
            this.tbx_geslo.TextChanged += new System.EventHandler(this.tbx_geslo_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(70, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 19);
            this.label2.TabIndex = 5;
            this.label2.Text = "Priimek";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 111);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(113, 19);
            this.label3.TabIndex = 6;
            this.label3.Text = "Uporabniško ime";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(81, 143);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 19);
            this.label4.TabIndex = 7;
            this.label4.Text = "Geslo";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(77, 79);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 19);
            this.label5.TabIndex = 8;
            this.label5.Text = "E-mail";
            // 
            // tbx_email
            // 
            this.tbx_email.Location = new System.Drawing.Point(131, 76);
            this.tbx_email.Name = "tbx_email";
            this.tbx_email.Size = new System.Drawing.Size(270, 26);
            this.tbx_email.TabIndex = 9;
            // 
            // btn_registracija
            // 
            this.btn_registracija.Location = new System.Drawing.Point(301, 172);
            this.btn_registracija.Name = "btn_registracija";
            this.btn_registracija.Size = new System.Drawing.Size(100, 32);
            this.btn_registracija.TabIndex = 10;
            this.btn_registracija.Text = "Registracija";
            this.btn_registracija.UseVisualStyleBackColor = true;
            this.btn_registracija.Click += new System.EventHandler(this.btn_registracija_Click);
            // 
            // lbl_status_update
            // 
            this.lbl_status_update.AutoSize = true;
            this.lbl_status_update.Location = new System.Drawing.Point(13, 207);
            this.lbl_status_update.Name = "lbl_status_update";
            this.lbl_status_update.Size = new System.Drawing.Size(49, 19);
            this.lbl_status_update.TabIndex = 11;
            this.lbl_status_update.Text = "Status:";
            // 
            // Registracija
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(418, 258);
            this.Controls.Add(this.lbl_status_update);
            this.Controls.Add(this.btn_registracija);
            this.Controls.Add(this.tbx_email);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbx_geslo);
            this.Controls.Add(this.tbx_uporabnisko);
            this.Controls.Add(this.tbx_priimek);
            this.Controls.Add(this.tbx_ime);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Registracija";
            this.Text = "Registracija";
            this.Load += new System.EventHandler(this.Registracija_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbx_ime;
        private System.Windows.Forms.TextBox tbx_priimek;
        private System.Windows.Forms.TextBox tbx_uporabnisko;
        private System.Windows.Forms.TextBox tbx_geslo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbx_email;
        private System.Windows.Forms.Button btn_registracija;
        private System.Windows.Forms.Label lbl_status_update;
    }
}