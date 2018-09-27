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
    public partial class AgentForm : UserControl
    {
        public AgentForm()
        {
            InitializeComponent();
        }
        Agent agent = new Agent();
        Personne personne = new Personne();
        Service service = new Service();

        public void chargementCombo() 
        {
            cboEtatCivAgent.Items.Add("CELIBATAIRE");
            cboEtatCivAgent.Items.Add("MARIE(E)");
            cboEtatCivAgent.Items.Add("VEUF(VE)");
            cboEtatCivAgent.SelectedIndex = 0;

            cboSexeAgent.Items.Add("M");
            cboSexeAgent.Items.Add("F");
            cboSexeAgent.SelectedIndex = 0;
        } 

        public void initialiseAgent() 
        {         
            txtIdAgent.Clear();
            txtNomAgent.Clear();
            txtPNomAgent.Clear();
            txtPrenomAgent.Clear();
            txtDateNaissanceAgent.Clear();
            txtTelephoneAgent.Clear();
            txtMatriculeAgent.Clear();
            txtFonctionAgent.Clear();
            txtAdresseAgent.Clear();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AgentForm));
            txtNomAgent.Focus();
        }

        public void RefreshAgent() 
        {
            dgvAgent.DataSource = Factory.Instance.GetAgents();
            cboMagasinier.DataSource = Factory.Instance.GetAgents();

            if (dgvAgent.RowCount > 0)
            {
                btnModifierAgent.Enabled = true;
                btnDeleteAgent.Enabled = true;
            }
            else
            {
                btnModifierAgent.Enabled = false;
                btnDeleteAgent.Enabled = false;
                btnSaveAgent.Enabled = false;
            }

            int col = 0;
            foreach (DataGridViewColumn dgvc in dgvAgent.Columns)
            {
                dgvAgent.AutoResizeColumn(col);
                col++;
            }
        }

        private void btnRefreshMagasinier_Click(object sender, EventArgs e)
        {
            RefreshAgent();
        }

        public void GetAgent() 
        {
            agent.Id_personne = agent.IdPers;
            personne.IdPers = agent.IdPers;
            agent.Nom = txtNomAgent.Text;
            agent.PostNom = txtPNomAgent.Text;
            agent.Prenom = txtPrenomAgent.Text;
            agent.Sexe = cboSexeAgent.Text;
            agent.EtatCivil = cboEtatCivAgent.Text;
            agent.Telephone = txtTelephoneAgent.Text;
            agent.Adresse = txtAdresseAgent.Text;
            agent.Matricule = txtMatriculeAgent.Text;
            agent.Fonction = txtFonctionAgent.Text;
            if (txtDateNaissanceAgent.Text.Equals("  /  /")) { agent.DateNaissance = null;}
            else { agent.DateNaissance = Convert.ToDateTime(txtDateNaissanceAgent.Text); };

            try
            {
                agent.Id_service = ((Service)cboIdService.SelectedItem).Id;
            }
            catch (Exception) { }
        }

        private void btnCloseAgent_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void lblAjouterService_Click(object sender, EventArgs e)
        {
            ServiceForm frm = new ServiceForm();
            frm.ShowDialog();
        }

        private void cboIdService_DropDown(object sender, EventArgs e)
        {
            if (Factory.EnterForFormService)
            {
                try
                {
                    cboIdService.DataSource = Factory.Instance.GetServices();
                }
                catch (Exception) { }
            }
        }

        private void cboIdService_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                agent.Id_service = ((Service)cboIdService.SelectedItem).Id;
            }
            catch (Exception) { }
        }

        private void btnSaveAgent_Click(object sender, EventArgs e)
        {
            try
            {
                if (agent != null && personne != null)
                {
                    GetAgent();
                    agent.Enregistrer();

                    btnSaveAgent.Enabled = false;
                    MessageBox.Show("Enregistrement éffectué", "Enregistrement", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    try
                    {
                        RefreshAgent();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Erreur lors de l'actualisation des Magasiniers", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Enregistrement", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnModifierAgent_Click(object sender, EventArgs e)
        {
            try
            {
                if (agent != null)
                {
                    GetAgent();
                    agent.Id = Convert.ToInt32(txtIdAgent.Text);
                    agent.Modifier();
                    MessageBox.Show("Modification effectuée!", "Modification", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    try
                    {
                        RefreshAgent();
                    }
                    catch (Exception ex1)
                    {
                        MessageBox.Show("Echec de la modification " + ex1.Message, "Modification", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }
            catch (Exception ex2)
            {
                MessageBox.Show(ex2.Message, "Modification", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnDeleteAgent_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show("Voulez - vous vraiment supprimer cet enregistrement ?", "Suppression", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    agent.Supprimer();

                    MessageBox.Show("Suppression éffectuée", "Suppression", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    initialiseAgent();

                    try
                    {
                        RefreshAgent();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Erreur lors de l'actualisation des Magasiniers", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }

                    if (dgvAgent.RowCount > 0)
                    {
                        btnModifierAgent.Enabled = true;
                        btnDeleteAgent.Enabled = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Suppression", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void dgvAgent_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgvAgent.SelectedRows.Count > 0)
                {
                    agent = (Agent)dgvAgent.SelectedRows[0].DataBoundItem;

                    //Personne
                    txtIdAgent.Text = Convert.ToString(agent.Id);
                    agent.IdPers = agent.Id_personne;
                    personne.IdPers = agent.IdPers;
                    agent.Id_personne = agent.Id_personne;
                    txtNomAgent.Text = agent.Nom;
                    txtPNomAgent.Text = agent.PostNom;
                    txtPrenomAgent.Text = agent.Prenom;
                    cboSexeAgent.Text = agent.Sexe;
                    cboEtatCivAgent.Text = agent.EtatCivil;
                    txtTelephoneAgent.Text = agent.Telephone;

                    //Agent
                    txtAdresseAgent.Text = agent.Adresse;
                    txtMatriculeAgent.Text = agent.Matricule;
                    txtFonctionAgent.Text = agent.Fonction;
                    txtDateNaissanceAgent.Text = Convert.ToString(agent.DateNaissance); 
                    cboIdService.Text = Factory.Instance.GetService(agent.Id_service).ToString();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Erreur dans la zone d'affichage", "Erreur d'affichage");
            }
        }

        private void AgentForm_Load(object sender, EventArgs e)
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
                dgvAgent.DataSource = Factory.Instance.GetAgents();
                cboMagasinier.DataSource = Factory.Instance.GetAgents();
                cboIdService.DataSource = Factory.Instance.GetServices();

                //On rend inisible certaines colonne des DataGridView qui recup les dataproperty
                //correspondant aux noms des accesseurs
                int col1 = 0, col2 = 0;
                foreach (DataGridViewColumn dgvc in dgvAgent.Columns)
                {
                    if (dgvc.DataPropertyName == "Id") dgvc.Visible = false;
                    else if (dgvc.DataPropertyName == "Id_personne") dgvc.Visible = false;
                    else if (dgvc.DataPropertyName == "Id_service") dgvc.Visible = false;
                    else if (dgvc.DataPropertyName == "IdPers") dgvc.Visible = false;
                    dgvAgent.AutoResizeColumn(col1);
                    col1++;
                }

                foreach (DataGridViewColumn dgvc in dgvCommandes.Columns)
                {
                    if (dgvc.DataPropertyName == "Id") dgvc.Visible = false;
                    else if (dgvc.DataPropertyName == "Id_agent") dgvc.Visible = false;
                    else if (dgvc.DataPropertyName == "Id_service") dgvc.Visible = false;
                    dgvCommandes.AutoResizeColumn(col2);
                    col2++;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("erreur lors de l'affichage", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            btnSaveAgent.Enabled = false;

            if (dgvAgent.RowCount <= 0)
            {
                btnSaveAgent.Enabled = false;
                btnModifierAgent.Enabled = false;
                btnDeleteAgent.Enabled = false;
            }
        }

        private void btnAddAgent_Click(object sender, EventArgs e)
        {
            try
            {
                initialiseAgent();
                agent.Id = Factory.Instance.ReNewIdValue(personne, 2);
                agent.IdPers = Factory.Instance.ReNewIdValue(personne);
                txtIdAgent.Text = agent.Id.ToString();
                btnSaveAgent.Enabled = true;
            }
            catch (Exception) { btnSaveAgent.Enabled = false; }
        }
    }
}
