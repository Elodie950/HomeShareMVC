using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeShare.DAL
{
    public class Pays
    {
        #region Fields
        private int _idPays;
        private string _libelle;
        #endregion

        #region Properties
        public int IdPays {
            get { return _idPays; }
            set { _idPays = value; }
        }

        public string Libelle {
            get { return _libelle; }
            set { _libelle = value; }
        }
        #endregion 

        #region Method
        public static List<Pays> getAllPays() 
        {
            List<Dictionary<string, Object>> mesPays = GestionConnexion.Instance.getData("select * from Pays");
            List<Pays> lesPays = new List<Pays>();
            foreach (Dictionary<string, object> item in mesPays)
            {
                Pays p = associe(item);
                lesPays.Add(p);
            }
            return lesPays;
        }

        public static Pays getUnPays(int id)
        {
            List<Dictionary<string, object>> lesPays = GestionConnexion.Instance.getData("select * from Pays where idPays=" + id);
            Pays pay = associe(lesPays[0]);
            return pay;
        }

        private static Pays associe(Dictionary<string,object> item)
        {
            Pays p = new Pays()
            {
                IdPays = (int)item["idPays"],
                Libelle = item["Libelle"].ToString(),
            };
            return p;
        }


        #endregion
    }
}
