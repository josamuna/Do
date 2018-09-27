using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GestionClinic_LIB
{
    public class Personne
    {
        public virtual void Enregistrer()
        {
            Factory.Instance.Save(this);
        }

        public virtual void Modifier()
        {
            Factory.Instance.Update(this);
        }

        public virtual void Supprimer()
        {
            Factory.Instance.Delete(this);
        }

        private int idPers;

        public int IdPers
        {
            get { return idPers; }
            set { idPers = value; }
        }

        private List<Personne> lstPersonne;

        public List<Personne> LstPersonne
        {
            get
            {
                if (lstPersonne == null) lstPersonne = new List<Personne>();
                return lstPersonne;
            }
        }

        public override string ToString()
        {
            return this.Nom + " " + this.PostNom + " " + this.Prenom;
        }

        private string nom;

        public string Nom
        {
            get { return nom; }
            set { nom = ValiderNom(value, false).ToUpper(); }
        }
        private string postNom;

        public string PostNom
        {
            get { return postNom; }
            set { postNom = ValiderNom(value, true).ToUpper(); }
        }
        private string prenom;

        public string Prenom
        {
            get { return prenom; }
            set { prenom = ValiderNom(value, true).ToUpper(); }
        }

        private DateTime? dateNaissance;

        public DateTime? DateNaissance
        {
            get { return dateNaissance; }
            set
            {
                if (value.HasValue)
                {
                    if (value.Equals("01/01/0001")) { }
                    if (value.Value.Year > 1 && value.Value.Year <= 1920)
                        throw new Exception("La date de naissance est invalide, l'année doit être supérieure à 1920 !");
                    else if (DateTime.Compare(value.Value, DateTime.Today) > 0)
                        throw new Exception("La date de naissance ne peut être supérieur à la date d'aujourd'hui");
                }
                dateNaissance = value;
            }
        }

        public string ValiderNom(String value, bool autoriserNull)
        {
            //Regex objAlphaPattern = new Regex("[^a-zA-Z]");
            if (string.IsNullOrEmpty(value) && !autoriserNull)
            {
                throw new Exception("Le nom de la personne est obligatoire !");
            }
            //else if (!objAlphaPattern.IsMatch(value))
            return value.ToUpper();
            //else
            //{
            //    throw new Exception("Le nom, le postnom et le prénom ne peuvent pas conténir des caractères spéciaux!");
            //}
        }

        private string sexe;

        public string Sexe
        {
            get { return sexe; }
            set { sexe = value; }
        }

        private string etatCivil;

        public string EtatCivil
        {
            get { return etatCivil; }
            set { etatCivil = value; }
        }

        private string telephone;

        public string Telephone
        {
            get { return telephone; }
            set { telephone = value; }
        }

        private string adresse;

        public string Adresse
        {
            get { return adresse; }
            set { adresse = value; }
        }
    }
}
