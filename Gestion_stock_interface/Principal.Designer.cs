namespace GestionClinic_WIN
{
    partial class Principal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Principal));
            this.tblBar = new System.Windows.Forms.MenuStrip();
            this.mnFichier = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.smQuitter = new System.Windows.Forms.ToolStripMenuItem();
            this.mnAction = new System.Windows.Forms.ToolStripMenuItem();
            this.mnRapport = new System.Windows.Forms.ToolStripMenuItem();
            this.smRptListeClient = new System.Windows.Forms.ToolStripMenuItem();
            this.smRptListeFournisseur = new System.Windows.Forms.ToolStripMenuItem();
            this.smRptEtatStock = new System.Windows.Forms.ToolStripMenuItem();
            this.smRptFacture = new System.Windows.Forms.ToolStripMenuItem();
            this.mnAdministration = new System.Windows.Forms.ToolStripMenuItem();
            this.mnAide = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.smAPropos = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.statusBar = new System.Windows.Forms.StatusStrip();
            this.lblTextCPG = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.dlgFile = new System.Windows.Forms.SaveFileDialog();
            this.dlgOpen = new System.Windows.Forms.OpenFileDialog();
            this.lblApropos = new System.Windows.Forms.Label();
            this.lblAgent = new System.Windows.Forms.Label();
            this.lblFournisseur = new System.Windows.Forms.Label();
            this.lblDepot = new System.Windows.Forms.Label();
            this.lblArticle = new System.Windows.Forms.Label();
            this.lblVente = new System.Windows.Forms.Label();
            this.lblClient = new System.Windows.Forms.Label();
            this.btnQuitApp = new System.Windows.Forms.ToolStripButton();
            this.btnConnexion = new System.Windows.Forms.ToolStripButton();
            this.btnClient = new System.Windows.Forms.ToolStripButton();
            this.btnFournisseur = new System.Windows.Forms.ToolStripButton();
            this.btnVente = new System.Windows.Forms.ToolStripButton();
            this.btnLivraison = new System.Windows.Forms.ToolStripButton();
            this.btnArticle = new System.Windows.Forms.ToolStripButton();
            this.btnAgent = new System.Windows.Forms.ToolStripButton();
            this.btnAide = new System.Windows.Forms.ToolStripButton();
            this.mnConnexion = new System.Windows.Forms.ToolStripMenuItem();
            this.smDeconnexion = new System.Windows.Forms.ToolStripMenuItem();
            this.smArticle = new System.Windows.Forms.ToolStripMenuItem();
            this.smClient = new System.Windows.Forms.ToolStripMenuItem();
            this.smFournisseur = new System.Windows.Forms.ToolStripMenuItem();
            this.smLivraison = new System.Windows.Forms.ToolStripMenuItem();
            this.smAgent = new System.Windows.Forms.ToolStripMenuItem();
            this.smVente = new System.Windows.Forms.ToolStripMenuItem();
            this.smRptListeArticle = new System.Windows.Forms.ToolStripMenuItem();
            this.smGestionUser = new System.Windows.Forms.ToolStripMenuItem();
            this.smSauvegardeBd = new System.Windows.Forms.ToolStripMenuItem();
            this.smRestaurationBd = new System.Windows.Forms.ToolStripMenuItem();
            this.smContenu = new System.Windows.Forms.ToolStripMenuItem();
            this.tblBar.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.statusBar.SuspendLayout();
            this.toolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // tblBar
            // 
            this.tblBar.BackColor = System.Drawing.SystemColors.Control;
            this.tblBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnFichier,
            this.mnAction,
            this.mnAdministration,
            this.mnRapport,
            this.mnAide});
            this.tblBar.Location = new System.Drawing.Point(0, 0);
            this.tblBar.Name = "tblBar";
            this.tblBar.Size = new System.Drawing.Size(851, 24);
            this.tblBar.TabIndex = 7;
            this.tblBar.Text = "MenuStrip";
            // 
            // mnFichier
            // 
            this.mnFichier.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator2,
            this.mnConnexion,
            this.smDeconnexion,
            this.toolStripSeparator4,
            this.smQuitter});
            this.mnFichier.ImageTransparentColor = System.Drawing.SystemColors.ActiveBorder;
            this.mnFichier.Name = "mnFichier";
            this.mnFichier.Size = new System.Drawing.Size(54, 20);
            this.mnFichier.Text = "&Fichier";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(159, 6);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(159, 6);
            // 
            // smQuitter
            // 
            this.smQuitter.Name = "smQuitter";
            this.smQuitter.Size = new System.Drawing.Size(162, 22);
            this.smQuitter.Text = "Quitter";
            this.smQuitter.Click += new System.EventHandler(this.smQuitter_Click);
            // 
            // mnAction
            // 
            this.mnAction.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.smArticle,
            this.smClient,
            this.smFournisseur,
            this.smLivraison,
            this.smAgent,
            this.smVente});
            this.mnAction.Name = "mnAction";
            this.mnAction.Size = new System.Drawing.Size(59, 20);
            this.mnAction.Text = "&Actions";
            // 
            // mnRapport
            // 
            this.mnRapport.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.smRptListeArticle,
            this.smRptListeClient,
            this.smRptListeFournisseur,
            this.smRptEtatStock,
            this.smRptFacture});
            this.mnRapport.Name = "mnRapport";
            this.mnRapport.Size = new System.Drawing.Size(66, 20);
            this.mnRapport.Text = "&Rapports";
            // 
            // smRptListeClient
            // 
            this.smRptListeClient.Name = "smRptListeClient";
            this.smRptListeClient.Size = new System.Drawing.Size(186, 22);
            this.smRptListeClient.Text = "Liste des clients";
            this.smRptListeClient.Click += new System.EventHandler(this.smRptFichePaieColectiveMensuel_Click);
            // 
            // smRptListeFournisseur
            // 
            this.smRptListeFournisseur.Name = "smRptListeFournisseur";
            this.smRptListeFournisseur.Size = new System.Drawing.Size(186, 22);
            this.smRptListeFournisseur.Text = "Liste des fournisseurs";
            // 
            // smRptEtatStock
            // 
            this.smRptEtatStock.Name = "smRptEtatStock";
            this.smRptEtatStock.Size = new System.Drawing.Size(186, 22);
            this.smRptEtatStock.Text = "Etat de stock";
            this.smRptEtatStock.Click += new System.EventHandler(this.smRapportPaieAnnuelle_Click);
            // 
            // smRptFacture
            // 
            this.smRptFacture.Name = "smRptFacture";
            this.smRptFacture.Size = new System.Drawing.Size(186, 22);
            this.smRptFacture.Text = "Facture";
            this.smRptFacture.Click += new System.EventHandler(this.smRapportPaieMensuel_Click);
            // 
            // mnAdministration
            // 
            this.mnAdministration.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.smGestionUser,
            this.smSauvegardeBd,
            this.smRestaurationBd});
            this.mnAdministration.Name = "mnAdministration";
            this.mnAdministration.Size = new System.Drawing.Size(98, 20);
            this.mnAdministration.Text = "A&dministration";
            // 
            // mnAide
            // 
            this.mnAide.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.smContenu,
            this.toolStripSeparator8,
            this.smAPropos});
            this.mnAide.Name = "mnAide";
            this.mnAide.Size = new System.Drawing.Size(43, 20);
            this.mnAide.Text = "&Aide";
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(143, 6);
            // 
            // smAPropos
            // 
            this.smAPropos.Name = "smAPropos";
            this.smAPropos.Size = new System.Drawing.Size(146, 22);
            this.smAPropos.Text = "&A propos ... ...";
            this.smAPropos.Click += new System.EventHandler(this.smAPropos_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 73);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.Color.Gray;
            this.splitContainer1.Panel1.Controls.Add(this.lblApropos);
            this.splitContainer1.Panel1.Controls.Add(this.lblAgent);
            this.splitContainer1.Panel1.Controls.Add(this.lblFournisseur);
            this.splitContainer1.Panel1.Controls.Add(this.lblDepot);
            this.splitContainer1.Panel1.Controls.Add(this.lblArticle);
            this.splitContainer1.Panel1.Controls.Add(this.lblVente);
            this.splitContainer1.Panel1.Controls.Add(this.lblClient);
            this.splitContainer1.Panel1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.AutoScroll = true;
            this.splitContainer1.Panel2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.splitContainer1.Panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer1_Panel2_Paint);
            this.splitContainer1.Size = new System.Drawing.Size(851, 651);
            this.splitContainer1.SplitterDistance = 195;
            this.splitContainer1.TabIndex = 9;
            // 
            // statusBar
            // 
            this.statusBar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.statusBar.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusBar.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.statusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblTextCPG});
            this.statusBar.Location = new System.Drawing.Point(0, 724);
            this.statusBar.Name = "statusBar";
            this.statusBar.Size = new System.Drawing.Size(851, 22);
            this.statusBar.TabIndex = 10;
            // 
            // lblTextCPG
            // 
            this.lblTextCPG.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblTextCPG.Name = "lblTextCPG";
            this.lblTextCPG.Size = new System.Drawing.Size(143, 17);
            this.lblTextCPG.Text = "toolStripStatusLabel1";
            // 
            // toolStrip
            // 
            this.toolStrip.AutoSize = false;
            this.toolStrip.BackColor = System.Drawing.Color.LightGray;
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnQuitApp,
            this.toolStripSeparator6,
            this.btnConnexion,
            this.toolStripSeparator1,
            this.btnClient,
            this.btnFournisseur,
            this.btnVente,
            this.btnLivraison,
            this.btnArticle,
            this.btnAgent,
            this.toolStripSeparator3,
            this.btnAide});
            this.toolStrip.Location = new System.Drawing.Point(0, 24);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(851, 49);
            this.toolStrip.TabIndex = 8;
            this.toolStrip.Text = "ToolStrip";
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 49);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 49);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 49);
            // 
            // dlgOpen
            // 
            this.dlgOpen.FileName = "openFileDialog1";
            // 
            // lblApropos
            // 
            this.lblApropos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblApropos.BackColor = System.Drawing.Color.Transparent;
            this.lblApropos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblApropos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblApropos.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblApropos.Image = global::GestionClinic_WIN.Properties.Resources.About;
            this.lblApropos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblApropos.Location = new System.Drawing.Point(-3, 404);
            this.lblApropos.Name = "lblApropos";
            this.lblApropos.Size = new System.Drawing.Size(198, 52);
            this.lblApropos.TabIndex = 14;
            this.lblApropos.Text = "     A propos";
            this.lblApropos.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblApropos.MouseLeave += new System.EventHandler(this.lblApropos_MouseLeave);
            this.lblApropos.Click += new System.EventHandler(this.lblApropos_Click);
            this.lblApropos.MouseEnter += new System.EventHandler(this.lblApropos_MouseEnter);
            // 
            // lblAgent
            // 
            this.lblAgent.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblAgent.BackColor = System.Drawing.Color.Transparent;
            this.lblAgent.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblAgent.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAgent.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblAgent.Image = global::GestionClinic_WIN.Properties.Resources.w_aim_2xOK;
            this.lblAgent.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblAgent.Location = new System.Drawing.Point(-3, 328);
            this.lblAgent.Name = "lblAgent";
            this.lblAgent.Size = new System.Drawing.Size(201, 52);
            this.lblAgent.TabIndex = 13;
            this.lblAgent.Text = "     Agent";
            this.lblAgent.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblAgent.MouseLeave += new System.EventHandler(this.lblMagasinier_MouseLeave);
            this.lblAgent.Click += new System.EventHandler(this.lblMagasinier_Click);
            this.lblAgent.MouseEnter += new System.EventHandler(this.lblMagasinier_MouseEnter);
            // 
            // lblFournisseur
            // 
            this.lblFournisseur.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFournisseur.BackColor = System.Drawing.Color.Transparent;
            this.lblFournisseur.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblFournisseur.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFournisseur.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblFournisseur.Image = global::GestionClinic_WIN.Properties.Resources.JournLogo;
            this.lblFournisseur.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblFournisseur.Location = new System.Drawing.Point(6, 74);
            this.lblFournisseur.Name = "lblFournisseur";
            this.lblFournisseur.Size = new System.Drawing.Size(192, 52);
            this.lblFournisseur.TabIndex = 12;
            this.lblFournisseur.Text = "      Fournisseur";
            this.lblFournisseur.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblFournisseur.MouseLeave += new System.EventHandler(this.lblFournisseur_MouseLeave);
            this.lblFournisseur.Click += new System.EventHandler(this.lblFournisseur_Click);
            this.lblFournisseur.MouseEnter += new System.EventHandler(this.lblFournisseur_MouseEnter);
            // 
            // lblDepot
            // 
            this.lblDepot.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDepot.BackColor = System.Drawing.Color.Transparent;
            this.lblDepot.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblDepot.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDepot.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblDepot.Image = global::GestionClinic_WIN.Properties.Resources.navBarActionIconLandscape_2x;
            this.lblDepot.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblDepot.Location = new System.Drawing.Point(0, 198);
            this.lblDepot.Name = "lblDepot";
            this.lblDepot.Size = new System.Drawing.Size(195, 52);
            this.lblDepot.TabIndex = 11;
            this.lblDepot.Text = "       Livraison";
            this.lblDepot.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblDepot.MouseLeave += new System.EventHandler(this.lblDepot_MouseLeave);
            this.lblDepot.Click += new System.EventHandler(this.lblDepot_Click);
            this.lblDepot.MouseEnter += new System.EventHandler(this.lblDepot_MouseEnter);
            // 
            // lblArticle
            // 
            this.lblArticle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblArticle.BackColor = System.Drawing.Color.Transparent;
            this.lblArticle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblArticle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblArticle.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblArticle.Image = global::GestionClinic_WIN.Properties.Resources.Googledocs_off_2xOK;
            this.lblArticle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblArticle.Location = new System.Drawing.Point(3, 265);
            this.lblArticle.Name = "lblArticle";
            this.lblArticle.Size = new System.Drawing.Size(196, 52);
            this.lblArticle.TabIndex = 10;
            this.lblArticle.Text = "     Article";
            this.lblArticle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblArticle.MouseLeave += new System.EventHandler(this.lblArticle_MouseLeave);
            this.lblArticle.Click += new System.EventHandler(this.lblArticle_Click);
            this.lblArticle.MouseEnter += new System.EventHandler(this.lblArticle_MouseEnter);
            // 
            // lblVente
            // 
            this.lblVente.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblVente.BackColor = System.Drawing.Color.Transparent;
            this.lblVente.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblVente.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVente.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblVente.Image = global::GestionClinic_WIN.Properties.Resources.navBarComposeIconLandscape_2x;
            this.lblVente.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblVente.Location = new System.Drawing.Point(3, 132);
            this.lblVente.Name = "lblVente";
            this.lblVente.Size = new System.Drawing.Size(196, 52);
            this.lblVente.TabIndex = 8;
            this.lblVente.Text = "     Vente";
            this.lblVente.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblVente.MouseLeave += new System.EventHandler(this.lblPaiement_MouseLeave);
            this.lblVente.Click += new System.EventHandler(this.lblVente_Click);
            this.lblVente.MouseEnter += new System.EventHandler(this.lblPaiement_MouseEnter);
            // 
            // lblClient
            // 
            this.lblClient.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblClient.BackColor = System.Drawing.Color.Transparent;
            this.lblClient.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblClient.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClient.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblClient.Image = global::GestionClinic_WIN.Properties.Resources.Agent2;
            this.lblClient.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblClient.Location = new System.Drawing.Point(3, 18);
            this.lblClient.Name = "lblClient";
            this.lblClient.Size = new System.Drawing.Size(196, 52);
            this.lblClient.TabIndex = 9;
            this.lblClient.Text = "Client";
            this.lblClient.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblClient.MouseLeave += new System.EventHandler(this.lblAgent_MouseLeave);
            this.lblClient.Click += new System.EventHandler(this.lblClient_Click);
            this.lblClient.MouseEnter += new System.EventHandler(this.lblAgent_MouseEnter);
            // 
            // btnQuitApp
            // 
            this.btnQuitApp.AutoSize = false;
            this.btnQuitApp.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnQuitApp.Image = ((System.Drawing.Image)(resources.GetObject("btnQuitApp.Image")));
            this.btnQuitApp.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnQuitApp.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnQuitApp.Name = "btnQuitApp";
            this.btnQuitApp.Size = new System.Drawing.Size(50, 50);
            this.btnQuitApp.Text = "Quitter";
            // 
            // btnConnexion
            // 
            this.btnConnexion.AutoSize = false;
            this.btnConnexion.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnConnexion.Image = ((System.Drawing.Image)(resources.GetObject("btnConnexion.Image")));
            this.btnConnexion.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnConnexion.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnConnexion.Name = "btnConnexion";
            this.btnConnexion.Size = new System.Drawing.Size(50, 50);
            this.btnConnexion.Text = "Manipulations Agent";
            this.btnConnexion.ToolTipText = "Connection à la base de données";
            this.btnConnexion.Click += new System.EventHandler(this.btnConnexion_Click);
            // 
            // btnClient
            // 
            this.btnClient.AutoSize = false;
            this.btnClient.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnClient.Image = global::GestionClinic_WIN.Properties.Resources.Agent3;
            this.btnClient.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnClient.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnClient.Name = "btnClient";
            this.btnClient.Size = new System.Drawing.Size(50, 50);
            this.btnClient.Text = "Manipulations Agent";
            this.btnClient.ToolTipText = "Client";
            this.btnClient.Click += new System.EventHandler(this.btnClient_Click);
            // 
            // btnFournisseur
            // 
            this.btnFournisseur.AutoSize = false;
            this.btnFournisseur.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnFournisseur.Image = global::GestionClinic_WIN.Properties.Resources.JournLogo;
            this.btnFournisseur.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnFournisseur.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnFournisseur.Name = "btnFournisseur";
            this.btnFournisseur.Size = new System.Drawing.Size(50, 50);
            this.btnFournisseur.Text = "Fournisseur";
            this.btnFournisseur.ToolTipText = "Fournisseur";
            this.btnFournisseur.Click += new System.EventHandler(this.btnFournisseur_Click);
            // 
            // btnVente
            // 
            this.btnVente.AutoSize = false;
            this.btnVente.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnVente.Image = global::GestionClinic_WIN.Properties.Resources.navBarComposeIconLandscape_2x1;
            this.btnVente.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnVente.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnVente.Name = "btnVente";
            this.btnVente.Size = new System.Drawing.Size(50, 50);
            this.btnVente.Text = "Vente";
            this.btnVente.ToolTipText = "Vente";
            this.btnVente.Click += new System.EventHandler(this.btnVente_Click);
            // 
            // btnLivraison
            // 
            this.btnLivraison.AutoSize = false;
            this.btnLivraison.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnLivraison.Image = global::GestionClinic_WIN.Properties.Resources.Accompte1;
            this.btnLivraison.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnLivraison.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnLivraison.Name = "btnLivraison";
            this.btnLivraison.Size = new System.Drawing.Size(50, 50);
            this.btnLivraison.Text = "Livraison";
            this.btnLivraison.ToolTipText = "Livraison";
            this.btnLivraison.Click += new System.EventHandler(this.btnLivraison_Click);
            // 
            // btnArticle
            // 
            this.btnArticle.AutoSize = false;
            this.btnArticle.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnArticle.Image = global::GestionClinic_WIN.Properties.Resources.Googledocs_off_2xOK1;
            this.btnArticle.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnArticle.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnArticle.Name = "btnArticle";
            this.btnArticle.Size = new System.Drawing.Size(50, 50);
            this.btnArticle.Text = "Article";
            this.btnArticle.ToolTipText = "Article";
            this.btnArticle.Click += new System.EventHandler(this.btnArticle_Click);
            // 
            // btnAgent
            // 
            this.btnAgent.AutoSize = false;
            this.btnAgent.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnAgent.Image = global::GestionClinic_WIN.Properties.Resources.w_aim_2xOK;
            this.btnAgent.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnAgent.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAgent.Name = "btnAgent";
            this.btnAgent.Size = new System.Drawing.Size(50, 50);
            this.btnAgent.Text = "Agent";
            this.btnAgent.ToolTipText = "Agent";
            this.btnAgent.Click += new System.EventHandler(this.btnAgent_Click);
            // 
            // btnAide
            // 
            this.btnAide.AutoSize = false;
            this.btnAide.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnAide.Image = ((System.Drawing.Image)(resources.GetObject("btnAide.Image")));
            this.btnAide.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnAide.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAide.Name = "btnAide";
            this.btnAide.Size = new System.Drawing.Size(50, 50);
            this.btnAide.Text = "Aide";
            this.btnAide.Click += new System.EventHandler(this.btnAide_Click);
            // 
            // mnConnexion
            // 
            this.mnConnexion.Image = ((System.Drawing.Image)(resources.GetObject("mnConnexion.Image")));
            this.mnConnexion.Name = "mnConnexion";
            this.mnConnexion.ShortcutKeys = System.Windows.Forms.Keys.F6;
            this.mnConnexion.Size = new System.Drawing.Size(162, 22);
            this.mnConnexion.Text = "&Connexion";
            this.mnConnexion.Click += new System.EventHandler(this.mnConnexion_Click);
            // 
            // smDeconnexion
            // 
            this.smDeconnexion.Image = ((System.Drawing.Image)(resources.GetObject("smDeconnexion.Image")));
            this.smDeconnexion.Name = "smDeconnexion";
            this.smDeconnexion.ShortcutKeys = System.Windows.Forms.Keys.F4;
            this.smDeconnexion.Size = new System.Drawing.Size(162, 22);
            this.smDeconnexion.Text = "&Déconnexion";
            this.smDeconnexion.Click += new System.EventHandler(this.smDeconnexion_Click);
            // 
            // smArticle
            // 
            this.smArticle.Image = global::GestionClinic_WIN.Properties.Resources.Googledocs_off_2xOK1;
            this.smArticle.Name = "smArticle";
            this.smArticle.Size = new System.Drawing.Size(131, 22);
            this.smArticle.Text = "Article";
            this.smArticle.Click += new System.EventHandler(this.smArticle_Click);
            // 
            // smClient
            // 
            this.smClient.Image = global::GestionClinic_WIN.Properties.Resources.Agent3;
            this.smClient.Name = "smClient";
            this.smClient.Size = new System.Drawing.Size(131, 22);
            this.smClient.Text = "Client";
            this.smClient.Click += new System.EventHandler(this.smClient_Click);
            // 
            // smFournisseur
            // 
            this.smFournisseur.Image = global::GestionClinic_WIN.Properties.Resources.Agent1;
            this.smFournisseur.Name = "smFournisseur";
            this.smFournisseur.Size = new System.Drawing.Size(131, 22);
            this.smFournisseur.Text = "Founisseur";
            this.smFournisseur.Click += new System.EventHandler(this.smFournisseur_Click);
            // 
            // smLivraison
            // 
            this.smLivraison.Image = global::GestionClinic_WIN.Properties.Resources.Accompte1;
            this.smLivraison.Name = "smLivraison";
            this.smLivraison.Size = new System.Drawing.Size(131, 22);
            this.smLivraison.Text = "Livraison";
            this.smLivraison.Click += new System.EventHandler(this.smLivraison_Click);
            // 
            // smAgent
            // 
            this.smAgent.Image = global::GestionClinic_WIN.Properties.Resources.w_aim_2x;
            this.smAgent.Name = "smAgent";
            this.smAgent.Size = new System.Drawing.Size(131, 22);
            this.smAgent.Text = "Agent";
            // 
            // smVente
            // 
            this.smVente.Image = global::GestionClinic_WIN.Properties.Resources.navBarComposeIconLandscape_2x1;
            this.smVente.Name = "smVente";
            this.smVente.Size = new System.Drawing.Size(131, 22);
            this.smVente.Text = "Vente";
            // 
            // smRptListeArticle
            // 
            this.smRptListeArticle.Image = ((System.Drawing.Image)(resources.GetObject("smRptListeArticle.Image")));
            this.smRptListeArticle.Name = "smRptListeArticle";
            this.smRptListeArticle.Size = new System.Drawing.Size(186, 22);
            this.smRptListeArticle.Text = "Liste des articles";
            this.smRptListeArticle.Click += new System.EventHandler(this.smRptFichePaieIndiv_Click);
            // 
            // smGestionUser
            // 
            this.smGestionUser.Image = ((System.Drawing.Image)(resources.GetObject("smGestionUser.Image")));
            this.smGestionUser.Name = "smGestionUser";
            this.smGestionUser.Size = new System.Drawing.Size(231, 22);
            this.smGestionUser.Text = "Gestion utilisateurs";
            this.smGestionUser.Click += new System.EventHandler(this.smGestionUser_Click);
            // 
            // smSauvegardeBd
            // 
            this.smSauvegardeBd.Image = ((System.Drawing.Image)(resources.GetObject("smSauvegardeBd.Image")));
            this.smSauvegardeBd.Name = "smSauvegardeBd";
            this.smSauvegardeBd.Size = new System.Drawing.Size(231, 22);
            this.smSauvegardeBd.Text = "Sauvegarde base des données";
            this.smSauvegardeBd.Click += new System.EventHandler(this.smSauvegardeBd_Click);
            // 
            // smRestaurationBd
            // 
            this.smRestaurationBd.Image = ((System.Drawing.Image)(resources.GetObject("smRestaurationBd.Image")));
            this.smRestaurationBd.Name = "smRestaurationBd";
            this.smRestaurationBd.Size = new System.Drawing.Size(231, 22);
            this.smRestaurationBd.Text = "Restaurer base des données";
            this.smRestaurationBd.Click += new System.EventHandler(this.smRestaurationBd_Click);
            // 
            // smContenu
            // 
            this.smContenu.Image = ((System.Drawing.Image)(resources.GetObject("smContenu.Image")));
            this.smContenu.Name = "smContenu";
            this.smContenu.ShortcutKeys = System.Windows.Forms.Keys.F1;
            this.smContenu.Size = new System.Drawing.Size(146, 22);
            this.smContenu.Text = "C&ontenu";
            // 
            // Principal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(851, 746);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.statusBar);
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.tblBar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.Name = "Principal";
            this.Text = "Gestion de stock";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Principal_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Principal_FormClosing);
            this.tblBar.ResumeLayout(false);
            this.tblBar.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.statusBar.ResumeLayout(false);
            this.statusBar.PerformLayout();
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton btnQuitApp;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnVente;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton btnAide;
        private System.Windows.Forms.MenuStrip tblBar;
        private System.Windows.Forms.ToolStripMenuItem mnFichier;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem smDeconnexion;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem smQuitter;
        private System.Windows.Forms.ToolStripMenuItem mnAction;
        private System.Windows.Forms.ToolStripMenuItem smArticle;
        private System.Windows.Forms.ToolStripMenuItem mnRapport;
        private System.Windows.Forms.ToolStripMenuItem smRptListeArticle;
        private System.Windows.Forms.ToolStripMenuItem smRptListeClient;
        private System.Windows.Forms.ToolStripMenuItem smRptEtatStock;
        private System.Windows.Forms.ToolStripMenuItem mnAide;
        private System.Windows.Forms.ToolStripMenuItem smContenu;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.ToolStripMenuItem smAPropos;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label lblArticle;
        private System.Windows.Forms.Label lblVente;
        private System.Windows.Forms.StatusStrip statusBar;
        private System.Windows.Forms.ToolStripMenuItem smFournisseur;
        private System.Windows.Forms.ToolStripMenuItem smRptListeFournisseur;
        private System.Windows.Forms.ToolStripButton btnLivraison;
        private System.Windows.Forms.ToolStripStatusLabel lblTextCPG;
        private System.Windows.Forms.ToolStripMenuItem mnConnexion;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripButton btnConnexion;
        public System.Windows.Forms.Label lblClient;
        private System.Windows.Forms.ToolStripButton btnClient;
        private System.Windows.Forms.ToolStripMenuItem smClient;
        private System.Windows.Forms.Label lblDepot;
        private System.Windows.Forms.ToolStripMenuItem smRptFacture;
        public System.Windows.Forms.Label lblFournisseur;
        private System.Windows.Forms.ToolStripMenuItem smAgent;
        private System.Windows.Forms.ToolStripButton btnFournisseur;
        private System.Windows.Forms.Label lblApropos;
        private System.Windows.Forms.Label lblAgent;
        private System.Windows.Forms.ToolStripMenuItem smLivraison;
        private System.Windows.Forms.ToolStripMenuItem smVente;
        private System.Windows.Forms.ToolStripMenuItem mnAdministration;
        private System.Windows.Forms.ToolStripMenuItem smGestionUser;
        private System.Windows.Forms.ToolStripMenuItem smSauvegardeBd;
        private System.Windows.Forms.ToolStripMenuItem smRestaurationBd;
        private System.Windows.Forms.ToolStripButton btnArticle;
        private System.Windows.Forms.ToolStripButton btnAgent;
        private System.Windows.Forms.SaveFileDialog dlgFile;
        private System.Windows.Forms.OpenFileDialog dlgOpen;
    }
}

