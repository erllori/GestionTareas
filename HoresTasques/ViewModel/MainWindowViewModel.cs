using HoresTasques.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace HoresTasques.ViewModel
{
    internal class MainWindowViewModel : BaseViewModel
    {
        #region Commands
        public ICommand LlistaTasquesCommand { get; }
        #endregion
        #region Constructor
        public MainWindowViewModel()
        {
            LlistaTasquesCommand = new LlistaTasquesCommand();
        }
        #endregion
    }
}
