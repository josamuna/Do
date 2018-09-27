using System;

namespace GestionClinic_LIB
{
    public class Client: Personne
    {
        public override void Enregistrer()
        {
            Factory.Instance.Save(this);
        }

        public override void Modifier()
        {
            base.Modifier();
            Factory.Instance.Update(this);
        }

        public override void Supprimer()
        {
            base.Supprimer();
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
    }
}
