using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.IO;

namespace GestionClinic_LIB
{
    public class Factory
    {
        public IDbConnection con;
        public SqlConnection connect;
        private static Factory staticFactory;
        public static string stringConnect = "";
        private static string fileNameSQLServer = "parametresSQLServer.par";
        private static bool isAdmin = false;
        private static bool isDirection = false;
        private static bool isOther = false;
        private static bool enterForFormService = false;

        #region Valeur pour actualisation des comboBox de form ouvert sur le form principal
        public static bool EnterForFormService
        {
            get { return enterForFormService; }
            set { enterForFormService = value; }
        }
        #endregion


        #region Truc pour activation et desactivation des items
        public static bool IsAdmin
        {
            get { return isAdmin; }
            set { isAdmin = value; }
        }
        public static bool IsDirection
        {
            get { return isDirection; }
            set { isDirection = value; }
        }
        public static bool IsOther
        {
            get { return isOther; }
            set { isOther = value; }
        }
        #endregion  

        #region Initialisation de la Factory
        public static Factory Instance
        {
            get
            {
                if (staticFactory == null)
                    staticFactory = new Factory();
                return staticFactory;
            }
        }
        private Factory()
        {
        }
        #endregion

        #region Ouverture de la connection \\ Ici pour les reports
        /// <summary>
        /// Permet l'ouverture de la connection à la base de données pour afficher le report
        /// et retourne un objet représentant la connexion à la dite base de données
        /// </summary>
        /// <returns>Objet IDbConnection</returns>
        public SqlConnection connectDB()
        {
            connect = new SqlConnection(stringConnect);
            if (connect.State.ToString().Equals("")) throw new Exception("Impossible de charger les données de la Base de données !!");
            else if (connect.State.ToString().Equals("Open")) { }
            else connect.Open();
            return connect;
        }
        #endregion

        #region RECUPERATION DU TYPE D'INSTANCE DE LA BASE DES DONNEES POUR CONNAITRE SUR QUELLE BD ON EST CONNECTE
        /// <summary>
        /// Permet de retourner un entier représentant le type de SGBD sur lequel on sest éffectivement connecté, ainsi on a
        /// 1 pour une Base des données PostGreSQL
        /// 2 pour une Base des données MySQL
        /// 3 pour une Base des données SQLServer et
        /// 4 pour une Base des données Access 2003 - 2007 ou 2010
        /// </summary>
        /// <returns></returns>
        public int GetTypeSGBDConnecting()
        {
            int sgbd = 0;
            if (con.GetType().ToString().Equals("System.Data.SqlClient.SqlConnection")) sgbd = 0;
            return sgbd;
        }
        #endregion

        #region Fermeture de la connexion à la base de données une fois déconnecté
        /// <summary>
        /// Permet la fermeture de la connexion à la base de données
        /// </summary>
        public void closeConnection()
        {
            con = null;
        }
        #endregion

        #region CREATION DU REPERTOIRE PERMETTANT DE GARDER LES PARAMETRES DU FICHIER POUR LA CONNEXION A LA BASE
        private static string updateCreateDirectory(string nomRepertoire)
        {
            string cheminAccesRepertoire = "";
            //Recuperation du nom du lecteur dans lequel le projet se trouve
            string lecteur = Environment.CurrentDirectory.ToString().Substring(0, 2);
            DirectoryInfo directory = new DirectoryInfo(lecteur + @"\" + nomRepertoire);
            if (!directory.Exists)
            {
                //Creation du repertoire
                directory.Create();
                directory.Attributes = FileAttributes.Hidden;
                cheminAccesRepertoire = directory.FullName;
            }
            else
            {
                //Dossier existant
                cheminAccesRepertoire = directory.FullName;
            }
            return cheminAccesRepertoire;
        }
        #endregion

        #region Verification et exécution de la connexion à la BD pour une base SQLServer ou Access(2003,2007 ou 2010)
        /// <summary>
        /// Permet de vérifier les valeurs de connexion à la base de données avant d'effectuer la connexion proprement dite
        /// le paramètre valueDB q pour valeur 0=>Pour PosyGresSQL, 1=>Pour MySQL, 2=> Pour SQLServer et 3=> Pour Accesss (2003, 2007 ou 2010)
        /// </summary>
        /// <param name="port">Numero de port avec comme numero de port local 5432 pour PostGresSQL</param>
        /// <param name="serveur">Nom du serveur et serveur par defaut localhost pour PostGresSQL et root pour MySql</param>
        /// <param name="database">Nom de la BD ou son chemin d'acces pour une base Access</param>
        /// <param name="userName">Nom d'utilisateur et utilisateur par defaut postgres pour PostGresSQ, sa pour SQLServer et root pour MySQLL</param>
        /// <param name="password">Mot de passe</param>
        /// <param name="stringConnect">Chaine de connexion</param>
        /// <param name="valueDB">entier representant la BD a choisir</param>
        /// <returns>un booleen</returns>
        public bool VerifieDoConnect(string serveur, string database, string userName, string password)
        {
                bool ok=false;
                Console.WriteLine("serveur: {0} Database: {1} User Name: {2} password:{3}", serveur, database, userName, password);
                 if (string.IsNullOrEmpty(serveur))
                    throw new Exception("Ce serveur n'existe pas !!");
                else if (string.IsNullOrEmpty(database))
                    throw new Exception("Cette base de données n'existe pas !!");
                else
                {
                    if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(password))
                    {
                        ok = false;
                        throw new Exception("Les informations d'authentification sont invalides !!");
                    }
                    else
                    {
                            //SQLServer
                            stringConnect = "Data Source=" + serveur + ";Initial Catalog=" + database + ";User ID=" + userName + ";Password=" + password + ";Integrated Security=" + false;//SQLServer
                            con = new SqlConnection(stringConnect);
                            //connect = new OleDbConnection(stringConnect);
                            //connect.Open();
                            con.Open();
                            saveParamConnection(serveur, database, userName);
                            ok = true;
                    }
                }
                 return ok;
            }
        /// <summary>
        ///Permet d'enregistrer la chaîne de connexion pour une base des donnée PostGresSQL dans un fichier texte 
        /// </summary>
        public void saveParamConnection(string serveur, string bd, string userName)
        {
            //if (valueBD == 0)
            //{
            using (StreamWriter srw = new StreamWriter(updateCreateDirectory("ManageStock") + @"\" + fileNameSQLServer, false))
            {
                srw.WriteLine("{0};{1};{2}", serveur, bd, userName);
                srw.Close();
            }
            //}
        }

        /// <summary>
        /// Permet de charger la chaîne de connection à partir d'un fichier texte pour une Base PostGresSql et retourne un tableau
        /// contenant ces différentes valeurs (Serveur, Base de données, Nom d'utilisateur et numero de port)
        /// </summary>
        /// <returns>retourne un tableau</returns>
        public string[] loadParam()
        {
            string[] values = { };
            //SQLServer
            values = new string[3];
            if (File.Exists(fileNameSQLServer))
            {
                using (StreamReader sr = new StreamReader(fileNameSQLServer))
                {
                    if (!sr.EndOfStream)
                    {
                        string str = sr.ReadLine();
                        string[] value = str.Split(new char[] { ';' });
                        values[0] = value[0];
                        values[1] = value[1];
                        values[2] = value[2];
                        sr.Close();
                    }
                }
            }
            return values;
        }

        #endregion

        #region REGENERATION POUR UN NOUVEL ID AUTO INCREMENTE PAR RAPPORT AU DERNIER ID DE LA TABLE
        /// <summary>
        /// Permet d'obtenir un nouveau ID pour l'objet passe en paramètre
        /// </summary>
        /// <param name="parametre">Paramètre de type Object</param>
        /// <returns>Un entier</returns>
        public int ReNewIdValue(object obj)
        {
            int goodId = 0;
            string tablename = "";
            string[] tbNanetable = new string[] { "article", "categorie_Article",  "commande", "livraison","paiement", 
                "paiementFournisseur", "personne", "photo", "service"};
            if (obj is Article) tablename = Convert.ToString(tbNanetable[0]);
            else if (obj is CategorieArticle) tablename = Convert.ToString(tbNanetable[1]);
            else if (obj is Commande) tablename = Convert.ToString(tbNanetable[2]);
            else if (obj is Livraison) tablename = Convert.ToString(tbNanetable[3]);
            else if (obj is PaiementArticle) tablename = Convert.ToString(tbNanetable[4]);
            else if (obj is PaiementFournisseur) tablename = Convert.ToString(tbNanetable[5]);
            else if (obj is Personne) tablename = Convert.ToString(tbNanetable[6]);
            else if (obj is Photo) tablename = Convert.ToString(tbNanetable[7]);
            else if (obj is  Service) tablename = Convert.ToString(tbNanetable[8]);
            else tablename = "";

            //if (con.State.ToString().Equals("Open")) { }
            //else con.Open();
            con.Close();
            con.Open();
            IDbCommand cmdRenewID = con.CreateCommand();
            cmdRenewID.CommandText = "SELECT MAX(id) AS maxid FROM " + tablename;

            IDataReader dr = cmdRenewID.ExecuteReader();
            if (dr.Read())
            {
                if (dr["maxid"] == DBNull.Value) goodId = 1;
                else goodId = Convert.ToInt32(dr["maxid"]) + 1;
            }
            dr.Close();
            cmdRenewID.Dispose();
            con.Close();
            return goodId;
        }

        public int ReNewIdValue(object obj, int value)
        {
            int goodId = 0;
            string tablename = "";
            string[] tbNanetable = new string[] { "client", "fournisseur", "agent" };
            if (obj is Personne && value == 0) tablename = Convert.ToString(tbNanetable[0]);
            else if (obj is Personne && value == 1) tablename = Convert.ToString(tbNanetable[1]);
            else if (obj is Personne && value == 2) tablename = Convert.ToString(tbNanetable[2]);
            else tablename = "";
            con.Close();
            con.Open();
            IDbCommand cmdRenewID = con.CreateCommand();
            cmdRenewID.CommandText = "SELECT MAX(id) AS maxid FROM " + tablename;

            IDataReader dr = cmdRenewID.ExecuteReader();
            if (dr.Read())
            {
                if (dr["maxid"] == DBNull.Value || Convert.ToInt32(dr["maxid"]) == 0) goodId = 1;
                else goodId = Convert.ToInt32(dr["maxid"]) + 1;
            }
            dr.Close();
            cmdRenewID.Dispose();
            con.Close();
            return goodId;
        }
        #endregion

        #region Execution de l'enregistrement quelque soit la classe appellante
        /// <summary>
        /// Permet d'enregistrer un item dans la base de données quelque soit le type d'objet
        /// </summary>
        /// <param name="obj">Object</param>
        internal void Save(object obj)
        {
            if (con.State.ToString().Equals("Open")) { }
            else con.Open();

            IDbCommand cmdSave = null, cmdSave1 = null;
            bool ok = false;

            if (obj is Article)
            {
                cmdSave = con.CreateCommand();
                cmdSave.CommandText = "insert into article(id,pu,designation,id_categorie) values(@id,@pu,@designation,@id_categorie)";

                IDataParameter paramId = cmdSave.CreateParameter();
                paramId.ParameterName = "@id";
                paramId.Value = ((Article)obj).Id;

                IDataParameter paramPu = cmdSave.CreateParameter();
                paramPu.ParameterName = "@pu";
                paramPu.Value = ((Article)obj).Pu;

                IDataParameter paramDesignation = cmdSave.CreateParameter();
                paramDesignation.ParameterName = "@designation";
                paramDesignation.Value = ((Article)obj).Designation;

                IDataParameter paramIdCategorie = cmdSave.CreateParameter();
                paramIdCategorie.ParameterName = "@id_categorie";
                paramIdCategorie.Value = ((Article)obj).Id_categorie;

                cmdSave.Parameters.Add(paramId);
                cmdSave.Parameters.Add(paramIdCategorie);
                cmdSave.Parameters.Add(paramDesignation);
                cmdSave.Parameters.Add(paramPu);
            }
            else if (obj is CategorieArticle)
            {
                cmdSave = con.CreateCommand();
                cmdSave.CommandText = "insert into categorie_Article(id,designation) values(@id,@designation)";

                IDataParameter paramId = cmdSave.CreateParameter();
                paramId.ParameterName = "@id";
                paramId.Value = ((CategorieArticle)obj).Id;

                IDataParameter paramDesignation = cmdSave.CreateParameter();
                paramDesignation.ParameterName = "@designation";
                paramDesignation.Value = ((CategorieArticle)obj).Designation;

                cmdSave.Parameters.Add(paramId);
                cmdSave.Parameters.Add(paramDesignation);
            }
            else if (obj is Commande)
            {
                cmdSave = con.CreateCommand();
                cmdSave.CommandText = "insert into commande(id,id_agent,id_fournisseur,date_commande) values(@id,@id_agent,@id_fournisseur,@date_commande)";

                IDataParameter paramId = cmdSave.CreateParameter();
                paramId.ParameterName = "@id";
                paramId.Value = ((Commande)obj);

                IDataParameter paramIdAgent = cmdSave.CreateParameter();
                paramIdAgent.ParameterName = "@id_agent";
                paramIdAgent.Value = ((Commande)obj).Id_agent;

                IDataParameter paramIdFournisseur = cmdSave.CreateParameter();
                paramIdFournisseur.ParameterName = "@id_fournisseur";
                paramIdFournisseur.Value = ((Commande)obj).Id_fournisseur;

                IDataParameter paramDateCommande = cmdSave.CreateParameter();
                paramDateCommande.ParameterName = "@date_commande";
                paramDateCommande.Value = ((Commande)obj).Date_commande;

                cmdSave.Parameters.Add(paramIdAgent);
                cmdSave.Parameters.Add(paramIdFournisseur);
                cmdSave.Parameters.Add(paramDateCommande);
                cmdSave.Parameters.Add(paramId);
            }
            else if (obj is Fournisseur)
            {
                ok = true;
                IDbTransaction transaction = null;

                try
                {
                    transaction = con.BeginTransaction(IsolationLevel.Serializable);
                    cmdSave1 = con.CreateCommand();
                    cmdSave1.CommandText = @"insert into personne(id,nom,postnom,prenom,sexe,etatcivil,dateNaissance,numeroTel,adresse)
                    values(@id,@nom,@postnom,@prenom,@sexe,@etatcivil,@dateNaissance,@numeroTel,@adresse)";

                    IDataParameter paramIdPers = cmdSave1.CreateParameter();
                    paramIdPers.ParameterName = "@id";
                    paramIdPers.Value = ((Fournisseur)obj).IdPers;

                    IDataParameter paramNom = cmdSave1.CreateParameter();
                    paramNom.ParameterName = "@nom";
                    paramNom.Value = ((Fournisseur)obj).Nom;

                    IDataParameter paramPostNom = cmdSave1.CreateParameter();
                    paramPostNom.ParameterName = "@postnom";
                    paramPostNom.Value = ((Fournisseur)obj).PostNom;

                    IDataParameter paramPrenom = cmdSave1.CreateParameter();
                    paramPrenom.ParameterName = "@prenom";
                    paramPrenom.Value = ((Fournisseur)obj).Prenom;

                    IDataParameter paramSexe = cmdSave1.CreateParameter();
                    paramSexe.ParameterName = "@sexe";
                    paramSexe.Value = ((Fournisseur)obj).Sexe;

                    IDataParameter paramEtat = cmdSave1.CreateParameter();
                    paramEtat.ParameterName = "@etatcivil";
                    paramEtat.Value = ((Fournisseur)obj).EtatCivil;


                    IDataParameter paramDateNaiss = cmdSave1.CreateParameter();
                    paramDateNaiss.ParameterName = "@dateNaissance";
                    paramDateNaiss.Value = ((Fournisseur)obj).DateNaissance;

                    IDataParameter paramTel = cmdSave1.CreateParameter();
                    paramTel.ParameterName = "@numeroTel";
                    paramTel.Value = ((Fournisseur)obj).Telephone;

                    IDataParameter paramAdresse = cmdSave1.CreateParameter();
                    paramAdresse.ParameterName = "@adresse";
                    paramAdresse.Value = ((Fournisseur)obj).Adresse;

                    cmdSave1.Parameters.Add(paramNom);
                    cmdSave1.Parameters.Add(paramPostNom);
                    cmdSave1.Parameters.Add(paramPrenom);
                    cmdSave1.Parameters.Add(paramSexe);
                    cmdSave1.Parameters.Add(paramEtat);
                    cmdSave1.Parameters.Add(paramDateNaiss);
                    cmdSave1.Parameters.Add(paramTel);
                    cmdSave1.Parameters.Add(paramAdresse);
                    cmdSave1.Parameters.Add(paramIdPers);

                    cmdSave1.Transaction = transaction;
                    cmdSave1.ExecuteNonQuery();
                    cmdSave1.Dispose();

                    cmdSave = con.CreateCommand();
                    cmdSave.CommandText = "insert into Fournisseur(id,id_personne,nrc) values(@id,@id_personne,@nrc)";

                    IDataParameter paramId = cmdSave.CreateParameter();
                    paramId.ParameterName = "@id";
                    paramId.Value = ((Fournisseur)obj).Id;

                    IDataParameter paramid_personne = cmdSave.CreateParameter();
                    paramid_personne.ParameterName = "@id_personne";
                    paramid_personne.Value = ((Fournisseur)obj).Id_personne;

                    IDataParameter paramNrc = cmdSave.CreateParameter();
                    paramNrc.ParameterName = "@nrc";
                    paramNrc.Value = ((Fournisseur)obj).Nrc;

                    cmdSave.Parameters.Add(paramid_personne);
                    cmdSave.Parameters.Add(paramNrc);
                    cmdSave.Parameters.Add(paramId);

                    cmdSave.Transaction = transaction;
                    cmdSave.ExecuteNonQuery();
                    transaction.Commit();
                    cmdSave.Dispose();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    if (transaction != null) throw new Exception("Echec de l'enregistrement, veuillez cliquer sur nouveau ou fermer le formulaire et réessayez svp");
                }
            }
            else if (obj is Livraison)
            {
                cmdSave = con.CreateCommand();
                cmdSave.CommandText = "insert into livraison(id,id_article,id_fournisseur,qte_e,date_livraison) values(@id,@id_article,@id_fournisseur,@qte_e,@date_livraison)";

                IDataParameter paramId = cmdSave.CreateParameter();
                paramId.ParameterName = "@id";
                paramId.Value = ((Livraison)obj).Id;

                IDataParameter paramid_article = cmdSave.CreateParameter();
                paramid_article.ParameterName = "@id_article";
                paramid_article.Value = ((Livraison)obj).Id_article;

                IDataParameter paramid_fournisseur = cmdSave.CreateParameter();
                paramid_fournisseur.ParameterName = "@id_fournisseur";
                paramid_fournisseur.Value = ((Livraison)obj).Id_fournisseur;

                IDataParameter paramqte_e = cmdSave.CreateParameter();
                paramqte_e.ParameterName = "@qte_e";
                paramqte_e.Value = ((Livraison)obj).Qte_e;

                IDataParameter paramdate_livraison = cmdSave.CreateParameter();
                paramdate_livraison.ParameterName = "@date_livraison";
                paramdate_livraison.Value = ((Livraison)obj).Date_livraison;

                cmdSave.Parameters.Add(paramid_article);
                cmdSave.Parameters.Add(paramid_fournisseur);
                cmdSave.Parameters.Add(paramqte_e);
                cmdSave.Parameters.Add(paramdate_livraison);
                cmdSave.Parameters.Add(paramId);
            }
            else if (obj is Service)
            {
                cmdSave = con.CreateCommand();
                cmdSave.CommandText = "insert into service(id,designation) values(@id,@designation)";

                IDataParameter paramId = cmdSave.CreateParameter();
                paramId.ParameterName = "@id";
                paramId.Value = ((Service)obj).Id;

                IDataParameter paramDesignation = cmdSave.CreateParameter();
                paramDesignation.ParameterName = "@designation";
                paramDesignation.Value = ((Service)obj).Designation;

                cmdSave.Parameters.Add(paramDesignation);
                cmdSave.Parameters.Add(paramId);
            }
            else if (obj is Agent)
            {
                ok = true;
                IDbTransaction transaction = null;

                try
                {
                    transaction = con.BeginTransaction(IsolationLevel.Serializable);
                    cmdSave1 = con.CreateCommand();
                    cmdSave1.CommandText = @"insert into personne(id,nom,postnom,prenom,sexe,etatcivil,dateNaissance,numeroTel,adresse)
                    values(@id,@nom,@postnom,@prenom,@sexe,@etatCivil,@dateNaissance,@numeroTel,@adresse)";

                    IDataParameter paramIdPers = cmdSave1.CreateParameter();
                    paramIdPers.ParameterName = "@id";
                    paramIdPers.Value = ((Agent)obj).IdPers;

                    IDataParameter paramNom = cmdSave1.CreateParameter();
                    paramNom.ParameterName = "@nom";
                    paramNom.Value = ((Agent)obj).Nom;

                    IDataParameter paramPostNom = cmdSave1.CreateParameter();
                    paramPostNom.ParameterName = "@postnom";
                    paramPostNom.Value = ((Agent)obj).PostNom;

                    IDataParameter paramPrenom = cmdSave1.CreateParameter();
                    paramPrenom.ParameterName = "@prenom";
                    paramPrenom.Value = ((Agent)obj).Prenom;

                    IDataParameter paramSexe = cmdSave1.CreateParameter();
                    paramSexe.ParameterName = "@sexe";
                    paramSexe.Value = ((Agent)obj).Sexe;

                    IDataParameter paramEtat = cmdSave1.CreateParameter();
                    paramEtat.ParameterName = "@etatCivil";
                    paramEtat.Value = ((Agent)obj).EtatCivil;

                    IDataParameter paramDateNaiss = cmdSave1.CreateParameter();
                    paramDateNaiss.ParameterName = "@dateNaissance";
                    paramDateNaiss.Value = ((Agent)obj).DateNaissance;

                    IDataParameter paramTel = cmdSave1.CreateParameter();
                    paramTel.ParameterName = "@numeroTel";
                    paramTel.Value = ((Agent)obj).Telephone;

                    IDataParameter paramAdresse = cmdSave1.CreateParameter();
                    paramAdresse.ParameterName = "@adresse";
                    paramAdresse.Value = ((Agent)obj).Adresse;

                    cmdSave1.Parameters.Add(paramNom);
                    cmdSave1.Parameters.Add(paramPostNom);
                    cmdSave1.Parameters.Add(paramPrenom);
                    cmdSave1.Parameters.Add(paramSexe);
                    cmdSave1.Parameters.Add(paramEtat);
                    cmdSave1.Parameters.Add(paramDateNaiss);
                    cmdSave1.Parameters.Add(paramTel);
                    cmdSave1.Parameters.Add(paramAdresse);
                    cmdSave1.Parameters.Add(paramIdPers);

                    cmdSave1.Transaction = transaction;
                    cmdSave1.ExecuteNonQuery();
                    cmdSave1.Dispose();

                    cmdSave = con.CreateCommand();
                    cmdSave.CommandText = "insert into agent(id,id_personne,id_service,matricule,fonction) values(@id,@id_personne,@id_service,@matricule,@fonction)";

                    IDataParameter paramId = cmdSave.CreateParameter();
                    paramId.ParameterName = "@id";
                    paramId.Value = ((Agent)obj).Id;

                    IDataParameter paramid_personne = cmdSave.CreateParameter();
                    paramid_personne.ParameterName = "@id_personne";
                    paramid_personne.Value = ((Agent)obj).Id_personne;

                    IDataParameter paramid_service = cmdSave.CreateParameter();
                    paramid_service.ParameterName = "@id_service";
                    paramid_service.Value = ((Agent)obj).Id_service;

                    IDataParameter paraMatricule = cmdSave.CreateParameter();
                    paraMatricule.ParameterName = "@matricule";
                    paraMatricule.Value = ((Agent)obj).Matricule;

                    IDataParameter paramFonction = cmdSave.CreateParameter();
                    paramFonction.ParameterName = "@fonction";
                    paramFonction.Value = ((Agent)obj).Fonction;

                    cmdSave.Parameters.Add(paramid_personne);
                    cmdSave.Parameters.Add(paramid_service);
                    cmdSave.Parameters.Add(paraMatricule);
                    cmdSave.Parameters.Add(paramFonction);
                    cmdSave.Parameters.Add(paramId);

                    cmdSave.Transaction = transaction;
                    cmdSave.ExecuteNonQuery();
                    transaction.Commit();
                    cmdSave.Dispose();
                }

                catch (Exception)
                {
                    transaction.Rollback();
                    if (transaction != null) throw new Exception("Echec de l'enregistrement, veuillez cliquer sur nouveau ou fermer le formulaire et réessayez svp");
                }
            }
            else if (obj is Client)
            {
                ok = true;
                IDbTransaction transaction = null;

                try
                {
                    transaction = con.BeginTransaction(IsolationLevel.Serializable);
                    cmdSave1 = con.CreateCommand();
                    cmdSave1.CommandText = @"insert into personne(id,nom,postnom,prenom,sexe,etatcivil,dateNaissance,numeroTel,adresse)
                    values(@id,@nom,@postnom,@prenom,@sexe,@etatcivil,@dateNaissance,@numeroTel,@adresse)";

                    IDataParameter paramIdPers = cmdSave1.CreateParameter();
                    paramIdPers.ParameterName = "@id";
                    paramIdPers.Value = ((Client)obj).IdPers;

                    IDataParameter paramNom = cmdSave1.CreateParameter();
                    paramNom.ParameterName = "@nom";
                    paramNom.Value = ((Client)obj).Nom;

                    IDataParameter paramPostNom = cmdSave1.CreateParameter();
                    paramPostNom.ParameterName = "@postnom";
                    paramPostNom.Value = ((Client)obj).PostNom;

                    IDataParameter paramPrenom = cmdSave1.CreateParameter();
                    paramPrenom.ParameterName = "@prenom";
                    paramPrenom.Value = ((Client)obj).Prenom;

                    IDataParameter paramSexe = cmdSave1.CreateParameter();
                    paramSexe.ParameterName = "@sexe";
                    paramSexe.Value = ((Client)obj).Sexe;

                    IDataParameter paramEtat = cmdSave1.CreateParameter();
                    paramEtat.ParameterName = "@etatcivil";
                    paramEtat.Value = ((Client)obj).EtatCivil;

                    IDataParameter paramDateNaiss = cmdSave1.CreateParameter();
                    paramDateNaiss.ParameterName = "@dateNaissance";
                    paramDateNaiss.Value = ((Client)obj).DateNaissance;

                    IDataParameter paramTel = cmdSave1.CreateParameter();
                    paramTel.ParameterName = "@numeroTel";
                    paramTel.Value = ((Client)obj).Telephone;

                    IDataParameter paramAdresse = cmdSave1.CreateParameter();
                    paramAdresse.ParameterName = "@adresse";
                    paramAdresse.Value = ((Client)obj).Adresse;

                    cmdSave1.Parameters.Add(paramIdPers);
                    cmdSave1.Parameters.Add(paramNom);
                    cmdSave1.Parameters.Add(paramPostNom);
                    cmdSave1.Parameters.Add(paramPrenom);
                    cmdSave1.Parameters.Add(paramSexe);
                    cmdSave1.Parameters.Add(paramEtat);
                    cmdSave1.Parameters.Add(paramDateNaiss);
                    cmdSave1.Parameters.Add(paramTel);
                    cmdSave1.Parameters.Add(paramAdresse);

                    cmdSave1.Transaction = transaction;
                    cmdSave1.ExecuteNonQuery();
                    cmdSave1.Dispose();

                    cmdSave = con.CreateCommand();
                    cmdSave.CommandText = "insert into client(id,id_personne) values(@id,@id_personne)";

                    IDataParameter paramId = cmdSave.CreateParameter();
                    paramId.ParameterName = "@id";
                    paramId.Value = ((Client)obj).Id;

                    IDataParameter paramid_personne = cmdSave.CreateParameter();
                    paramid_personne.ParameterName = "@id_personne";
                    paramid_personne.Value = ((Client)obj).Id_personne;

                    cmdSave.Parameters.Add(paramid_personne);
                    cmdSave.Parameters.Add(paramId);

                    cmdSave.Transaction = transaction;
                    cmdSave.ExecuteNonQuery();
                    transaction.Commit();
                    cmdSave.Dispose();
                }

                catch (Exception)
                {
                    transaction.Rollback();
                    if (transaction != null) throw new Exception("Echec de l'enregistrement, veuillez cliquer sur nouveau ou fermer le formulaire et réessayez svp");
                }
            }
            else if (obj is Photo)
            {
                cmdSave = con.CreateCommand();
                cmdSave.CommandText = "insert into photo(id,id_personne,photo) values(@id,@id_personne,@photo)";

                IDataParameter paramId = cmdSave.CreateParameter();
                paramId.ParameterName = "@id";
                paramId.Value = ((Photo)obj).Id;
                Console.WriteLine("((Photo)obj).Id = " + ((Photo)obj).Id);
                IDataParameter paramId_personne = cmdSave.CreateParameter();
                paramId_personne.ParameterName = "@id_personne";
                paramId_personne.Value = ((Photo)obj).Id_personne;
                cmdSave.Parameters.Add(paramId);
                cmdSave.Parameters.Add(paramId_personne);

                if ((((Photo)obj).PhotoPersonne) == null)
                {
                    IDataParameter paramPhoto = cmdSave.CreateParameter();
                    paramPhoto.ParameterName = "@photo";
                    paramPhoto.Value = "";
                    cmdSave.Parameters.Add(paramPhoto);
                }
                else
                {
                    IDataParameter paramPhoto = cmdSave.CreateParameter();
                    paramPhoto.ParameterName = "@photo";
                    paramPhoto.Value = GetImage(((Photo)obj).PhotoPersonne);
                    cmdSave.Parameters.Add(paramPhoto);
                }
            }
            else if (obj is PaiementFournisseur)
            {
                cmdSave = con.CreateCommand();
                cmdSave.CommandText = "insert into paiementFournisseur(id,id_agent,id_fournisseur,date_paiement,montant) values(@id,@id_agent,@id_fournisseur,@date_paiement,@montant)";

                IDataParameter paramId = cmdSave.CreateParameter();
                paramId.ParameterName = "@id";
                paramId.Value = ((PaiementFournisseur)obj).Id;

                IDataParameter paramid_agent = cmdSave.CreateParameter();
                paramid_agent.ParameterName = "@id_agent";
                paramid_agent.Value = ((PaiementFournisseur)obj).Id_agent;

                IDataParameter paramid_fournisseur = cmdSave.CreateParameter();
                paramid_fournisseur.ParameterName = "@id_fournisseur";
                paramid_fournisseur.Value = ((PaiementFournisseur)obj).Id_fournisseur;

                IDataParameter parammontant = cmdSave.CreateParameter();
                parammontant.ParameterName = "@montant";
                parammontant.Value = ((PaiementFournisseur)obj).Montant;

                IDataParameter paramdate_paiement = cmdSave.CreateParameter();
                paramdate_paiement.ParameterName = "@date_paiement";
                paramdate_paiement.Value = ((PaiementFournisseur)obj).Date;

                cmdSave.Parameters.Add(paramid_agent);
                cmdSave.Parameters.Add(paramid_fournisseur);
                cmdSave.Parameters.Add(parammontant);
                cmdSave.Parameters.Add(paramdate_paiement);
                cmdSave.Parameters.Add(paramId);
            }

            else if (obj is PaiementArticle)
            {
                cmdSave = con.CreateCommand();
                cmdSave.CommandText = "insert into paiement(id,id_client,id_article,date_paiement,montant,qte_vendue) values(@id,@id_client,@id_article,@date_paiement,@montant,@qte_vendue)";

                IDataParameter paramId = cmdSave.CreateParameter();
                paramId.ParameterName = "@id";
                paramId.Value = ((PaiementArticle)obj).Id;

                IDataParameter paramid_client = cmdSave.CreateParameter();
                paramid_client.ParameterName = "@id_client";
                paramid_client.Value = ((PaiementArticle)obj).Id_client;

                IDataParameter paramid_article = cmdSave.CreateParameter();
                paramid_article.ParameterName = "@id_article";
                paramid_article.Value = ((PaiementArticle)obj).Id_article;

                IDataParameter parammontant = cmdSave.CreateParameter();
                parammontant.ParameterName = "@montant";
                parammontant.Value = ((PaiementArticle)obj).MontantPaye;

                IDataParameter paramdate_paiement = cmdSave.CreateParameter();
                paramdate_paiement.ParameterName = "@date_paiement";
                paramdate_paiement.Value = ((PaiementArticle)obj).Date;

                IDataParameter paramqte_vendue = cmdSave.CreateParameter();
                paramqte_vendue.ParameterName = "@qte_vendue";
                paramqte_vendue.Value = ((PaiementArticle)obj).Quantite;

                cmdSave.Parameters.Add(paramid_client);
                cmdSave.Parameters.Add(paramid_article);
                cmdSave.Parameters.Add(parammontant);
                cmdSave.Parameters.Add(paramdate_paiement);
                cmdSave.Parameters.Add(paramqte_vendue);
                cmdSave.Parameters.Add(paramId);
            }
            if (ok) { }
            else
            {
                int misJour = cmdSave.ExecuteNonQuery();
                cmdSave.Dispose();

            }
            con.Close();
        }
        #endregion

        #region Execution de la modification quelque soit la classe appellante
        /// <summary>
        /// Permet de modifier un item dans la base de données quelque soit le type d'objet
        /// </summary>
        /// <param name="obj"></param>
        internal void Update(object obj)
        {
            if (con.State.ToString().Equals("Open")) { }
            else con.Open();

            IDbCommand cmdUpdate = null, cmdUpdate1 = null;
            bool ok = false;

            if (obj is Article)
            {
                cmdUpdate = con.CreateCommand();
                cmdUpdate.CommandText = "update article set pu=@pu,designation=@designation,id_categorie=@id_categorie where id=@id";

                IDataParameter paramId = cmdUpdate.CreateParameter();
                paramId.ParameterName = "@id";
                paramId.Value = ((Article)obj).Id;

                IDataParameter paramPu = cmdUpdate.CreateParameter();
                paramPu.ParameterName = "@pu";
                paramPu.Value = ((Article)obj).Pu;

                IDataParameter paramDesignation = cmdUpdate.CreateParameter();
                paramDesignation.ParameterName = "@designation";
                paramDesignation.Value = ((Article)obj).Designation;

                IDataParameter paramIdCategorie = cmdUpdate.CreateParameter();
                paramIdCategorie.ParameterName = "@id_categorie";
                paramIdCategorie.Value = ((Article)obj).Id_categorie;

                cmdUpdate.Parameters.Add(paramId);
                cmdUpdate.Parameters.Add(paramIdCategorie);
                cmdUpdate.Parameters.Add(paramDesignation);
                cmdUpdate.Parameters.Add(paramPu);
            }
            else if (obj is Service)
            {
                cmdUpdate = con.CreateCommand();
                cmdUpdate.CommandText = "update service set designation=@designation where id=@id";

                IDataParameter paramId = cmdUpdate.CreateParameter();
                paramId.ParameterName = "@id";
                paramId.Value = ((Service)obj).Id;

                IDataParameter paramDesignation = cmdUpdate.CreateParameter();
                paramDesignation.ParameterName = "@designation";
                paramDesignation.Value = ((Service)obj).Designation;

                cmdUpdate.Parameters.Add(paramId);
                cmdUpdate.Parameters.Add(paramDesignation);
            }
            else if (obj is CategorieArticle)
            {
                cmdUpdate = con.CreateCommand();
                cmdUpdate.CommandText = "update categorie_Article set designation=@designation where id=@id";

                IDataParameter paramId = cmdUpdate.CreateParameter();
                paramId.ParameterName = "@id";
                paramId.Value = ((CategorieArticle)obj).Id;

                IDataParameter paramDesignation = cmdUpdate.CreateParameter();
                paramDesignation.ParameterName = "@designation";
                paramDesignation.Value = ((CategorieArticle)obj).Designation;

                cmdUpdate.Parameters.Add(paramId);
                cmdUpdate.Parameters.Add(paramDesignation);
            }
            else if (obj is Commande)
            {
                cmdUpdate = con.CreateCommand();
                cmdUpdate.CommandText = "update commande set id=@id,id_agent=@id_agent,id_fournisseur=@id_fournisseur,date_commande=@date_commande where id=@id";
                IDataParameter paramId = cmdUpdate.CreateParameter();
                paramId.ParameterName = "@id";
                paramId.Value = ((Commande)obj).Id;

                IDataParameter paramIdMagasinier = cmdUpdate.CreateParameter();
                paramIdMagasinier.ParameterName = "@id_agent";
                paramIdMagasinier.Value = ((Commande)obj).Id_agent;

                IDataParameter paramIdFournisseur = cmdUpdate.CreateParameter();
                paramIdFournisseur.ParameterName = "@id_fournisseur";
                paramIdFournisseur.Value = ((Commande)obj).Id_fournisseur;

                IDataParameter paramDateCommande = cmdUpdate.CreateParameter();
                paramDateCommande.ParameterName = "@date_commande";
                paramDateCommande.Value = ((Commande)obj).Date_commande;

                cmdUpdate.Parameters.Add(paramIdMagasinier);
                cmdUpdate.Parameters.Add(paramIdFournisseur);
                cmdUpdate.Parameters.Add(paramDateCommande);
                cmdUpdate.Parameters.Add(paramId);
            }
            else if (obj is Fournisseur)
            {
                ok = true;
                IDbTransaction transaction = null;

                try
                {
                    transaction = con.BeginTransaction(IsolationLevel.Serializable);
                    cmdUpdate1 = con.CreateCommand();
                    cmdUpdate1.CommandText = "update personne set nom=@nom,postnom=@postnom,prenom=@prenom,sexe=@sexe,etatcivil=@etatcivil,dateNaissance=@dateNaissance,numeroTel=@numeroTel where id=@id";

                    IDataParameter paramIdPers = cmdUpdate1.CreateParameter();
                    paramIdPers.ParameterName = "@id";
                    paramIdPers.Value = ((Fournisseur)obj).IdPers;

                    IDataParameter paramNom = cmdUpdate1.CreateParameter();
                    paramNom.ParameterName = "@nom";
                    paramNom.Value = ((Fournisseur)obj).Nom;

                    IDataParameter paramPostNom = cmdUpdate1.CreateParameter();
                    paramPostNom.ParameterName = "@postnom";
                    paramPostNom.Value = ((Fournisseur)obj).PostNom;

                    IDataParameter paramPrenom = cmdUpdate1.CreateParameter();
                    paramPrenom.ParameterName = "@prenom";
                    paramPrenom.Value = ((Fournisseur)obj).Prenom;

                    IDataParameter paramSexe = cmdUpdate1.CreateParameter();
                    paramSexe.ParameterName = "@sexe";
                    paramSexe.Value = ((Fournisseur)obj).Sexe;

                    IDataParameter paramDateNaiss = cmdUpdate1.CreateParameter();
                    paramDateNaiss.ParameterName = "@dateNaissance";
                    paramDateNaiss.Value = ((Fournisseur)obj).DateNaissance;

                    IDataParameter paramEtat = cmdUpdate1.CreateParameter();
                    paramEtat.ParameterName = "@etatcivil";
                    paramEtat.Value = ((Fournisseur)obj).EtatCivil;

                    IDataParameter paramTel = cmdUpdate1.CreateParameter();
                    paramTel.ParameterName = "@numeroTel";
                    paramTel.Value = ((Fournisseur)obj).Telephone;

                    IDataParameter paramAdresse = cmdUpdate1.CreateParameter();
                    paramAdresse.ParameterName = "@numeroTel";
                    paramAdresse.Value = ((Fournisseur)obj).Telephone;

                    cmdUpdate1.Parameters.Add(paramNom);
                    cmdUpdate1.Parameters.Add(paramPostNom);
                    cmdUpdate1.Parameters.Add(paramPrenom);
                    cmdUpdate1.Parameters.Add(paramSexe);
                    cmdUpdate1.Parameters.Add(paramEtat);
                    cmdUpdate1.Parameters.Add(paramDateNaiss);
                    cmdUpdate1.Parameters.Add(paramTel);
                    cmdUpdate1.Parameters.Add(paramIdPers);

                    cmdUpdate1.Transaction = transaction;
                    cmdUpdate1.ExecuteNonQuery();
                    cmdUpdate1.Dispose();

                    cmdUpdate = con.CreateCommand();
                    cmdUpdate.CommandText = "update Fournisseur set id_personne=@id_personne where id=@id";

                    IDataParameter paramId = cmdUpdate.CreateParameter();
                    paramId.ParameterName = "@id";
                    paramId.Value = ((Fournisseur)obj).Id;

                    IDataParameter paramid_personne = cmdUpdate.CreateParameter();
                    paramid_personne.ParameterName = "@id_personne";
                    paramid_personne.Value = ((Fournisseur)obj).Id_personne;

                    cmdUpdate.Parameters.Add(paramid_personne);
                    cmdUpdate.Parameters.Add(paramId);

                    cmdUpdate.Transaction = transaction;
                    cmdUpdate.ExecuteNonQuery();
                    transaction.Commit();
                    cmdUpdate.Dispose();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    if (transaction != null) throw new Exception("Echec de l'enregistrement, veuillez cliquer sur nouveau ou fermer le formulaire et réessayez svp");
                }
            }
            else if (obj is Client)
            {
                ok = true;
                IDbTransaction transaction = null;

                try
                {
                    transaction = con.BeginTransaction(IsolationLevel.Serializable);
                    cmdUpdate1 = con.CreateCommand();
                    cmdUpdate1.CommandText = "update personne set nom=@nom,postnom=@postnom,prenom=@prenom,sexe=@sexe,etatcivil=@etatcivil,dateNaissance=@dateNaissance,numeroTel=@numeroTel,adresse=@adresse where id=@id";

                    IDataParameter paramIdPers = cmdUpdate1.CreateParameter();
                    paramIdPers.ParameterName = "@id";
                    paramIdPers.Value = ((Client)obj).IdPers;

                    IDataParameter paramNom = cmdUpdate1.CreateParameter();
                    paramNom.ParameterName = "@nom";
                    paramNom.Value = ((Client)obj).Nom;

                    IDataParameter paramPostNom = cmdUpdate1.CreateParameter();
                    paramPostNom.ParameterName = "@postnom";
                    paramPostNom.Value = ((Client)obj).PostNom;

                    IDataParameter paramPrenom = cmdUpdate1.CreateParameter();
                    paramPrenom.ParameterName = "@prenom";
                    paramPrenom.Value = ((Client)obj).Prenom;

                    IDataParameter paramSexe = cmdUpdate1.CreateParameter();
                    paramSexe.ParameterName = "@sexe";
                    paramSexe.Value = ((Client)obj).Sexe;

                    IDataParameter paramEtat = cmdUpdate1.CreateParameter();
                    paramEtat.ParameterName = "@etatcivil";
                    paramEtat.Value = ((Client)obj).EtatCivil;

                    IDataParameter paramDateNaiss = cmdUpdate1.CreateParameter();
                    paramDateNaiss.ParameterName = "@dateNaissance";
                    paramDateNaiss.Value = ((Client)obj).DateNaissance;

                    IDataParameter paramTel = cmdUpdate1.CreateParameter();
                    paramTel.ParameterName = "@numeroTel";
                    paramTel.Value = ((Client)obj).Telephone;

                    IDataParameter paramAdresse = cmdUpdate1.CreateParameter();
                    paramAdresse.ParameterName = "@adresse";
                    paramAdresse.Value = ((Client)obj).Adresse;

                    cmdUpdate1.Parameters.Add(paramNom);
                    cmdUpdate1.Parameters.Add(paramPostNom);
                    cmdUpdate1.Parameters.Add(paramPrenom);
                    cmdUpdate1.Parameters.Add(paramSexe);
                    cmdUpdate1.Parameters.Add(paramEtat);
                    cmdUpdate1.Parameters.Add(paramDateNaiss);
                    cmdUpdate1.Parameters.Add(paramTel);
                    cmdUpdate1.Parameters.Add(paramAdresse);
                    cmdUpdate1.Parameters.Add(paramIdPers);

                    cmdUpdate1.Transaction = transaction;
                    cmdUpdate1.ExecuteNonQuery();
                    cmdUpdate1.Dispose();

                    cmdUpdate = con.CreateCommand();
                    cmdUpdate.CommandText = "update client set id_personne=@id_personne where id=@id";

                    IDataParameter paramId = cmdUpdate.CreateParameter();
                    paramId.ParameterName = "@id";
                    paramId.Value = ((Client)obj).Id;

                    IDataParameter paramid_personne = cmdUpdate.CreateParameter();
                    paramid_personne.ParameterName = "@id_personne";
                    paramid_personne.Value = ((Client)obj).Id_personne;

                    cmdUpdate.Parameters.Add(paramid_personne);
                    cmdUpdate.Parameters.Add(paramId);

                    cmdUpdate.Transaction = transaction;
                    cmdUpdate.ExecuteNonQuery();
                    transaction.Commit();
                    cmdUpdate.Dispose();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    if (transaction != null) throw new Exception("Echec de l'enregistrement, veuillez cliquer sur nouveau ou fermer le formulaire et réessayez svp");
                }
            }
            else if (obj is Livraison)
            {
                cmdUpdate = con.CreateCommand();
                cmdUpdate.CommandText = "update livraison set id_article=@id_article,id_fournisseur=@id_fournisseur,qte_e=@qte_e,date_livraison=@date_livraison where id=@id";

                IDataParameter paramId = cmdUpdate.CreateParameter();
                paramId.ParameterName = "@id";
                paramId.Value = ((Livraison)obj).Id;

                IDataParameter paramid_article = cmdUpdate.CreateParameter();
                paramid_article.ParameterName = "@id_article";
                paramid_article.Value = ((Livraison)obj).Id_article;

                IDataParameter paramid_fournisseur = cmdUpdate.CreateParameter();
                paramid_fournisseur.ParameterName = "@id_fournisseur";
                paramid_fournisseur.Value = ((Livraison)obj).Id_fournisseur;

                IDataParameter paramqte_e = cmdUpdate.CreateParameter();
                paramqte_e.ParameterName = "@qte_e";
                paramqte_e.Value = ((Livraison)obj).Qte_e;

                IDataParameter paramdate_livraison = cmdUpdate.CreateParameter();
                paramdate_livraison.ParameterName = "@date_livraison";
                paramdate_livraison.Value = ((Livraison)obj).Date_livraison;

                cmdUpdate.Parameters.Add(paramid_article);
                cmdUpdate.Parameters.Add(paramid_fournisseur);
                cmdUpdate.Parameters.Add(paramqte_e);
                cmdUpdate.Parameters.Add(paramdate_livraison);
                cmdUpdate.Parameters.Add(paramId);
            }
            else if (obj is Agent)
            {
                ok = true;
                IDbTransaction transaction = null;

                try
                {
                    transaction = con.BeginTransaction(IsolationLevel.Serializable);
                    cmdUpdate1 = con.CreateCommand();
                    cmdUpdate1.CommandText = "update personne set nom=@nom,postnom=@postnom,prenom=@prenom,sexe=@sexe,etatcivil=@etatcivil,dateNaissance=@dateNaissance,numeroTel=@numeroTel,adresse=@adresse where id=@id";

                    IDataParameter paramIdPers = cmdUpdate1.CreateParameter();
                    paramIdPers.ParameterName = "@id";
                    paramIdPers.Value = ((Agent)obj).Id_personne;

                    IDataParameter paramNom = cmdUpdate1.CreateParameter();
                    paramNom.ParameterName = "@nom";
                    paramNom.Value = ((Agent)obj).Nom;

                    IDataParameter paramPostNom = cmdUpdate1.CreateParameter();
                    paramPostNom.ParameterName = "@postnom";
                    paramPostNom.Value = ((Agent)obj).PostNom;

                    IDataParameter paramPrenom = cmdUpdate1.CreateParameter();
                    paramPrenom.ParameterName = "@prenom";
                    paramPrenom.Value = ((Agent)obj).Prenom;

                    IDataParameter paramSexe = cmdUpdate1.CreateParameter();
                    paramSexe.ParameterName = "@sexe";
                    paramSexe.Value = ((Agent)obj).Sexe;

                    IDataParameter paramEtat = cmdUpdate1.CreateParameter();
                    paramEtat.ParameterName = "@etatcivil";
                    paramEtat.Value = ((Agent)obj).EtatCivil;

                    IDataParameter paramDateNaiss = cmdUpdate1.CreateParameter();
                    paramDateNaiss.ParameterName = "@dateNaissance";
                    paramDateNaiss.Value = ((Agent)obj).DateNaissance;

                    IDataParameter paramTel = cmdUpdate1.CreateParameter();
                    paramTel.ParameterName = "@numeroTel";
                    paramTel.Value = ((Agent)obj).Telephone;

                    IDataParameter paramAdresse = cmdUpdate1.CreateParameter();
                    paramAdresse.ParameterName = "@adresse";
                    paramAdresse.Value = ((Agent)obj).Adresse;

                    cmdUpdate1.Parameters.Add(paramNom);
                    cmdUpdate1.Parameters.Add(paramPostNom);
                    cmdUpdate1.Parameters.Add(paramPrenom);
                    cmdUpdate1.Parameters.Add(paramSexe);
                    cmdUpdate1.Parameters.Add(paramEtat);
                    cmdUpdate1.Parameters.Add(paramDateNaiss);
                    cmdUpdate1.Parameters.Add(paramTel);
                    cmdUpdate1.Parameters.Add(paramAdresse);
                    cmdUpdate1.Parameters.Add(paramIdPers);

                    cmdUpdate1.Transaction = transaction;
                    cmdUpdate1.ExecuteNonQuery();
                    cmdUpdate1.Dispose();

                    cmdUpdate = con.CreateCommand();
                    cmdUpdate.CommandText = "update  agent set id_personne=@id_personne,id_service=@id_service,matricule=@matricule,fonction=@fonction where id=@id";

                    IDataParameter paramId = cmdUpdate.CreateParameter();
                    paramId.ParameterName = "@id";
                    paramId.Value = ((Agent)obj).Id;

                    IDataParameter paramid_personne = cmdUpdate.CreateParameter();
                    paramid_personne.ParameterName = "@id_personne";
                    paramid_personne.Value = ((Agent)obj).Id_personne;

                    IDataParameter paramId_service = cmdUpdate.CreateParameter();
                    paramId_service.ParameterName = "@id_service";
                    paramId_service.Value = ((Agent)obj).Id_service;

                    IDataParameter paramMatricule = cmdUpdate.CreateParameter();
                    paramMatricule.ParameterName = "@matricule";
                    paramMatricule.Value = ((Agent)obj).Matricule;

                    IDataParameter paramFonction = cmdUpdate.CreateParameter();
                    paramFonction.ParameterName = "@fonction";
                    paramFonction.Value = ((Agent)obj).Fonction;

                    cmdUpdate.Parameters.Add(paramid_personne);
                    cmdUpdate.Parameters.Add(paramId);
                    cmdUpdate.Parameters.Add(paramId_service);
                    cmdUpdate.Parameters.Add(paramMatricule);
                    cmdUpdate.Parameters.Add(paramFonction);

                    cmdUpdate.Transaction = transaction;
                    cmdUpdate.ExecuteNonQuery();
                    transaction.Commit();
                    cmdUpdate.Dispose();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    if (transaction != null) throw new Exception("Echec de l'enregistrement, veuillez cliquer sur nouveau ou fermer le formulaire et réessayez svp");
                }
            }
            else if (obj is Photo)
            {
                cmdUpdate = con.CreateCommand();
                cmdUpdate.CommandText = "update photo set id_personne=@id_personne,photo=@photo where id=@id";

                IDataParameter paramId_personne = cmdUpdate.CreateParameter();
                paramId_personne.ParameterName = "@id_personne";
                paramId_personne.Value = ((Photo)obj).Id_personne;
                cmdUpdate.Parameters.Add(paramId_personne);
                if ((((Photo)obj).PhotoPersonne) == null)
                {
                    IDataParameter paramPhoto = cmdUpdate.CreateParameter();
                    paramPhoto.ParameterName = "@photo";
                    paramPhoto.Value = "";
                    cmdUpdate.Parameters.Add(paramPhoto);
                }
                else
                {
                    IDataParameter paramPhoto = cmdUpdate.CreateParameter();
                    paramPhoto.ParameterName = "@photo";
                    paramPhoto.Value = GetImage(((Photo)obj).PhotoPersonne);
                    cmdUpdate.Parameters.Add(paramPhoto);
                }
                IDataParameter paramId = cmdUpdate.CreateParameter();
                paramId.ParameterName = "@id";
                paramId.Value = ((Photo)obj).Id;
                cmdUpdate.Parameters.Add(paramId);
            }
            else if (obj is PaiementFournisseur)
            {
                cmdUpdate = con.CreateCommand();
                cmdUpdate.CommandText = "update paiementFournisseur set id_agent=@id_agent,id_fournisseur=@id_fournisseur,date_paiement=@date_paiement,montant=@montant where id=@id";

                IDataParameter paramId = cmdUpdate.CreateParameter();
                paramId.ParameterName = "@id";
                paramId.Value = ((PaiementFournisseur)obj).Id;

                IDataParameter paramid_agent = cmdUpdate.CreateParameter();
                paramid_agent.ParameterName = "@id_agent";
                paramid_agent.Value = ((PaiementFournisseur)obj).Id_agent;

                IDataParameter paramid_fournisseur = cmdUpdate.CreateParameter();
                paramid_fournisseur.ParameterName = "@id_fournisseur";
                paramid_fournisseur.Value = ((PaiementFournisseur)obj).Id_fournisseur;

                IDataParameter parammontant = cmdUpdate.CreateParameter();
                parammontant.ParameterName = "@montant";
                parammontant.Value = ((PaiementFournisseur)obj).Montant;

                IDataParameter paramdate_paiement = cmdUpdate.CreateParameter();
                paramdate_paiement.ParameterName = "@date_paiement";
                paramdate_paiement.Value = ((PaiementFournisseur)obj).Date;


                cmdUpdate.Parameters.Add(paramid_agent);
                cmdUpdate.Parameters.Add(paramid_fournisseur);
                cmdUpdate.Parameters.Add(parammontant);
                cmdUpdate.Parameters.Add(paramdate_paiement);
                cmdUpdate.Parameters.Add(paramId);
            }
            else if (obj is PaiementArticle)
            {
                cmdUpdate = con.CreateCommand();
                cmdUpdate.CommandText = "update paiement set id_client=@id_client,id_article=@id_article,date_paiement=@date_paiement,montant=@montant,qte_vendue=@qte_vendue where id=@id";

                IDataParameter paramId = cmdUpdate.CreateParameter();
                paramId.ParameterName = "@id";
                paramId.Value = ((PaiementArticle)obj).Id;

                IDataParameter paramid_client = cmdUpdate.CreateParameter();
                paramid_client.ParameterName = "@id_client";
                paramid_client.Value = ((PaiementArticle)obj).Id_client;

                IDataParameter paramid_article = cmdUpdate.CreateParameter();
                paramid_article.ParameterName = "@id_article";
                paramid_article.Value = ((PaiementArticle)obj).Id_article;

                IDataParameter parammontant = cmdUpdate.CreateParameter();
                parammontant.ParameterName = "@montant";
                parammontant.Value = ((PaiementArticle)obj).MontantPaye;

                IDataParameter paramdate_paiement = cmdUpdate.CreateParameter();
                paramdate_paiement.ParameterName = "@date_paiement";
                paramdate_paiement.Value = ((PaiementArticle)obj).Date;

                IDataParameter paramqte_vendue = cmdUpdate.CreateParameter();
                paramqte_vendue.ParameterName = "@qte_vendue";
                paramqte_vendue.Value = ((PaiementArticle)obj).Quantite;

                cmdUpdate.Parameters.Add(paramid_client);
                cmdUpdate.Parameters.Add(paramid_article);
                cmdUpdate.Parameters.Add(parammontant);
                cmdUpdate.Parameters.Add(paramdate_paiement);
                cmdUpdate.Parameters.Add(paramqte_vendue);
                cmdUpdate.Parameters.Add(paramId);
            }

            if (ok) { }
            else
            {
                int misJour = cmdUpdate.ExecuteNonQuery();
                cmdUpdate.Dispose();
                if (misJour == 0) throw new Exception("rassurez vous que cet enregistrement existe réellement et réessayez svp");
            }
            con.Close();
        }
        #endregion

        #region CONVERTION DE L'IMAGE EN BINAIRE
        /// <summary>
        /// Permet de convertire l'image en données binaires
        /// </summary>
        /// <param name="filePath">Chemin de l'image</param>
        /// <returns>L'image sous forme de byte[]</returns>
        private byte[] GetImage(string cheminFichier)
        {
            FileStream fs = new FileStream(cheminFichier, FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fs);
            byte[] img = br.ReadBytes((int)fs.Length);
            br.Close();
            fs.Close();
            return img;
        }
        #endregion

        #region Execution de la suppression quelque soit la classe appellante
        /// <summary>
        /// Permet de supprimer un item dans la base de données quelque soit le type d'objet
        /// </summary>
        /// <param name="obj">Object</param>
        internal void Delete(object obj)
        {
            if (con.State.ToString().Equals("Open")) { }
            else con.Open();

            IDbCommand cmdDelete = null;

            if (obj is Article)
            {
                cmdDelete = con.CreateCommand();
                cmdDelete.CommandText = "delete from Article where id=@id ";

                IDataParameter paramId = cmdDelete.CreateParameter();
                paramId.ParameterName = "@id";
                paramId.Value = ((Article)obj).Id;

                cmdDelete.Parameters.Add(paramId);
            }
            else if (obj is CategorieArticle)
            {
                cmdDelete = con.CreateCommand();
                cmdDelete.CommandText = "delete from categorie_Article where id=@id";

                IDataParameter paramId = cmdDelete.CreateParameter();
                paramId.ParameterName = "@id";
                paramId.Value = ((CategorieArticle)obj).Id;

                cmdDelete.Parameters.Add(paramId);
            }
            else if (obj is Commande)
            {
                cmdDelete = con.CreateCommand();
                cmdDelete.CommandText = "delete from commande where id=@id";

                IDataParameter paramId = cmdDelete.CreateParameter();
                paramId.ParameterName = "@id";
                paramId.Value = ((Commande)obj).Id;

                cmdDelete.Parameters.Add(paramId);
            }
            else if (obj is Fournisseur)
            {
                cmdDelete = con.CreateCommand();
                cmdDelete.CommandText = "update fournisseur set deleted=1 where id=@id";

                IDataParameter paramId = cmdDelete.CreateParameter();
                paramId.ParameterName = "@id";
                paramId.Value = ((Fournisseur)obj).Id;

                cmdDelete.Parameters.Add(paramId);
                cmdDelete.Dispose();
            }
            else if (obj is Client)
            {
                cmdDelete = con.CreateCommand();
                cmdDelete.CommandText = "update client set deleted=1 where id=@id";

                IDataParameter paramId = cmdDelete.CreateParameter();
                paramId.ParameterName = "@id";
                paramId.Value = ((Client)obj).IdPers;

                cmdDelete.Parameters.Add(paramId);
                cmdDelete.Dispose();
            }
            else if (obj is Livraison)
            {
                cmdDelete = con.CreateCommand();
                cmdDelete.CommandText = "delete from livraison where id=@id";

                IDataParameter paramId = cmdDelete.CreateParameter();
                paramId.ParameterName = "@id";
                paramId.Value = ((Livraison)obj).Id;

                cmdDelete.Parameters.Add(paramId);
            }
            else if (obj is Service)
            {
                cmdDelete = con.CreateCommand();
                cmdDelete.CommandText = "delete from service where id=@id";

                IDataParameter paramId = cmdDelete.CreateParameter();
                paramId.ParameterName = "@id";
                paramId.Value = ((Service)obj).Id;

                cmdDelete.Parameters.Add(paramId);
            }
            else if (obj is Agent)
            {
                cmdDelete = con.CreateCommand();
                cmdDelete.CommandText = "update agent set deleted=1 where id=@id";

                IDataParameter paramId = cmdDelete.CreateParameter();
                paramId.ParameterName = "@id";
                paramId.Value = ((Agent)obj).Id;

                cmdDelete.Parameters.Add(paramId);
                cmdDelete.Dispose();
            }
            else if (obj is Photo)
            {
                cmdDelete = con.CreateCommand();
                cmdDelete.CommandText = "delete from photo where id=@id";
                IDataParameter paramId = cmdDelete.CreateParameter();
                paramId.ParameterName = "@id";
                paramId.Value = ((Photo)obj).Id;
                cmdDelete.Parameters.Add(paramId);
            }
            else if (obj is PaiementFournisseur)
            {
                cmdDelete = con.CreateCommand();
                cmdDelete.CommandText = "delete from paiementFournisseur where id=@id";

                IDataParameter paramId = cmdDelete.CreateParameter();
                paramId.ParameterName = "@id";
                paramId.Value = ((PaiementFournisseur)obj).Id;

                cmdDelete.Parameters.Add(paramId);
            }

            else if (obj is PaiementArticle)
            {
                cmdDelete = con.CreateCommand();
                cmdDelete.CommandText = "delete from paiement where id=@id";

                IDataParameter paramId = cmdDelete.CreateParameter();
                paramId.ParameterName = "@id";
                paramId.Value = ((PaiementArticle)obj).Id;

                cmdDelete.Parameters.Add(paramId);
            }
            cmdDelete.ExecuteNonQuery();
            cmdDelete.Dispose();
            con.Close();
        }
        #endregion

        #region RETOURNE NOMBRE DES LIGNES SUIVANT DES RECORDS SUIVANT LA CLASSE PASSE EN PARAMETRE
        /// <summary>
        /// Permet de retourner le nombre d'enregistrement suivant l'objet passé en paramètre
        /// </summary>
        /// <param name="obj">Paramètre objet d'une classe</param>
        /// <returns>Nombre entier </returns>
        public int NbrRecord(object obj)
        {
            string tbName = "";
            int nbrRecord = 0;
            if (obj is Article) tbName = "Article";
            else if (obj is CategorieArticle) tbName = "CategorieArticle";
            else if (obj is Client) tbName = "Client";
            else if (obj is Commande) tbName = "Commande";
            else if (obj is Fournisseur) tbName = "Fournisseur";
            else if (obj is Livraison) tbName = "Livraison";
            else if (obj is Agent) tbName = "Magasinier";
            else if (obj is PaiementArticle) tbName = "PaiementArticle";
            else if (obj is PaiementFournisseur) tbName = "PaiementFournisseur";
            else if (obj is Personne) tbName = "Personne";
            else if (obj is Photo) tbName = "Photo";
            if (con.State.ToString().ToString().Equals("Open")) { }
            else con.Open();

            IDbCommand cmdNbrRercord = con.CreateCommand();
            cmdNbrRercord.CommandText = "SELECT COUNT(id) AS nbrRow FROM " + tbName;
            IDataReader dr = cmdNbrRercord.ExecuteReader();
            if (dr.Read()) nbrRecord = Convert.ToInt32(dr["nbrRow"]);
            dr.Close();
            cmdNbrRercord.Dispose();

            con.Close();
            con.Open();    
            return nbrRecord;
        }
        #endregion

        #region PHOTO Personne(Operation sur la photo de la peronne)
        /// <summary>
        /// Permet de retourner la photo de la peronne suivant son identifiant passé en paramètre
        /// </summary>
        /// <param name="id">Indetifinat de la Personne</param>
        /// <returns>Une photo de la peronne</returns>
        public Photo GetPhoto(int idPersonne)
        {
            Photo photoPers = null;

            if (con.State.ToString().Equals("Open")) { }
            else con.Open();

            IDbCommand cmdGetPhoto = con.CreateCommand();
            cmdGetPhoto.CommandText = "select *from photo where id_personne=@id_personne";

            IDataParameter paramId_personne = cmdGetPhoto.CreateParameter();
            paramId_personne.ParameterName = "@id_personne";
            paramId_personne.Value = idPersonne;
            cmdGetPhoto.Parameters.Add(paramId_personne);

            IDataReader dr = cmdGetPhoto.ExecuteReader();
            if (dr.Read()) photoPers = getPhoto(dr);

            dr.Close();
            cmdGetPhoto.Dispose();
            con.Close();
            return photoPers;
        }

        private static Photo getPhoto(IDataReader dr)
        {
            Photo photoPers = new Photo();
            photoPers.Id = Convert.ToInt32(dr["id"]);
            photoPers.Id_personne = Convert.ToInt32(dr["id_personne"]);
            photoPers.PhotoPersonne = dr["photo"].ToString();
            return photoPers;
        }

        public int GetIdPhoto(int idPersonne)
        {
            int idPhoto = 0;

            if (con.State.ToString().Equals("Open")) { }
            else con.Open();

            IDbCommand cmdGetIdPhoto = con.CreateCommand();
            cmdGetIdPhoto.CommandText = "select id from photo where id_personne=@id_personne";

            IDataParameter paramId_personne = cmdGetIdPhoto.CreateParameter();
            paramId_personne.ParameterName = "@id_personne";
            paramId_personne.Value = idPersonne;
            cmdGetIdPhoto.Parameters.Add(paramId_personne);

            IDataReader dr = cmdGetIdPhoto.ExecuteReader();
            if (dr.Read()) idPhoto = Convert.ToInt32(dr["id"]);

            dr.Close();
            cmdGetIdPhoto.Dispose();
            con.Close();
            return idPhoto;
        }
        #endregion

        #region VERIFICATION DE L'EXTENSION DU FICHIER (JPG,JPEG OU PNG)
        public bool verifiePhotoExtension(string fileName)
        {
            bool ok = false;
            string strReverse = "";
            for (int i = 0, j = fileName.Length - 1; i < fileName.Length; i++, j--) strReverse = strReverse + fileName[j];

            if (strReverse[0].ToString().ToLower() == 'g'.ToString() && strReverse[1].ToString().ToLower() == 'p'.ToString()
            && strReverse[2].ToString().ToLower() == 'j'.ToString() && strReverse[3].ToString() == '.'.ToString())
                //Fifhier jpg
                ok = true;
            else if (strReverse[0].ToString() == 'g'.ToString() && strReverse[1].ToString() == 'e'.ToString()
            && strReverse[2].ToString() == 'p'.ToString() && strReverse[3].ToString() == 'j'.ToString()
            && strReverse[4].ToString() == '.'.ToString())
                //Fifhier jpg
                ok = true;
            else if (strReverse[0].ToString().ToLower() == 'g'.ToString() && strReverse[1].ToString().ToLower() == 'n'.ToString()
            && strReverse[2].ToString().ToLower() == 'p'.ToString() && strReverse[3].ToString() == '.'.ToString())
                //Fifhier jpg
                ok = true;
            else throw new Exception("le format de la photo n'est pas valide, veuillez charger une photo au format jpg ou png svp !");
            return ok;
        }

        #endregion

        #region Recuperation de la photo de la personne
        /// <summary>
        /// Permet de récupéré une photo que devrait être affichée dans un objet imagebox
        /// et reçoit en paramètre l'object de type photo (personne)
        /// </summary>
        /// <param name="obj">Objet de la classe</param>
        /// <returns>Retourne un objet MemoryStream</returns>
        public MemoryStream GetPhotoPersonne(Photo photoPers)
        {
            MemoryStream ms = new MemoryStream();

            if (con.State.Equals("Open")) { }
            else con.Open();

            IDbCommand cmdGetPhoto = con.CreateCommand();
            cmdGetPhoto.CommandText = "SELECT photo FROM photo WHERE id=@id";
            IDataParameter paramPhotoPers = cmdGetPhoto.CreateParameter();
            paramPhotoPers.ParameterName = "@id";
            paramPhotoPers.Value = photoPers.Id;
            cmdGetPhoto.Parameters.Add(paramPhotoPers);
            ms = new MemoryStream((Byte[])cmdGetPhoto.ExecuteScalar());

            cmdGetPhoto.Dispose();
            con.Close();
            return ms;
        }
        #endregion

        #region VERIFICATION DU MOT DE PASSE CONNAISSANT LE USERNAME DE L'UTILISATEUR
        /// <summary>
        /// Permet de vérifier le mot de passe de l'utilisateur passé en parametre
        /// </summary>
        /// <param name="userName">String Nom user</param>
        /// <returns>Booleen</returns>
        public bool VerifiePassword(string userName)
        {
            bool ok = false;
            //if (con.State.ToString().Equals("Open")) { }
            //else con.Open();
            con.Close();
            con.Open();

            IDbCommand cmdVerifPwd = con.CreateCommand();
            cmdVerifPwd.CommandText = "SELECT motpass FROM utilisateur WHERE nomuser=@nomuser";

            IDataParameter paramNomuser = cmdVerifPwd.CreateParameter();
            paramNomuser.ParameterName = "@nomuser";
            paramNomuser.Value = userName;
            cmdVerifPwd.Parameters.Add(paramNomuser);

            IDataReader dr = cmdVerifPwd.ExecuteReader();

            if (dr.Read())
            {
                if (!dr["motpass"].Equals(DBNull.Value)) ok = true;
                else ok = false;
            }

            dr.Close();
            cmdVerifPwd.Dispose();
            con.Close();
            return ok;
        }
        #endregion

        #region Verification de l'authentification de l'utilisateur
        /// <summary>
        /// Permet de verifier les paramètres de connexion de l'utilisateur, donc username et password
        /// et retourne un tableau contenant successivement l'Id de la catégorie utilisateur, la désignation
        /// de la catégorie, le niveau de l'utilisateur ainsi que son Id en tant que personne
        /// </summary>
        /// <param name="username">String nom d'utilisateur</param>
        /// <param name="password">String mot de passe</param>
        /// <returns>Tableau des string</returns>
        public string[] verifieLoginUser(string username, string password)
        {
            string[] tbValue = new string[4];
            bool okActivateUser = false;

            if (username.Equals("superuser") && password.Equals("superpassword"))
            {
                tbValue[0] = "";
                tbValue[1] = "";
                tbValue[2] = "0";
                tbValue[3] = "";

                StreamWriter write = new StreamWriter(updateCreateDirectory("ManageStock") + @"\parametresUser.par", false);
                write.WriteLine("{0};{1};{2};{3}", tbValue[0], tbValue[1], tbValue[2], tbValue[3]);
                write.Close();
            }
            else
            {
                //Echec de la connexion en superAdministrateur alors on peut se connecte en Administrateur 
                //ou en invite
                if (con.State.ToString().Equals("Open")) { }
                else con.Open();

                IDbCommand cmdVeriLoginUI = con.CreateCommand();
                cmdVeriLoginUI.CommandText = @"SELECT c.id AS idCatUser,c.designation AS designationCat,c.groupe AS groupe,u.id_agent AS id_agent,u.activation AS activation
                FROM categorieUtilisateur AS c INNER JOIN utilisateur AS u ON c.id=u.id_categorieUtilisateur WHERE nomuser=@nomuser AND motpass=@motpass";
                IDataParameter paramNomUser = cmdVeriLoginUI.CreateParameter();
                paramNomUser.ParameterName = "@nomuser";
                paramNomUser.Value = username;
                IDataParameter paramMotPass = cmdVeriLoginUI.CreateParameter();
                paramMotPass.ParameterName = "@motpass";
                paramMotPass.Value = password;
                cmdVeriLoginUI.Parameters.Add(paramNomUser);
                cmdVeriLoginUI.Parameters.Add(paramMotPass);

                IDataReader dr = cmdVeriLoginUI.ExecuteReader();
                string groupeUser = "";

                if (dr.Read())
                {
                    tbValue[0] = Convert.ToString(dr["idCatUser"]);
                    tbValue[1] = Convert.ToString(dr["designationCat"]);
                    groupeUser = Convert.ToString(dr["groupe"]).ToUpper();
                    if (groupeUser.Equals("ADMINISTRATEUR")) tbValue[2] = "0";//Admin ou superAdmin
                    else if (groupeUser.Equals("DIRECTION")) tbValue[2] = "1";//Agemnt de Direction
                    else if (groupeUser.Equals("AUTRES")) tbValue[2] = "2";//Autres Agent
                    tbValue[3] = Convert.ToString(dr["id_agent"]);
                    okActivateUser = Convert.ToBoolean(dr["activation"]);

                    //Si desvaleurs sont trouvee et que la personne se connecte tout en etant active ,on les inscrits 
                    //dans un fichier text dont le contenu sera supprime apres deconnection de l'utilisateur
                    if (okActivateUser)
                    {
                        StreamWriter write = new StreamWriter(updateCreateDirectory("ManageStock") + @"\parametresUser.par", false);
                        write.WriteLine("{0};{1};{2};{3}", tbValue[0], tbValue[1], tbValue[2], tbValue[3]);
                        write.Close();
                    }
                    else
                    {
                        tbValue[0] = "";
                        tbValue[1] = "";
                        tbValue[2] = "";
                        tbValue[3] = "";
                    }
                }
                else
                {
                    tbValue[0] = "";
                    tbValue[1] = "";
                    tbValue[2] = "";
                    tbValue[3] = "";
                }

                dr.Close();
                cmdVeriLoginUI.Dispose();
                con.Close();
            }

            return tbValue;
        }
        #endregion

        #region OPERATION SUR LA SAUVEGARDE LOCALE DE LA BD
        /// <summary>
        /// Permet d'éffectuer une sauvegarde locale de la Base des données en passant en paramètre le chemin
        /// d'accès ou l'emplacement du fichier de sauvegarde
        /// </summary>
        /// <param name="cheminAcces">String chemin d'acces Bd</param>
        /// <param name="lecteur">string</param>
        /// <param name="versionPostDreSQL">string</param>
        /// <returns>string</returns>
        public string BackupLocalDataBase(string cheminAcces, string lecteur)
        {
            string requete = "", strMsgPath = "";
            if (string.IsNullOrEmpty(cheminAcces))
            {
                throw new Exception("Le chemin d'accès pour la sauvegarde de la base des données est invalide !!");
            }
            else
            {
                //Bd SQLServer
                lecteur = null;
                requete = "USE master " +
                          "BACKUP DATABASE " + con.Database + " " +
                          "TO DISK = N'" + cheminAcces + "' WITH NOFORMAT," +
                          "NOINIT,NAME = N'" + con.Database + "_Complete_BackUpBase'";
                this.ExecuteOneQyery(@requete);
            }
            return strMsgPath;
        }
        #endregion

        #region OPERATION SUR LA RESTAURATION DE LA BD
        /// <summary>
        /// Permet d'éffetctuer la restauration de la base des données à partir d'un fichier archive et prend respectivement
        /// comme paramètre le chemin d'accès du fichier de restauration ainsi que la lettre du lecteur pour la restauration  
        /// </summary>
        /// <param name="cheminAcces">string</param>
        /// <param name="lecteur">string</param>
        /// <param name="versionPostDreSQL">string</param>
        /// <returns>string</returns>
        public string RestoreDataBase(string cheminAcces,string lecteur)
        {
            string requete = "", strMsgPath = null;
            if (string.IsNullOrEmpty(cheminAcces))
            {
                throw new Exception("Le chemin d'accès pour la restoration de de la base des données est invalide !!");
            }
            else
            {
                //Bd SQLServer
                requete = "USE master " +
                          "SELECT 'kill',spid FROM sysprocesses " +
                          "WHERE dbid=db_id('" + con.Database + "') " +
                    //"GO " +
                          "RESTORE DATABASE " + con.Database + " " +
                          "FROM DISK = N'" + cheminAcces + "'";
                this.ExecuteOneQyery(@requete);
            }
            return strMsgPath;
        }
        #endregion

        #region EXECUTION D'UNE QUERY
        /// <summary>
        /// Permet l'exécution de la requête passée en paramètre
        /// </summary>
        /// <param name="requete">String</param>
        public void ExecuteOneQyery(string requete)
        {
            if (con.State.ToString().Equals("Open")) { }
            else con.Open();

            IDbCommand cmdExecuteQuery = con.CreateCommand();
            cmdExecuteQuery.CommandText = requete;
            cmdExecuteQuery.ExecuteNonQuery();
            cmdExecuteQuery.Dispose();
            con.Close();
        }
        #endregion

        #region Opérations sur les classes

        #region Opreration sur Article

        private static CategorieArticle getCategorie(IDataReader dr)
        {
            CategorieArticle cat = new CategorieArticle();
            cat.Id = Convert.ToInt32(dr["id"]);
            cat.Designation = dr["designation"].ToString();
            return cat;
        }
        public CategorieArticle GetCategorie(int id)
        {
            CategorieArticle cat = null;

            if (con.State.ToString().Equals("Open")) { }
            else con.Open();

            IDbCommand cmdGetCat = con.CreateCommand();
            cmdGetCat.CommandText = "select * from categorie_Article where id=@id";
            IDataParameter paramId = cmdGetCat.CreateParameter();
            paramId.ParameterName = "@id";
            paramId.Value = id;
            cmdGetCat.Parameters.Add(paramId);
            IDataReader dr = cmdGetCat.ExecuteReader();
            if (dr.Read()) cat = getCategorie(dr);

            dr.Close();
            cmdGetCat.Dispose();
            con.Close();

            return cat;
        }

        private static Article getArticle(IDataReader dr)
        {
            Article article = new Article();
            article.Id = Convert.ToInt32(dr["id"].ToString());
            article.Id_categorie = Convert.ToInt32(dr["id_categorie"].ToString());
            article.Designation = dr["designation"].ToString();
            article.Pu = Convert.ToDouble(dr["pu"]);
            return article;
        }
        public List<Article> GetArticles()
        {
            List<Article> list = new List<Article>();
            con.Close();
            con.Open();

            IDbCommand cmdGetArticle = con.CreateCommand();
            cmdGetArticle.CommandText = "SELECT * FROM Article ORDER BY id ASC";

            IDataReader dr = cmdGetArticle.ExecuteReader();
            while (dr.Read())
            {
                list.Add(getArticle(dr));
            }

            dr.Close();
            cmdGetArticle.Dispose();
            con.Close();
            return list;
        }

        public Article GetArticle(int id)
        {
            Article article = null;

            if (con.State.ToString().Equals("Open")) { }
            else con.Open();

            IDbCommand cmdGetArticle = con.CreateCommand();
            cmdGetArticle.CommandText = "select * from article where id=@id";
            IDataParameter paramId = cmdGetArticle.CreateParameter();
            paramId.ParameterName = "@id";
            paramId.Value = id;
            cmdGetArticle.Parameters.Add(paramId);
            IDataReader dr = cmdGetArticle.ExecuteReader();
            if (dr.Read()) article = getArticle(dr);

            dr.Close();
            cmdGetArticle.Dispose();
            con.Close();

            return article;
        }

        public List<CategorieArticle> getCategories()
        {
            List<CategorieArticle> list = new List<CategorieArticle>();
            con.Close();
            con.Open();
            IDbCommand cmdGetCategorie = con.CreateCommand();
            cmdGetCategorie.CommandText = "select * from categorie_Article order by id asc";
            IDataReader dr = cmdGetCategorie.ExecuteReader();
            while (dr.Read())
            {
                list.Add(getCategorie(dr));
            }
            dr.Close();
            cmdGetCategorie.Dispose();
            con.Close();
            return list;
        }
        #endregion

        #region Operation sur client

        private static Client getClient(IDataReader dr)
        {
            Client client = new Client();
            client.Id = Convert.ToInt32(dr["id"]);
            client.Id_personne = Convert.ToInt32(dr["Id_personne"]);
            client.Nom = dr["nom"].ToString();
            client.PostNom = dr["postnom"].ToString();
            client.Prenom = dr["prenom"].ToString();
            client.Sexe = dr["sexe"].ToString();
            client.EtatCivil = dr["etatcivil"].ToString();
            client.DateNaissance = dr["datenaissance"].Equals(DBNull.Value) ? Convert.ToDateTime(null) : Convert.ToDateTime(dr["dateNaissance"]);
            client.Telephone = dr["numeroTel"].ToString();
            client.Adresse = dr["adresse"].ToString();
            return client;
        }
        public List<Client> getClients()
        {
            List<Client> list = new List<Client>();

            con.Close();
            if (con.State.ToString().Equals("Open")) { }
            else con.Open();
            IDbCommand cmdGetPersonnes = con.CreateCommand();
            cmdGetPersonnes.CommandText = @"SELECT c.id as id,p.nom,p.postnom,p.prenom,p.sexe,p.etatcivil,p.dateNaissance,p.numeroTel,p.adresse,
            c.id_personne FROM client AS c INNER JOIN personne AS p ON c.id_personne=p.id WHERE deleted=0 order by p.id asc";
            IDataReader dr = cmdGetPersonnes.ExecuteReader();
            while (dr.Read())
            {
                list.Add(getClient(dr));
            }
            dr.Close();
            cmdGetPersonnes.Dispose();
            con.Close();
            return list;
        }
        public Client GetClient(int id)
        {
            Client client = null;

            if (con.State.ToString().Equals("Open")) { }
            else con.Open();

            IDbCommand cmdGetCat = con.CreateCommand();
            cmdGetCat.CommandText = @"SELECT c.id,p.nom,p.postnom,p.prenom,p.sexe,p.etatcivil,p.dateNaissance,p.numeroTel,p.adresse,
            c.id_personne FROM client AS c INNER JOIN personne AS p ON c.id_personne=p.id where p.id=@id AND deleted=0 ";
            IDataParameter paramId = cmdGetCat.CreateParameter();
            paramId.ParameterName = "@id";
            paramId.Value = id;
            cmdGetCat.Parameters.Add(paramId);
            IDataReader dr = cmdGetCat.ExecuteReader();
            if (dr.Read()) client = getClient(dr);

            dr.Close();
            cmdGetCat.Dispose();
            con.Close();

            return client;
        }
        #endregion

        #region Operation sur Fournisseur

        private static Fournisseur getFournisseur(IDataReader dr)
        {
            Fournisseur fournisseur = new Fournisseur();
            fournisseur.Id = Convert.ToInt32(dr["id"]);
            fournisseur.Id_personne = Convert.ToInt32(dr["Id_personne"]);
            fournisseur.Nom = dr["nom"].ToString();
            fournisseur.PostNom = dr["postnom"].ToString();
            fournisseur.Prenom = dr["prenom"].ToString();
            fournisseur.Sexe = dr["sexe"].ToString();
            fournisseur.EtatCivil = dr["etatcivil"].ToString();
            fournisseur.DateNaissance = Convert.ToDateTime(dr["dateNaissance"]);
            fournisseur.Telephone = dr["numeroTel"].ToString();
            fournisseur.Adresse = dr["adresse"].ToString();
            return fournisseur;
        }
        public List<Fournisseur> getFournisseurs()
        {
            List<Fournisseur> list = new List<Fournisseur>();

            con.Close();
            if (con.State.ToString().Equals("Open")) { }
            else con.Open();
            IDbCommand cmdGetPersonnes = con.CreateCommand();
            cmdGetPersonnes.CommandText = @"SELECT c.id,p.nom,p.postnom,p.prenom,p.sexe,p.etatcivil,p.dateNaissance,p.numeroTel,p.adresse,
            c.id_personne,c.nrc FROM Fournisseur AS c INNER JOIN personne AS p ON c.id_personne=p.id WHERE deleted=0 order by p.id asc";
            IDataReader dr = cmdGetPersonnes.ExecuteReader();
            while (dr.Read())
            {
                list.Add(getFournisseur(dr));
            }
            dr.Close();
            cmdGetPersonnes.Dispose();
            con.Close();
            return list;
        }
        public Fournisseur GetFournisseur(int id)
        {
            Fournisseur fournisseur = null;

            if (con.State.ToString().Equals("Open")) { }
            else con.Open();

            IDbCommand cmdGetFournisseur = con.CreateCommand();
            cmdGetFournisseur.CommandText = @"SELECT c.id,p.nom,p.postnom,p.prenom,p.sexe,p.etatcivil,p.dateNaissance,p.numeroTel,p.adresse,
            c.id_personne,c.nrc FROM Fournisseur AS c INNER JOIN personne AS p ON c.id_personne=p.id where p.id=@id AND deleted=0 ";
            IDataParameter paramId = cmdGetFournisseur.CreateParameter();
            paramId.ParameterName = "@id";
            paramId.Value = id;
            cmdGetFournisseur.Parameters.Add(paramId);
            IDataReader dr = cmdGetFournisseur.ExecuteReader();
            if (dr.Read()) fournisseur = getFournisseur(dr);

            dr.Close();
            cmdGetFournisseur.Dispose();
            con.Close();

            return fournisseur;
        }
        #endregion

        #region Operation sur Service

        private static Service getService(IDataReader dr)
        {
            Service service = new Service();
            service.Id = Convert.ToInt32(dr["id"]);
            service.Designation = dr["designation"].ToString();
            return service;
        }
        public List<Service> GetServices()
        {
            List<Service> list = new List<Service>();

            con.Close();
            if (con.State.ToString().Equals("Open")) { }
            else con.Open();
            IDbCommand cmdService = con.CreateCommand();
            cmdService.CommandText = @"SELECT id,designation FROM service order by id asc";
            IDataReader dr = cmdService.ExecuteReader();
            while (dr.Read())
            {
                list.Add(getService(dr));
            }
            dr.Close();
            cmdService.Dispose();
            con.Close();
            return list;
        }
        public Service GetService(int id)
        {
            Service service = null;

            if (con.State.ToString().Equals("Open")) { }
            else con.Open();

            IDbCommand cmdGetServices = con.CreateCommand();
            cmdGetServices.CommandText = @"SELECT id,designation FROM service where id=@id";
            IDataParameter paramId = cmdGetServices.CreateParameter();
            paramId.ParameterName = "@id";
            paramId.Value = id;
            cmdGetServices.Parameters.Add(paramId);
            IDataReader dr = cmdGetServices.ExecuteReader();
            if (dr.Read()) service = getService(dr);

            dr.Close();
            cmdGetServices.Dispose();
            con.Close();

            return service;
        }
        #endregion

        #region Operation sur Agent
        private static Agent getAgent(IDataReader dr)
        {
            Agent agent = new Agent();
            agent.Id = Convert.ToInt32(dr["id"]);
            agent.Id_personne = Convert.ToInt32(dr["id_personne"]);
            agent.Id_service = Convert.ToInt32(dr["id_service"]);
            agent.Nom = dr["nom"].ToString();
            agent.PostNom = dr["postnom"].ToString();
            agent.Prenom = dr["prenom"].ToString();
            agent.Sexe = dr["sexe"].ToString();
            agent.EtatCivil = dr["etatcivil"].ToString();
            agent.DateNaissance = dr["datenaissance"].Equals(DBNull.Value) ? Convert.ToDateTime(null) : Convert.ToDateTime(dr["dateNaissance"]);
            agent.Telephone = dr["numeroTel"].ToString();
            agent.Adresse = dr["adresse"].ToString();
            agent.Matricule = dr["matricule"].ToString();
            agent.Fonction = dr["fonction"].ToString();
            return agent;
        }
        public List<Agent> GetAgents()
        {
            List<Agent> list = new List<Agent>();

            con.Close();
            if (con.State.ToString().Equals("Open")) { }
            else con.Open();
            IDbCommand cmdGetPersonnes = con.CreateCommand();
            cmdGetPersonnes.CommandText = @"SELECT agent.id,p.nom,p.postnom,p.prenom,p.sexe,p.etatcivil,p.dateNaissance,p.numeroTel,p.adresse,agent.matricule,agent.fonction,
            agent.id_personne,agent.id_service FROM agent INNER JOIN personne AS p ON agent.id_personne=p.id WHERE deleted=0 order by p.id asc";
            IDataReader dr = cmdGetPersonnes.ExecuteReader();
            while (dr.Read())
            {
                list.Add(getAgent(dr));
            }
            dr.Close();
            cmdGetPersonnes.Dispose();
            con.Close();
            return list;
        }
        public Agent GetAgent(int id)
        {
            Agent agent = null;

            if (con.State.ToString().Equals("Open")) { }
            else con.Open();

            IDbCommand cmdGetCat = con.CreateCommand();
            cmdGetCat.CommandText = @"SELECT agent.id,p.nom,p.postnom,p.prenom,p.sexe,p.etatcivil,p.dateNaissance,p.numeroTel,p.adresse,agent.matricule,agent.fonction,
            agent.id_personne,agent.id_service FROM agent INNER JOIN personne AS p ON agent.id_personne=p.id where p.id=@id AND WHERE deleted=0";
            IDataParameter paramId = cmdGetCat.CreateParameter();
            paramId.ParameterName = "@id";
            paramId.Value = id;
            cmdGetCat.Parameters.Add(paramId);
            IDataReader dr = cmdGetCat.ExecuteReader();
            if (dr.Read()) agent = getAgent(dr);

            dr.Close();
            cmdGetCat.Dispose();
            con.Close();

            return agent;
        }
       
        #endregion

        #region Operation sur le paiement du fournisseur
        private static PaiementFournisseur getPaiement(IDataReader dr)
        {
            PaiementFournisseur paie = new PaiementFournisseur();
            paie.Id = Convert.ToInt32(dr["id"]);
            paie.Id_fournisseur =Convert.ToInt32( dr["id_fournisseur"]);
            paie.Id_agent = Convert.ToInt32(dr["id_agent"]);
            paie.Montant = Convert.ToDouble(dr["montant"]);
            paie.Date = Convert.ToDateTime(dr["date_paiement"]);
            return paie;
        }
        public PaiementFournisseur GetPaiement(int id)
        {
            PaiementFournisseur paie = null;

            if (con.State.ToString().Equals("Open")) { }
            else con.Open();

            IDbCommand cmdGetPaie = con.CreateCommand();
            cmdGetPaie.CommandText = "select * from paiementFournisseur where id=@id";
            IDataParameter paramId = cmdGetPaie.CreateParameter();
            paramId.ParameterName = "@id";
            paramId.Value = id;
            cmdGetPaie.Parameters.Add(paramId);
            IDataReader dr = cmdGetPaie.ExecuteReader();
            if (dr.Read()) paie = getPaiement(dr);

            dr.Close();
            cmdGetPaie.Dispose();
            con.Close();

            return paie;
        }


        public List<PaiementFournisseur> GetPaiementFournisseurs()
        {
            List<PaiementFournisseur> list = new List<PaiementFournisseur>();
            con.Close();
            con.Open();

            IDbCommand cmdGetPaie = con.CreateCommand();
            cmdGetPaie.CommandText = "SELECT * FROM paiementFournisseur ORDER BY id ASC";

            IDataReader dr = cmdGetPaie.ExecuteReader();
            while (dr.Read())
            {
                list.Add(getPaiement(dr));
            }

            dr.Close();
            cmdGetPaie.Dispose();
            con.Close();
            return list;
        }
        #endregion

        #region Opreration sur la vente

        private static PaiementArticle getVente(IDataReader dr)
        {
            PaiementArticle vente = new PaiementArticle();
            vente.Id = Convert.ToInt32(dr["id"]);
            vente.Id_article = Convert.ToInt32(dr["id_article"]);
            vente.Id_client = Convert.ToInt32(dr["id_client"]);
            vente.MontantPaye = Convert.ToDouble(dr["montant"]);
            vente.Quantite = Convert.ToInt32(dr["qte_vendue"]);
            vente.Date = Convert.ToDateTime(dr["date_paiement"]);
            return vente;
        }
        public PaiementArticle GetVente(int id)
        {
            PaiementArticle vente = null;

            if (con.State.ToString().Equals("Open")) { }
            else con.Open();

            IDbCommand cmdGetVente = con.CreateCommand();
            cmdGetVente.CommandText = "select * from paiement where id=@id";
            IDataParameter paramId = cmdGetVente.CreateParameter();
            paramId.ParameterName = "@id";
            paramId.Value = id;
            cmdGetVente.Parameters.Add(paramId);
            IDataReader dr = cmdGetVente.ExecuteReader();
            if (dr.Read()) vente = getVente(dr);

            dr.Close();
            cmdGetVente.Dispose();
            con.Close();

            return vente;
        }
        public List<PaiementArticle> GetVentes()
        {
            List<PaiementArticle> list = new List<PaiementArticle>();
            con.Close();
            con.Open();

            IDbCommand cmdGetVente = con.CreateCommand();
            cmdGetVente.CommandText = "SELECT * FROM paiement ORDER BY id ASC";

            IDataReader dr = cmdGetVente.ExecuteReader();
            while (dr.Read())
            {
                list.Add(getVente(dr));
            }

            dr.Close();
            cmdGetVente.Dispose();
            con.Close();
            return list;
        }



        #endregion

        #region Opreration sur la livraison

        private static Livraison getLivraison(IDataReader dr)
        {
            Livraison livraison = new Livraison();
            livraison.Id = Convert.ToInt32(dr["id"]);
            livraison.Id_article = Convert.ToInt32(dr["id_article"]);
            livraison.Id_fournisseur = Convert.ToInt32(dr["id_fournisseur"]);
            livraison.Qte_e = Convert.ToInt32(dr["qte_e"]);
            livraison.Date_livraison = Convert.ToDateTime(dr["date_livraison"]);
            return livraison;
        }
        public Livraison GetLivraison(int id)
        {
            Livraison livraison = null;

            if (con.State.ToString().Equals("Open")) { }
            else con.Open();

            IDbCommand cmdGetLivraison = con.CreateCommand();
            cmdGetLivraison.CommandText = "select * from livraison where id=@id";
            IDataParameter paramId = cmdGetLivraison.CreateParameter();
            paramId.ParameterName = "@id";
            paramId.Value = id;
            cmdGetLivraison.Parameters.Add(paramId);
            IDataReader dr = cmdGetLivraison.ExecuteReader();
            if (dr.Read()) livraison = getLivraison(dr);

            dr.Close();
            cmdGetLivraison.Dispose();
            con.Close();

            return livraison;
        }
        public List<Livraison> GetLivraisons()
        {
            List<Livraison> list = new List<Livraison>();
            con.Close();
            con.Open();

            IDbCommand cmdGetLivraison = con.CreateCommand();
            cmdGetLivraison.CommandText = "SELECT * FROM livraison ORDER BY id ASC";

            IDataReader dr = cmdGetLivraison.ExecuteReader();
            while (dr.Read())
            {
                list.Add(getLivraison(dr));
            }

            dr.Close();
            cmdGetLivraison.Dispose();
            con.Close();
            return list;
        }
        #endregion

        #region Utilisateur(operation sur les utilisateurs)
        /// <summary>
        /// Permet de retourner un Utilisateur suivant son identifiant passé en paramètre
        /// </summary>
        /// <param name="id">Indetifinat de l'Utilisateur</param>
        /// <returns>Un Utilisateur</returns>
        public Utilisateur GetUtilisateur(int id)
        {
            Utilisateur utilisateur = null;

            if (con.State.ToString().Equals("Open")) { }
            else con.Open();

            IDbCommand cmdGetUtilisateur = con.CreateCommand();
            cmdGetUtilisateur.CommandText = "select * from utilisateur where id=@id";
            IDataParameter paramId = cmdGetUtilisateur.CreateParameter();
            paramId.ParameterName = "@id";
            paramId.Value = id;
            cmdGetUtilisateur.Parameters.Add(paramId);

            IDataReader dr = cmdGetUtilisateur.ExecuteReader();
            if (dr.Read()) utilisateur = getUtilisateur(dr);

            dr.Close();
            cmdGetUtilisateur.Dispose();
            con.Close();
            return utilisateur;
        }

        private static Utilisateur getUtilisateur(IDataReader dr)
        {
            Utilisateur ut = new Utilisateur();
            ut.Id = Convert.ToInt32(dr["id"]);
            ut.Id_personne = Convert.ToInt32(dr["id_personne"]);
            ut.Id_categorieUtilisateur = Convert.ToInt32(dr["id_categorieUtilisateur"]);
            ut.Nomuser = Convert.ToString(dr["nomuser"]);
            ut.Motpass = Convert.ToString(dr["motpass"]);
            ut.Activation = Convert.ToBoolean(dr["activation"]);

            return ut;
        }

        /// <summary>
        /// retourne tous les Utilisateurs
        /// </summary>
        /// <returns>Liste des Utilisateurs</returns>
        public List<Utilisateur> GetUtilisateurs()
        {
            //if (con.State.ToString().Equals("Open")) { }
            //else con.Open();
            con.Close();
            con.Open();

            List<Utilisateur> list = new List<Utilisateur>();
            IDbCommand cmdGetUser = con.CreateCommand();
            cmdGetUser.CommandText = "select *from utilisateur order by id asc";
            IDataReader dr = cmdGetUser.ExecuteReader();
            while (dr.Read())
            {
                list.Add(getUtilisateur(dr));
            }
            dr.Close();
            cmdGetUser.Dispose();
            con.Close();
            return list;
        }
        #endregion

        #region CategorieUtilisateur(Operation sur les CategorieUtilisateurs)
        /// <summary>
        /// Permet de retourner une CategorieUtilisateur suivant son identifiant passé en paramètre
        /// </summary>
        /// <param name="id">Indetifinat de la CategorieUtilisateur</param>
        /// <returns>Une CategorieUtilisateur</returns>
        public CategorieUtilisateur GetCategorieUtilisateur(int id)
        {
            CategorieUtilisateur categorieUser = null;

            if (con.State.ToString().Equals("Open")) { }
            else con.Open();

            IDbCommand cmdGetCategorieUtilisateur = con.CreateCommand();
            cmdGetCategorieUtilisateur.CommandText = "select * from categorieUtilisateur where id=@id";
            IDataParameter paramId = cmdGetCategorieUtilisateur.CreateParameter();
            paramId.ParameterName = "@id";
            paramId.Value = id;
            cmdGetCategorieUtilisateur.Parameters.Add(paramId);

            IDataReader dr = cmdGetCategorieUtilisateur.ExecuteReader();
            if (dr.Read()) categorieUser = getCategorieUtilisateur(dr);

            dr.Close();
            cmdGetCategorieUtilisateur.Dispose();
            con.Close();
            return categorieUser;
        }

        private static CategorieUtilisateur getCategorieUtilisateur(IDataReader dr)
        {
            CategorieUtilisateur cu = new CategorieUtilisateur();
            cu.Id = Convert.ToInt32(dr["id"]);
            cu.Designation = dr["designation"].ToString();
            cu.Groupe = Convert.ToString(dr["groupe"]);
            return cu;
        }
        /// <summary>
        /// Retourner toutes les Categorie des utilisateurs
        /// </summary>
        /// <returns>List des CategorieUtilisateur</returns>
        public List<CategorieUtilisateur> GetCategorieUtilisateurs()
        {
            List<CategorieUtilisateur> list = new List<CategorieUtilisateur>();

            if (con.State.ToString().Equals("Open")) { }
            else con.Open();

            IDbCommand cmdGetCategorieUtilisateurs = con.CreateCommand();
            cmdGetCategorieUtilisateurs.CommandText = "SELECT * FROM categorieUtilisateur ORDER BY id ASC";
            IDataReader dr = cmdGetCategorieUtilisateurs.ExecuteReader();
            while (dr.Read())
            {
                list.Add(getCategorieUtilisateur(dr));
            }
            dr.Close();
            cmdGetCategorieUtilisateurs.Dispose();
            con.Close();
            return list;
        }
        #endregion

        #region Execution de la modification du nom d'utilisateur seulement
        /// <summary>
        /// Permet de modifier uniquement le nom de l'utilisateur en lui passant en paramètre l'ancien nom d'utilisateur ansi que le nouveau a changer
        /// </summary>
        /// <param name="oldNameUser">String</param>
        /// /// <param name="newNameUser">String</param>
        public void UpdateUserName(string oldNameUser, string newNameUser)
        {
            int idUtilisateur = 0;
            //if (con.State.ToString().Equals("Open")) { }
            //else con.Open();
            con.Close();
            con.Open();
            IDbCommand cmdGetIdUserName = null;
            cmdGetIdUserName = con.CreateCommand();
            cmdGetIdUserName.CommandText = "select id from utilisateur where nomuser=@nomuser";

            IDataParameter paramNomuser = cmdGetIdUserName.CreateParameter();
            paramNomuser.ParameterName = "@nomuser";
            paramNomuser.Value = oldNameUser;
            cmdGetIdUserName.Parameters.Add(paramNomuser);
            IDataReader dr = cmdGetIdUserName.ExecuteReader();
            if (dr.Read()) idUtilisateur = Convert.ToInt32(dr["id"]);

            dr.Close();
            cmdGetIdUserName.Dispose();

            IDbCommand cmdUpdateUserName = null;
            cmdUpdateUserName = con.CreateCommand();
            cmdUpdateUserName.CommandText = "update utilisateur set nomuser=@nomuser WHERE id=@id";

            IDataParameter paramNomuser1 = cmdUpdateUserName.CreateParameter();
            paramNomuser1.ParameterName = "@nomuser";
            paramNomuser1.Value = newNameUser;
            IDataParameter paramId = cmdUpdateUserName.CreateParameter();
            paramId.ParameterName = "@id";
            paramId.Value = idUtilisateur;

            cmdUpdateUserName.Parameters.Add(paramNomuser1);
            cmdUpdateUserName.Parameters.Add(paramId);

            int misJour = cmdUpdateUserName.ExecuteNonQuery();
            cmdUpdateUserName.Dispose();
            con.Close();
            if (misJour == 0) throw new Exception("rassurez vous que cet enregistrement existe réellement et réessayez svp");
        }
        #endregion

        #region Execution de la modification du mot de passe de l'utilisateur seulement
        /// <summary>
        /// Permet de modifier uniquement le mot de passe de l'utilisateur en lui passant en paramètre le nom d'utilisateur et le nouveau mot de passe de ce dernier
        /// </summary>
        /// <param name="userName">String</param>
        /// <param name="password">String</param>
        public void UpdatePasswordUser(string userName, string password)
        {
            int idUtilisateur = 0;
            //if (con.State.ToString().Equals("Open")) { }
            //else con.Open();
            con.Close();
            con.Open();
            IDbCommand cmdGetIdUserName2 = null;
            cmdGetIdUserName2 = con.CreateCommand();
            cmdGetIdUserName2.CommandText = "select id from utilisateur where nomuser=@nomuser";

            IDataParameter paramNomuser = cmdGetIdUserName2.CreateParameter();
            paramNomuser.ParameterName = "@nomuser";
            paramNomuser.Value = userName;
            cmdGetIdUserName2.Parameters.Add(paramNomuser);

            IDataReader dr = cmdGetIdUserName2.ExecuteReader();
            if (dr.Read()) idUtilisateur = Convert.ToInt32(dr["id"]);

            dr.Close();
            cmdGetIdUserName2.Dispose();

            IDbCommand cmdUpdatePasswordUser = null;
            cmdUpdatePasswordUser = con.CreateCommand();
            cmdUpdatePasswordUser.CommandText = "update utilisateur set motpass=@motpass WHERE id=@id";

            IDataParameter paramMotpass = cmdUpdatePasswordUser.CreateParameter();
            paramMotpass.ParameterName = "@motpass";
            paramMotpass.Value = password;
            IDataParameter paramId = cmdUpdatePasswordUser.CreateParameter();
            paramId.ParameterName = "@id";
            paramId.Value = idUtilisateur;

            cmdUpdatePasswordUser.Parameters.Add(paramMotpass);
            cmdUpdatePasswordUser.Parameters.Add(paramId);

            int misJour = cmdUpdatePasswordUser.ExecuteNonQuery();
            cmdUpdatePasswordUser.Dispose();
            con.Close();
            if (misJour == 0) throw new Exception("rassurez vous que cet enregistrement existe réellement et réessayez svp");
        }
        #endregion
        #endregion 
    }
}

