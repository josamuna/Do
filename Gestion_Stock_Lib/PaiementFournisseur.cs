using System;
using GestionClinic_LIB;


namespace GestionClinic_LIB
{
    public class PaiementFournisseur
    {

        public void Enregistrer() 
        {
            Factory.Instance.Save(this);
        }
        public void modifier() 
        {
            Factory.Instance.Update(this);
        }
        public void supprimer() 
        {
            Factory.Instance.Delete(this);
        }
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private int id_agent;

        public int Id_agent
        {
            get { return id_agent; }
            set { id_agent = value; }
        }

        private int id_fournisseur;

        public int Id_fournisseur
        {
            get { return id_fournisseur; }
            set { id_fournisseur = value; }
        }
        private double montant;

        public double Montant
        {
            get { return montant; }
            set { montant = value; }
        }
        DateTime date;

        public DateTime Date
        {
            get { return date; }
            set { date = value; }
        }
    }
}
