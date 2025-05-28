using HoresTasques.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoresTasques.Services
{
    internal class TascaService
    {
        private const string CSVFilePath = "Dades/Tasques.csv"; // Path to the CSV file

        public static List<clsTasca> CarregarTasques()
        {
            List<clsTasca> tasques = new List<clsTasca>();

            using (StreamReader reader = new StreamReader(CSVFilePath))
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

            return tasques.Where(t => !t.Eliminada).ToList();
        }
    }
}
