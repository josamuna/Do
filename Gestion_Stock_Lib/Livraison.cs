using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GestionClinic_LIB
{
    public class Livraison
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        private int id_article;

        public int Id_article
        {
            get { return id_article; }
            set { id_article = value; }
        }

        private int id_fournisseur;

        public int Id_fournisseur
        {
            get { return id_fournisseur; }
            set { id_fournisseur = value; }
        }
        private  int qte_e;

        public int Qte_e
        {
            get { return qte_e; }
            set
            {
                if (value <= 0) throw new Exception("La Quantité que vous avez entré n'est pas valide!");
                qte_e = value;
            }
        }

        private DateTime date_livraison = DateTime.Today;

        public DateTime Date_livraison
        {
            get { return date_livraison; }
            set { date_livraison = value; }
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
