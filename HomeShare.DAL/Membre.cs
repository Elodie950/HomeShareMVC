using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeShare.DAL
{
    public class Membre
    {
        #region Fields
        private int _idMembre;
        private string _nom;
        private string _prenom;
        private string _email;
        private int _pays;
        private string _telephone;
        private string _login;
        private string _password;
        #endregion

        #region Properties
        public int IdMembre {
            get { return _idMembre; }
            set { _idMembre = value; }
        }
        public string Nom
        {
            get{return _nom;}
            set{ _nom = value;}
        }
        public string Prenom 
        {
            get{return _prenom ;}
            set{ _prenom = value;}
        }
        public string Email
        {
            get{return _email ;}
            set{ _email = value;}
        }
        public int Pays
        {
            get { return _pays; }
            set { _pays = value; }
        }
        public string Telephone
        {
            get{return _telephone ;}
            set{ _telephone = value;}
        }
        public string Login 
        {
            get{return _login ;}
            set{ _login = value;}
        }
        public string Password {
            get{return _password ;}
            set{ _password = value;}
        }

        #endregion

        #region Method
        public static List<Membre> getAllMembre() 
        {
            List<Dictionary<string, object>> lesMembres = GestionConnexion.Instance.getData("select * from Membre");
            List<Membre> mesMembres = new List<Membre>();
            foreach(Dictionary<string, object> item in lesMembres){
                Membre m = associe(item);
                mesMembres.Add(m);
            }
            return mesMembres;
        
        }

        public static Membre getUnMembre(int id)
        {
            List<Dictionary<string, object>> lesMembres = GestionConnexion.Instance.getData("select * from Membre where idMembre=" + id);
            Membre m = associe(lesMembres[0]);
            return m;
        }
        public static Membre getUnMembreParBien(int id)
        {
            List<Dictionary<string, object>> lesMembres = GestionConnexion.Instance.getData("select Membre.idMembre, Membre.Nom, Membre.Prenom from Membre inner join BienEchange on BienEchange.idMembre = Membre.idMembre where idBien=" + id);
            Membre m = new Membre();
            m.IdMembre = int.Parse(lesMembres[0]["idMembre"].ToString());
            m.Nom = lesMembres[0]["Nom"].ToString();
            m.Prenom = lesMembres[0]["Prenom"].ToString();

            return m;
        }
          


        private static Membre associe(Dictionary<string, object> item)
        {
            Membre memb = new Membre()
            {
                IdMembre = (int)item["idMembre"],
                Nom = item["Nom"].ToString(),
                Prenom = item["Prenom"].ToString(),
                Email = item["Email"].ToString(),
                Pays = (int)item["Pays"],
                Telephone = item["Telephone"].ToString(),
                Login = item["Login"].ToString(),
                Password = item["Password"].ToString(),
            };
            return memb;
        }

        #endregion

        #region Function

        public static Membre AuthentifieMoi(string txtlogin, string txtpass)
        {
            List<Dictionary<string, object>> infoMembre = GestionConnexion.Instance.getData("Select * from Membre where Login='" + txtlogin + "' and Password='" + txtpass + "'");
            Membre retour = null;
            if (infoMembre.Count > 0)
            {
                int idMembre = (int)infoMembre[0]["idMembre"];
                retour = Membre.getUnMembre(idMembre);
            }
            return retour;
        }

        #endregion
    }
}
