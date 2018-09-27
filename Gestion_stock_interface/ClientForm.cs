using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GestionClinic_LIB;



namespace GestionClinic_WIN
{
    public partial class ClientForm : UserControl
    {
        public ClientForm()
        {
            InitializeComponent();
        }
        private bool modiPhoto;
        private string pathPhotoLoad = null;
        Client client = new Client();
        Photo photo = new Photo();
        Personne personne = new Personne();

        private void ClientForm_Load(object sender, EventArgs e)
        {
            try
            {
                CmbRechercherClient.DataSource = Factory.Instance.getClients();
                CmbRechercherClient.AutoCompleteSource = AutoCompleteSource.ListItems;
                CmbRechercherClient.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                CmbRechercherClient.Text = "";
            }
            catch (Exception) { }
            //Chargement des tous les Combos
            try
            {
                chargementComboClient();
            }
            catch (Exception)
            {
                MessageBox.Show("erreur lors du chargement des listes déroulantes", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            try
            {
                dgvClient.DataSource = Factory.Instance.getClients();
                
            }
            catch (Exception)
            {
                MessageBox.Show("erreur lors de l'affichage", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            btnSaveClient.Enabled = false;

            if (dgvClient.RowCount <= 0)
            {
                btnSaveClient.Enabled = false;
                btnModifierClient.Enabled = false;
                btnSpprimerClient.Enabled = false;   
            }
        }

        private void chargementComboClient()
        {
            cboEtatCivClient.Items.Add("CELIBATAIRE");
            cboEtatCivClient.Items.Add("MARIE(E)");
            cboEtatCivClient.Items.Add("VEUF(VE)");
            cboEtatCivClient.SelectedIndex = 0;

            cboSexeClient.Items.Add("M");
            cboSexeClient.Items.Add("F");
            cboSexeClient.SelectedIndex = 0;
        }

        public void initialiseClient() 
        {
            txtCodeClient.Clear();
            txtNomClient.Clear();
            txtPNomClient.Clear();
            txtPrenomClient.Clear();
            txtDateNaissanceClient.Clear();
            txtNumTelClient.Clear();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ClientForm));
            picPhoto.Image = null;
            pathPhotoLoad = null;
            txtNomClient.Focus();
        }
        private void btnAddClient_Click(object sender, EventArgs e)
        {
            try
            {   initialiseClient();
                client.Id = Factory.Instance.ReNewIdValue(client, 0);
                photo.Id=Factory.Instance.ReNewIdValue(photo);
                client.IdPers=Factory.Instance.ReNewIdValue(personne);
                txtCodeClient.Text = client.Id.ToString();
                btnSaveClient.Enabled = true;
            }
            catch (Exception) { btnSaveClient.Enabled = false; }
        }

        private void txtDateNaissanceAgent_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }
        public void refreshClient() 
        {
            modiPhoto = false; //initialisation de la variable pour n'est pa permettre la modifocation de la photo
            dgvClient.DataSource = Factory.Instance.getClients();
            if (dgvClient.RowCount > 0)
            {
                btnModifierClient.Enabled = true;
                btnSpprimerClient.Enabled = true;
            }
            else
            {
                btnModifierClient.Enabled = false;
                btnSpprimerClient.Enabled = false;
                btnSaveClient.Enabled = false;
            }

            int col = 0;
            foreach (DataGridViewColumn dgvc in dgvClient.Columns)
            {
                dgvClient.AutoResizeColumn(col);
                col++;
            }
        }

        public void GetClient() 
        {
            //Personne-Agent
            client.Id_personne = client.IdPers;
            client.Id =Convert.ToInt32(txtCodeClient.Text);
            client.Nom = txtNomClient.Text;
            client.PostNom = txtPNomClient.Text;
            client.Prenom = txtPrenomClient.Text;
            client.Sexe = cboSexeClient.Text;
            client.EtatCivil = cboEtatCivClient.Text;
            client.Telephone = txtNumTelClient.Text;
            if (txtDateNaissanceClient.Text.Equals("  /  /")) { client.DateNaissance = null; }
            else { client.DateNaissance = Convert.ToDateTime(txtDateNaissanceClient.Text); }

            //Agent
            client.Id =Convert.ToInt32(txtCodeClient.Text);
            
            //Parametres pour la photo de la personne
            photo.Id_personne = client.IdPers;
            photo.PhotoPersonne = pathPhotoLoad;
        }

        private void btnRefreshClient_Click(object sender, EventArgs e)
        {
            refreshClient();
        
        }

        private void btnSaveClient_Click(object sender, EventArgs e)
        {
            try
            {
                if (client != null && personne != null)
                {
                    GetClient();
                    client.Enregistrer();

                    //Apres l'insertion de la personne et de l'agent, on insere sa photo
                    //if (Factory.Instance.GetIdPhoto(agent.IdPers) == 0) photo.Id = (Factory.Instance.GetIdPhoto(agent.IdPers)) + 1;
                    //else photo.Id = Factory.Instance.GetIdPhoto(agent.IdPers);

                    //photo.Enregistrer();
                    btnSaveClient.Enabled = false;
                    MessageBox.Show("Enregistrement éffectué", "Enregistrement", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    try
                    {
                        refreshClient();
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

        private void dgvClient_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgvClient.SelectedRows.Count > 0)
                {
                    modiPhoto = false;//unitialisation de la variable pour hinibé la modification de la photo
                    client = null;
                    client = (Client)dgvClient.SelectedRows[0].DataBoundItem;

                    client.IdPers = client.Id_personne;//On sette l'Id de la personne
                    client.Sexe = cboSexeClient.Text;
                    client.EtatCivil = cboEtatCivClient.Text;

                    //Personne
                    client.Id_personne = client.IdPers;
                    txtCodeClient.Text = Convert.ToString(client.Id);
                    txtNomClient.Text = client.Nom;
                    txtPNomClient.Text = client.PostNom;
                    txtPrenomClient.Text = client.Prenom;
                    cboSexeClient.Text = client.Sexe;
                    cboEtatCivClient.Text = client.EtatCivil;
                    txtNumTelClient.Text = client.Telephone;
                    txtDateNaissanceClient.Text = Convert.ToString(client.DateNaissance);
                    //Chargement de la photo
                    try
                    {
                        picPhoto.Image = Bitmap.FromStream(Factory.Instance.GetPhotoPersonne(Factory.Instance.GetPhoto(client.IdPers)));
                    }
                    catch (Exception)
                    {
                        picPhoto.Image = null;
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Erreur dans la zone d'affichage", "Erreur d'affichage");
            }
        }

        private void btnModifierClient_Click(object sender, EventArgs e)
        {
            try
            {
                if (client != null && photo != null)
                {
                    GetClient(); ;
                    client.Modifier();
                    if (modiPhoto)
                    {
                        //On modifie la photo de l'Agent qui est une personne
                        if (Factory.Instance.GetIdPhoto(client.IdPers) == 0) photo.Id = (Factory.Instance.GetIdPhoto(client.IdPers)) + 1;
                        else photo.Id = Factory.Instance.GetIdPhoto(client.IdPers);
                        photo.Modifier();
                    }
                    MessageBox.Show("Modification effectuée!", "Modification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    pathPhotoLoad = null;

                    try
                    {
                        refreshClient();
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

        private void btnSpprimerClient_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show("Voulez - vous vraiment supprimer cet enregistrement ?", "Suppression", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    //avant de supprimer la personne, on supprime d'abord sa photo
                    if (Factory.Instance.GetIdPhoto(client.IdPers) == 0) photo.Id = (Factory.Instance.GetIdPhoto(client.IdPers)) + 1;
                    else photo.Id = Factory.Instance.GetIdPhoto(client.IdPers);
                    //photo.Supprimer();
                    client.Supprimer();

                    MessageBox.Show("Suppression éffectuée", "Suppression", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    initialiseClient();

                    try
                    {
                        refreshClient();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Erreur lors de l'actualisation des Agents", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }

                    if (dgvClient.RowCount > 0)
                    {
                        btnModifierClient.Enabled = true;
                        btnSpprimerClient.Enabled = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Suppression", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void lblLoadPhotoAgent_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (dlgFile.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    FileInfo file = new FileInfo(dlgFile.FileName);
                    picPhoto.Load(dlgFile.FileName);
                    //On verifie d'abord que l'extension est .jpg ou .png
                    if (Factory.Instance.verifiePhotoExtension(dlgFile.FileName))
                    {
                        pathPhotoLoad = file.FullName;
                        modiPhoto = true; //la variable prand true pour permetre la modification de la photo
                    }
                }
                catch (ArgumentException)
                {
                    MessageBox.Show("Impossible de charger le fichier", "Photo invalide", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Impossible de charger le fichier, " + ex.Message, "Photo invalide", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private void CmbRechercherClient_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                client = (Client)CmbRechercherClient.SelectedItem;

                client.IdPers = client.Id_personne;//On sette l'Id de la personne
                client.Sexe = cboSexeClient.Text;
                client.EtatCivil = cboEtatCivClient.Text;

                //Personne
                client.Id_personne = client.IdPers;
                txtCodeClient.Text = Convert.ToString(client.Id);
                txtNomClient.Text = client.Nom;
                txtPNomClient.Text = client.PostNom;
                txtPrenomClient.Text = client.Prenom;
                cboSexeClient.Text = client.Sexe;
                cboEtatCivClient.Text = client.EtatCivil;
                txtNumTelClient.Text = client.Telephone;
                txtDateNaissanceClient.Text = Convert.ToString(client.DateNaissance);
                //Chargement de la photo
                try
                {
                    picPhoto.Image = Bitmap.FromStream(Factory.Instance.GetPhotoPersonne(Factory.Instance.GetPhoto(client.IdPers)));
                }
                catch (Exception)
                {
                    picPhoto.Image = null;
                }
            }
            catch (Exception) { }
        }

        private void btnCloseAgent_Click(object sender, EventArgs e)
        {
            this.Dispose();
        } 
    }
}
