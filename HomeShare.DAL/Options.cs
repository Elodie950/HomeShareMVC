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
        #endregion

        #region Method
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
