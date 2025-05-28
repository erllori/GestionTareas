using HoresTasques.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoresTasques.Utils
{
    public static class Utils
    {
        public static List<clsTasca> CarregarTasquesCSV(string rutaFitxer)
        {
            List<clsTasca> tasques = new List<clsTasca>();

            using (StreamReader reader = new StreamReader(rutaFitxer))
            {
                string? linia;
                bool primeraLinia = true;

                while ((linia = reader.ReadLine()) != null)
                {
                    if (primeraLinia)
                    {
                        primeraLinia = false;
                        continue;
                    }

                    string[] camps = linia.Split(',');

                    if (camps.Length >= 4)
                    {
                        clsTasca tasca = new clsTasca
                        {
                            Nom = camps[0].Trim(),
                            Hores = double.TryParse(camps[1], out double hores) ? hores : 0,
                            Finalitzada = bool.TryParse(camps[2], out bool finalitzada) ? finalitzada : false,
                            Data = DateTime.TryParse(camps[3], out DateTime data) ? data : DateTime.MinValue
                        };

                        tasques.Add(tasca);
                    }
                }
            }

            return tasques;
        }

        public static void GuardarTasques(List<clsTasca> tasques, string rutaFitxer)
        {
            using (StreamWriter writer = new StreamWriter(rutaFitxer, false, Encoding.UTF8))
            {
                // Escrivim la capçalera
                writer.WriteLine("Nom,Hores,Finalitzada,Data");
                foreach (var tasca in tasques)
                {
                    string linia = $"{tasca.Nom},{tasca.Hores},{tasca.Finalitzada},{tasca.Data:yyyy-MM-dd}";
                    writer.WriteLine(linia);
                }
            }
        }
    }
}
