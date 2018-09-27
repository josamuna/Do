using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GestionClinic_LIB;


namespace GestionClinic_WIN
{
    public partial class FournisseurForm : UserControl
    {
     
        public FournisseurForm()
        {
            InitializeComponent();
        }
        PaiementFournisseur paienmentF = new PaiementFournisseur();
        Fournisseur fournisseur = new Fournisseur();
        Personne personne = new Personne();

        public void initialiseFournisseur() 
        {
            txtIdFournisseur.Clear();
            txtNomFournisseur.Clear();
            txtPNomFournisseur.Clear();
            txtPrenomFournisseur.Clear();
            txtDateNaissanceFournisseur.Clear();
            txtTelephoneFournisseur.Clear();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AgentForm));
            txtNomFournisseur.Focus();
        }
        public void GetFournisseur()
        {
            
            fournisseur.Id_personne = fournisseur.IdPers;
            fournisseur.Id = Convert.ToInt32(txtIdFournisseur.Text);
            fournisseur.Nom = txtNomFournisseur.Text;
            fournisseur.PostNom = txtPNomFournisseur.Text;
            fournisseur.Prenom = txtPrenomFournisseur.Text;
            fournisseur.Sexe = cboSexeFournisseur.Text;
            fournisseur.EtatCivil = cboEtatCivFournisseur.Text;
            fournisseur.Telephone = txtTelephoneFournisseur.Text;
            if (txtDateNaissanceFournisseur.Text.Equals("  /  /")) { fournisseur.DateNaissance = null; }
            else { fournisseur.DateNaissance = Convert.ToDateTime(txtDateNaissanceFournisseur.Text);};

            
            fournisseur.Id = Convert.ToInt32(txtIdFournisseur.Text);
        }
        private void btnAddFournisseur_Click(object sender, EventArgs e)
        {
            try
            {
                initialiseFournisseur();
                fournisseur.Id = Factory.Instance.ReNewIdValue(fournisseur, 1);
                fournisseur.IdPers = Factory.Instance.ReNewIdValue(personne);
                txtIdFournisseur.Text = fournisseur.Id.ToString();
                btnSaveFournisseur.Enabled = true;
            }
            catch (Exception) { btnSaveFournisseur.Enabled = false; }
        }
        public void chargementCombo()
        {
            cboEtatCivFournisseur.Items.Add("CELIBATAIRE");
            cboEtatCivFournisseur.Items.Add("MARIE(E)");
            cboEtatCivFournisseur.Items.Add("VEUF(VE)");
            cboEtatCivFournisseur.SelectedIndex = 0;

            cboSexeFournisseur.Items.Add("M");
            cboSexeFournisseur.Items.Add("F");
            cboSexeFournisseur.SelectedIndex = 0;

            cboMagasinier.DataSource = Factory.Instance.GetAgents();
        }
        private void FournisseurForm_Load(object sender, EventArgs e)
        {            
            try
            {
                chargementCombo();
            }
            catch (Exception)
            {
                MessageBox.Show("erreur lors du chargement des listes déroulantes", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            try
            {
                dgvFournisseur.DataSource = Factory.Instance.getFournisseurs();
                dgvPaiement.DataSource = Factory.Instance.GetPaiementFournisseurs();
                cboFournisseur.DataSource = Factory.Instance.getFournisseurs();
            }
            catch (Exception)
            {
                MessageBox.Show("erreur lors de l'affichage", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            btnSaveFournisseur.Enabled = false;

            if (dgvFournisseur.RowCount <= 0)
            {
                btnSaveFournisseur.Enabled = false;
                btnUpdateFournisseur.Enabled = false;
                btnDeleteFournisseur.Enabled = false;
            }
        }

        public void refreshFounisseur()
        {
            dgvFournisseur.DataSource = Factory.Instance.getFournisseurs();
            if (dgvFournisseur.RowCount > 0)
            {
                btnUpdateFournisseur.Enabled = true;
                btnDeleteFournisseur.Enabled = true;
            }
            else
            {
                btnUpdateFournisseur.Enabled = false;
                btnDeleteFournisseur.Enabled = false;
                btnSaveFournisseur.Enabled = false;
            }

            int col = 0;
            foreach (DataGridViewColumn dgvc in dgvFournisseur.Columns)
            {
                dgvFournisseur.AutoResizeColumn(col);
                col++;
            }
        }
        private void btnRefreshFournisseur_Click(object sender, EventArgs e)
        {
            refreshFounisseur();
        }

        private void btnSaveFournisseur_Click(object sender, EventArgs e)
        {
            try
            {
                if (fournisseur != null && personne != null)
                {
                    GetFournisseur();
                    fournisseur.Enregistrer();

                    btnSaveFournisseur.Enabled = false;
                    MessageBox.Show("Enregistrement éffectué", "Enregistrement", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    try
                    {
                        refreshFounisseur();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Erreur lors de l'actualisation des Clients", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Enregistrement", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnUpdateFournisseur_Click(object sender, EventArgs e)
        {
            try
            {
                if (fournisseur != null)
                {
                    GetFournisseur(); ;
                    fournisseur.Modifier();
                    MessageBox.Show("Modification effectuée!", "Modification", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    try
                    {
                        refreshFounisseur();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Echec de la modification " + ex.Message, "Modification", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }
            catch (Exception)
            {

            }
        }

        private void btnDeleteFournisseur_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show("Voulez - vous vraiment supprimer cet enregistrement ?", "Suppression", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    fournisseur.Supprimer();

                    MessageBox.Show("Suppression éffectuée", "Suppression", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    initialiseFournisseur();

                    try
                    {
                        refreshFounisseur();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Erreur lors de l'actualisation des Agents", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }

                    if (dgvFournisseur.RowCount > 0)
                    {
                        btnUpdateFournisseur.Enabled = true;
                        btnDeleteFournisseur.Enabled = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Suppression", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void dgvFournisseur_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgvFournisseur.SelectedRows.Count > 0)
                {
                    fournisseur = null;
                    fournisseur = (Fournisseur)dgvFournisseur.SelectedRows[0].DataBoundItem;

                    fournisseur.IdPers = fournisseur.Id_personne;
                    fournisseur.Sexe = cboSexeFournisseur.Text;
                    fournisseur.EtatCivil = cboEtatCivFournisseur.Text;

                    //Personne
                    fournisseur.Id_personne = fournisseur.IdPers;
                    txtIdFournisseur.Text = Convert.ToString(fournisseur.Id);
                    txtNomFournisseur.Text = fournisseur.Nom;
                    txtPNomFournisseur.Text = fournisseur.PostNom;
                    txtPrenomFournisseur.Text = fournisseur.Prenom;
                    cboSexeFournisseur.Text = fournisseur.Sexe;
                    cboEtatCivFournisseur.Text = fournisseur.EtatCivil;
                    txtTelephoneFournisseur.Text = fournisseur.Telephone;
                    txtDateNaissanceFournisseur.Text = Convert.ToString(fournisseur.DateNaissance);
                    
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Erreur dans la zone d'affichage", "Erreur d'affichage");
            }
        }

        public void initialisePaiement() 
        {
            txtMontantPaye.Clear();
            txtDatePaie.Clear();
            txtMontantPaye.Focus();
            txtDatePaie.Text = DateTime.Today.ToString();
        }

        private void btnAddPaie_Click(object sender, EventArgs e)
        {
            try
            {
                paienmentF.Id = Factory.Instance.ReNewIdValue(paienmentF);
                txtIdP.Text = paienmentF.Id.ToString();
                initialisePaiement();
                btnSavePaieF.Enabled = true;
            }
            catch (Exception) { btnSavePaieF.Enabled = false; }
        }

        public void RefreshPaie() 
        {
            dgvPaiement.DataSource = Factory.Instance.GetPaiementFournisseurs();
            cboFournisseur.DataSource = Factory.Instance.getFournisseurs();

            if (dgvPaiement.RowCount > 0)
            {
                btnModPF.Enabled = true;
                btnDeletePf.Enabled = true;
            }
            else
            {
                btnModPF.Enabled = false;
                btnDeletePf.Enabled = false;
                btnSavePaieF.Enabled = false;
            }
            int col = 0;
            foreach (DataGridViewColumn dgvc in dgvPaiement.Columns)
            {
                dgvPaiement.AutoResizeColumn(col);
                col++;
            }
        }
        private void btnRefreshPaie_Click(object sender, EventArgs e)
        {
            RefreshPaie();
        }

        public void getAtrPaiementF()
        {
            paienmentF.Id = Convert.ToInt32(txtIdP.Text);
            paienmentF.Montant =Convert.ToDouble(txtMontantPaye.Text);
            paienmentF.Date = Convert.ToDateTime(txtDatePaie.Text);
            

        }

        private void btnSavePaieF_Click(object sender, EventArgs e)
        {
            try
            {
                if (paienmentF != null)
                {
                    getAtrPaiementF();
                    paienmentF.Enregistrer();
                    btnSavePaieF.Enabled = false;
                    MessageBox.Show("Enregistrement éffectué", "Enregistrement", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    try
                    {
                        RefreshPaie();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Erreur lors de l'actualisation des catégories", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Echec de l'enregistrement " + ex.Message, "Enregistrement", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void cboMagasinier_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                paienmentF.Id_agent = Convert.ToInt32(((Agent)cboMagasinier.SelectedItem).Id);
            }
            catch (Exception) { }
        }

        private void cboFournisseur_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                paienmentF.Id_fournisseur= Convert.ToInt32(((Fournisseur)cboFournisseur.SelectedItem).Id);
            }
            catch (Exception) { }
        }

        private void btnModPF_Click(object sender, EventArgs e)
        {
            try
            {
                if (paienmentF != null)
                {
                    getAtrPaiementF();
                    paienmentF.modifier();
                    MessageBox.Show("Modification éffectuée", "Modification", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    try
                    {
                        RefreshPaie();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Erreur lors de l'actualisation des paiements Fournisseur", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Echec de la modification " + ex.Message, "Modification", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }        
        }

        private void btnDeletePf_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show("Voulez - vous vraiment supprimer cet enregistrement ?", "Suppression", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    getAtrPaiementF();
                    paienmentF.supprimer();
                    MessageBox.Show("Suppréssion éffectuée", "Suppression", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    try
                    {
                        RefreshPaie();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Erreur lors de l'actualisation des Paiements de Fournisseur", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Echec de la Spression " + ex.Message, "Suppression", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void dgvPaiement_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgvPaiement.SelectedRows.Count > 0)
                {
                    paienmentF = null;
                    btnModPF.Enabled = true;
                    btnDeletePf.Enabled = true;
                    paienmentF = (PaiementFournisseur)dgvPaiement.SelectedRows[0].DataBoundItem;
                    txtIdP.Text = paienmentF.Id.ToString();
                    txtMontantPaye.Text = paienmentF.Montant.ToString();
                    txtDatePaie.Text = paienmentF.Date.ToString();
                    cboFournisseur.Text = Factory.Instance.GetFournisseur(paienmentF.Id_fournisseur).ToString();
                    cboMagasinier.Text = Factory.Instance.GetAgent(paienmentF.Id_agent).ToString();
                }
            }
            catch (Exception) { MessageBox.Show("Erreur dans la zone d'affichage des paiement de fournisseurs", "Erreur d'affichage"); }
        }

        private void btnCloseAgent_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
       

    }
}
