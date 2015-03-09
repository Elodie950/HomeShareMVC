using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeShare.DAL
{
    public class MembreBienEchange
    {
        #region Fields
        private int _idMembre;
        private int _idBien;
        private DateTime _dateDebEchange;
        private DateTime _dateFinEchange;
        private bool? _assurance;
        private bool _valide;
        #endregion

        #region Properties
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
        public DateTime DateDebEchange
        {
            get { return _dateDebEchange; }
            set { _dateDebEchange = value; }
        }
        public DateTime DateFinEchange
        {
            get { return _dateFinEchange; }
            set { _dateFinEchange = value; }
        }
        public bool? Assurance
        {
            get { return _assurance; }
            set { _assurance = value; }
        }
        public bool Valide
        {
            get { return _valide; }
            set { _valide = value; }
        }

        #endregion
    }
}
