using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using GestionClinic_LIB;
using GestionClinic_RPT;

namespace GestionClinic_WIN
{
    public partial class rptListeClient : UserControl
    {
        public rptListeClient()
        {
            InitializeComponent();
        }

        private void rptListeClientF_Load(object sender, EventArgs e)
        {
            
        }

        private void rptListeClient_Load(object sender, EventArgs e)
        {
            try
            {
                ListeClient rpt = new ListeClient();
                SqlCommand cmd = new SqlCommand(@"SELECT personne.nom, personne.postnom, personne.prenom, personne.sexe, personne.numeroTel
                FROM client INNER JOIN personne ON client.id_personne = personne.id", Factory.Instance.connectDB());
                SqlDataAdapter sa = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                sa.Fill(ds, "doc");
                rpt.SetDataSource(ds.Tables["doc"]);
                rptListeClientF.ReportSource = rpt;
                rptListeClientF.Refresh();
                sa.Dispose();
                ds.Dispose();
                cmd.Dispose();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Erreur de l'afichage du rapport", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnCloseAgent_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
