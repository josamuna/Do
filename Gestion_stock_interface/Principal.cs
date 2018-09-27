using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GestionClinic_LIB;
using Microsoft.VisualBasic;

namespace GestionClinic_WIN
{
    public partial class Principal : Form
    {
        public Principal()
        {
            InitializeComponent();
            lblTextCPG.Text = "Copyright © 2013 Josué ISAMUNA - Prisma Entreprise";
        }

        private void lblAgent_MouseEnter(object sender, EventArgs e)
        {
            ((Control)lblClient).ForeColor = Color.BlueViolet;
            ((Control)lblClient).BackColor = Color.FromArgb(153,180,209);
        }

        private void lblAgent_MouseLeave(object sender, EventArgs e)
        {
            ((Control)lblClient).ForeColor = Color.White;
            ((Control)lblClient).BackColor = Color.Transparent;
        }
        private void smQuitter_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Voulez - vous vraiment quitter l'application ?", "Quitter l'applcation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                Application.Exit();
            }

            try
            {
                Factory.Instance.closeConnection();
            }
            catch (Exception) { }
        }

        private void Principal_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                Factory.Instance.closeConnection();
                //Factory.Instance.EmptyFileParametersUser();
            }
            catch (Exception) { }

            Application.Exit();
        }

        private void lblPaiement_MouseEnter(object sender, EventArgs e)
        {
            ((Control)lblVente).ForeColor = Color.BlueViolet;
            ((Control)lblVente).BackColor = Color.FromArgb(153, 180, 209);
        }

        private void lblPaiement_MouseLeave(object sender, EventArgs e)
        {
            ((Control)lblVente).ForeColor = Color.White;
            ((Control)lblVente).BackColor = Color.Transparent;
        }

        private void smAPropos_Click(object sender, EventArgs e)
        {
            this.splitContainer1.Panel2.Controls.Clear();

            Apropos frm = new Apropos();
            frm.Parent = this.splitContainer1.Panel2;
            this.splitContainer1.Panel2.Controls.Add(frm);
        }

        private void smDeconnexion_Click(object sender, EventArgs e)
        {
            this.splitContainer1.Panel2.Controls.Clear();

            menuDes();
        }
     
        private void lblClient_Click(object sender, EventArgs e)
        {
            this.splitContainer1.Panel2.Controls.Clear();

            ClientForm frm = new ClientForm();
            frm.Parent = this.splitContainer1.Panel2;
            this.splitContainer1.Panel2.Controls.Add(frm);
        }

        private void lblFournisseur_Click(object sender, EventArgs e)
        {
            this.splitContainer1.Panel2.Controls.Clear();

            FournisseurForm frm = new FournisseurForm();
            frm.Parent = this.splitContainer1.Panel2;
            this.splitContainer1.Panel2.Controls.Add(frm);
        }

        private void lblVente_Click(object sender, EventArgs e)
        {
            this.splitContainer1.Panel2.Controls.Clear();

            VenteForm frm = new VenteForm();
            frm.Parent = this.splitContainer1.Panel2;
            this.splitContainer1.Panel2.Controls.Add(frm);
        }

        public void menuDes() 
        {
            lblArticle.Enabled = false;
            lblClient.Enabled = false;
            lblDepot.Enabled = false;
            lblFournisseur.Enabled = false;
            lblAgent.Enabled = false;
            lblVente.Enabled = false;

            smArticle.Enabled = false;
            smClient.Enabled = false;
            smLivraison.Enabled = false;
            smFournisseur.Enabled = false;
            smVente.Enabled = false;
            smAgent.Enabled = false;

            smRptListeArticle.Enabled = false;
            smRptListeClient.Enabled = false;
            smRptListeFournisseur.Enabled = false;
            smRptEtatStock.Enabled = false;
            smRptFacture.Enabled = false;

            smGestionUser.Enabled = false;
            smSauvegardeBd.Enabled = false;
            smRestaurationBd.Enabled = false;

            btnClient.Enabled = false;
            btnFournisseur.Enabled = false;
            btnLivraison.Enabled = false;
            btnArticle.Enabled = false;
            btnVente.Enabled = false;
            btnAgent.Enabled = false;

            btnConnexion.Enabled = true;
            mnConnexion.Enabled = true;
            smDeconnexion.Enabled = false;
        }

        public void MenuActivateAdmin()
        {
            lblArticle.Enabled = true;
            lblClient.Enabled = true;
            lblDepot.Enabled = true;
            lblFournisseur.Enabled = true;
            lblAgent.Enabled = true;
            lblVente.Enabled = true;

            btnClient.Enabled = true;
            btnFournisseur.Enabled = true;
            btnLivraison.Enabled = true;
            btnVente.Enabled = true;
            btnClient.Enabled = true;

            smArticle.Enabled = true;
            smClient.Enabled = true;
            smLivraison.Enabled = true;
            smFournisseur.Enabled = true;
            smVente.Enabled = true;
            smAgent.Enabled = true;

            smRptListeArticle.Enabled = true;
            smRptListeClient.Enabled = true;
            smRptListeFournisseur.Enabled = true;
            smRptEtatStock.Enabled = true;
            smRptFacture.Enabled = true;

            btnClient.Enabled = true;
            btnFournisseur.Enabled = true;
            btnLivraison.Enabled = true;
            btnArticle.Enabled = true;
            btnVente.Enabled = true;
            btnAgent.Enabled = true;

            smGestionUser.Enabled = true;
            smSauvegardeBd.Enabled = true;
            smRestaurationBd.Enabled = true;

            btnConnexion.Enabled = false;
            mnConnexion.Enabled = false;
            smDeconnexion.Enabled = true;
        }

        private void commonDisabledUser()
        {
            lblArticle.Enabled = false;
            lblClient.Enabled = false;
            lblDepot.Enabled = false;
            lblFournisseur.Enabled = false;
            lblAgent.Enabled = false;
            lblVente.Enabled = false;

            smArticle.Enabled = false;
            smClient.Enabled = false;
            smLivraison.Enabled = false;
            smFournisseur.Enabled = false;
            smVente.Enabled = false;
            smAgent.Enabled = false;

            btnClient.Enabled = false;
            btnFournisseur.Enabled = false;
            btnLivraison.Enabled = false;
            btnArticle.Enabled = false;
            btnVente.Enabled = false;
            btnAgent.Enabled = false;

            btnConnexion.Enabled = false;
            mnConnexion.Enabled = false;
            smDeconnexion.Enabled = true;

            smGestionUser.Enabled = false;
            smSauvegardeBd.Enabled = false;
            smRestaurationBd.Enabled = false;
        }

        public void MenuActivateDirection()
        {
            commonDisabledUser();

            smRptListeArticle.Enabled = true;
            smRptListeClient.Enabled = true;
            smRptListeFournisseur.Enabled = true;
            smRptEtatStock.Enabled = true;
            smRptFacture.Enabled = true;  
        }

        public void MenuActivateOtherUser()
        {
            commonDisabledUser();

            smRptListeArticle.Enabled = true;
            smRptListeClient.Enabled = true;
            smRptListeFournisseur.Enabled = true;
            smRptEtatStock.Enabled = false;
            smRptFacture.Enabled = false;
        }

        private void Principal_Load(object sender, EventArgs e)
        {
            this.splitContainer1.SplitterDistance = 165;
            menuDes();
        }

        private void lblFournisseur_MouseEnter(object sender, EventArgs e)
        {
            ((Control)lblFournisseur).ForeColor = Color.BlueViolet;
            ((Control)lblFournisseur).BackColor = Color.FromArgb(153, 180, 209);
        }

        private void lblFournisseur_MouseLeave(object sender, EventArgs e)
        {
            ((Control)lblFournisseur).ForeColor = Color.White;
            ((Control)lblFournisseur).BackColor = Color.Transparent;
        }

        private void lblDepot_MouseEnter(object sender, EventArgs e)
        {
            ((Control)lblDepot).ForeColor = Color.BlueViolet;
            ((Control)lblDepot).BackColor = Color.FromArgb(153, 180, 209);
        }

        private void lblDepot_MouseLeave(object sender, EventArgs e)
        {
            ((Control)lblDepot).ForeColor = Color.White;
            ((Control)lblDepot).BackColor = Color.Transparent;
        }

        private void lblDepot_Click(object sender, EventArgs e)
        {
            this.splitContainer1.Panel2.Controls.Clear();

            LivraisonForm frm = new LivraisonForm();
            frm.Parent = this.splitContainer1.Panel2;
            this.splitContainer1.Panel2.Controls.Add(frm);
        }

        private void lblArticle_Click(object sender, EventArgs e)
        {
            this.splitContainer1.Panel2.Controls.Clear();
            ArticleForm frm = new ArticleForm();
            frm.Parent = this.splitContainer1.Panel2;
            this.splitContainer1.Panel2.Controls.Add(frm);
        }

        private void lblArticle_MouseEnter(object sender, EventArgs e)
        {
            ((Control)lblArticle).ForeColor = Color.BlueViolet;
            ((Control)lblArticle).BackColor = Color.FromArgb(153, 180, 209);
        }

        private void lblArticle_MouseLeave(object sender, EventArgs e)
        {
            ((Control)lblArticle).ForeColor = Color.White;
            ((Control)lblArticle).BackColor = Color.Transparent;
        }

        private void lblMagasinier_MouseEnter(object sender, EventArgs e)
        {
            ((Control)lblAgent).ForeColor = Color.BlueViolet;
            ((Control)lblAgent).BackColor = Color.FromArgb(153, 180, 209);
        }

        private void lblMagasinier_MouseLeave(object sender, EventArgs e)
        {
            ((Control)lblAgent).ForeColor = Color.White;
            ((Control)lblAgent).BackColor = Color.Transparent;
        }

        private void lblMagasinier_Click(object sender, EventArgs e)
        {
            this.splitContainer1.Panel2.Controls.Clear();
            AgentForm frm = new AgentForm();
            frm.Parent = this.splitContainer1.Panel2;
            this.splitContainer1.Panel2.Controls.Add(frm);
        }

        private void lblApropos_Click(object sender, EventArgs e)
        {
            this.splitContainer1.Panel2.Controls.Clear();

            Apropos frm = new Apropos();
            frm.Parent = this.splitContainer1.Panel2;
            this.splitContainer1.Panel2.Controls.Add(frm);
        }

        public void conF() 
        {
            this.splitContainer1.Panel2.Controls.Clear();
            ConnexionBd frm = new ConnexionBd();
            frm.Parent = this.splitContainer1.Panel2;
            this.splitContainer1.Panel2.Controls.Add(frm);
        }
        private void mnConnexion_Click(object sender, EventArgs e)
        {
            conF();
            //MenuAct();
        }

        private void btnConnexion_Click(object sender, EventArgs e)
        {
            conF();
            //MenuAct();
        }

        private void smArticle_Click(object sender, EventArgs e)
        {
            this.splitContainer1.Panel2.Controls.Clear();
            ArticleForm frm = new ArticleForm();
            frm.Parent = this.splitContainer1.Panel2;
            this.splitContainer1.Panel2.Controls.Add(frm);
        }

        private void smClient_Click(object sender, EventArgs e)
        {
            this.splitContainer1.Panel2.Controls.Clear();
            ClientForm frm = new ClientForm();
            frm.Parent = this.splitContainer1.Panel2;
            this.splitContainer1.Panel2.Controls.Add(frm);
        }

        private void smFournisseur_Click(object sender, EventArgs e)
        {
            this.splitContainer1.Panel2.Controls.Clear();

            FournisseurForm frm = new FournisseurForm();
            frm.Parent = this.splitContainer1.Panel2;
            this.splitContainer1.Panel2.Controls.Add(frm);
        }

        private void smLivraison_Click(object sender, EventArgs e)
        {
            this.splitContainer1.Panel2.Controls.Clear();

            LivraisonForm frm = new LivraisonForm();
            frm.Parent = this.splitContainer1.Panel2;
            this.splitContainer1.Panel2.Controls.Add(frm);
        }

        private void smRptFichePaieColectiveMensuel_Click(object sender, EventArgs e)
        {
            this.splitContainer1.Panel2.Controls.Clear();

            rptListeClient frm = new rptListeClient();
            frm.Parent = this.splitContainer1.Panel2;
            this.splitContainer1.Panel2.Controls.Add(frm);
        }

        private void smRptFichePaieIndiv_Click(object sender, EventArgs e)
        {
            this.splitContainer1.Panel2.Controls.Clear();

            rptListeArticle frm = new rptListeArticle();
            frm.Parent = this.splitContainer1.Panel2;
            this.splitContainer1.Panel2.Controls.Add(frm);
        }

        private void smRapportPaieAnnuelle_Click(object sender, EventArgs e)
        {
            this.splitContainer1.Panel2.Controls.Clear();

            rptEtatStockF frm = new rptEtatStockF();
            frm.Parent = this.splitContainer1.Panel2;
            this.splitContainer1.Panel2.Controls.Add(frm);
        }

        private void smRapportPaieMensuel_Click(object sender, EventArgs e)
        {
            this.splitContainer1.Panel2.Controls.Clear();

            FactureFrm frm = new FactureFrm();
            frm.Parent = this.splitContainer1.Panel2;
            this.splitContainer1.Panel2.Controls.Add(frm);
        }

        private void lblApropos_MouseEnter(object sender, EventArgs e)
        {
            ((Control)lblApropos).ForeColor = Color.BlueViolet;
            ((Control)lblApropos).BackColor = Color.FromArgb(153, 180, 209);
        }

        private void lblApropos_MouseLeave(object sender, EventArgs e)
        {
            ((Control)lblApropos).ForeColor = Color.White;
            ((Control)lblApropos).BackColor = Color.Transparent;
        }

        private void btnClient_Click(object sender, EventArgs e)
        {
            this.splitContainer1.Panel2.Controls.Clear();

            ClientForm frm = new ClientForm();
            frm.Parent = this.splitContainer1.Panel2;
            this.splitContainer1.Panel2.Controls.Add(frm);
        }

        private void btnFournisseur_Click(object sender, EventArgs e)
        {
            this.splitContainer1.Panel2.Controls.Clear();

            FournisseurForm frm = new FournisseurForm();
            frm.Parent = this.splitContainer1.Panel2;
            this.splitContainer1.Panel2.Controls.Add(frm);
        }

        private void btnVente_Click(object sender, EventArgs e)
        {
            this.splitContainer1.Panel2.Controls.Clear();

            VenteForm frm = new VenteForm();
            frm.Parent = this.splitContainer1.Panel2;
            this.splitContainer1.Panel2.Controls.Add(frm);
        
        }

        private void btnLivraison_Click(object sender, EventArgs e)
        {
            this.splitContainer1.Panel2.Controls.Clear();

            LivraisonForm frm = new LivraisonForm();
            frm.Parent = this.splitContainer1.Panel2;
            this.splitContainer1.Panel2.Controls.Add(frm);
        }

        private void btnAide_Click(object sender, EventArgs e)
        {
            this.splitContainer1.Panel2.Controls.Clear();

            Apropos frm = new Apropos();
            frm.Parent = this.splitContainer1.Panel2;
            this.splitContainer1.Panel2.Controls.Add(frm);
        }

        private void smGestionUser_Click(object sender, EventArgs e)
        {
            this.splitContainer1.Panel2.Controls.Clear();

            ManipulationUtilisateur frm = new ManipulationUtilisateur();
            frm.Parent = this.splitContainer1.Panel2;
            this.splitContainer1.Panel2.Controls.Add(frm);
        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {
            if (Factory.IsAdmin)
            {
                MenuActivateAdmin();
            }
            else if (Factory.IsAdmin)
            {
                MenuActivateDirection();
            }
            else if (Factory.IsAdmin)
            {
                MenuActivateOtherUser();
            }
        }

        private void btnArticle_Click(object sender, EventArgs e)
        {
            this.splitContainer1.Panel2.Controls.Clear();

            ArticleForm frm = new ArticleForm();
            frm.Parent = this.splitContainer1.Panel2;
            this.splitContainer1.Panel2.Controls.Add(frm);
        }

        private void btnAgent_Click(object sender, EventArgs e)
        {
            this.splitContainer1.Panel2.Controls.Clear();

            AgentForm frm = new AgentForm();
            frm.Parent = this.splitContainer1.Panel2;
            this.splitContainer1.Panel2.Controls.Add(frm);
        }

        private void smSauvegardeBd_Click(object sender, EventArgs e)
        {
            dlgFile.Title = "Veuillez sélectionner l'emplacement de sauvegarde";

            if (dlgFile.ShowDialog() == DialogResult.OK)
            {
                string cheminAccesBd = dlgFile.FileName;
                try
                {
                    if (Factory.Instance.GetTypeSGBDConnecting() == 1)
                    {
                        string lecteur = Interaction.InputBox("Veuillez saisir la lettre du lecteur sur lequel vous aller éffectuer la sauvegarde", "Lecteur de sauvegarde", "C", 300, 300);
                        string versionPostGreSQL = Interaction.InputBox("Veuillez saisir le numéro de la version de PostGreSQL que vous utilisez", "Version de PostGreSQL", "9.1", 300, 300);
                        string message = Factory.Instance.BackupLocalDataBase(cheminAccesBd, lecteur);
                        MessageBox.Show("Sauvegarde éffectuée avec succès dans l'emplacement | " + message + " |", "Sauvegarde locale de la base des données", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        string message = Factory.Instance.BackupLocalDataBase(cheminAccesBd, null);
                        MessageBox.Show("Sauvegarde éffectuée avec succès dans l'emplacement | " + cheminAccesBd + " |", "Sauvegarde locale de la base des données", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Echec de la sauvegarde dans l'emplacement | " + cheminAccesBd + " |", "Sauvegarde locale de la base des données", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private void smRestaurationBd_Click(object sender, EventArgs e)
        {
            dlgFile.Title = "Veuillez sélectionner le fichier pour la restauration";

            if (dlgOpen.ShowDialog() == DialogResult.OK)
            {
                string cheminAccesBd = dlgOpen.FileName;
                try
                {
                    if (Factory.Instance.GetTypeSGBDConnecting() == 1)
                    {
                        string lecteur = Interaction.InputBox("Veuillez saisir la lettre du lecteur à partir duquel vous voulez éffectuer la restauration", "Lecteur source de restauration", "C", 300, 300);
                        string versionPostGreSQL = Interaction.InputBox("Veuillez saisir le numéro de la version de PostGreSQL que vous utilisez", "Version de PostGreSQL", "9.1", 300, 300);
                        string message = Factory.Instance.RestoreDataBase(cheminAccesBd, lecteur);
                        MessageBox.Show("restauration éffectuée avec succès", "restauration", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        string msg = Factory.Instance.RestoreDataBase(cheminAccesBd, null);
                        MessageBox.Show("Restauration éffectuée avec succès à partir de l'emplacement | " + cheminAccesBd + " |", "Restauration de la base des données", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Echec de la restauration à parir de l'emplacement | " + cheminAccesBd + " |", "Restauration de la base des données", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }
    }
}
