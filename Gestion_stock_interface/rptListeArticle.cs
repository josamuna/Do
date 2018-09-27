using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using GestionClinic_LIB;
using GestionClinic_RPT;
namespace GestionClinic_WIN
{
    public partial class rptListeArticle : UserControl
    {
        public rptListeArticle()
        {
            InitializeComponent();
        }

        private void rptListeArticle_Load(object sender, EventArgs e)
        {
            try
            {
                ListeArticle rpt = new ListeArticle();
                SqlCommand cmd = new SqlCommand(@"SELECT  Article.designation AS Article, Article.pu, categorie_Article.designation FROM Article INNER JOIN
                categorie_Article ON Article.id_categorie = categorie_Article.id", Factory.Instance.connectDB());
                SqlDataAdapter sa = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                sa.Fill(ds, "doc");
                rpt.SetDataSource(ds.Tables["doc"]);
                rptListeArt.ReportSource = rpt;
                rptListeArt.Refresh();
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
