using System;

namespace GestionClinic_LIB
{
    public class Service
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
                else throw new Exception("La designation du service ne peut être vide");
            }
        }
        
        public override string ToString()
        {
            return this.designation;
        }
    }
}

