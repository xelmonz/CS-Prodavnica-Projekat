namespace CS_Projekat
{
    partial class Form_NoviProizvod
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
            this.components = new System.ComponentModel.Container();
            this.txtNaziv = new System.Windows.Forms.TextBox();
            this.txtCena = new System.Windows.Forms.TextBox();
            this.txtKolicina = new System.Windows.Forms.TextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btn_nazad = new System.Windows.Forms.Button();
            this.msSQL_ProdavnicaDataSet = new CS_Projekat.MsSQL_ProdavnicaDataSet();
            this.msSQLProdavnicaDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.kategorijaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.kategorijaTableAdapter = new CS_Projekat.MsSQL_ProdavnicaDataSetTableAdapters.kategorijaTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.msSQL_ProdavnicaDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.msSQLProdavnicaDataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kategorijaBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // txtNaziv
            // 
            this.txtNaziv.Location = new System.Drawing.Point(111, 40);
            this.txtNaziv.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtNaziv.Name = "txtNaziv";
            this.txtNaziv.Size = new System.Drawing.Size(163, 20);
            this.txtNaziv.TabIndex = 0;
            // 
            // txtCena
            // 
            this.txtCena.Location = new System.Drawing.Point(111, 119);
            this.txtCena.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtCena.Name = "txtCena";
            this.txtCena.Size = new System.Drawing.Size(163, 20);
            this.txtCena.TabIndex = 1;
            // 
            // txtKolicina
            // 
            this.txtKolicina.Location = new System.Drawing.Point(111, 158);
            this.txtKolicina.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtKolicina.Name = "txtKolicina";
            this.txtKolicina.Size = new System.Drawing.Size(163, 20);
            this.txtKolicina.TabIndex = 2;
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(111, 79);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(163, 21);
            this.comboBox1.TabIndex = 3;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(134, 189);
            this.button1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(106, 41);
            this.button1.TabIndex = 4;
            this.button1.Text = "Dodaj proizvod";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(71, 44);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Naziv:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(50, 84);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Kategorija:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(73, 122);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Cena:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(62, 162);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Količina:";
            // 
            // btn_nazad
            // 
            this.btn_nazad.Location = new System.Drawing.Point(302, 10);
            this.btn_nazad.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btn_nazad.Name = "btn_nazad";
            this.btn_nazad.Size = new System.Drawing.Size(66, 29);
            this.btn_nazad.TabIndex = 34;
            this.btn_nazad.Text = "Nazad";
            this.btn_nazad.UseVisualStyleBackColor = true;
            this.btn_nazad.Click += new System.EventHandler(this.btn_nazad_Click);
            // 
            // msSQL_ProdavnicaDataSet
            // 
            this.msSQL_ProdavnicaDataSet.DataSetName = "MsSQL_ProdavnicaDataSet";
            this.msSQL_ProdavnicaDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // msSQLProdavnicaDataSetBindingSource
            // 
            this.msSQLProdavnicaDataSetBindingSource.DataSource = this.msSQL_ProdavnicaDataSet;
            this.msSQLProdavnicaDataSetBindingSource.Position = 0;
            // 
            // kategorijaBindingSource
            // 
            this.kategorijaBindingSource.DataMember = "kategorija";
            this.kategorijaBindingSource.DataSource = this.msSQLProdavnicaDataSetBindingSource;
            // 
            // kategorijaTableAdapter
            // 
            this.kategorijaTableAdapter.ClearBeforeFill = true;
            // 
            // Form_NoviProizvod
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(383, 251);
            this.Controls.Add(this.btn_nazad);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.txtKolicina);
            this.Controls.Add(this.txtCena);
            this.Controls.Add(this.txtNaziv);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Form_NoviProizvod";
            this.Text = "Form_NoviProizvod";
            this.Load += new System.EventHandler(this.Form_NoviProizvod_Load);
            ((System.ComponentModel.ISupportInitialize)(this.msSQL_ProdavnicaDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.msSQLProdavnicaDataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kategorijaBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtNaziv;
        private System.Windows.Forms.TextBox txtCena;
        private System.Windows.Forms.TextBox txtKolicina;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btn_nazad;
        private System.Windows.Forms.BindingSource msSQLProdavnicaDataSetBindingSource;
        private MsSQL_ProdavnicaDataSet msSQL_ProdavnicaDataSet;
        private System.Windows.Forms.BindingSource kategorijaBindingSource;
        private MsSQL_ProdavnicaDataSetTableAdapters.kategorijaTableAdapter kategorijaTableAdapter;
    }
}