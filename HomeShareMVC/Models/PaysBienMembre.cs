using HomeShare.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HomeShareMVC.Models
{
    public class PaysBienMembre
    {
        private BienEchange _unBien;
        private Pays _unPays;
        private Membre _unMembre;

        public BienEchange UnBien
        {
            get { return _unBien; }
            set { _unBien = value; }
        }
        public Pays UnPays
        {
            get { return _unPays; }
            set { _unPays = value; }
        }
        public Membre UnMembre
        {
            get { return _unMembre; }
            set { _unMembre = value; }
        }
    }
}