using System;
using System.Windows.Forms;
using GestionClinic_LIB;

namespace GestionClinic_WIN
{
    public partial class ManipulationUtilisateur : UserControl
    {
        private Utilisateur utilisateur = new Utilisateur();
        private Agent agent = new Agent();
        private CategorieUtilisateur catU = new CategorieUtilisateur();

        public ManipulationUtilisateur()
        {
            InitializeComponent();
        }

        private void ManipulationUtilisateur_Load(object sender, EventArgs e)
        {
            //Chargement des combo box : Utilisateur
            try
            {
                this.loadAllCbo();
            }
            catch (Exception) { }

            cboIdAgent.AutoCompleteSource = AutoCompleteSource.ListItems;
            cboIdAgent.AutoCompleteMode = AutoCompleteMode.SuggestAppend;

            cboUser.AutoCompleteSource = AutoCompleteSource.ListItems;
            cboUser.AutoCompleteMode = AutoCompleteMode.SuggestAppend;

            cboUserModPsd.AutoCompleteSource = AutoCompleteSource.ListItems;
            cboUserModPsd.AutoCompleteMode = AutoCompleteMode.SuggestAppend;

            try
            {
                cboIdAgent.DataSource = Factory.Instance.GetAgents();
                cboCategorieUtilisateur.DataSource = Factory.Instance.GetCategorieUtilisateurs();
            }
            catch (Exception) { }

            try
            {
                dgvUser.DataSource = Factory.Instance.GetUtilisateurs();
                dgvCatUser.DataSource = Factory.Instance.GetCategorieUtilisateurs();
            }
            catch (Exception) { }

            foreach (DataGridViewColumn dgvc in dgvUser.Columns)
            {
                int col = 0;
                if (dgvc.DataPropertyName == "Id") dgvc.Visible = false;
                if (dgvc.DataPropertyName == "Id_personne") dgvc.Visible = false;
                if (dgvc.DataPropertyName == "Id_categorieUtilisateur") dgvc.Visible = false;
                if (dgvc.DataPropertyName == "Motpass") dgvc.Visible = false;
                dgvUser.AutoResizeColumn(col);
                col++;
            }
            foreach (DataGridViewColumn dgvc in dgvCatUser.Columns)
            {
                int col = 0;
                if (dgvc.DataPropertyName == "Id") dgvc.Visible = false;
                dgvCatUser.AutoResizeColumn(col);
                col++;
            }
            lblConfirmPwd.Visible = false;

            if (dgvUser.RowCount <= 0)
            {
                cmdSaveUser.Enabled = false;
                cmdDeleteUser.Enabled = false;
                cmdUpdateUser.Enabled = false;
            }

            if (dgvCatUser.RowCount <= 0)
            {
                cmdSaveCatUser.Enabled = false;
                cmdModiCatUser.Enabled = false;
                cmdDeleteCatUser.Enabled = false;
            }
        }

        private void getAttributUtilisateur()
        {
            utilisateur.Id = Convert.ToInt32(lblIdUser.Text);
            utilisateur.Nomuser = txtUserName.Text;
            utilisateur.Motpass = txtPwd.Text;
            utilisateur.Activation = chkActivationUser.Checked;
        }

        private void loadAllCbo()
        {
            cboUser.DataSource = Factory.Instance.GetUtilisateurs();
            cboUserModPsd.DataSource = Factory.Instance.GetUtilisateurs();
            cboGroupeUser.Items.Add("ADMINISTRATEUR");//2
            cboGroupeUser.Items.Add("DIRECTION");//3
            cboGroupeUser.Items.Add("AUTRES");//4
            cboGroupeUser.SelectedIndex = 1;
            if (cboUser.Items.Count > 0) cboUser.SelectedIndex = 0;
            else { }
            if (cboUserModPsd.Items.Count > 0) cboUserModPsd.SelectedIndex = 0;
            else { }

            txtOldUserName.Text = cboUser.Text;
        }

        private void dgvUser_SelectionChanged(object sender, EventArgs e)
        {
            cmdSaveUser.Enabled = false;
            txtPwd.Clear();
            if (dgvUser.SelectedRows.Count > 0)
            {
                cmdDeleteUser.Enabled = true; 
                cmdUpdateUser.Enabled = true;

                utilisateur = (Utilisateur)dgvUser.SelectedRows[0].DataBoundItem;
                lblIdUser.Text = utilisateur.Id.ToString();
                cboIdAgent.Text = Factory.Instance.GetAgent(utilisateur.Id_personne).Nom + " " + Factory.Instance.GetAgent(utilisateur.Id_personne).PostNom + " " + Factory.Instance.GetAgent(utilisateur.Id_personne).Prenom;
                cboCategorieUtilisateur.Text = Factory.Instance.GetCategorieUtilisateur(utilisateur.Id_categorieUtilisateur).Designation;
                txtUserName.Text = utilisateur.Nomuser;
                if ((utilisateur.Activation).ToString().Equals("True")) chkActivationUser.Checked = true;
                else chkActivationUser.Checked = false;
                //txtPwd.Text = u.Motpass;
            }

            lblConfirmPwd.Visible = false;
            txtConfirmPwd.Visible = false;
        }

        private void btnCloseManipUsers_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btModifierUserName_Click(object sender, EventArgs e)
        {
            try
            {
                utilisateur.Nomuser = cboUser.Text;

                if (!txtOldUserName.Text.Equals(""))
                {
                    if (!txtNewUserName.Text.Equals(""))
                    {
                        Factory.Instance.UpdateUserName(utilisateur.Nomuser, txtNewUserName.Text);
                        MessageBox.Show("Modification éffectué", "Modification", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        //Chargement des combo box : Utilisateur
                        try
                        {
                            this.loadAllCbo();
                        }
                        catch (Exception) { }

                        try
                        {
                            dgvUser.DataSource = Factory.Instance.GetUtilisateurs();
                        }
                        catch (Exception) { }

                        this.btClearUserName_Click(sender, e);
                    }
                    else
                    {
                        MessageBox.Show("Le nouveau nom d'utilisateur que vous avez saisis est invalide", "Modification", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                else
                {
                    MessageBox.Show("L'ancien nom d'utilisateur que vous avez saisis est invalide", "Modification", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Echec de la modification, " + ex.Message, "Modification", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btModifierPwdUser_Click(object sender, EventArgs e)
        {
            try
            {
                utilisateur.Nomuser = cboUserModPsd.Text;
                utilisateur.Motpass = txtNewPwd.Text;

                if (!txtOldPwd.Text.Equals(""))
                {
                    if (Factory.Instance.VerifiePassword(utilisateur.Nomuser))
                    {
                        if (!txtNewPwd.Text.Equals(""))
                        {
                            if (!txtConfNewPwd.Text.Equals(""))
                            {
                                if (txtNewPwd.Text.Equals(txtConfNewPwd.Text))
                                {
                                    Factory.Instance.UpdatePasswordUser(utilisateur.Nomuser, utilisateur.Motpass);
                                    MessageBox.Show("Modification éffectué", "Modification", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                    //Chargement des combo box : Utilisateur
                                    try
                                    {
                                        this.loadAllCbo();
                                    }
                                    catch (Exception) { }

                                    this.btClearPwdUser_Click(sender, e);
                                }
                                else
                                {
                                    MessageBox.Show("Les mots de passe que vous avez entrés ne correspondent pas", "Modification", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    txtNewPwd.Focus();
                                }
                            }
                            else
                            {
                                MessageBox.Show("Le mot de de confirmation ne peut être vide", "Modification", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                txtConfNewPwd.Focus();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Le nouveau mot de passe ne peut être vide", "Modification", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            txtNewPwd.Focus();
                        }
                    }
                    else
                    {
                        MessageBox.Show("L'ancien mot de passe est invalide", "Modification", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        txtOldPwd.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("L'ancien mot de passe ne peut être vide", "Modification", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtOldPwd.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Echec de la modification, " + ex.Message, "Modification", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btClearUserName_Click(object sender, EventArgs e)
        {
            txtOldUserName.Clear();
            txtNewUserName.Clear();
            txtOldUserName.Focus();
            if (cboUser.Items.Count != 0) cboUser.SelectedIndex = 0;
        }

        private void btClearPwdUser_Click(object sender, EventArgs e)
        {
            txtOldPwd.Clear();
            txtNewPwd.Clear();
            txtConfNewPwd.Clear();
            txtOldPwd.Focus();
            if (cboUserModPsd.Items.Count != 0) cboUserModPsd.SelectedIndex = 0;
        }

        private void cboIdPersonne_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                utilisateur.Id_personne = Convert.ToInt32(((Agent)cboIdAgent.SelectedItem).Id);
            }
            catch (Exception) { }
        }

        private void cmdAddCatUser_Click(object sender, EventArgs e)
        {
            try
            {
                lblIdCatUser.Text = Factory.Instance.ReNewIdValue(catU).ToString();
                txtDesignationCatUser.Clear();
                txtDesignationCatUser.Focus();
                cmdSaveCatUser.Enabled = true;
            }
            catch (Exception) { cmdSaveCatUser.Enabled = false; }
        }

        private void cmdSaveCatUser_Click(object sender, EventArgs e)
        {
            try
            {
                if (catU != null)
                {
                    catU.Id = Convert.ToInt32(lblIdCatUser.Text);
                    catU.Designation = txtDesignationCatUser.Text;
                    catU.Enregistrer();
                    cmdSaveCatUser.Enabled = false;
                    MessageBox.Show("Enregistrement éffectué", "Enregistrement", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    try
                    {
                        dgvCatUser.DataSource = Factory.Instance.GetCategorieUtilisateurs();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Erreur lors de l'actalisation de l'affichage", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                try
                {
                    cboCategorieUtilisateur.DataSource = Factory.Instance.GetCategorieUtilisateurs();
                }
                catch (Exception) { }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Echec de l'enregistrement, " + ex.Message, "Enregistrement", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void cmdDeleteCatUser_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show("Voulez - vous vraiment supprimer cet enregistrement ?", "Suppression", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    catU.Id = Convert.ToInt32(lblIdCatUser.Text);
                    catU.Supprimer();
                    MessageBox.Show("Suppression éffectuée", "Suppression", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    try
                    {
                        dgvCatUser.DataSource = Factory.Instance.GetCategorieUtilisateurs();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Erreur lors de l'actalisation de l'affichage", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }

                    if (dgvCatUser.RowCount <= 0)
                    {
                        cmdSaveCatUser.Enabled = false;
                        cmdModiCatUser.Enabled = false;
                        cmdDeleteCatUser.Enabled = false;
                    }

                    txtDesignationCatUser.Clear();
                    txtDesignationCatUser.Focus();

                    try
                    {
                        cboCategorieUtilisateur.DataSource = Factory.Instance.GetCategorieUtilisateurs();
                    }
                    catch (Exception) { }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Echec de la suppression", "Suppression", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            } 
        }

        private void cmdModiCatUser_Click(object sender, EventArgs e)
        {
            try
            {
                if (catU != null)
                {
                    catU.Id = Convert.ToInt32(lblIdCatUser.Text);
                    catU.Designation = txtDesignationCatUser.Text;
                    catU.Modifier();
                    MessageBox.Show("Modification éffectué", "Modification", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    try
                    {
                        dgvCatUser.DataSource = Factory.Instance.GetCategorieUtilisateurs();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Erreur lors de l'actalisation de l'affichage", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                try
                {
                    cboCategorieUtilisateur.DataSource = Factory.Instance.GetCategorieUtilisateurs();
                }
                catch (Exception) { }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Echec de la modification, " + ex.Message, "Modification", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void cboLeveluser_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                catU.Groupe = Convert.ToString(cboGroupeUser.SelectedItem);
            }
            catch (Exception) { }
        }

        private void cboCategorieUtilisateur_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                utilisateur.Id_categorieUtilisateur = Convert.ToInt32(((CategorieUtilisateur)cboCategorieUtilisateur.SelectedItem).Id);
            }
            catch (Exception) { }
        }

        private void cboLevelUser_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                catU.Groupe = Convert.ToString(cboGroupeUser.SelectedItem);
            }
            catch (Exception) { }
        }

        private void cmdAddUser_Click(object sender, EventArgs e)
        {
            try
            {
                lblIdUser.Text = Factory.Instance.ReNewIdValue(utilisateur).ToString();
                txtUserName.Clear();
                txtPwd.Clear();
                txtConfirmPwd.Clear();
                txtUserName.Focus();
                cmdSaveUser.Enabled = true;
                lblConfirmPwd.Visible = true;
                txtConfirmPwd.Visible = true;
            }
            catch (Exception) { cmdSaveUser.Enabled = false; }
        }

        private void cmdSaveUser_Click(object sender, EventArgs e)
        {
            try
            {
                if (utilisateur != null)
                {
                    if (txtPwd.Text == txtConfirmPwd.Text)
                    {
                        getAttributUtilisateur();
                        utilisateur.Enregistrer();
                        cmdSaveUser.Enabled = false;
                        cmdUpdateUser.Enabled = true;
                        MessageBox.Show("Enregistrement éffectué", "Enregistrement", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        try
                        {
                            dgvUser.DataSource = Factory.Instance.GetUtilisateurs();
                        }
                        catch (Exception e1)
                        {
                            MessageBox.Show(e1.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }

                        //Chargement des combo box : Utilisateur
                        try
                        {
                            this.loadAllCbo();
                        }
                        catch (Exception) { }
                    }
                    else
                    {
                        MessageBox.Show("Les mots de passe que vous avez entrés ne correspondent pas", "Enregistrement", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Echec de l'enregistrement, " + ex.Message, "Enregistrement", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void cmdDeleteUser_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show("Voulez - vous vraiment supprimer cet utilisateur ?", "Suppression", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    utilisateur.Id = Convert.ToInt32(lblIdUser.Text);
                    utilisateur.Supprimer();
                    MessageBox.Show("Suppression éffectuée", "Suppression", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    try
                    {
                        dgvUser.DataSource = Factory.Instance.GetUtilisateurs();
                    }
                    catch (Exception e1)
                    {
                        MessageBox.Show(e1.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }

                    //Chargement des combo box : Utilisateur
                    try
                    {
                        this.loadAllCbo();
                    }
                    catch (Exception) { }

                    if (dgvUser.RowCount <= 0)
                    {
                        cmdSaveUser.Enabled = false;
                        cmdDeleteUser.Enabled = false;
                    }
                    txtUserName.Clear();
                    txtPwd.Clear();
                    txtUserName.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Suppression", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void dgvCatUser_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                cmdSaveCatUser.Enabled = false;
                if (dgvCatUser.SelectedRows.Count > 0)
                {
                    cmdModiCatUser.Enabled = true;
                    cmdDeleteCatUser.Enabled = true;

                    catU = (CategorieUtilisateur)dgvCatUser.SelectedRows[0].DataBoundItem;
                    lblIdCatUser.Text = catU.Id.ToString();
                    cboGroupeUser.Text = catU.Groupe;
                    txtDesignationCatUser.Text = catU.Designation;
                }
            }
            catch (Exception) { }
        }

        private void cmdUpdateUser_Click(object sender, EventArgs e)
        {
            try
            {
                utilisateur.Id = Convert.ToInt32(lblIdUser.Text);
                utilisateur.Nomuser = txtUserName.Text;
                utilisateur.Activation = chkActivationUser.Checked;

                utilisateur.Modifier();

                MessageBox.Show("Modification éffectuée", "Modification", MessageBoxButtons.OK, MessageBoxIcon.Information);

                try
                {
                    dgvUser.DataSource = Factory.Instance.GetUtilisateurs();
                }
                catch (Exception e1)
                {
                    MessageBox.Show(e1.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Echec de la modification, " + ex.Message, "Modification", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
