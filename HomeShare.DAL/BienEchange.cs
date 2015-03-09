using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeShare.DAL
{
    public class BienEchange
    {
        #region Fields
        private int _idBien;
        private string _titre;
        private string _descCourte;
        private string _descLong;
        private int _nombrePerson;
        private int _pays;
        private string _ville;
        private string _rue;
        private string _numero;
        private string _codePostal;
        private string _photo;
        private bool _assuranceObligatoire;
        private bool _isEnabled;
        private DateTime? _disabledDate;
        private string _latitude;
        private string _longitude;
        private int _idMembre;
        private DateTime _dateCreation;
        #endregion

        #region Properties
        public int IdBien 
        {
            get{return _idBien;}
            set{_idBien = value;}
        }
        public string Titre
        {
            get{return _titre;}
            set{ _titre= value;}
        }
        public string DescCourte 
        {
            get{return _descCourte;}
            set{ _descCourte = value;}
        }
        public string DescLong 
        {
            get{return _descLong;}
            set{ _descLong = value;}
        }
        public int NombrePerson
        {
            get{return _nombrePerson ;}
            set{ _nombrePerson = value;}
        }
        public int Pays 
        {
            get{return _pays;}
            set{ _pays = value;}
        }
        public string Ville 
        {
            get{return _ville;}
            set{ _ville = value;}
        }
        public string Rue 
        {
            get{return _rue;}
            set{ _rue = value;}
        }
        public string Numero 
        {
            get{return _numero;}
            set{ _numero = value;}
        }
        public string CodePostal 
        {
            get{return _codePostal ;}
            set{ _codePostal = value;}
        }
        public string Photo 
        {
            get{return _photo ;}
            set{ _photo = value;}
        }
        public bool AssuranceObligatoire 
        {
            get{return _assuranceObligatoire;}
            set{ _assuranceObligatoire = value;}
        }
        public bool IsEnabled 
        {
            get{return _isEnabled;}
            set{ _isEnabled = value;}
        }
        public DateTime? DisabledDate 
        {
            get{return _disabledDate;}
            set{ _disabledDate = value;}
        }
        public string Latitude 
        {
            get{return _latitude;}
            set{ _latitude = value;}
        }
        public string Longitude 
        {
            get{return _longitude;}
            set{ _longitude = value;}
        }
        public int IdMembre 
        {
            get{return _idMembre;}
            set{ _idMembre= value;}
        }
        public DateTime DateCreation 
        {
            get{return _dateCreation;}
            set{ _dateCreation = value;}
        }
        #endregion

        #region Method
        public static List<BienEchange> getAllBienEchange() 
        {
            List<Dictionary<string, object>> allBien = GestionConnexion.Instance.getData("select * from BienEchange");
            List<BienEchange> mesBien = new List<BienEchange>();
            foreach (Dictionary<string, object> item in allBien) 
            {
                BienEchange be = associe(item);
                mesBien.Add(be);
            }
            return mesBien;
        }



        public static BienEchange getUnBienEchange(int id)
        {
            List<Dictionary<string, object>> allBien = GestionConnexion.Instance.getData("select * from BienEchange where idBien=" + id);
            BienEchange be = associe(allBien[0]);
            return be;
        }

        private static BienEchange associe(Dictionary<string, object> item)
        {
            BienEchange be = new BienEchange();

                be.IdBien = (int)item["idBien"];
                be.Titre = item["titre"].ToString();
                be.DescCourte = item["DescCourte"].ToString();
                be.DescLong = item["DescLong"].ToString();
                be.NombrePerson = (int)item["NombrePerson"];
                be.Pays = (int)item["Pays"];
                be.Ville = item["Ville"].ToString();
                be.Rue = item["Rue"].ToString();
                be.Numero = item["Numero"].ToString();
                be.CodePostal = item["CodePostal"].ToString();
                be.Photo = item["Photo"].ToString();
                be.AssuranceObligatoire = (bool)item["AssuranceObligatoire"];
                be.IsEnabled = (bool)item["isEnabled"];
                if (item["DisabledDate"].ToString() != "") be.DisabledDate = (DateTime)item["DisabledDate"];
                be.Latitude = item["Latitude"].ToString();
                be.Longitude = item["Longitude"].ToString();
                be.IdMembre = (int)item["idMembre"];
                be.DateCreation = (DateTime)item["DateCreation"];

            
            return be;
        }
        #endregion

        #region Fonctions

        public virtual bool InsererBien(string titre, string descCourte, string descLong, int nombrePerson, int pays, string ville, string rue, string numero, string codePostal, string photo, string assuranceObligatoire, string latitude, string longitude, int idMembre)
        {
            bool isEnabled = true;
            DateTime dateCreation = DateTime.Now;

            string query = "insert into BienEchange (idBien, titre, descCourte, descLong, nombrePerson, pays, ville, rue, numero, codePostal, photo, assuranceObligatoire, isEnabled, disableDate, latitude, longitude, idMembre, dateCreation)values (@idBien, @titre, @descCourte, @descLong, @nombrePerson, @pays, @ville, @rue, @numero, @codePostal, @photo, @assuranceObligatoire, @isEnabled, @disableDate, @latitude, @longitude, @idMembre, @dateCreation) ";

             Dictionary<string, object> valeurs = new Dictionary<string,object>();
            valeurs.Add("titre", titre);
            valeurs.Add("descCourte", descCourte);
            valeurs.Add("descLong", descLong);
            valeurs.Add("nombrePerson", nombrePerson);
            valeurs.Add("pays", pays);
            valeurs.Add("ville", ville);
            valeurs.Add("rue", rue);
            valeurs.Add("numero", numero);
            valeurs.Add("codePostal", codePostal);
            valeurs.Add("photo", photo);
            valeurs.Add("assuranceObligatoire", assuranceObligatoire);
            valeurs.Add("isEnabled", isEnabled);
            valeurs.Add("disableDate", null);
            valeurs.Add("latitude", latitude);
            valeurs.Add("longitude", longitude);
            valeurs.Add("idMembre", idMembre);
            valeurs.Add("dateCreation",dateCreation);

              if (GestionConnexion.Instance.saveData(query, GenerateKey.APP, valeurs))
              {
                  return true;
              }
              else {
                  return false;
              }
        }


        public virtual bool ModifierBien()
        {
            BienEchange b = BienEchange.getUnBienEchange(this.IdBien);

            string query = @"update BienEchange 
                            set [Titre] = @Titre,
                                [DescCourte] = @DescCourte,
                                [DescLong] = @DescLong,
                                [NombrePerson] = @NombrePerson,
                                [Pays] = @Pays,
                                [Ville] =@Ville,
                                [Rue] = @Rue,
                                [Numero] = @Numero,
                                [CodePostal] = @CodePostal,
                                [Photo] =@Photo,
                                [AssuranceObligatoire] = @AssuranceObligatoire,
                                [IsEnabled] = @IsEnabled,
                                [DisableDate] = @DisableDate,
                                [Latitude] = @Latitude,
                                [Longitude] = @Longitude,
                                [IdMembre] = @IdMembre,
                                [DateCreation] = @DateCreation
                                where [idBien] = @idBien";

            Dictionary<string, object> valeurs = new Dictionary<string, object>();
            valeurs.Add("titre", this.Titre);
            valeurs.Add("descCourte", this.DescCourte);
            valeurs.Add("descLong", this.DescLong);
            valeurs.Add("nombrePerson", this.NombrePerson);
            valeurs.Add("pays", this.Pays);
            valeurs.Add("ville", this.Ville);
            valeurs.Add("rue", this.Rue);
            valeurs.Add("numero", this.Numero);
            valeurs.Add("codePostal", this.CodePostal);
            valeurs.Add("photo", this.Photo);
            valeurs.Add("assuranceObligatoire", this.AssuranceObligatoire);
            valeurs.Add("isEnabled", this.IsEnabled);
            valeurs.Add("disableDate", this.DisabledDate);
            valeurs.Add("latitude", this.Latitude);
            valeurs.Add("longitude", this.Longitude);
            valeurs.Add("idMembre", this.IdMembre);
            valeurs.Add("dateCreation", this.DateCreation);

            if (GestionConnexion.Instance.saveData(query, GenerateKey.APP, valeurs))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public virtual bool SupprimerBien(int id)
        {
            BienEchange b = BienEchange.getUnBienEchange(id);

            DateTime disableDate = DateTime.Now;

            string query = @"update BienEchange 
                            set [Titre] = @Titre,
                                [DescCourte] = @DescCourte,
                                [DescLong] = @DescLong,
                                [NombrePerson] = @NombrePerson,
                                [Pays] = @Pays,
                                [Ville] =@Ville,
                                [Rue] = @Rue,
                                [Numero] = @Numero,
                                [CodePostal] = @CodePostal,
                                [Photo] =@Photo,
                                [AssuranceObligatoire] = @AssuranceObligatoire,
                                [IsEnabled] = @IsEnabled,
                                [DisableDate] = @DisableDate,
                                [Latitude] = @Latitude,
                                [Longitude] = @Longitude,
                                [IdMembre] = @IdMembre,
                                [DateCreation] = @DateCreation
                                where [idBien] = @idBien";

            Dictionary<string, object> valeurs = new Dictionary<string, object>();
            valeurs.Add("titre", this.Titre);
            valeurs.Add("descCourte", this.DescCourte);
            valeurs.Add("descLong", this.DescLong);
            valeurs.Add("nombrePerson", this.NombrePerson);
            valeurs.Add("pays", this.Pays);
            valeurs.Add("ville", this.Ville);
            valeurs.Add("rue", this.Rue);
            valeurs.Add("numero", this.Numero);
            valeurs.Add("codePostal", this.CodePostal);
            valeurs.Add("photo", this.Photo);
            valeurs.Add("assuranceObligatoire", this.AssuranceObligatoire);
            valeurs.Add("isEnabled", false);
            valeurs.Add("disableDate", disableDate);
            valeurs.Add("latitude", this.Latitude);
            valeurs.Add("longitude", this.Longitude);
            valeurs.Add("idMembre", this.IdMembre);
            valeurs.Add("dateCreation", this.DateCreation);

            if (GestionConnexion.Instance.saveData(query, GenerateKey.APP, valeurs))
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        #endregion
    }
}
