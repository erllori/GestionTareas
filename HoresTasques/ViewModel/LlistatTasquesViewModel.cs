using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace HoresTasques.ViewModel
{
    internal class LlistatTasquesViewModel : BaseViewModel
    {
        #region Properties
        private readonly ObservableCollection<TascaViewModel> _tasques;
        public IEnumerable<TascaViewModel> Tasques => _tasques;
        #endregion

        #region Commands
        public ICommand AfegirTascaCommand { get; }
        #endregion

        #region Constructor
        public LlistatTasquesViewModel()
        {
            _tasques = new ObservableCollection<TascaViewModel>();
        }
        #endregion
    }
}
