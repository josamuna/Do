namespace GestionClinic_WIN
{
    partial class rptListeClient
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(rptListeClient));
            this.bindingNavigator2 = new System.Windows.Forms.BindingNavigator(this.components);
            this.btnCloseAgent = new System.Windows.Forms.ToolStripButton();
            this.rptListeClientF = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator2)).BeginInit();
            this.bindingNavigator2.SuspendLayout();
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
            this.bindingNavigator2.Size = new System.Drawing.Size(911, 25);
            this.bindingNavigator2.TabIndex = 136;
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
            // rptListeClientF
            // 
            this.rptListeClientF.ActiveViewIndex = -1;
            this.rptListeClientF.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rptListeClientF.Location = new System.Drawing.Point(0, 28);
            this.rptListeClientF.Name = "rptListeClientF";
            this.rptListeClientF.SelectionFormula = "";
            this.rptListeClientF.Size = new System.Drawing.Size(908, 412);
            this.rptListeClientF.TabIndex = 137;
            this.rptListeClientF.ViewTimeSelectionFormula = "";
            this.rptListeClientF.Load += new System.EventHandler(this.rptListeClientF_Load);
            // 
            // rptListeClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.rptListeClientF);
            this.Controls.Add(this.bindingNavigator2);
            this.Name = "rptListeClient";
            this.Size = new System.Drawing.Size(911, 443);
            this.Load += new System.EventHandler(this.rptListeClient_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator2)).EndInit();
            this.bindingNavigator2.ResumeLayout(false);
            this.bindingNavigator2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingNavigator bindingNavigator2;
        private System.Windows.Forms.ToolStripButton btnCloseAgent;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer rptListeClientF;

    }
}
