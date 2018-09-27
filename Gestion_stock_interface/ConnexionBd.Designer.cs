namespace GestionClinic_WIN
{
    partial class ConnexionBd
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConnexionBd));
            this.bnavSvc = new System.Windows.Forms.BindingNavigator(this.components);
            this.btfermer = new System.Windows.Forms.ToolStripButton();
            this.cmdConnect = new System.Windows.Forms.Button();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.txtBD = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cboServeur = new System.Windows.Forms.ComboBox();
            this.txtMotPass = new System.Windows.Forms.TextBox();
            this.txtNomUser = new System.Windows.Forms.TextBox();
            this.lblPwdUser = new System.Windows.Forms.Label();
            this.lblUserId = new System.Windows.Forms.Label();
            this.lblServeur = new System.Windows.Forms.Label();
            this.txtPwdUserSimple = new System.Windows.Forms.TextBox();
            this.txtUserSimple = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.bnavSvc)).BeginInit();
            this.bnavSvc.SuspendLayout();
            this.SuspendLayout();
            // 
            // bnavSvc
            // 
            this.bnavSvc.AddNewItem = null;
            this.bnavSvc.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bnavSvc.BackgroundImage")));
            this.bnavSvc.CountItem = null;
            this.bnavSvc.DeleteItem = null;
            this.bnavSvc.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.bnavSvc.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btfermer});
            this.bnavSvc.Location = new System.Drawing.Point(0, 0);
            this.bnavSvc.MoveFirstItem = null;
            this.bnavSvc.MoveLastItem = null;
            this.bnavSvc.MoveNextItem = null;
            this.bnavSvc.MovePreviousItem = null;
            this.bnavSvc.Name = "bnavSvc";
            this.bnavSvc.PositionItem = null;
            this.bnavSvc.Size = new System.Drawing.Size(412, 25);
            this.bnavSvc.TabIndex = 81;
            this.bnavSvc.Text = "bindingNavigator1";
            // 
            // btfermer
            // 
            this.btfermer.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btfermer.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btfermer.Image = ((System.Drawing.Image)(resources.GetObject("btfermer.Image")));
            this.btfermer.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btfermer.Name = "btfermer";
            this.btfermer.Size = new System.Drawing.Size(23, 22);
            this.btfermer.Text = "Fermer";
            this.btfermer.Click += new System.EventHandler(this.btfermer_Click);
            // 
            // cmdConnect
            // 
            this.cmdConnect.Image = ((System.Drawing.Image)(resources.GetObject("cmdConnect.Image")));
            this.cmdConnect.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdConnect.Location = new System.Drawing.Point(234, 219);
            this.cmdConnect.Name = "cmdConnect";
            this.cmdConnect.Size = new System.Drawing.Size(82, 26);
            this.cmdConnect.TabIndex = 8;
            this.cmdConnect.Text = "Co&nnecter";
            this.cmdConnect.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdConnect.UseVisualStyleBackColor = true;
            this.cmdConnect.Click += new System.EventHandler(this.cmdConnect_Click);
            // 
            // cmdCancel
            // 
            this.cmdCancel.Image = ((System.Drawing.Image)(resources.GetObject("cmdCancel.Image")));
            this.cmdCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdCancel.Location = new System.Drawing.Point(322, 219);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(74, 26);
            this.cmdCancel.TabIndex = 9;
            this.cmdCancel.Text = "&Annuler";
            this.cmdCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdCancel.UseVisualStyleBackColor = true;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // txtBD
            // 
            this.txtBD.Location = new System.Drawing.Point(161, 65);
            this.txtBD.Name = "txtBD";
            this.txtBD.Size = new System.Drawing.Size(235, 20);
            this.txtBD.TabIndex = 86;
            // 
            // label2
            // 
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(12, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 15);
            this.label2.TabIndex = 93;
            this.label2.Text = "Base de données :";
            // 
            // cboServeur
            // 
            this.cboServeur.FormattingEnabled = true;
            this.cboServeur.Location = new System.Drawing.Point(161, 38);
            this.cboServeur.Name = "cboServeur";
            this.cboServeur.Size = new System.Drawing.Size(235, 21);
            this.cboServeur.TabIndex = 85;
            // 
            // txtMotPass
            // 
            this.txtMotPass.Location = new System.Drawing.Point(161, 123);
            this.txtMotPass.Name = "txtMotPass";
            this.txtMotPass.PasswordChar = '*';
            this.txtMotPass.Size = new System.Drawing.Size(235, 20);
            this.txtMotPass.TabIndex = 89;
            this.txtMotPass.Text = "ijn";
            // 
            // txtNomUser
            // 
            this.txtNomUser.Location = new System.Drawing.Point(161, 94);
            this.txtNomUser.Name = "txtNomUser";
            this.txtNomUser.Size = new System.Drawing.Size(235, 20);
            this.txtNomUser.TabIndex = 88;
            // 
            // lblPwdUser
            // 
            this.lblPwdUser.AutoSize = true;
            this.lblPwdUser.ForeColor = System.Drawing.Color.Black;
            this.lblPwdUser.Location = new System.Drawing.Point(12, 128);
            this.lblPwdUser.Name = "lblPwdUser";
            this.lblPwdUser.Size = new System.Drawing.Size(77, 13);
            this.lblPwdUser.TabIndex = 92;
            this.lblPwdUser.Text = "Mot de passe :";
            // 
            // lblUserId
            // 
            this.lblUserId.AutoSize = true;
            this.lblUserId.ForeColor = System.Drawing.Color.Black;
            this.lblUserId.Location = new System.Drawing.Point(12, 98);
            this.lblUserId.Name = "lblUserId";
            this.lblUserId.Size = new System.Drawing.Size(101, 13);
            this.lblUserId.TabIndex = 91;
            this.lblUserId.Text = "Nom de l\'utilisateur :";
            // 
            // lblServeur
            // 
            this.lblServeur.AutoSize = true;
            this.lblServeur.ForeColor = System.Drawing.Color.Black;
            this.lblServeur.Location = new System.Drawing.Point(13, 41);
            this.lblServeur.Name = "lblServeur";
            this.lblServeur.Size = new System.Drawing.Size(88, 13);
            this.lblServeur.TabIndex = 90;
            this.lblServeur.Text = "Nom du serveur :";
            // 
            // txtPwdUserSimple
            // 
            this.txtPwdUserSimple.ForeColor = System.Drawing.Color.White;
            this.txtPwdUserSimple.Location = new System.Drawing.Point(160, 180);
            this.txtPwdUserSimple.Name = "txtPwdUserSimple";
            this.txtPwdUserSimple.PasswordChar = '*';
            this.txtPwdUserSimple.Size = new System.Drawing.Size(236, 20);
            this.txtPwdUserSimple.TabIndex = 95;
            this.txtPwdUserSimple.Text = "superpassword";
            // 
            // txtUserSimple
            // 
            this.txtUserSimple.Location = new System.Drawing.Point(161, 154);
            this.txtUserSimple.Name = "txtUserSimple";
            this.txtUserSimple.Size = new System.Drawing.Size(235, 20);
            this.txtUserSimple.TabIndex = 94;
            this.txtUserSimple.Text = "superuser";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(11, 185);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(77, 13);
            this.label7.TabIndex = 97;
            this.label7.Text = "Mot de passe :";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(11, 158);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(85, 13);
            this.label8.TabIndex = 96;
            this.label8.Text = "Nom utilisateur  :";
            // 
            // ConnexionBd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.txtPwdUserSimple);
            this.Controls.Add(this.txtUserSimple);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdConnect);
            this.Controls.Add(this.txtBD);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cboServeur);
            this.Controls.Add(this.txtMotPass);
            this.Controls.Add(this.txtNomUser);
            this.Controls.Add(this.lblPwdUser);
            this.Controls.Add(this.lblUserId);
            this.Controls.Add(this.lblServeur);
            this.Controls.Add(this.bnavSvc);
            this.Name = "ConnexionBd";
            this.Size = new System.Drawing.Size(412, 261);
            this.Load += new System.EventHandler(this.ConnexionBd_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bnavSvc)).EndInit();
            this.bnavSvc.ResumeLayout(false);
            this.bnavSvc.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingNavigator bnavSvc;
        private System.Windows.Forms.ToolStripButton btfermer;
        private System.Windows.Forms.Button cmdConnect;
        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.TextBox txtBD;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboServeur;
        private System.Windows.Forms.TextBox txtMotPass;
        private System.Windows.Forms.TextBox txtNomUser;
        private System.Windows.Forms.Label lblPwdUser;
        private System.Windows.Forms.Label lblUserId;
        private System.Windows.Forms.Label lblServeur;
        private System.Windows.Forms.TextBox txtPwdUserSimple;
        private System.Windows.Forms.TextBox txtUserSimple;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
    }
}
