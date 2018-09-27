namespace GestionClinic_WIN
{
    partial class FactureFrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FactureFrm));
            this.bindingNavigator2 = new System.Windows.Forms.BindingNavigator(this.components);
            this.rptvFacture = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnValider = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cboClient = new System.Windows.Forms.ComboBox();
            this.btnCloseAgent = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator2)).BeginInit();
            this.bindingNavigator2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
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
            this.bindingNavigator2.Size = new System.Drawing.Size(828, 25);
            this.bindingNavigator2.TabIndex = 141;
            this.bindingNavigator2.Text = "bindingNavigator2";
            // 
            // rptvFacture
            // 
            this.rptvFacture.ActiveViewIndex = -1;
            this.rptvFacture.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rptvFacture.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rptvFacture.Location = new System.Drawing.Point(0, 25);
            this.rptvFacture.Name = "rptvFacture";
            this.rptvFacture.SelectionFormula = "";
            this.rptvFacture.Size = new System.Drawing.Size(828, 430);
            this.rptvFacture.TabIndex = 142;
            this.rptvFacture.ViewTimeSelectionFormula = "";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btnValider);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.cboClient);
            this.panel1.Location = new System.Drawing.Point(3, 55);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(141, 108);
            this.panel1.TabIndex = 143;
            // 
            // btnValider
            // 
            this.btnValider.Location = new System.Drawing.Point(39, 71);
            this.btnValider.Name = "btnValider";
            this.btnValider.Size = new System.Drawing.Size(65, 23);
            this.btnValider.TabIndex = 2;
            this.btnValider.Text = "Valider";
            this.btnValider.UseVisualStyleBackColor = true;
            this.btnValider.Click += new System.EventHandler(this.btnValider_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Choix du client";
            // 
            // cboClient
            // 
            this.cboClient.FormattingEnabled = true;
            this.cboClient.Location = new System.Drawing.Point(3, 35);
            this.cboClient.Name = "cboClient";
            this.cboClient.Size = new System.Drawing.Size(133, 21);
            this.cboClient.TabIndex = 0;
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
            // FactureFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.rptvFacture);
            this.Controls.Add(this.bindingNavigator2);
            this.Name = "FactureFrm";
            this.Size = new System.Drawing.Size(828, 455);
            this.Load += new System.EventHandler(this.FactureFrm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator2)).EndInit();
            this.bindingNavigator2.ResumeLayout(false);
            this.bindingNavigator2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingNavigator bindingNavigator2;
        private System.Windows.Forms.ToolStripButton btnCloseAgent;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer rptvFacture;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnValider;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboClient;
    }
}
