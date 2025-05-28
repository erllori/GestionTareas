using HoresTasques.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace HoresTasques
{
    /// <summary>
    /// Lógica de interacción para TascaWindow.xaml
    /// </summary>
    public partial class TascaWindow : Window
    {
        public bool EsNova { get; set; } = false;
        clsTasca? tasca = null;
        clsTasca? tascaOriginal = null;

        public TascaWindow(clsTasca? tasca)
        {
            InitializeComponent();

            this.tasca = tasca;

            if (tasca != null)
            {
                this.tascaOriginal = (clsTasca)tasca.Clone();
            }

            this.DataContext = tasca;

        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            if (tasca != null)
            {
                try
                {
                    // Validació bàsica
                    tasca.Nom = tbNom.Text;
                    tasca.Hores = double.Parse(tbHores.Text);
                    tasca.Data = dpData.SelectedDate ?? DateTime.Now;
                    tasca.Finalitzada = chkFinalitzada.IsChecked ?? false;

                    // Aquí podries retornar la tasca o fer alguna acció
                    DialogResult = true;
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }


        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            // Revert changes if editing an existing task
            if (tasca != null && tascaOriginal != null)
            {
                tasca.Nom = tascaOriginal.Nom;
                tasca.Hores = tascaOriginal.Hores;
                tasca.Data = tascaOriginal.Data;
                tasca.Finalitzada = tascaOriginal.Finalitzada;
            }
            // Set DialogResult to false to indicate cancellation
            DialogResult = false;
            this.Close();
        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            if (tasca != null && !this.EsNova)
            {
                // Ask for confirmation before deleting
                MessageBoxResult result = MessageBox.Show($"Are you sure you want to delete the task '{tasca.Nom}'?", "Confirm Deletion", MessageBoxButton.YesNo, MessageBoxImage.Warning);

                if (result == MessageBoxResult.Yes)
                {
                    tasca.Eliminada = true;
                    DialogResult = false; // Set DialogResult to false, but MainWindow will check 'Eliminat'
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("No task selected for deletion.", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
