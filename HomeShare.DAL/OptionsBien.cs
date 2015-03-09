using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeShare.DAL
{
    public class OptionsBien
    {
        #region Fields
        private int _idOption;
        private int _idBien;
        private string _valeur;
        #endregion

        #region Properties
        public int IdOption
        {
            get { return _idOption; }
            set { _idOption = value; }
        }
        public int IdBien
        {
            get { return _idBien; }
            set { _idBien = value; }
        }
        public string Valeur
        {
            get { return _valeur; }
            set { _valeur = value; }
        }
        #endregion

        #region Method
        #endregion
    }
}
