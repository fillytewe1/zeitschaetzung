namespace Zeitschätzung
{
    partial class Form1
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Beschreibung = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GeschaetzteZeit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lbnSumme = new System.Windows.Forms.Label();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnloeschen = new System.Windows.Forms.Button();
            this.lbnliveAusgabe = new System.Windows.Forms.Label();
            this.lbnVollstaendig = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Beschreibung,
            this.GeschaetzteZeit});
            this.dataGridView1.Location = new System.Drawing.Point(5, 5);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(6);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(720, 473);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellEndEdit);
            this.dataGridView1.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellLeave);
            this.dataGridView1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataGridView1_KeyDown);
            // 
            // Beschreibung
            // 
            this.Beschreibung.FillWeight = 172.5889F;
            this.Beschreibung.HeaderText = "Beschreibung";
            this.Beschreibung.Name = "Beschreibung";
            // 
            // GeschaetzteZeit
            // 
            this.GeschaetzteZeit.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.GeschaetzteZeit.FillWeight = 27.41118F;
            this.GeschaetzteZeit.HeaderText = "Geschätzte Zeit";
            this.GeschaetzteZeit.Name = "GeschaetzteZeit";
            // 
            // lbnSumme
            // 
            this.lbnSumme.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lbnSumme.AutoSize = true;
            this.lbnSumme.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbnSumme.Location = new System.Drawing.Point(455, 16);
            this.lbnSumme.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbnSumme.Name = "lbnSumme";
            this.lbnSumme.Size = new System.Drawing.Size(70, 18);
            this.lbnSumme.TabIndex = 2;
            this.lbnSumme.Text = "Summe:";
            // 
            // btnExport
            // 
            this.btnExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnExport.Location = new System.Drawing.Point(0, 12);
            this.btnExport.Margin = new System.Windows.Forms.Padding(2);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(93, 27);
            this.btnExport.TabIndex = 6;
            this.btnExport.Text = "Kopieren";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnloeschen
            // 
            this.btnloeschen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnloeschen.Location = new System.Drawing.Point(109, 12);
            this.btnloeschen.Margin = new System.Windows.Forms.Padding(2);
            this.btnloeschen.Name = "btnloeschen";
            this.btnloeschen.Size = new System.Drawing.Size(102, 27);
            this.btnloeschen.TabIndex = 7;
            this.btnloeschen.Text = "Zurücksetzen";
            this.btnloeschen.UseVisualStyleBackColor = true;
            this.btnloeschen.Click += new System.EventHandler(this.btnloeschen_Click);
            // 
            // lbnliveAusgabe
            // 
            this.lbnliveAusgabe.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lbnliveAusgabe.AutoSize = true;
            this.lbnliveAusgabe.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbnliveAusgabe.Location = new System.Drawing.Point(529, 16);
            this.lbnliveAusgabe.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbnliveAusgabe.Name = "lbnliveAusgabe";
            this.lbnliveAusgabe.Size = new System.Drawing.Size(72, 18);
            this.lbnliveAusgabe.TabIndex = 9;
            this.lbnliveAusgabe.Text = "Ausgabe";
            // 
            // lbnVollstaendig
            // 
            this.lbnVollstaendig.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lbnVollstaendig.AutoSize = true;
            this.lbnVollstaendig.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbnVollstaendig.Location = new System.Drawing.Point(307, 16);
            this.lbnVollstaendig.Name = "lbnVollstaendig";
            this.lbnVollstaendig.Size = new System.Drawing.Size(0, 18);
            this.lbnVollstaendig.TabIndex = 10;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lbnSumme);
            this.panel1.Controls.Add(this.lbnVollstaendig);
            this.panel1.Controls.Add(this.btnExport);
            this.panel1.Controls.Add(this.lbnliveAusgabe);
            this.panel1.Controls.Add(this.btnloeschen);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(5, 427);
            this.panel1.MinimumSize = new System.Drawing.Size(650, 50);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(8);
            this.panel1.Size = new System.Drawing.Size(720, 51);
            this.panel1.TabIndex = 11;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(730, 483);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dataGridView1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.Text = "Zeitschätzung ";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label lbnSumme;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Button btnloeschen;
        private System.Windows.Forms.Label lbnliveAusgabe;
        private System.Windows.Forms.Label lbnVollstaendig;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Beschreibung;
        private System.Windows.Forms.DataGridViewTextBoxColumn GeschaetzteZeit;
    }
}

