using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GestionClinic_LIB;

namespace GestionClinic_LIB
{
    public class Fournisseur: Personne
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

        private string nrc;

        public string Nrc
        {
            get { return nrc; }
            set { nrc = value; }
        }
    }
}
