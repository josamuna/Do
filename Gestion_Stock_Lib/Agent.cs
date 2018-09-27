using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GestionClinic_LIB;

namespace GestionClinic_LIB
{
    public class Agent: Personne
    {
    
        public override void Enregistrer()
        {
            Factory.Instance.Save(this);
        }

        public override void Modifier()
        {
            Factory.Instance.Update(this);
        }

        public override void Supprimer()
        {
            Factory.Instance.Delete(this);
        }
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private int id_personne;

        public int Id_personne
        {
            get { return id_personne; }
            set { id_personne = value; }
        }
        private int id_service;

        public int Id_service
        {
            get { return id_service; }
            set { id_service = value; }
        }
        private string matricule;

        public string Matricule
        {
            get { return matricule; }
            set { matricule = value; }
        }
        private string fonction;

        public string Fonction
        {
            get { return fonction; }
            set
            {
                if (value != null && value != "")
                {
                    fonction = value.ToUpper();
                }
                else throw new Exception("La fonction de l'agent ne peut être vide");
            }
        }
    }
}
