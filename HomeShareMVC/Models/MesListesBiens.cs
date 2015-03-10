using HomeShare.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HomeShareMVC.Models
{
    public class MesListesBiens
    {
        private List<BienEchange> _meilleursBiens;
        private List<BienEchange> _derniersBiens;

        public List<BienEchange> MeilleursBiens
        {
            get { return _meilleursBiens; }
            set { _meilleursBiens = value; }
        }

        public List<BienEchange> DerniersBiens
        {
            get { return _derniersBiens; }
            set { _derniersBiens = value; }
        }
    }
}