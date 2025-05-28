using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoresTasques.Model
{
    public class clsTasca : INotifyPropertyChanged, ICloneable
    {
        private string nom;
        private double hores;
        private DateTime? data;
        private bool finalitzada;
        private bool eliminada;

        public string Nom
        {
            get => nom;
            set { nom = value; OnPropertyChanged(nameof(Nom)); }
        }

        public double Hores
        {
            get => hores;
            set { hores = value; OnPropertyChanged(nameof(Hores)); }
        }

        public DateTime? Data
        {
            get => data;
            set { data = value; OnPropertyChanged(nameof(Data)); }
        }

        public bool Finalitzada
        {
            get => finalitzada;
            set { finalitzada = value; OnPropertyChanged(nameof(Finalitzada)); }
        }

        public bool Eliminada
        {
            get => eliminada;
            set { eliminada = value; OnPropertyChanged(nameof(Eliminada)); }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        public object Clone()
        {
            return new clsTasca
            {
                Nom = Nom,
                Hores = Hores,
                Data = Data,
                Finalitzada = Finalitzada
            };
        }
        public override string ToString()
        {
            return $"{Nom} - {Hores} hores - {Data?.ToShortDateString()} - {(Finalitzada ? "Finalitzada" : "Pendent")}";
        }
    }
}
