using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoresTasques.Model
{
    internal class LlistatTasquesModel
    {
        public List<TascaModel> Tasques { get; set; } 

        public LlistatTasquesModel()
        {
            Tasques = new List<TascaModel>();
        }

        /// <summary>
        /// Retorna totes les tasques del llistat que no estan finalitzades.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<TascaModel> GetTasquesNoFinalitzades()
        {
            return Tasques.Where(t => !t.Finalitzada);
        }

        /// <summary>
        /// Retorna totes les tasques del llistat que estan finalitzades.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<TascaModel> GetTasquesFinalitzades()
        {
            return Tasques.Where(t => t.Finalitzada);
        }

        /// <summary>
        /// Afegir una tasca al llistat.
        /// </summary>
        /// <param name="tasca"></param>
        public void AfegirTasca(TascaModel tasca)
        {
            TascaModel? tascaExistent = Tasques.FirstOrDefault(t => t.Titol == tasca.Titol && !t.Finalitzada);

            if (tascaExistent != null)
            {
                tascaExistent.Hores += tasca.Hores;
                tascaExistent.Desc = tasca.Desc; // Actualitza altres si cal
                return;
            }
            Tasques.Add(tasca);
        }

        /// <summary>
        /// Finalitzar una tasca per títol.
        /// </summary>
        /// <param name="titol"></param>
        public void FinalitzarTasca(string titol)
        {
            TascaModel? tasca = Tasques.FirstOrDefault(t => t.Titol == titol && !t.Finalitzada);
            if (tasca != null)
            {
                tasca.Finalitzada = true;
            }
        }
    }
}
