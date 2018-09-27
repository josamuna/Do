using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using GestionClinic_LIB;
using GestionClinic_RPT;

namespace GestionClinic_WIN
{
    public partial class FactureFrm : UserControl
    {
        public FactureFrm()
        {
            InitializeComponent();
        }

        private void FactureFrm_Load(object sender, EventArgs e)
        {
            cboClient.DataSource = Factory.Instance.getClients();
        }

        private void ReportLoad()
        {
            //try
            //{
                Facture rpt = new Facture();
                SqlCommand cmd = new SqlCommand(@"SELECT personne.nom, personne.postnom, personne.prenom, personne.sexe, 
                Article.designation AS Article, Article.pu,paiement.qte_vendue AS [Quantité vendu], paiement.qte_vendue * Article.pu AS [Prix total], paiement.date_paiement 
                FROM paiement INNER JOIN Article ON paiement.id_article = Article.id INNER JOIN client ON 
                paiement.id_client = client.id INNER JOIN personne ON client.id_personne = personne.id where client.id=@id", Factory.Instance.connectDB());

                SqlDataAdapter sa = new SqlDataAdapter(cmd);

                SqlParameter paramId = cmd.CreateParameter();
                paramId.ParameterName = "@id";
                paramId.Value = ((Client)cboClient.SelectedItem).Id;
                cmd.Parameters.Add(paramId);
                cmd.ExecuteNonQuery();

                DataSet ds = new DataSet();

                sa.Fill(ds, "doc");
                rpt.SetDataSource(ds.Tables["doc"]);
                rptvFacture.ReportSource = rpt;
                rptvFacture.Refresh();
                sa.Dispose();
                ds.Dispose();
                cmd.Dispose();
            //}
            //catch (Exception exc)
            //{
            //    MessageBox.Show(exc.Message, "Erreur de l'afichage du rapport", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //}
        }

        private void btnValider_Click(object sender, EventArgs e)
        {
            ReportLoad();
        }

        private void btnCloseAgent_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
