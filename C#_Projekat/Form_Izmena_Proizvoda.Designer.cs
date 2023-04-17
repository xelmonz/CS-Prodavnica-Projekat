namespace CS_Projekat
{
    partial class Form_Izmena_Proizvoda
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
            this.btn_nazad = new System.Windows.Forms.Button();
            this.cb_naziv_proizvoda = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_naziv = new System.Windows.Forms.TextBox();
            this.txt_cena = new System.Windows.Forms.TextBox();
            this.txt_kolicina = new System.Windows.Forms.TextBox();
            this.cb_kategorija = new System.Windows.Forms.ComboBox();
            this.kategorijaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.msSQL_ProdavnicaDataSet = new CS_Projekat.MsSQL_ProdavnicaDataSet();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btn_izmena = new System.Windows.Forms.Button();
            this.msSQLProdavnicaDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.kategorijaTableAdapter = new CS_Projekat.MsSQL_ProdavnicaDataSetTableAdapters.kategorijaTableAdapter();
            this.error_naziv = new System.Windows.Forms.ErrorProvider(this.components);
            this.error_kategorija = new System.Windows.Forms.ErrorProvider(this.components);
            this.error_cena = new System.Windows.Forms.ErrorProvider(this.components);
            this.error_kolicina = new System.Windows.Forms.ErrorProvider(this.components);
            this.korisniciBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.korisniciTableAdapter = new CS_Projekat.MsSQL_ProdavnicaDataSetTableAdapters.korisniciTableAdapter();
            this.kategorijaBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.kategorijaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.msSQL_ProdavnicaDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.msSQLProdavnicaDataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.error_naziv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.error_kategorija)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.error_cena)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.error_kolicina)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.korisniciBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kategorijaBindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_nazad
            // 
            this.btn_nazad.Location = new System.Drawing.Point(449, 12);
            this.btn_nazad.Name = "btn_nazad";
            this.btn_nazad.Size = new System.Drawing.Size(88, 36);
            this.btn_nazad.TabIndex = 35;
            this.btn_nazad.Text = "Nazad";
            this.btn_nazad.UseVisualStyleBackColor = true;
            this.btn_nazad.Click += new System.EventHandler(this.btn_nazad_Click);
            // 
            // cb_naziv_proizvoda
            // 
            this.cb_naziv_proizvoda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_naziv_proizvoda.FormattingEnabled = true;
            this.cb_naziv_proizvoda.Location = new System.Drawing.Point(200, 24);
            this.cb_naziv_proizvoda.Name = "cb_naziv_proizvoda";
            this.cb_naziv_proizvoda.Size = new System.Drawing.Size(213, 24);
            this.cb_naziv_proizvoda.TabIndex = 36;
            this.cb_naziv_proizvoda.SelectedIndexChanged += new System.EventHandler(this.cb_naziv_proizvoda_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(70, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 17);
            this.label1.TabIndex = 37;
            this.label1.Text = "Izaberite proizvod:";
            // 
            // txt_naziv
            // 
            this.txt_naziv.Location = new System.Drawing.Point(200, 89);
            this.txt_naziv.Name = "txt_naziv";
            this.txt_naziv.Size = new System.Drawing.Size(213, 22);
            this.txt_naziv.TabIndex = 38;
            // 
            // txt_cena
            // 
            this.txt_cena.Location = new System.Drawing.Point(200, 186);
            this.txt_cena.Name = "txt_cena";
            this.txt_cena.Size = new System.Drawing.Size(213, 22);
            this.txt_cena.TabIndex = 40;
            // 
            // txt_kolicina
            // 
            this.txt_kolicina.Location = new System.Drawing.Point(200, 235);
            this.txt_kolicina.Name = "txt_kolicina";
            this.txt_kolicina.Size = new System.Drawing.Size(213, 22);
            this.txt_kolicina.TabIndex = 41;
            // 
            // cb_kategorija
            // 
            this.cb_kategorija.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_kategorija.FormattingEnabled = true;
            this.cb_kategorija.Location = new System.Drawing.Point(200, 134);
            this.cb_kategorija.Name = "cb_kategorija";
            this.cb_kategorija.Size = new System.Drawing.Size(213, 24);
            this.cb_kategorija.TabIndex = 42;
            // 
            // kategorijaBindingSource
            // 
            this.kategorijaBindingSource.DataMember = "kategorija";
            this.kategorijaBindingSource.DataSource = this.msSQL_ProdavnicaDataSet;
            // 
            // msSQL_ProdavnicaDataSet
            // 
            this.msSQL_ProdavnicaDataSet.DataSetName = "MsSQL_ProdavnicaDataSet";
            this.msSQL_ProdavnicaDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(138, 93);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 17);
            this.label2.TabIndex = 43;
            this.label2.Text = "Naziv:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(109, 141);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 17);
            this.label3.TabIndex = 44;
            this.label3.Text = "Kategorija:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(138, 191);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 17);
            this.label4.TabIndex = 45;
            this.label4.Text = "Cena:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(124, 240);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 17);
            this.label5.TabIndex = 46;
            this.label5.Text = "Količina:";
            // 
            // btn_izmena
            // 
            this.btn_izmena.Location = new System.Drawing.Point(200, 277);
            this.btn_izmena.Name = "btn_izmena";
            this.btn_izmena.Size = new System.Drawing.Size(213, 44);
            this.btn_izmena.TabIndex = 47;
            this.btn_izmena.Text = "Izmeni";
            this.btn_izmena.UseVisualStyleBackColor = true;
            this.btn_izmena.Click += new System.EventHandler(this.btn_izmena_Click);
            // 
            // msSQLProdavnicaDataSetBindingSource
            // 
            this.msSQLProdavnicaDataSetBindingSource.DataSource = this.msSQL_ProdavnicaDataSet;
            this.msSQLProdavnicaDataSetBindingSource.Position = 0;
            // 
            // kategorijaTableAdapter
            // 
            this.kategorijaTableAdapter.ClearBeforeFill = true;
            // 
            // error_naziv
            // 
            this.error_naziv.ContainerControl = this;
            // 
            // error_kategorija
            // 
            this.error_kategorija.ContainerControl = this;
            // 
            // error_cena
            // 
            this.error_cena.ContainerControl = this;
            // 
            // error_kolicina
            // 
            this.error_kolicina.ContainerControl = this;
            // 
            // korisniciBindingSource
            // 
            this.korisniciBindingSource.DataMember = "korisnici";
            this.korisniciBindingSource.DataSource = this.msSQLProdavnicaDataSetBindingSource;
            // 
            // korisniciTableAdapter
            // 
            this.korisniciTableAdapter.ClearBeforeFill = true;
            // 
            // kategorijaBindingSource1
            // 
            this.kategorijaBindingSource1.DataMember = "kategorija";
            this.kategorijaBindingSource1.DataSource = this.msSQLProdavnicaDataSetBindingSource;
            // 
            // Form_Izmena_Proizvoda
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(596, 348);
            this.Controls.Add(this.btn_izmena);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cb_kategorija);
            this.Controls.Add(this.txt_kolicina);
            this.Controls.Add(this.txt_cena);
            this.Controls.Add(this.txt_naziv);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cb_naziv_proizvoda);
            this.Controls.Add(this.btn_nazad);
            this.Name = "Form_Izmena_Proizvoda";
            this.Text = "Form_Izmena_Proizvoda";
            this.Load += new System.EventHandler(this.Form_Izmena_Proizvoda_Load);
            ((System.ComponentModel.ISupportInitialize)(this.kategorijaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.msSQL_ProdavnicaDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.msSQLProdavnicaDataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.error_naziv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.error_kategorija)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.error_cena)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.error_kolicina)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.korisniciBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kategorijaBindingSource1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_nazad;
        private System.Windows.Forms.ComboBox cb_naziv_proizvoda;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_naziv;
        private System.Windows.Forms.TextBox txt_cena;
        private System.Windows.Forms.TextBox txt_kolicina;
        private System.Windows.Forms.ComboBox cb_kategorija;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btn_izmena;
        private System.Windows.Forms.BindingSource msSQLProdavnicaDataSetBindingSource;
        private MsSQL_ProdavnicaDataSet msSQL_ProdavnicaDataSet;
        private System.Windows.Forms.BindingSource kategorijaBindingSource;
        private MsSQL_ProdavnicaDataSetTableAdapters.kategorijaTableAdapter kategorijaTableAdapter;
        private System.Windows.Forms.ErrorProvider error_naziv;
        private System.Windows.Forms.ErrorProvider error_kategorija;
        private System.Windows.Forms.ErrorProvider error_cena;
        private System.Windows.Forms.ErrorProvider error_kolicina;
        private System.Windows.Forms.BindingSource korisniciBindingSource;
        private MsSQL_ProdavnicaDataSetTableAdapters.korisniciTableAdapter korisniciTableAdapter;
        private System.Windows.Forms.BindingSource kategorijaBindingSource1;
    }
}