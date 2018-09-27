using System;
using System.Windows.Forms;
using GestionClinic_LIB;

namespace GestionClinic_WIN
{
    public partial class ServiceForm : Form
    {
        public ServiceForm()
        {
            InitializeComponent();
        }
        Service service = new Service();
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            refresh();
        }
        private void refresh()
        {
            try
            {

                dgvService.DataSource = Factory.Instance.GetServices();

                if (dgvService.RowCount > 0)
                {
                    btnModifier.Enabled = true;
                    btnDelete.Enabled = true;
                }
                else
                {
                    btnModifier.Enabled = false;
                    btnDelete.Enabled = false;
                    btnSave.Enabled = false;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Erreur lors de l'actualisation", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (service != null)
                {
                    getAttributs();

                    service.Enregistrer();
                    btnSave.Enabled = false;
                    //Permet l'actualisation des valeur des services sur le formulair des Agents
                    Factory.EnterForFormService = true;
                    MessageBox.Show("Enregistrement éffectué", "Enregistrement", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    refresh();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Echec de l'enregistrement " + ex.Message, "Enregistrement", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private void getAttributs()
        {
            service.Id = Convert.ToInt32(txtId.Text);
            service.Designation = txtDesign.Text;
        }

        private void btnModifier_Click(object sender, EventArgs e)
        {
            try
            {
                if (service != null)
                {
                    getAttributs();
                    service.Modifier();
                    //Permet l'actualisation des valeur des qualification sur le formulair des Agents
                    Factory.EnterForFormService = true;
                    MessageBox.Show("Modification effectuée!", "Modification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Echec de la modification " + ex.Message, "Modification", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show("Voulez - vous vraiment supprimer cet enregistrement ?", "Suppression", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    service.Id = Convert.ToInt32(txtId.Text);
                    service.Supprimer();
                    //Permet l'actualisation des valeur des qualification sur le formulair des Agents
                    Factory.EnterForFormService = true;
                    MessageBox.Show("Suppression éffectuée", "Suppression", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    refresh();

                    if (dgvService.RowCount <= 0)
                    {
                        btnSave.Enabled = false;
                        btnModifier.Enabled = false;
                        btnDelete.Enabled = false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Echec de la suppression " + ex.Message, "Suppression", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                txtId.Text = Factory.Instance.ReNewIdValue(service).ToString();
                txtDesign.Clear();
                btnSave.Enabled = true;
            }
            catch (Exception) { btnSave.Enabled = false; }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ServiceForm_Load(object sender, EventArgs e)
        {
            refresh();
            txtId.Enabled = false;
        }

        private void dgvService_SelectionChanged_1(object sender, EventArgs e)
        {
            try
            {
                if (dgvService.SelectedRows.Count > 0)
                {
                    service = (Service)dgvService.SelectedRows[0].DataBoundItem;
                    txtId.Text = service.Id.ToString();
                    txtDesign.Text = service.Designation.ToString();
                }
            }
            catch (Exception) { MessageBox.Show("Erreur dans la zone d'affichage", "Erreur d'affichage"); }
        }
    }
}
