namespace GestionClinic_WIN
{
    partial class AgentForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AgentForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.maskedTextBox1 = new System.Windows.Forms.MaskedTextBox();
            this.bindingNavigator3 = new System.Windows.Forms.BindingNavigator(this.components);
            this.toolStripButton6 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton7 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton8 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton9 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton10 = new System.Windows.Forms.ToolStripButton();
            this.dgvCommandes = new System.Windows.Forms.DataGridView();
            this.cboMagasinier = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.cboFournisseur = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.txtMatriculeAgent = new System.Windows.Forms.TextBox();
            this.txtFonctionAgent = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtAdresseAgent = new System.Windows.Forms.TextBox();
            this.lblAjouterService = new System.Windows.Forms.Label();
            this.cboIdService = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtIdAgent = new System.Windows.Forms.TextBox();
            this.bindingNavigator1 = new System.Windows.Forms.BindingNavigator(this.components);
            this.btnAddAgent = new System.Windows.Forms.ToolStripButton();
            this.btnRefreshAgent = new System.Windows.Forms.ToolStripButton();
            this.btnSaveAgent = new System.Windows.Forms.ToolStripButton();
            this.btnModifierAgent = new System.Windows.Forms.ToolStripButton();
            this.btnDeleteAgent = new System.Windows.Forms.ToolStripButton();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTelephoneAgent = new System.Windows.Forms.TextBox();
            this.cboEtatCivAgent = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txtDateNaissanceAgent = new System.Windows.Forms.MaskedTextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cboSexeAgent = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtNomAgent = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPNomAgent = new System.Windows.Forms.TextBox();
            this.txtPrenomAgent = new System.Windows.Forms.TextBox();
            this.dgvAgent = new System.Windows.Forms.DataGridView();
            this.bindingNavigator2 = new System.Windows.Forms.BindingNavigator(this.components);
            this.btnCloseAgent = new System.Windows.Forms.ToolStripButton();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator3)).BeginInit();
            this.bindingNavigator3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCommandes)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).BeginInit();
            this.bindingNavigator1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAgent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator2)).BeginInit();
            this.bindingNavigator2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.groupBox1.Controls.Add(this.maskedTextBox1);
            this.groupBox1.Controls.Add(this.bindingNavigator3);
            this.groupBox1.Controls.Add(this.dgvCommandes);
            this.groupBox1.Controls.Add(this.cboMagasinier);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.cboFournisseur);
            this.groupBox1.Location = new System.Drawing.Point(514, 28);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(414, 435);
            this.groupBox1.TabIndex = 136;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Commande";
            // 
            // maskedTextBox1
            // 
            this.maskedTextBox1.Location = new System.Drawing.Point(118, 110);
            this.maskedTextBox1.Mask = "00/00/0000";
            this.maskedTextBox1.Name = "maskedTextBox1";
            this.maskedTextBox1.Size = new System.Drawing.Size(216, 20);
            this.maskedTextBox1.TabIndex = 13;
            this.maskedTextBox1.ValidatingType = typeof(System.DateTime);
            // 
            // bindingNavigator3
            // 
            this.bindingNavigator3.AddNewItem = null;
            this.bindingNavigator3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bindingNavigator3.BackgroundImage")));
            this.bindingNavigator3.CountItem = null;
            this.bindingNavigator3.DeleteItem = null;
            this.bindingNavigator3.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.bindingNavigator3.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton6,
            this.toolStripButton7,
            this.toolStripButton8,
            this.toolStripButton9,
            this.toolStripButton10});
            this.bindingNavigator3.Location = new System.Drawing.Point(3, 16);
            this.bindingNavigator3.MoveFirstItem = null;
            this.bindingNavigator3.MoveLastItem = null;
            this.bindingNavigator3.MoveNextItem = null;
            this.bindingNavigator3.MovePreviousItem = null;
            this.bindingNavigator3.Name = "bindingNavigator3";
            this.bindingNavigator3.PositionItem = null;
            this.bindingNavigator3.Size = new System.Drawing.Size(408, 25);
            this.bindingNavigator3.TabIndex = 147;
            this.bindingNavigator3.Text = "bindingNavigator3";
            // 
            // toolStripButton6
            // 
            this.toolStripButton6.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton6.Image = global::GestionClinic_WIN.Properties.Resources.navBarAddIcon_2x;
            this.toolStripButton6.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton6.Name = "toolStripButton6";
            this.toolStripButton6.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton6.Text = "Ajouter";
            // 
            // toolStripButton7
            // 
            this.toolStripButton7.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton7.Image = global::GestionClinic_WIN.Properties.Resources.update;
            this.toolStripButton7.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton7.Name = "toolStripButton7";
            this.toolStripButton7.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton7.Text = "Refresh";
            // 
            // toolStripButton8
            // 
            this.toolStripButton8.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton8.Image = global::GestionClinic_WIN.Properties.Resources.check_2x;
            this.toolStripButton8.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton8.Name = "toolStripButton8";
            this.toolStripButton8.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton8.Text = "Enregistrer";
            // 
            // toolStripButton9
            // 
            this.toolStripButton9.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton9.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton9.Image")));
            this.toolStripButton9.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton9.Name = "toolStripButton9";
            this.toolStripButton9.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton9.Text = "Modifier";
            // 
            // toolStripButton10
            // 
            this.toolStripButton10.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton10.Image = global::GestionClinic_WIN.Properties.Resources.mp_delete_md_n_lt_2x;
            this.toolStripButton10.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton10.Name = "toolStripButton10";
            this.toolStripButton10.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton10.Text = "Supprimer";
            // 
            // dgvCommandes
            // 
            this.dgvCommandes.AllowUserToAddRows = false;
            this.dgvCommandes.AllowUserToDeleteRows = false;
            this.dgvCommandes.BackgroundColor = System.Drawing.SystemColors.ButtonShadow;
            this.dgvCommandes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCommandes.Location = new System.Drawing.Point(16, 167);
            this.dgvCommandes.MultiSelect = false;
            this.dgvCommandes.Name = "dgvCommandes";
            this.dgvCommandes.ReadOnly = true;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCommandes.RowHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvCommandes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCommandes.Size = new System.Drawing.Size(385, 113);
            this.dgvCommandes.TabIndex = 14;
            // 
            // cboMagasinier
            // 
            this.cboMagasinier.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMagasinier.FormattingEnabled = true;
            this.cboMagasinier.Location = new System.Drawing.Point(118, 52);
            this.cboMagasinier.Name = "cboMagasinier";
            this.cboMagasinier.Size = new System.Drawing.Size(227, 21);
            this.cboMagasinier.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 137;
            this.label2.Text = "Magasinier";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 83);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(73, 13);
            this.label6.TabIndex = 136;
            this.label6.Text = "Fournisseur :  ";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 114);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(36, 13);
            this.label7.TabIndex = 134;
            this.label7.Text = "Date :";
            // 
            // cboFournisseur
            // 
            this.cboFournisseur.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFournisseur.FormattingEnabled = true;
            this.cboFournisseur.Location = new System.Drawing.Point(118, 80);
            this.cboFournisseur.Name = "cboFournisseur";
            this.cboFournisseur.Size = new System.Drawing.Size(123, 21);
            this.cboFournisseur.TabIndex = 12;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.txtMatriculeAgent);
            this.groupBox2.Controls.Add(this.txtFonctionAgent);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.txtAdresseAgent);
            this.groupBox2.Controls.Add(this.lblAjouterService);
            this.groupBox2.Controls.Add(this.cboIdService);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.txtIdAgent);
            this.groupBox2.Controls.Add(this.bindingNavigator1);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.txtTelephoneAgent);
            this.groupBox2.Controls.Add(this.cboEtatCivAgent);
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Controls.Add(this.txtDateNaissanceAgent);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.cboSexeAgent);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.txtNomAgent);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.txtPNomAgent);
            this.groupBox2.Controls.Add(this.txtPrenomAgent);
            this.groupBox2.Location = new System.Drawing.Point(9, 28);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(495, 435);
            this.groupBox2.TabIndex = 137;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Agent";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(15, 262);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(54, 13);
            this.label13.TabIndex = 187;
            this.label13.Text = "Fonction :";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(15, 232);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(56, 13);
            this.label14.TabIndex = 186;
            this.label14.Text = "Matricule :";
            // 
            // txtMatriculeAgent
            // 
            this.txtMatriculeAgent.Location = new System.Drawing.Point(117, 229);
            this.txtMatriculeAgent.Name = "txtMatriculeAgent";
            this.txtMatriculeAgent.Size = new System.Drawing.Size(215, 20);
            this.txtMatriculeAgent.TabIndex = 5;
            // 
            // txtFonctionAgent
            // 
            this.txtFonctionAgent.Location = new System.Drawing.Point(117, 260);
            this.txtFonctionAgent.Name = "txtFonctionAgent";
            this.txtFonctionAgent.Size = new System.Drawing.Size(215, 20);
            this.txtFonctionAgent.TabIndex = 6;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(11, 357);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(51, 13);
            this.label12.TabIndex = 183;
            this.label12.Text = "Adresse :";
            // 
            // txtAdresseAgent
            // 
            this.txtAdresseAgent.Location = new System.Drawing.Point(114, 354);
            this.txtAdresseAgent.Multiline = true;
            this.txtAdresseAgent.Name = "txtAdresseAgent";
            this.txtAdresseAgent.Size = new System.Drawing.Size(216, 41);
            this.txtAdresseAgent.TabIndex = 9;
            // 
            // lblAjouterService
            // 
            this.lblAjouterService.Image = ((System.Drawing.Image)(resources.GetObject("lblAjouterService.Image")));
            this.lblAjouterService.Location = new System.Drawing.Point(338, 78);
            this.lblAjouterService.Name = "lblAjouterService";
            this.lblAjouterService.Size = new System.Drawing.Size(16, 18);
            this.lblAjouterService.TabIndex = 181;
            this.lblAjouterService.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.lblAjouterService.Click += new System.EventHandler(this.lblAjouterService_Click);
            // 
            // cboIdService
            // 
            this.cboIdService.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboIdService.FormattingEnabled = true;
            this.cboIdService.Location = new System.Drawing.Point(117, 77);
            this.cboIdService.Name = "cboIdService";
            this.cboIdService.Size = new System.Drawing.Size(213, 21);
            this.cboIdService.TabIndex = 0;
            this.cboIdService.SelectedIndexChanged += new System.EventHandler(this.cboIdService_SelectedIndexChanged);
            this.cboIdService.DropDown += new System.EventHandler(this.cboIdService_DropDown);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(13, 82);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(49, 13);
            this.label10.TabIndex = 151;
            this.label10.Text = "Service :";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(14, 54);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(22, 13);
            this.label9.TabIndex = 149;
            this.label9.Text = "Id :";
            // 
            // txtIdAgent
            // 
            this.txtIdAgent.Enabled = false;
            this.txtIdAgent.Location = new System.Drawing.Point(115, 50);
            this.txtIdAgent.Name = "txtIdAgent";
            this.txtIdAgent.Size = new System.Drawing.Size(215, 20);
            this.txtIdAgent.TabIndex = 148;
            // 
            // bindingNavigator1
            // 
            this.bindingNavigator1.AddNewItem = null;
            this.bindingNavigator1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bindingNavigator1.BackgroundImage")));
            this.bindingNavigator1.CountItem = null;
            this.bindingNavigator1.DeleteItem = null;
            this.bindingNavigator1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.bindingNavigator1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAddAgent,
            this.btnRefreshAgent,
            this.btnSaveAgent,
            this.btnModifierAgent,
            this.btnDeleteAgent});
            this.bindingNavigator1.Location = new System.Drawing.Point(3, 16);
            this.bindingNavigator1.MoveFirstItem = null;
            this.bindingNavigator1.MoveLastItem = null;
            this.bindingNavigator1.MoveNextItem = null;
            this.bindingNavigator1.MovePreviousItem = null;
            this.bindingNavigator1.Name = "bindingNavigator1";
            this.bindingNavigator1.PositionItem = null;
            this.bindingNavigator1.Size = new System.Drawing.Size(489, 25);
            this.bindingNavigator1.TabIndex = 147;
            this.bindingNavigator1.Text = "bindingNavigator1";
            // 
            // btnAddAgent
            // 
            this.btnAddAgent.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnAddAgent.Image = global::GestionClinic_WIN.Properties.Resources.navBarAddIcon_2x;
            this.btnAddAgent.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAddAgent.Name = "btnAddAgent";
            this.btnAddAgent.Size = new System.Drawing.Size(23, 22);
            this.btnAddAgent.Text = "Ajouter";
            this.btnAddAgent.Click += new System.EventHandler(this.btnAddAgent_Click);
            // 
            // btnRefreshAgent
            // 
            this.btnRefreshAgent.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnRefreshAgent.Image = global::GestionClinic_WIN.Properties.Resources.update;
            this.btnRefreshAgent.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRefreshAgent.Name = "btnRefreshAgent";
            this.btnRefreshAgent.Size = new System.Drawing.Size(23, 22);
            this.btnRefreshAgent.Text = "Refresh";
            this.btnRefreshAgent.Click += new System.EventHandler(this.btnRefreshMagasinier_Click);
            // 
            // btnSaveAgent
            // 
            this.btnSaveAgent.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnSaveAgent.Image = global::GestionClinic_WIN.Properties.Resources.check_2x;
            this.btnSaveAgent.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSaveAgent.Name = "btnSaveAgent";
            this.btnSaveAgent.Size = new System.Drawing.Size(23, 22);
            this.btnSaveAgent.Text = "Enregistrer";
            this.btnSaveAgent.Click += new System.EventHandler(this.btnSaveAgent_Click);
            // 
            // btnModifierAgent
            // 
            this.btnModifierAgent.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnModifierAgent.Image = ((System.Drawing.Image)(resources.GetObject("btnModifierAgent.Image")));
            this.btnModifierAgent.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnModifierAgent.Name = "btnModifierAgent";
            this.btnModifierAgent.Size = new System.Drawing.Size(23, 22);
            this.btnModifierAgent.Text = "Modifier";
            this.btnModifierAgent.Click += new System.EventHandler(this.btnModifierAgent_Click);
            // 
            // btnDeleteAgent
            // 
            this.btnDeleteAgent.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnDeleteAgent.Image = global::GestionClinic_WIN.Properties.Resources.mp_delete_md_n_lt_2x;
            this.btnDeleteAgent.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDeleteAgent.Name = "btnDeleteAgent";
            this.btnDeleteAgent.Size = new System.Drawing.Size(23, 22);
            this.btnDeleteAgent.Text = "Supprimer";
            this.btnDeleteAgent.Click += new System.EventHandler(this.btnDeleteAgent_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 407);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 92;
            this.label1.Text = "Télephone :";
            // 
            // txtTelephoneAgent
            // 
            this.txtTelephoneAgent.Location = new System.Drawing.Point(114, 403);
            this.txtTelephoneAgent.Name = "txtTelephoneAgent";
            this.txtTelephoneAgent.Size = new System.Drawing.Size(216, 20);
            this.txtTelephoneAgent.TabIndex = 10;
            // 
            // cboEtatCivAgent
            // 
            this.cboEtatCivAgent.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEtatCivAgent.FormattingEnabled = true;
            this.cboEtatCivAgent.Location = new System.Drawing.Point(115, 324);
            this.cboEtatCivAgent.Name = "cboEtatCivAgent";
            this.cboEtatCivAgent.Size = new System.Drawing.Size(181, 21);
            this.cboEtatCivAgent.TabIndex = 8;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(14, 329);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(53, 13);
            this.label15.TabIndex = 119;
            this.label15.Text = "Etat civil :";
            // 
            // txtDateNaissanceAgent
            // 
            this.txtDateNaissanceAgent.Location = new System.Drawing.Point(116, 200);
            this.txtDateNaissanceAgent.Mask = "00/00/0000";
            this.txtDateNaissanceAgent.Name = "txtDateNaissanceAgent";
            this.txtDateNaissanceAgent.Size = new System.Drawing.Size(216, 20);
            this.txtDateNaissanceAgent.TabIndex = 4;
            this.txtDateNaissanceAgent.ValidatingType = typeof(System.DateTime);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(14, 204);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(102, 13);
            this.label8.TabIndex = 78;
            this.label8.Text = "Date de naissance :";
            // 
            // cboSexeAgent
            // 
            this.cboSexeAgent.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSexeAgent.FormattingEnabled = true;
            this.cboSexeAgent.Location = new System.Drawing.Point(116, 293);
            this.cboSexeAgent.Name = "cboSexeAgent";
            this.cboSexeAgent.Size = new System.Drawing.Size(181, 21);
            this.cboSexeAgent.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(14, 298);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 13);
            this.label5.TabIndex = 118;
            this.label5.Text = "Sexe :";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(14, 111);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(35, 13);
            this.label11.TabIndex = 26;
            this.label11.Text = "Nom :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 171);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Prénom :";
            // 
            // txtNomAgent
            // 
            this.txtNomAgent.Location = new System.Drawing.Point(117, 109);
            this.txtNomAgent.Name = "txtNomAgent";
            this.txtNomAgent.Size = new System.Drawing.Size(215, 20);
            this.txtNomAgent.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 141);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Post - nom :";
            // 
            // txtPNomAgent
            // 
            this.txtPNomAgent.Location = new System.Drawing.Point(116, 138);
            this.txtPNomAgent.Name = "txtPNomAgent";
            this.txtPNomAgent.Size = new System.Drawing.Size(215, 20);
            this.txtPNomAgent.TabIndex = 2;
            // 
            // txtPrenomAgent
            // 
            this.txtPrenomAgent.Location = new System.Drawing.Point(116, 169);
            this.txtPrenomAgent.Name = "txtPrenomAgent";
            this.txtPrenomAgent.Size = new System.Drawing.Size(215, 20);
            this.txtPrenomAgent.TabIndex = 3;
            // 
            // dgvAgent
            // 
            this.dgvAgent.AllowUserToAddRows = false;
            this.dgvAgent.AllowUserToDeleteRows = false;
            this.dgvAgent.BackgroundColor = System.Drawing.SystemColors.ButtonShadow;
            this.dgvAgent.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAgent.Location = new System.Drawing.Point(9, 472);
            this.dgvAgent.MultiSelect = false;
            this.dgvAgent.Name = "dgvAgent";
            this.dgvAgent.ReadOnly = true;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvAgent.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvAgent.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAgent.Size = new System.Drawing.Size(917, 101);
            this.dgvAgent.TabIndex = 15;
            this.dgvAgent.SelectionChanged += new System.EventHandler(this.dgvAgent_SelectionChanged);
            // 
            // bindingNavigator2
            // 
            this.bindingNavigator2.AddNewItem = null;
            this.bindingNavigator2.CountItem = null;
            this.bindingNavigator2.DeleteItem = null;
            this.bindingNavigator2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.bindingNavigator2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnCloseAgent});
            this.bindingNavigator2.Location = new System.Drawing.Point(0, 0);
            this.bindingNavigator2.MoveFirstItem = null;
            this.bindingNavigator2.MoveLastItem = null;
            this.bindingNavigator2.MoveNextItem = null;
            this.bindingNavigator2.MovePreviousItem = null;
            this.bindingNavigator2.Name = "bindingNavigator2";
            this.bindingNavigator2.PositionItem = null;
            this.bindingNavigator2.Size = new System.Drawing.Size(933, 25);
            this.bindingNavigator2.TabIndex = 138;
            this.bindingNavigator2.Text = "bindingNavigator2";
            // 
            // btnCloseAgent
            // 
            this.btnCloseAgent.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnCloseAgent.BackColor = System.Drawing.SystemColors.Control;
            this.btnCloseAgent.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnCloseAgent.Image = ((System.Drawing.Image)(resources.GetObject("btnCloseAgent.Image")));
            this.btnCloseAgent.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCloseAgent.Name = "btnCloseAgent";
            this.btnCloseAgent.Size = new System.Drawing.Size(23, 22);
            this.btnCloseAgent.Text = "Quitter";
            this.btnCloseAgent.Click += new System.EventHandler(this.btnCloseAgent_Click);
            // 
            // AgentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.Controls.Add(this.bindingNavigator2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.dgvAgent);
            this.Name = "AgentForm";
            this.Size = new System.Drawing.Size(933, 581);
            this.Load += new System.EventHandler(this.AgentForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator3)).EndInit();
            this.bindingNavigator3.ResumeLayout(false);
            this.bindingNavigator3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCommandes)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).EndInit();
            this.bindingNavigator1.ResumeLayout(false);
            this.bindingNavigator1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAgent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator2)).EndInit();
            this.bindingNavigator2.ResumeLayout(false);
            this.bindingNavigator2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvCommandes;
        private System.Windows.Forms.ComboBox cboMagasinier;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cboFournisseur;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTelephoneAgent;
        private System.Windows.Forms.ComboBox cboEtatCivAgent;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.MaskedTextBox txtDateNaissanceAgent;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cboSexeAgent;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtNomAgent;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPNomAgent;
        private System.Windows.Forms.TextBox txtPrenomAgent;
        private System.Windows.Forms.DataGridView dgvAgent;
        private System.Windows.Forms.BindingNavigator bindingNavigator2;
        private System.Windows.Forms.ToolStripButton btnCloseAgent;
        private System.Windows.Forms.BindingNavigator bindingNavigator3;
        private System.Windows.Forms.ToolStripButton toolStripButton6;
        private System.Windows.Forms.ToolStripButton toolStripButton7;
        private System.Windows.Forms.ToolStripButton toolStripButton8;
        private System.Windows.Forms.ToolStripButton toolStripButton9;
        private System.Windows.Forms.ToolStripButton toolStripButton10;
        private System.Windows.Forms.BindingNavigator bindingNavigator1;
        private System.Windows.Forms.ToolStripButton btnAddAgent;
        private System.Windows.Forms.ToolStripButton btnRefreshAgent;
        private System.Windows.Forms.ToolStripButton btnSaveAgent;
        private System.Windows.Forms.ToolStripButton btnModifierAgent;
        private System.Windows.Forms.ToolStripButton btnDeleteAgent;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtIdAgent;
        private System.Windows.Forms.MaskedTextBox maskedTextBox1;
        private System.Windows.Forms.ComboBox cboIdService;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lblAjouterService;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtAdresseAgent;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtMatriculeAgent;
        private System.Windows.Forms.TextBox txtFonctionAgent;

    }
}
