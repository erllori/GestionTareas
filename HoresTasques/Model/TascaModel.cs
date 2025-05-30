using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoresTasques.Model
{
    internal class TascaModel
    {
        public string Titol { get; set; }
        public double Hores { get; set; }
        public DateTime DataInici { get; set; }
        public string Desc { get; set; }
        public bool Finalitzada { get; set; }

        public TascaModel(string titol, DateTime dataInici, double hores, bool finalitzada)
        {
            Titol = titol;
            Hores = hores;
            DataInici = dataInici;
            Desc = String.Empty;
            Finalitzada = finalitzada;
        }

        public TascaModel(string titol, double hores, DateTime dataInici, string desc, bool finalitzada)
        {
            Titol = titol;
            Hores = hores;
            DataInici = dataInici;
            Desc = desc;
            Finalitzada = finalitzada;
        }
    }
}
