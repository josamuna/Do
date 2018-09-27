using System;

namespace GestionClinic_LIB
{
    public class CategorieArticle
    {

        public void Enregistrer() 
        {
            Factory.Instance.Save(this);
        }
        public void modifier() 
        {
            Factory.Instance.Update(this);
        }
        public void Supprimmer() 
        {
            Factory.Instance.Delete(this);
        }
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public override string ToString()
        {
            return designation;
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
                else throw new Exception("La designation ne peut pas être vide");
          }
        }
    }
}
