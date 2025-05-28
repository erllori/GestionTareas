using HoresTasques.Model;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HoresTasques
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ObservableCollection<clsTasca> tasques;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnAfegir_Click(object sender, RoutedEventArgs e)
        {
            clsTasca novaTasca = new clsTasca();
            TascaWindow frm = new TascaWindow(novaTasca);
            frm.EsNova = true;

            if (frm.ShowDialog() == true)
            {
                tasques.Add(novaTasca);
                Utils.GuardarTasques(tasques.ToList(), CSVFilePath);
            }
        }

        private void LlistaOrdenada_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (LlistaOrdenada.SelectedItem is clsTasca tascaSeleccionada)
            {
                TascaWindow frm = new TascaWindow(tascaSeleccionada);
                frm.EsNova = false;
                frm.ShowDialog();

                if (tascaSeleccionada.Eliminada)
                {
                    tasques.Remove(tascaSeleccionada);
                    Utils.GuardarTasques(tasques.ToList(), CSVFilePath);
                }
                else
                {
                    var sortedList = tasques.OrderBy(t => t.Data)
                                    .ThenBy(t => !t.Finalitzada)
                                    .ThenBy(t => t.Nom)
                                    .ToList();
                    tasques.Clear();
                    foreach (var item in sortedList)
                    {
                        tasques.Add(item);
                    }

                    Utils.GuardarTasques(tasques.ToList(), CSVFilePath);
                }
            }
        }
    }
}