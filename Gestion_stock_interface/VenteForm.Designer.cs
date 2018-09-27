namespace GestionClinic_WIN
{
    partial class VenteForm
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VenteForm));
            this.dgvVente = new System.Windows.Forms.DataGridView();
            this.txtMontantPaye = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.cboArticle = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtDatePaiement = new System.Windows.Forms.MaskedTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.cboClien = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.txtQuantite = new System.Windows.Forms.MaskedTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtId = new System.Windows.Forms.MaskedTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblClose = new System.Windows.Forms.Label();
            this.bindingNavigator1 = new System.Windows.Forms.BindingNavigator(this.components);
            this.btAdd = new System.Windows.Forms.ToolStripButton();
            this.btRefrech = new System.Windows.Forms.ToolStripButton();
            this.btEnregistre = new System.Windows.Forms.ToolStripButton();
            this.btModifier = new System.Windows.Forms.ToolStripButton();
            this.btSupprimer = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVente)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).BeginInit();
            this.bindingNavigator1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvVente
            // 
            this.dgvVente.AllowUserToAddRows = false;
            this.dgvVente.AllowUserToDeleteRows = false;
            this.dgvVente.BackgroundColor = System.Drawing.SystemColors.ButtonShadow;
            this.dgvVente.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVente.Location = new System.Drawing.Point(369, 34);
            this.dgvVente.MultiSelect = false;
            this.dgvVente.Name = "dgvVente";
            this.dgvVente.ReadOnly = true;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvVente.RowHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvVente.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvVente.Size = new System.Drawing.Size(363, 194);
            this.dgvVente.TabIndex = 132;
            this.dgvVente.SelectionChanged += new System.EventHandler(this.dgvVente_SelectionChanged);
            // 
            // txtMontantPaye
            // 
            this.txtMontantPaye.Location = new System.Drawing.Point(116, 88);
            this.txtMontantPaye.Name = "txtMontantPaye";
            this.txtMontantPaye.Size = new System.Drawing.Size(150, 20);
            this.txtMontantPaye.TabIndex = 151;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(282, 92);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(16, 18);
            this.label12.TabIndex = 150;
            this.label12.Text = "$";
            // 
            // cboArticle
            // 
            this.cboArticle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboArticle.FormattingEnabled = true;
            this.cboArticle.Location = new System.Drawing.Point(116, 32);
            this.cboArticle.Name = "cboArticle";
            this.cboArticle.Size = new System.Drawing.Size(150, 21);
            this.cboArticle.TabIndex = 142;
            this.cboArticle.SelectedIndexChanged += new System.EventHandler(this.cboArticle_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 148;
            this.label2.Text = "Article :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(10, 62);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(39, 13);
            this.label6.TabIndex = 147;
            this.label6.Text = "Client :";
            // 
            // txtDatePaiement
            // 
            this.txtDatePaiement.Location = new System.Drawing.Point(117, 115);
            this.txtDatePaiement.Name = "txtDatePaiement";
            this.txtDatePaiement.Size = new System.Drawing.Size(149, 20);
            this.txtDatePaiement.TabIndex = 143;
            this.txtDatePaiement.ValidatingType = typeof(System.DateTime);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(10, 119);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(83, 13);
            this.label7.TabIndex = 145;
            this.label7.Text = "Date Paiement :";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(10, 92);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(79, 13);
            this.label9.TabIndex = 146;
            this.label9.Text = "Montant Payé :";
            // 
            // cboClien
            // 
            this.cboClien.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboClien.FormattingEnabled = true;
            this.cboClien.Location = new System.Drawing.Point(116, 59);
            this.cboClien.Name = "cboClien";
            this.cboClien.Size = new System.Drawing.Size(182, 21);
            this.cboClien.TabIndex = 144;
            this.cboClien.SelectedIndexChanged += new System.EventHandler(this.cboClien_SelectedIndexChanged);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.txtQuantite);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txtId);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtMontantPaye);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.cboArticle);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.txtDatePaiement);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.cboClien);
            this.panel1.Location = new System.Drawing.Point(5, 34);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(358, 194);
            this.panel1.TabIndex = 152;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(117, 170);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 13);
            this.label4.TabIndex = 157;
            this.label4.Text = "Quantité :";
            // 
            // txtQuantite
            // 
            this.txtQuantite.Location = new System.Drawing.Point(117, 141);
            this.txtQuantite.Name = "txtQuantite";
            this.txtQuantite.Size = new System.Drawing.Size(149, 20);
            this.txtQuantite.TabIndex = 154;
            this.txtQuantite.ValidatingType = typeof(System.DateTime);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 145);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 155;
            this.label3.Text = "Quantité :";
            // 
            // txtId
            // 
            this.txtId.Location = new System.Drawing.Point(116, 6);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(149, 20);
            this.txtId.TabIndex = 152;
            this.txtId.ValidatingType = typeof(System.DateTime);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(22, 13);
            this.label1.TabIndex = 153;
            this.label1.Text = "Id :";
            // 
            // lblClose
            // 
            this.lblClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClose.Image = global::GestionClinic_WIN.Properties.Resources.Close;
            this.lblClose.Location = new System.Drawing.Point(708, 0);
            this.lblClose.Name = "lblClose";
            this.lblClose.Size = new System.Drawing.Size(33, 25);
            this.lblClose.TabIndex = 153;
            this.lblClose.Click += new System.EventHandler(this.lblClose_Click);
            // 
            // bindingNavigator1
            // 
            this.bindingNavigator1.AddNewItem = null;
            this.bindingNavigator1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bindingNavigator1.BackgroundImage")));
            this.bindingNavigator1.CountItem = null;
            this.bindingNavigator1.DeleteItem = null;
            this.bindingNavigator1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.bindingNavigator1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btAdd,
            this.btRefrech,
            this.btEnregistre,
            this.btModifier,
            this.btSupprimer});
            this.bindingNavigator1.Location = new System.Drawing.Point(0, 0);
            this.bindingNavigator1.MoveFirstItem = null;
            this.bindingNavigator1.MoveLastItem = null;
            this.bindingNavigator1.MoveNextItem = null;
            this.bindingNavigator1.MovePreviousItem = null;
            this.bindingNavigator1.Name = "bindingNavigator1";
            this.bindingNavigator1.PositionItem = null;
            this.bindingNavigator1.Size = new System.Drawing.Size(741, 25);
            this.bindingNavigator1.TabIndex = 154;
            this.bindingNavigator1.Text = "bindingNavigator1";
            // 
            // btAdd
            // 
            this.btAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btAdd.Image = global::GestionClinic_WIN.Properties.Resources.navBarAddIcon_2x;
            this.btAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btAdd.Name = "btAdd";
            this.btAdd.Size = new System.Drawing.Size(23, 22);
            this.btAdd.Text = "Ajouter";
            this.btAdd.Click += new System.EventHandler(this.btAdd_Click);
            // 
            // btRefrech
            // 
            this.btRefrech.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btRefrech.Image = global::GestionClinic_WIN.Properties.Resources.update;
            this.btRefrech.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btRefrech.Name = "btRefrech";
            this.btRefrech.Size = new System.Drawing.Size(23, 22);
            this.btRefrech.Text = "Refresh";
            this.btRefrech.Click += new System.EventHandler(this.btRefrech_Click);
            // 
            // btEnregistre
            // 
            this.btEnregistre.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btEnregistre.Image = global::GestionClinic_WIN.Properties.Resources.check_2x;
            this.btEnregistre.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btEnregistre.Name = "btEnregistre";
            this.btEnregistre.Size = new System.Drawing.Size(23, 22);
            this.btEnregistre.Text = "Enregistrer";
            this.btEnregistre.Click += new System.EventHandler(this.btEnregistre_Click);
            // 
            // btModifier
            // 
            this.btModifier.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btModifier.Image = ((System.Drawing.Image)(resources.GetObject("btModifier.Image")));
            this.btModifier.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btModifier.Name = "btModifier";
            this.btModifier.Size = new System.Drawing.Size(23, 22);
            this.btModifier.Text = "Modifier";
            this.btModifier.Click += new System.EventHandler(this.btModifier_Click);
            // 
            // btSupprimer
            // 
            this.btSupprimer.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btSupprimer.Image = global::GestionClinic_WIN.Properties.Resources.mp_delete_md_n_lt_2x;
            this.btSupprimer.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btSupprimer.Name = "btSupprimer";
            this.btSupprimer.Size = new System.Drawing.Size(23, 22);
            this.btSupprimer.Text = "Supprimer";
            this.btSupprimer.Click += new System.EventHandler(this.btSupprimer_Click);
            // 
            // VenteForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.Controls.Add(this.lblClose);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dgvVente);
            this.Controls.Add(this.bindingNavigator1);
            this.Name = "VenteForm";
            this.Size = new System.Drawing.Size(741, 237);
            this.Load += new System.EventHandler(this.VenteForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvVente)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).EndInit();
            this.bindingNavigator1.ResumeLayout(false);
            this.bindingNavigator1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvVente;
        private System.Windows.Forms.TextBox txtMontantPaye;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox cboArticle;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.MaskedTextBox txtDatePaiement;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cboClien;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.MaskedTextBox txtId;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblClose;
        private System.Windows.Forms.BindingNavigator bindingNavigator1;
        private System.Windows.Forms.ToolStripButton btAdd;
        private System.Windows.Forms.ToolStripButton btRefrech;
        private System.Windows.Forms.ToolStripButton btEnregistre;
        private System.Windows.Forms.ToolStripButton btModifier;
        private System.Windows.Forms.ToolStripButton btSupprimer;
        private System.Windows.Forms.MaskedTextBox txtQuantite;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}
