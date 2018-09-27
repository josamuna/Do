using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using GestionClinic_LIB;
using GestionClinic_RPT;

namespace GestionClinic_WIN
{
    public partial class rptEtatStockF : UserControl
    {
        public rptEtatStockF()
        {
            InitializeComponent();
        }

        private void rptEtatStockF_Load(object sender, EventArgs e)
        {
            try
            {
                Etat_Stock rpt = new Etat_Stock();
                SqlCommand cmd = new SqlCommand(@"SELECT Article.designation, SUM(paiement.qte_vendue) AS Quantite_Vendue, SUM(livraison.qte_e) AS Quantite_Entree, 
                livraison.qte_e - paiement.qte_vendue AS Etat_Stock FROM paiement INNER JOIN livraison ON paiement.id = livraison.id INNER JOIN Article 
                ON paiement.id_article = Article.id AND livraison.id_article = Article.id GROUP BY livraison.qte_e - paiement.qte_vendue, Article.designation", Factory.Instance.connectDB());
                SqlDataAdapter sa = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                sa.Fill(ds, "doc");
                rpt.SetDataSource(ds.Tables["doc"]);
                rptvEtat.ReportSource = rpt;
                rptvEtat.Refresh();
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
