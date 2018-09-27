using System;

namespace GestionClinic_LIB
{
    public class Article
    {
        public void Enregistrer() 
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

        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private string designation;

        public string Designation
        {
            get { return designation; }
            set
            {
                if (value != null && value != "")
                {
                    designation = value.ToUpper();
                }
                else throw new Exception("La designation de l'article ne peut être vide");
            }
        }
        private double pu;

        public double Pu
        {
            get { return pu; }
            set 
            {
                if (value <= 0) throw new Exception("Le prix ne peut pas être inférieur ou égal à 0");
                else
                pu = value; 
            }
        }
        private int id_categorie;

        public int Id_categorie
        {
            get { return id_categorie; }
            set { id_categorie = value; }
        }

        public override string ToString()
        {
            return this.designation;
        }
    }
}

