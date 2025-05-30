using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace HoresTasques.ViewModel
{
    internal class TascaViewModel : BaseViewModel
    {
        #region Properties
        private string _nom;
        private double _hores;
        private DateTime _dataInici;
        private string _desc;
        private bool _finalitzada;
        public string Nom
        {
            get => _nom;
            set => OnPropertyChanged(nameof(Nom));
        }
        public double Hores
        {
            get => _hores;
            set => OnPropertyChanged(nameof(Hores));
        }
        public DateTime DataInici
        {
            get => _dataInici;
            set => OnPropertyChanged(nameof(DataInici));
        }
        public string Desc
        {
            get => _desc;
            set => OnPropertyChanged(nameof(Desc));
        }
        public bool Finalitzada
        {
            get => _finalitzada;
            set => OnPropertyChanged(nameof(Finalitzada));
        }
        #endregion

        #region Commands
        public ICommand GuardarTascaCommand { get; }
        public ICommand CancelarTascaCommand { get; }
        public ICommand EliminarTascaCommand { get; }
        #endregion

        #region Constructor
        public TascaViewModel()
        {

        }
        #endregion
    }
}
