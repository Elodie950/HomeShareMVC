using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeShare.DAL
{
    public class AvisMembreBien
    {
        #region Fields
        private int _idAvis;
        private int _note;
        private string _message;
        private int _idMembre;
        private int _idBien;
        private DateTime _dateAvis;
        private bool _approuve;
        #endregion

        #region Properties
        public int IdAvis
        {
            get { return _idAvis; }
            set { _idAvis = value; }
        }
        public int Note
        {
            get { return _note; }
            set { _note = value; }
        }
        public string Message
        {
            get { return _message; }
            set { _message = value; }
        }
        public int IdMembre
        {
            get { return _idMembre; }
            set { _idMembre = value; }
        }
        public int IdBien
        {
            get { return _idBien; }
            set { _idBien = value; }
        }
        public DateTime DateAvis
        {
            get { return _dateAvis; }
            set { _dateAvis = value; }
        }
        public bool Approuve
        {
            get { return _approuve; }
            set { _approuve = value; }
        }
        #endregion

        #region function

        public virtual bool InsererAvis(string txtAvis, int noteAvis, int idMembre, int idBien)
        {
            DateTime d = DateTime.Now;
            bool approuv = false;

            string query = "insert into AvisMembreBien (note, message, idMembre, idBien, DateAvis, Approuve)values (@note, @message, @idMembre, @idBien, @DateAvis, @Approuve) ";

            Dictionary<string, object> valeurs = new Dictionary<string, object>();
            valeurs.Add("note", noteAvis);
            valeurs.Add("message", txtAvis);
            valeurs.Add("idMembre", idMembre);
            valeurs.Add("idBien", idBien);
            valeurs.Add("DateAvis", d);
            valeurs.Add("Approuve", approuv);

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
