using System;
using System.Text;

namespace GestionClinic_LIB
{
    public class PaiementArticle
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        private int quantite;

        public int Quantite
        {
            get { return quantite; }
            set { quantite = value; }
        }
        private DateTime date;

        public DateTime Date
        {
            get { return date; }
            set { date = value; }
        }
        private int id_article;

        public int Id_article
        {
            get { return id_article; }
            set { id_article = value; }
        }
        private int id_client;

        public int Id_client
        {
            get { return id_client; }
            set { id_client = value; }
        }

        private double montantPaye;

        public double MontantPaye
        {
            get { return montantPaye; }
            set { montantPaye = value; }
        }


        public void Enregistre()
        {
            Factory.Instance.Save(this);
        }

        public void Modifier()
        {
            Factory.Instance.Update(this);
        }

        public void Supprimer()
        {
            Factory.Instance.Delete(this);
        }
    }
}
