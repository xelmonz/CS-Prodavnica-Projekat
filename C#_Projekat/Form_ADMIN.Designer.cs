namespace CS_Projekat
{
    partial class Form_ADMIN
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
            this.btn_Statistika = new System.Windows.Forms.Button();
            this.btnRacuni = new System.Windows.Forms.Button();
            this.btn_New = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btn_izmena = new System.Windows.Forms.Button();
            this.btn_izmena_user = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_Statistika
            // 
            this.btn_Statistika.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Statistika.Location = new System.Drawing.Point(104, 154);
            this.btn_Statistika.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btn_Statistika.Name = "btn_Statistika";
            this.btn_Statistika.Size = new System.Drawing.Size(124, 24);
            this.btn_Statistika.TabIndex = 21;
            this.btn_Statistika.Text = "Statistika";
            this.btn_Statistika.UseVisualStyleBackColor = true;
            this.btn_Statistika.Click += new System.EventHandler(this.btn_Statistika_Click);
            // 
            // btnRacuni
            // 
            this.btnRacuni.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRacuni.Location = new System.Drawing.Point(104, 124);
            this.btnRacuni.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnRacuni.Name = "btnRacuni";
            this.btnRacuni.Size = new System.Drawing.Size(124, 25);
            this.btnRacuni.TabIndex = 20;
            this.btnRacuni.Text = "Prikaz računa";
            this.btnRacuni.UseVisualStyleBackColor = true;
            this.btnRacuni.Click += new System.EventHandler(this.btnRacuni_Click);
            // 
            // btn_New
            // 
            this.btn_New.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_New.Location = new System.Drawing.Point(104, 96);
            this.btn_New.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btn_New.Name = "btn_New";
            this.btn_New.Size = new System.Drawing.Size(124, 23);
            this.btn_New.TabIndex = 19;
            this.btn_New.Text = "Novi proizvod";
            this.btn_New.UseVisualStyleBackColor = true;
            this.btn_New.Click += new System.EventHandler(this.btn_New_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(260, 10);
            this.button1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(66, 29);
            this.button1.TabIndex = 34;
            this.button1.Text = "Odjavi se";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Btn_Nazad);
            // 
            // btn_izmena
            // 
            this.btn_izmena.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_izmena.Location = new System.Drawing.Point(104, 68);
            this.btn_izmena.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btn_izmena.Name = "btn_izmena";
            this.btn_izmena.Size = new System.Drawing.Size(124, 23);
            this.btn_izmena.TabIndex = 35;
            this.btn_izmena.Text = "Izmena proizvoda";
            this.btn_izmena.UseVisualStyleBackColor = true;
            this.btn_izmena.Click += new System.EventHandler(this.btn_izmena_Click);
            // 
            // btn_izmena_user
            // 
            this.btn_izmena_user.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_izmena_user.Location = new System.Drawing.Point(104, 41);
            this.btn_izmena_user.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btn_izmena_user.Name = "btn_izmena_user";
            this.btn_izmena_user.Size = new System.Drawing.Size(124, 23);
            this.btn_izmena_user.TabIndex = 36;
            this.btn_izmena_user.Text = "Izmena korisnika";
            this.btn_izmena_user.UseVisualStyleBackColor = true;
            this.btn_izmena_user.Click += new System.EventHandler(this.btn_izmena_user_Click);
            // 
            // Form_ADMIN
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(335, 271);
            this.Controls.Add(this.btn_izmena_user);
            this.Controls.Add(this.btn_izmena);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btn_Statistika);
            this.Controls.Add(this.btnRacuni);
            this.Controls.Add(this.btn_New);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Form_ADMIN";
            this.Text = "Form_ADMIN";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_Statistika;
        private System.Windows.Forms.Button btnRacuni;
        private System.Windows.Forms.Button btn_New;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btn_izmena;
        private System.Windows.Forms.Button btn_izmena_user;
    }
}