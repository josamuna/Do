using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GestionClinic_LIB
{
    public class Commande
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        private DateTime date_commande;

        public DateTime Date_commande
        {
            get { return date_commande; }
            set { date_commande = value; }
        }

        private int id_fournisseur;

        public int Id_fournisseur
        {
            get { return id_fournisseur; }
            set { id_fournisseur = value; }
        }
        private int id_agent;

        public int Id_agent
        {
            get { return id_agent; }
            set { id_agent = value; }
        }
        
    }
}
