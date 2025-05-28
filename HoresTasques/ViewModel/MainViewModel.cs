using HoresTasques.Model;
using HoresTasques.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;

namespace HoresTasques.ViewModel
{
    internal class MainViewModel : BaseViewModel
    {
        public MainViewModel()
        {
            var llista = Services.TascaService.CarregarTasques()
                .OrderBy(t => t.Data)
                .ThenBy(t => !t.Finalitzada)
                .ThenBy(t => t.Nom);

            Tasques = new ObservableCollection<TascaViewModel>(llista.Select(t => new TascaViewModel(t)));
        }

        private ObservableCollection<TascaViewModel> _tasques;
        public ObservableCollection<TascaViewModel> Tasques
        {
            get => _tasques;
            set
            {
                _tasques = value;
                OnPropertyChanged(nameof(Tasques));
            }
        }

        public ICommand AfegirTascaCommand { get; }

        private void AfegirTasca()
        {
            clsTasca novaTasca = new clsTasca();
            var tascaVM = new TascaViewModel(novaTasca);
            var tascaWindow = new TascaWindow();
            tascaWindow.DataContext = tascaVM;

            if (tascaWindow.ShowDialog() == true)
            {
                Tareas.Add(novaTasca);
                _tascaService.GuardarTareas(Tareas.ToList());
            }
        }
    }
}
