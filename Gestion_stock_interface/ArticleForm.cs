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
    public partial class ArticleForm : UserControl
    {
        public ArticleForm()
        {
            InitializeComponent();
        }

        CategorieArticle cat = new CategorieArticle();
        Article art = new Article();
        private void ArticleForm_Load(object sender, EventArgs e)
        {
            try
            {
                chargementComboCat();
            }
            catch (Exception)
            {
                MessageBox.Show("erreur lors du chargement des listes déroulantes", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            try
            {
                dtCatArt.DataSource = Factory.Instance.getCategories();
                dtArticle.DataSource = Factory.Instance.GetArticles();
            }
            catch (Exception)
            {
                MessageBox.Show("erreur lors de l'affichage", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            btnSaveCat.Enabled = false;
            btnSaveArticle.Enabled = false;

            if (dtCatArt.RowCount <= 0)
            {
                btnModifyCat.Enabled = false;
                btnDeleteCat.Enabled = false;
                btnSaveCat.Enabled = false;
            }

            if (dtArticle.RowCount <= 0)
            {
                btnModifierArticle.Enabled = false;
                deleteArticle.Enabled = false;
                btnSaveArticle.Enabled = false;
            }

        }

        private void chargementComboCat()
        {
            cboCatArticle.DataSource = Factory.Instance.getCategories();
        }

        public void initialiseCategorie()
        {
            txtDesignCatArt.Clear();
            txtDesignCatArt.Focus();
        }
        private void btnAddCatArt_Click(object sender, EventArgs e)
        {
            try
            {
                cat.Id = Factory.Instance.ReNewIdValue(cat);
                txtIdCatArt.Text = cat.Id.ToString();
                initialiseCategorie();
                btnSaveCat.Enabled = true;
            }
            catch (Exception) { btnSaveCat.Enabled = false; }
        }

        public void getAtrCatArt()
        {
            cat.Id = Convert.ToInt32(txtIdCatArt.Text);
            cat.Designation = txtDesignCatArt.Text;
        }

        public void refreshCat()
        {
            dtCatArt.DataSource = Factory.Instance.getCategories();
            cboCatArticle.DataSource = Factory.Instance.getCategories();

            if (dtCatArt.RowCount > 0)
            {
                btnModifyCat.Enabled = true;
                btnDeleteCat.Enabled = true;
            }
            else
            {
                btnModifyCat.Enabled = false;
                btnDeleteCat.Enabled = false;
                btnSaveCat.Enabled = false;
            }
            int col = 0;
            foreach (DataGridViewColumn dgvc in dtCatArt.Columns)
            {
                dtCatArt.AutoResizeColumn(col);
                col++;
            }
        }

        private void btnSaveCat_Click(object sender, EventArgs e)
        {
            try
            {
                if (cat != null)
                {
                    getAtrCatArt();

                    cat.Enregistrer();
                    btnSaveCat.Enabled = false;
                    MessageBox.Show("Enregistrement éffectué", "Enregistrement", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    try
                    {
                        refreshCat();
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

        private void btnModifyCat_Click(object sender, EventArgs e)
        {
            try
            {
                if (cat != null)
                {
                    getAtrCatArt();
                    cat.modifier();
                    MessageBox.Show("Modification éffectuée", "Modification", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    try
                    {
                        refreshCat();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Erreur lors de l'actualisation des catégories", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Echec de la modification " + ex.Message, "Modification", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnrefreshCat_Click(object sender, EventArgs e)
        {
            refreshCat();
        }

        private void dtCatArt_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dtCatArt.SelectedRows.Count > 0)
                {
                    cat = null;
                    btnModifyCat.Enabled = true;
                    btnDeleteCat.Enabled = true;

                    cat = (CategorieArticle)dtCatArt.SelectedRows[0].DataBoundItem;
                    txtIdCatArt.Text = cat.Id.ToString();
                    txtDesignCatArt.Text = cat.Designation;
                }
            }
            catch (Exception) { MessageBox.Show("Erreur dans la zone d'affichage des Catégories", "Erreur d'affichage"); }
        }

        private void btnDeleteCat_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show("Voulez - vous vraiment supprimer cet enregistrement ?", "Suppression", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    getAtrCatArt();
                    cat.Supprimmer();
                    MessageBox.Show("Suppréssion éffectuée", "Suppression", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    try
                    {
                        refreshCat();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Erreur lors de l'actualisation des catégories", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Echec de la Spression " + ex.Message, "Suppression", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        public void initialiseArticle()
        {
            txtDesignArt.Clear();
            txtPu.Clear();
            txtDesignArt.Focus();
        }
        private void btnAddArt_Click(object sender, EventArgs e)
        {
            try
            {
                art.Id = Factory.Instance.ReNewIdValue(art);
                txtIdArt.Text = art.Id.ToString();
                initialiseArticle();
                btnSaveArticle.Enabled = true;
            }
            catch (Exception) { btnSaveCat.Enabled = false; }
        }


        public void getAtrArt()
        {
            art.Id = Convert.ToInt32(txtIdArt.Text);
            art.Designation = txtDesignArt.Text;
            art.Pu = Convert.ToDouble(txtPu.Text);
        }
        private void btnSaveArticle_Click(object sender, EventArgs e)
        {
            try
            {
                if (art != null)
                {
                    getAtrArt();
                    art.Enregistrer();
                    btnSaveArticle.Enabled = false;
                    MessageBox.Show("Enregistrement éffectué", "Enregistrement", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    try
                    {
                        refreshArticle();
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
        public void refreshArticle()
        {
            dtArticle.DataSource = Factory.Instance.GetArticles();
            if (dtArticle.RowCount > 0)
            {
                btnModifierArticle.Enabled = true;
                deleteArticle.Enabled = true;
            }
            else
            {
                btnModifierArticle.Enabled = false;
                deleteArticle.Enabled = false;
                btnSaveArticle.Enabled = false;
            }
            int col = 0;
            foreach (DataGridViewColumn dgvc in dtArticle.Columns)
            {
                dtArticle.AutoResizeColumn(col);
                col++;
            }
        }
        private void btnRefreshArt_Click(object sender, EventArgs e)
        {
            refreshArticle();
        }

        private void cboCatArticle_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                art.Id_categorie = Convert.ToInt32(((CategorieArticle)cboCatArticle.SelectedItem).Id);
            }
            catch (Exception) { }
        }

        private void dtArticle_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dtArticle.SelectedRows.Count > 0)
                {
                    art = null;
                    btnModifierArticle.Enabled = true;
                    deleteArticle.Enabled = true;
                    art = (Article)dtArticle.SelectedRows[0].DataBoundItem;
                    txtIdArt.Text = art.Id.ToString();
                    txtDesignArt.Text = art.Designation;
                    txtPu.Text = art.Pu.ToString();
                    cboCatArticle.Text = Factory.Instance.GetCategorie(art.Id_categorie).ToString();
                }
            }
            catch (Exception) { MessageBox.Show("Erreur dans la zone d'affichage des Fonctions", "Erreur d'affichage"); }
        }

        private void btnModifierArticle_Click(object sender, EventArgs e)
        {
            try
            {
                if (art != null)
                {
                    getAtrArt();
                    art.Modifier();
                    MessageBox.Show("Modification éffectuée", "Modification", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    try
                    {
                        refreshArticle();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Erreur lors de l'actualisation des catégories", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }

                }
              }
            catch (Exception ex)
            {
                    MessageBox.Show("Echec de la modification " + ex.Message, "Modification", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }        
        }

        private void deleteArticle_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show("Voulez - vous vraiment supprimer cet enregistrement ?", "Suppression", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    getAtrArt();
                    art.Supprimer();
                    MessageBox.Show("Suppréssion éffectuée", "Suppression", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    try
                    {
                        refreshArticle();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Erreur lors de l'actualisation des catégories", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }

}
