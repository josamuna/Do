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
    public partial class VenteForm : UserControl
    {
        public VenteForm()
        {
            InitializeComponent();
        }
        PaiementArticle vente = new PaiementArticle();


        private void VenteForm_Load(object sender, EventArgs e)
        {
            btEnregistre.Enabled = false;
            try
            {
                cboArticle.DataSource = Factory.Instance.GetArticles();
                cboClien.DataSource = Factory.Instance.getClients();
            }
            catch (Exception)
            {
                MessageBox.Show("erreur lors du chargement des listes déroulantes", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            try
            {
                dgvVente.DataSource = Factory.Instance.GetVentes();

            }
            catch (Exception)
            {
                MessageBox.Show("erreur lors de l'affichage", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void cboArticle_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                vente.Id_article = Convert.ToInt32(((Article)cboArticle.SelectedItem).Id);
            }
            catch (Exception) { }
        }

        private void cboClien_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                vente.Id_client = Convert.ToInt32(((Client)cboClien.SelectedItem).Id);
            }
            catch (Exception) { }
        }

        private void dgvVente_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvVente.SelectedRows.Count > 0)
            {
                vente = null;
                btModifier.Enabled = true;
                btModifier.Enabled = true;
                vente = (PaiementArticle)dgvVente.SelectedRows[0].DataBoundItem;
                txtId.Text = vente.Id.ToString();
                cboArticle.Text = Factory.Instance.GetArticle(vente.Id_article).ToString();
                cboClien.Text = Factory.Instance.GetClient(vente.Id_client).ToString();
                txtMontantPaye.Text = vente.MontantPaye.ToString();
                txtDatePaiement.Text = vente.Date.ToString();
                txtQuantite.Text = vente.Quantite.ToString();
                
            }
        }

        private void btAdd_Click(object sender, EventArgs e)
        {
            txtId.Text = Factory.Instance.ReNewIdValue(vente).ToString();
            txtMontantPaye.Clear();
            txtQuantite.Clear();
            txtDatePaiement.Clear();
            btEnregistre.Enabled = true;
        }

        private void btRefrech_Click(object sender, EventArgs e)
        {
            Refrech();
        }

        private void Refrech()
        {
            try
            {
                cboArticle.DataSource = Factory.Instance.GetArticles();
                cboClien.DataSource = Factory.Instance.getClients();
            }
            catch (Exception)
            {
                MessageBox.Show("erreur lors du chargement des listes déroulantes", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            try
            {
                dgvVente.DataSource = Factory.Instance.GetVentes();

            }
            catch (Exception)
            {
                MessageBox.Show("erreur lors de l'affichage", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btEnregistre_Click(object sender, EventArgs e)
        {
            try
            {
                if (vente != null)
                {
                    getVente();
                    vente.Enregistre();
                    btEnregistre.Enabled = false;
                    MessageBox.Show("Enregistrement éffectué", "Enregistrement", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    try
                    {
                        Refrech();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Erreur lors de l'actualisation des ventes", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Echec de l'enregistrement " + ex.Message, "Enregistrement", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void getVente()
        {
            vente.Id = Convert.ToInt32(txtId.Text);
            vente.Date = Convert.ToDateTime(txtDatePaiement.Text);
            vente.Quantite = Convert.ToInt32(txtQuantite.Text);
            vente.MontantPaye = Convert.ToDouble(txtMontantPaye.Text);
        }

        private void btModifier_Click(object sender, EventArgs e)
        {
            try
            {
                if (vente != null)
                {
                    getVente();
                    vente.Modifier();
                    MessageBox.Show("Modification éffectuée", "Modification", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    try
                    {
                        Refrech();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Erreur lors de l'actualisation dee ventes", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Echec de la modification " + ex.Message, "Modification", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            } 
        }

        private void btSupprimer_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show("Voulez - vous vraiment supprimer cet enregistrement ?", "Suppression", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    getVente();
                    vente.Supprimer();
                    MessageBox.Show("Suppréssion éffectuée", "Suppression", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    try
                    {
                        Refrech();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Erreur lors de l'actualisation des ventes", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Echec de la Spression " + ex.Message, "Suppression", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void lblClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
