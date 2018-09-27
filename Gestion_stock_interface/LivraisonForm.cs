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
    public partial class LivraisonForm : UserControl
    {
        public LivraisonForm()
        {
            InitializeComponent();
        }
        Livraison livraison = new Livraison();
        private void LivraisonForm_Load(object sender, EventArgs e)
        {
            btEnregistre.Enabled = false;
            try
            {
                cboArticle.DataSource = Factory.Instance.GetArticles();
                cboFounisseur.DataSource = Factory.Instance.getFournisseurs();
            }
            catch (Exception)
            {
                MessageBox.Show("erreur lors du chargement des listes déroulantes", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            try
            {
                dtgLivraison.DataSource = Factory.Instance.GetLivraisons();

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
                livraison.Id_article = Convert.ToInt32(((Article)cboArticle.SelectedItem).Id);
            }
            catch (Exception) { }
        }

        private void cboFounisseur_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                livraison.Id_fournisseur = Convert.ToInt32(((Fournisseur)cboFounisseur.SelectedItem).Id);
            }
            catch (Exception) { }
        }

        private void dtgLivraison_SelectionChanged(object sender, EventArgs e)
        {
            if (dtgLivraison.SelectedRows.Count > 0)
            {
                livraison = null;
                btModifier.Enabled = true;
                livraison = (Livraison)dtgLivraison.SelectedRows[0].DataBoundItem;
                txtIdLivraison.Text = livraison.Id.ToString();
                cboArticle.Text = Factory.Instance.GetArticle(livraison.Id_article).ToString();
                cboFounisseur.Text = Factory.Instance.GetFournisseur(livraison.Id_fournisseur).ToString();
                txtQuantite.Text = livraison.Qte_e.ToString();
                txtDateLivraison.Text = livraison.Date_livraison.ToString();
            }
        }

        private void btAdd_Click(object sender, EventArgs e)
        {
            txtIdLivraison.Text = Factory.Instance.ReNewIdValue(livraison).ToString();
            txtDateLivraison.Clear();
            txtQuantite.Clear();
            btEnregistre.Enabled = true;
        }

        private void btRefrech_Click(object sender, EventArgs e)
        {
            RefreshLivraison();
        }

        private void RefreshLivraison()
        {
            try
            {
                cboArticle.DataSource = Factory.Instance.GetArticles();
                cboFounisseur.DataSource = Factory.Instance.getFournisseurs();
            }
            catch (Exception)
            {
                MessageBox.Show("erreur lors du chargement des listes déroulantes", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            try
            {
                dtgLivraison.DataSource = Factory.Instance.GetLivraisons();

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
                if (livraison != null)
                {
                    getLivraison();
                    livraison.Enregistre();
                    btEnregistre.Enabled = false;
                    MessageBox.Show("Enregistrement éffectué", "Enregistrement", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    try
                    {
                        RefreshLivraison();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Erreur lors de l'actualisation des livraisons", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Echec de l'enregistrement " + ex.Message, "Enregistrement", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void getLivraison()
        {
            livraison.Id = Convert.ToInt32(txtIdLivraison.Text);
            livraison.Qte_e = Convert.ToInt32(txtQuantite.Text);
            livraison.Date_livraison = Convert.ToDateTime(txtDateLivraison.Text);
        }

        private void btModifier_Click(object sender, EventArgs e)
        {
            try
            {
                if (livraison != null)
                {
                    getLivraison();
                    livraison.Modifier();
                    MessageBox.Show("Modification éffectuée", "Modification", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    try
                    {
                        RefreshLivraison();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Erreur lors de l'actualisation dee livraisons", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                    getLivraison();
                    livraison.Supprimer();
                    MessageBox.Show("Suppréssion éffectuée", "Suppression", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    try
                    {
                        RefreshLivraison();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Erreur lors de l'actualisation des livraisons", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Echec de la Spression " + ex.Message, "Suppression", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnCloseAgent_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btAdd_Click_1(object sender, EventArgs e)
        {

        }
    }
}
