namespace GestionClinic_WIN
{
    partial class ArticleForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ArticleForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.bindingNavigator1 = new System.Windows.Forms.BindingNavigator(this.components);
            this.btnAddArt = new System.Windows.Forms.ToolStripButton();
            this.btnRefreshArt = new System.Windows.Forms.ToolStripButton();
            this.btnSaveArticle = new System.Windows.Forms.ToolStripButton();
            this.btnModifierArticle = new System.Windows.Forms.ToolStripButton();
            this.deleteArticle = new System.Windows.Forms.ToolStripButton();
            this.cboCatArticle = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtIdArt = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDesignArt = new System.Windows.Forms.TextBox();
            this.txtPu = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.bindingNavigator3 = new System.Windows.Forms.BindingNavigator(this.components);
            this.btnAddCatArt = new System.Windows.Forms.ToolStripButton();
            this.btnrefreshCat = new System.Windows.Forms.ToolStripButton();
            this.btnSaveCat = new System.Windows.Forms.ToolStripButton();
            this.btnModifyCat = new System.Windows.Forms.ToolStripButton();
            this.btnDeleteCat = new System.Windows.Forms.ToolStripButton();
            this.label1 = new System.Windows.Forms.Label();
            this.txtIdCatArt = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDesignCatArt = new System.Windows.Forms.TextBox();
            this.dtCatArt = new System.Windows.Forms.DataGridView();
            this.dtArticle = new System.Windows.Forms.DataGridView();
            this.bindingNavigator2 = new System.Windows.Forms.BindingNavigator(this.components);
            this.btnCloseAgent = new System.Windows.Forms.ToolStripButton();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).BeginInit();
            this.bindingNavigator1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator3)).BeginInit();
            this.bindingNavigator3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtCatArt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtArticle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator2)).BeginInit();
            this.bindingNavigator2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.groupBox1.Controls.Add(this.bindingNavigator1);
            this.groupBox1.Controls.Add(this.cboCatArticle);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtIdArt);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtDesignArt);
            this.groupBox1.Controls.Add(this.txtPu);
            this.groupBox1.Location = new System.Drawing.Point(3, 26);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(379, 201);
            this.groupBox1.TabIndex = 138;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Article";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // bindingNavigator1
            // 
            this.bindingNavigator1.AddNewItem = null;
            this.bindingNavigator1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bindingNavigator1.BackgroundImage")));
            this.bindingNavigator1.CountItem = null;
            this.bindingNavigator1.DeleteItem = null;
            this.bindingNavigator1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.bindingNavigator1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAddArt,
            this.btnRefreshArt,
            this.btnSaveArticle,
            this.btnModifierArticle,
            this.deleteArticle});
            this.bindingNavigator1.Location = new System.Drawing.Point(3, 16);
            this.bindingNavigator1.MoveFirstItem = null;
            this.bindingNavigator1.MoveLastItem = null;
            this.bindingNavigator1.MoveNextItem = null;
            this.bindingNavigator1.MovePreviousItem = null;
            this.bindingNavigator1.Name = "bindingNavigator1";
            this.bindingNavigator1.PositionItem = null;
            this.bindingNavigator1.Size = new System.Drawing.Size(373, 25);
            this.bindingNavigator1.TabIndex = 147;
            this.bindingNavigator1.Text = "bindingNavigator1";
            // 
            // btnAddArt
            // 
            this.btnAddArt.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnAddArt.Image = global::GestionClinic_WIN.Properties.Resources.navBarAddIcon_2x;
            this.btnAddArt.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAddArt.Name = "btnAddArt";
            this.btnAddArt.Size = new System.Drawing.Size(23, 22);
            this.btnAddArt.Text = "Ajouter";
            this.btnAddArt.Click += new System.EventHandler(this.btnAddArt_Click);
            // 
            // btnRefreshArt
            // 
            this.btnRefreshArt.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnRefreshArt.Image = global::GestionClinic_WIN.Properties.Resources.update;
            this.btnRefreshArt.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRefreshArt.Name = "btnRefreshArt";
            this.btnRefreshArt.Size = new System.Drawing.Size(23, 22);
            this.btnRefreshArt.Text = "Refresh";
            this.btnRefreshArt.Click += new System.EventHandler(this.btnRefreshArt_Click);
            // 
            // btnSaveArticle
            // 
            this.btnSaveArticle.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnSaveArticle.Image = global::GestionClinic_WIN.Properties.Resources.check_2x;
            this.btnSaveArticle.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSaveArticle.Name = "btnSaveArticle";
            this.btnSaveArticle.Size = new System.Drawing.Size(23, 22);
            this.btnSaveArticle.Text = "Enregistrer";
            this.btnSaveArticle.Click += new System.EventHandler(this.btnSaveArticle_Click);
            // 
            // btnModifierArticle
            // 
            this.btnModifierArticle.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnModifierArticle.Image = ((System.Drawing.Image)(resources.GetObject("btnModifierArticle.Image")));
            this.btnModifierArticle.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnModifierArticle.Name = "btnModifierArticle";
            this.btnModifierArticle.Size = new System.Drawing.Size(23, 22);
            this.btnModifierArticle.Text = "Modifier";
            this.btnModifierArticle.Click += new System.EventHandler(this.btnModifierArticle_Click);
            // 
            // deleteArticle
            // 
            this.deleteArticle.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.deleteArticle.Image = global::GestionClinic_WIN.Properties.Resources.mp_delete_md_n_lt_2x;
            this.deleteArticle.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.deleteArticle.Name = "deleteArticle";
            this.deleteArticle.Size = new System.Drawing.Size(23, 22);
            this.deleteArticle.Text = "Supprimer";
            this.deleteArticle.Click += new System.EventHandler(this.deleteArticle_Click);
            // 
            // cboCatArticle
            // 
            this.cboCatArticle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCatArticle.FormattingEnabled = true;
            this.cboCatArticle.Location = new System.Drawing.Point(117, 143);
            this.cboCatArticle.Name = "cboCatArticle";
            this.cboCatArticle.Size = new System.Drawing.Size(181, 21);
            this.cboCatArticle.TabIndex = 15;
            this.cboCatArticle.SelectedIndexChanged += new System.EventHandler(this.cboCatArticle_SelectedIndexChanged);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(17, 148);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(52, 13);
            this.label15.TabIndex = 119;
            this.label15.Text = "Catégorie";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(16, 61);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(22, 13);
            this.label11.TabIndex = 26;
            this.label11.Text = "Id :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 121);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Prix unitaire :";
            // 
            // txtIdArt
            // 
            this.txtIdArt.Enabled = false;
            this.txtIdArt.Location = new System.Drawing.Point(117, 57);
            this.txtIdArt.Name = "txtIdArt";
            this.txtIdArt.Size = new System.Drawing.Size(215, 20);
            this.txtIdArt.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 91);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Designation";
            // 
            // txtDesignArt
            // 
            this.txtDesignArt.Location = new System.Drawing.Point(116, 86);
            this.txtDesignArt.Name = "txtDesignArt";
            this.txtDesignArt.Size = new System.Drawing.Size(215, 20);
            this.txtDesignArt.TabIndex = 3;
            // 
            // txtPu
            // 
            this.txtPu.Location = new System.Drawing.Point(116, 117);
            this.txtPu.Name = "txtPu";
            this.txtPu.Size = new System.Drawing.Size(215, 20);
            this.txtPu.TabIndex = 4;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.groupBox2.Controls.Add(this.bindingNavigator3);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.txtIdCatArt);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.txtDesignCatArt);
            this.groupBox2.Controls.Add(this.dtCatArt);
            this.groupBox2.Location = new System.Drawing.Point(393, 31);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(338, 196);
            this.groupBox2.TabIndex = 139;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Catégorie Article";
            // 
            // bindingNavigator3
            // 
            this.bindingNavigator3.AddNewItem = null;
            this.bindingNavigator3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bindingNavigator3.BackgroundImage")));
            this.bindingNavigator3.CountItem = null;
            this.bindingNavigator3.DeleteItem = null;
            this.bindingNavigator3.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.bindingNavigator3.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAddCatArt,
            this.btnrefreshCat,
            this.btnSaveCat,
            this.btnModifyCat,
            this.btnDeleteCat});
            this.bindingNavigator3.Location = new System.Drawing.Point(3, 16);
            this.bindingNavigator3.MoveFirstItem = null;
            this.bindingNavigator3.MoveLastItem = null;
            this.bindingNavigator3.MoveNextItem = null;
            this.bindingNavigator3.MovePreviousItem = null;
            this.bindingNavigator3.Name = "bindingNavigator3";
            this.bindingNavigator3.PositionItem = null;
            this.bindingNavigator3.Size = new System.Drawing.Size(332, 25);
            this.bindingNavigator3.TabIndex = 147;
            this.bindingNavigator3.Text = "bindingNavigator3";
            // 
            // btnAddCatArt
            // 
            this.btnAddCatArt.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnAddCatArt.Image = global::GestionClinic_WIN.Properties.Resources.navBarAddIcon_2x;
            this.btnAddCatArt.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAddCatArt.Name = "btnAddCatArt";
            this.btnAddCatArt.Size = new System.Drawing.Size(23, 22);
            this.btnAddCatArt.Text = "Ajouter";
            this.btnAddCatArt.Click += new System.EventHandler(this.btnAddCatArt_Click);
            // 
            // btnrefreshCat
            // 
            this.btnrefreshCat.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnrefreshCat.Image = global::GestionClinic_WIN.Properties.Resources.update;
            this.btnrefreshCat.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnrefreshCat.Name = "btnrefreshCat";
            this.btnrefreshCat.Size = new System.Drawing.Size(23, 22);
            this.btnrefreshCat.Text = "Refresh";
            this.btnrefreshCat.Click += new System.EventHandler(this.btnrefreshCat_Click);
            // 
            // btnSaveCat
            // 
            this.btnSaveCat.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnSaveCat.Image = global::GestionClinic_WIN.Properties.Resources.check_2x;
            this.btnSaveCat.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSaveCat.Name = "btnSaveCat";
            this.btnSaveCat.Size = new System.Drawing.Size(23, 22);
            this.btnSaveCat.Text = "Enregistrer";
            this.btnSaveCat.Click += new System.EventHandler(this.btnSaveCat_Click);
            // 
            // btnModifyCat
            // 
            this.btnModifyCat.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnModifyCat.Image = ((System.Drawing.Image)(resources.GetObject("btnModifyCat.Image")));
            this.btnModifyCat.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnModifyCat.Name = "btnModifyCat";
            this.btnModifyCat.Size = new System.Drawing.Size(23, 22);
            this.btnModifyCat.Text = "Modifier";
            this.btnModifyCat.Click += new System.EventHandler(this.btnModifyCat_Click);
            // 
            // btnDeleteCat
            // 
            this.btnDeleteCat.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnDeleteCat.Image = global::GestionClinic_WIN.Properties.Resources.mp_delete_md_n_lt_2x;
            this.btnDeleteCat.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDeleteCat.Name = "btnDeleteCat";
            this.btnDeleteCat.Size = new System.Drawing.Size(23, 22);
            this.btnDeleteCat.Text = "Supprimer";
            this.btnDeleteCat.Click += new System.EventHandler(this.btnDeleteCat_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(22, 13);
            this.label1.TabIndex = 142;
            this.label1.Text = "Id :";
            // 
            // txtIdCatArt
            // 
            this.txtIdCatArt.Enabled = false;
            this.txtIdCatArt.Location = new System.Drawing.Point(111, 53);
            this.txtIdCatArt.Name = "txtIdCatArt";
            this.txtIdCatArt.Size = new System.Drawing.Size(215, 20);
            this.txtIdCatArt.TabIndex = 139;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 141;
            this.label2.Text = "Designation";
            // 
            // txtDesignCatArt
            // 
            this.txtDesignCatArt.Location = new System.Drawing.Point(110, 82);
            this.txtDesignCatArt.Name = "txtDesignCatArt";
            this.txtDesignCatArt.Size = new System.Drawing.Size(215, 20);
            this.txtDesignCatArt.TabIndex = 140;
            // 
            // dtCatArt
            // 
            this.dtCatArt.AllowUserToAddRows = false;
            this.dtCatArt.AllowUserToDeleteRows = false;
            this.dtCatArt.BackgroundColor = System.Drawing.SystemColors.ButtonShadow;
            this.dtCatArt.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtCatArt.Location = new System.Drawing.Point(13, 115);
            this.dtCatArt.MultiSelect = false;
            this.dtCatArt.Name = "dtCatArt";
            this.dtCatArt.ReadOnly = true;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtCatArt.RowHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dtCatArt.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtCatArt.Size = new System.Drawing.Size(312, 70);
            this.dtCatArt.TabIndex = 132;
            this.dtCatArt.SelectionChanged += new System.EventHandler(this.dtCatArt_SelectionChanged);
            // 
            // dtArticle
            // 
            this.dtArticle.AllowUserToAddRows = false;
            this.dtArticle.AllowUserToDeleteRows = false;
            this.dtArticle.BackgroundColor = System.Drawing.SystemColors.ButtonShadow;
            this.dtArticle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtArticle.Location = new System.Drawing.Point(6, 230);
            this.dtArticle.MultiSelect = false;
            this.dtArticle.Name = "dtArticle";
            this.dtArticle.ReadOnly = true;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtArticle.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dtArticle.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtArticle.Size = new System.Drawing.Size(725, 86);
            this.dtArticle.TabIndex = 143;
            this.dtArticle.SelectionChanged += new System.EventHandler(this.dtArticle_SelectionChanged);
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
            this.bindingNavigator2.Size = new System.Drawing.Size(739, 25);
            this.bindingNavigator2.TabIndex = 144;
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
            // ArticleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.Controls.Add(this.bindingNavigator2);
            this.Controls.Add(this.dtArticle);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "ArticleForm";
            this.Size = new System.Drawing.Size(739, 326);
            this.Load += new System.EventHandler(this.ArticleForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).EndInit();
            this.bindingNavigator1.ResumeLayout(false);
            this.bindingNavigator1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator3)).EndInit();
            this.bindingNavigator3.ResumeLayout(false);
            this.bindingNavigator3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtCatArt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtArticle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator2)).EndInit();
            this.bindingNavigator2.ResumeLayout(false);
            this.bindingNavigator2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cboCatArticle;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtIdArt;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDesignArt;
        private System.Windows.Forms.TextBox txtPu;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtIdCatArt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDesignCatArt;
        private System.Windows.Forms.DataGridView dtCatArt;
        private System.Windows.Forms.DataGridView dtArticle;
        private System.Windows.Forms.BindingNavigator bindingNavigator2;
        private System.Windows.Forms.ToolStripButton btnCloseAgent;
        private System.Windows.Forms.BindingNavigator bindingNavigator1;
        private System.Windows.Forms.ToolStripButton btnAddArt;
        private System.Windows.Forms.ToolStripButton btnRefreshArt;
        private System.Windows.Forms.ToolStripButton btnSaveArticle;
        private System.Windows.Forms.ToolStripButton btnModifierArticle;
        private System.Windows.Forms.ToolStripButton deleteArticle;
        private System.Windows.Forms.BindingNavigator bindingNavigator3;
        private System.Windows.Forms.ToolStripButton btnAddCatArt;
        private System.Windows.Forms.ToolStripButton btnrefreshCat;
        private System.Windows.Forms.ToolStripButton btnSaveCat;
        private System.Windows.Forms.ToolStripButton btnModifyCat;
        private System.Windows.Forms.ToolStripButton btnDeleteCat;
    }
}
