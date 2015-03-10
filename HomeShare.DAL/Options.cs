using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeShare.DAL
{
    public class Options
    {
        #region Fields
        private int _idOption;
        private string _libelle;
        private List<BienEchange> _lesBiens;
        #endregion
        #region Properties
        public int IdOption
        {
            get { return _idOption; }
            set { _idOption = value; }
        }
        public string Libelle
        {
            get { return _libelle; }
            set { _libelle = value; }
        }
        public List<BienEchange> LesBiens
        {
            get
            {
                if (_lesBiens == null)
                {
                    _lesBiens = ChargerLesBiens();
                }
                return _lesBiens;
            }
        }
        #endregion

        #region Method

        private List<BienEchange> ChargerLesBiens()
        {
            string query = @"select BienEchange.idBien, BienEchange.titre, BienEchange.DescCourte, BienEchange.DescLong, BienEchange.NombrePerson, BienEchange.Pays, BienEchange.Ville, BienEchange.Rue, BienEchange.Numero, BienEchange.CodePostal, BienEchange.Photo, BienEchange.AssuranceObligatoire, BienEchange.IsEnabled, BienEchange.DisabledDate, BienEchange.Latitude, BienEchange.Longitude, BienEchange.idMembre, BienEchange.DateCreation 
                            from BienEchange 
                            join OptionsBien 
                            on OptionsBien.idBien = BienEchange.idBien 
                            where OptionsBien.idOption= 2" + this.IdOption;
            List<BienEchange> retour = new List<BienEchange>();
            List<Dictionary<string, object>> mesBiens = GestionConnexion.Instance.getData(query);

            foreach (Dictionary<string, object> item in mesBiens)
            {
                BienEchange monBien = new BienEchange();
                monBien.IdBien = (int)item["idBien"];
                monBien.Titre = item["titre"].ToString();
                monBien.DescCourte = item["DescCourte"].ToString();
                monBien.DescLong = item["DescLong"].ToString();
                monBien.NombrePerson = (int)item["NombrePerson"];
                monBien.Pays = (int)item["Pays"];
                monBien.Ville = item["Ville"].ToString();
                monBien.Rue = item["Rue"].ToString();
                monBien.Numero = item["Numero"].ToString();
                monBien.CodePostal = item["CodePostal"].ToString();
                monBien.Photo = item["Photo"].ToString();
                monBien.AssuranceObligatoire = (bool)item["AssuranceObligatoire"];
                monBien.IsEnabled = (bool)item["isEnabled"];
                if (item["DisabledDate"].ToString() != "") monBien.DisabledDate = (DateTime)item["DisabledDate"];
                monBien.Latitude = item["Latitude"].ToString();
                monBien.Longitude = item["Longitude"].ToString();
                monBien.IdMembre = (int)item["idMembre"];
                monBien.DateCreation = (DateTime)item["DateCreation"];

                retour.Add(monBien);
            }
            return retour;
        }

        public static List<Options> getAllOptions()
        {
            List<Dictionary<string, object>> allOptions = GestionConnexion.Instance.getData("select * from Options");
            List<Options> mesOptions = new List<Options>();
            foreach (Dictionary<string, object> item in allOptions)
            {
                Options op = associe(item);
                mesOptions.Add(op);
            }
            return mesOptions;
        }

        public static Options getUneOption(int id)
        {
            List<Dictionary<string, object>> allOptions = GestionConnexion.Instance.getData("select * from Options where idOption="+id);
            Options op = associe(allOptions[0]);
            return op;
        }
        private static Options associe(Dictionary<string, object> item)
        {
            Options op = new Options()
            {
                IdOption = (int)item["idOption"],
                Libelle = item["Libelle"].ToString(),
            };
            return op;
        }
        #endregion
    }
}
