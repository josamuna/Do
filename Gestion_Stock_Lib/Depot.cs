using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gestion_Stock_Lib
{
    public class Depot
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
        int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        string designation;

        public string Designation
        {
            get { return designation; }
            set
            {
                if (value != null && value != "")
                {
                    designation = value.ToUpper();
                }
                else throw new Exception("La designation ne peut pas être vide");
            }
        }
        public override string ToString()
        {
            return designation;
        }
    }
}

