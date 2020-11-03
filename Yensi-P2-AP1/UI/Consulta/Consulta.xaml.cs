using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Yensi_P2_AP1.BLL;
using Yensi_P2_AP1.Entidades;

namespace Yensi_P2_AP1.UI.Consulta
{
    /// <summary>
    /// Interaction logic for Consulta.xaml
    /// </summary>
    public partial class Consulta : Window
    {
        public Consulta()
        {
            InitializeComponent();
        }
        private void BuscarBoton_Click(object sender, RoutedEventArgs e)
        {
            var lista = new List<Proyecto>();

            if (CriterioTextBox.Text.Trim().Length > 0)
            {
                switch (FiltroComboBox.SelectedIndex)
                {
                    case 0:
                        lista = ProyectoBLL.GetList(p => p.Tiempo == Convert.ToInt32(CriterioTextBox.Text));
                        break;

                    case 1:
                        lista = ProyectoBLL.GetList(p => p.ProyectoID == Convert.ToInt32(CriterioTextBox.Text));
                        break;
                    case 2:
                        lista = ProyectoBLL.GetList(p => p.Descripcion == CriterioTextBox.Text);
                        break;
                }
            }
            else
            {
                lista = ProyectoBLL.GetList(c => true);
            }
            if (lista == null)
            {
                MessageBox.Show("Proyecto no encontrado", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            DatosDataGrid.ItemsSource = null;
            DatosDataGrid.ItemsSource = lista;
        }
    }
}
