using System;
using System.Windows.Forms;
using GestionClinic_LIB;

namespace GestionClinic_WIN
{
    public partial class ConnexionBd : UserControl
    {
        public ConnexionBd()
        {
            InitializeComponent();
        }

        private void ConnexionBd_Load(object sender, EventArgs e)
        {
          
            try
            {
                cboServeur.Text = Factory.Instance.loadParam()[0];
                txtBD.Text = Factory.Instance.loadParam()[1];
                txtNomUser.Text = Factory.Instance.loadParam()[2];
            }
            catch (Exception) { }
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void CallVerifieConnect()
        {
            bool ok = false;
            Utilisateur utilisateur = new Utilisateur();//"superuser", "superpassword"
            utilisateur.Nomuser = txtUserSimple.Text;
            utilisateur.Motpass = txtPwdUserSimple.Text;

            if (Factory.Instance.verifieLoginUser(utilisateur.Nomuser, utilisateur.Motpass)[2].Equals("0"))
            {
                ok = true;
                Factory.IsAdmin = true;
            }//L'Utilisateur est un SuperAdministrateur ou un Administrateur
            else if (Factory.Instance.verifieLoginUser(utilisateur.Nomuser, utilisateur.Motpass)[2].Equals("1"))
            {
                ok = true;
                Factory.IsDirection = true;
            }//L'Utilisateur est un Agent de Direction
            else if (Factory.Instance.verifieLoginUser(utilisateur.Nomuser, utilisateur.Motpass)[2].Equals("2"))
            {
                ok = true;
                Factory.IsOther = true;
            }//L'Utilisateur est un Agent simple

            if (ok)
            {
                MessageBox.Show("Connexion réussie", "Connexion à la base de données", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Visible = false;
                //principal.Show();
            }
            else
            {
                MessageBox.Show("Echec de l'authentification de l'utilisateur", "Authentification de l'utilisateur", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtPwdUserSimple.Clear();
                txtUserSimple.Clear();
                txtUserSimple.Focus();
            } 
        }

        private void cmdConnect_Click(object sender, EventArgs e)
        {
            try
            {
                if (Factory.Instance.VerifieDoConnect(cboServeur.Text, txtBD.Text, txtNomUser.Text, txtMotPass.Text))
                {
                    CallVerifieConnect();
                }
                else MessageBox.Show("Echec de connexion", "Connexion à la base de données", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Connexion à la base de données", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btfermer_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
