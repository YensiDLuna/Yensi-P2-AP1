using System;
using System.Collections.Generic;
using System.Linq;
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

namespace Yensi_P2_AP1.UI.Registro
{
    /// <summary>
    /// Interaction logic for Registro_de_Proyectos.xaml
    /// </summary>
    public partial class Registro_de_Proyectos : Window
    {
        int Tiempo;
        Proyecto proyecto;
        public Registro_de_Proyectos()
        {
            InitializeComponent();
            proyecto = new Proyecto();
          DataContext = proyecto;

          //  DetallesDataGrid.ItemsSource = new List<ProyectoDetalle>();
        }
        public bool Existe()
        {
            var orden = ProyectoBLL.Buscar(Convert.ToInt32(ProyectoIdTextBox.Text));

            return proyecto != null;
        }

        private void Actualizar()
        {
            this.DataContext = null;
           
            
            FechaDatePicker.SelectedDate = proyecto.Fecha.Date;
             DetallesDataGrid.ItemsSource = proyecto.ProyectoDetalles;
        }


        private void Limpiar()
        {
            this.proyecto = new Proyecto();
            this.DataContext = this.proyecto;

            DetallesDataGrid.ItemsSource = new List<ProyectoDetalle>();
            Actualizar();
        }

        public void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            bool guardado = false;

            proyecto.Fecha = Convert.ToDateTime(FechaDatePicker.SelectedDate.ToString());
            

            if (string.IsNullOrWhiteSpace(ProyectoIdTextBox.Text) || ProyectoIdTextBox.Text == "0")
                guardado = ProyectoBLL.Guardar(proyecto);
            else
            {
                if (!Existe())
                {
                    MessageBox.Show("No se pudede modificar", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                guardado = ProyectoBLL.Modificar(proyecto);
            }

            if (guardado)
            {
                Limpiar();
                MessageBox.Show("Exito.", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("No se puede guardar.", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);

            }
        }

        public void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            Proyecto anterior = ProyectoBLL.Buscar(Convert.ToInt32(ProyectoIdTextBox.Text));

            if (anterior != null)
            {
                proyecto = anterior;
                Actualizar();
                MessageBox.Show("Exito!!");
            }
            else
            {
                MessageBox.Show("No existe.");
            }
        }
        public void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            if (ProyectoBLL.Eliminar(Convert.ToInt32(ProyectoIdTextBox.Text)))
            {
                MessageBox.Show("Exito.", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
                Limpiar();
            }
            else
            {
                MessageBox.Show(" No se pudo eliminar.", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void NuevoButton_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }

        private void AgregarButton_Click(object sender, RoutedEventArgs e)
        {
            this.proyecto.ProyectoDetalles.Add(new ProyectoDetalle(proyecto.ProyectoID, Convert.ToInt32(TipoIdComboBox.SelectedValue) + 1, RequerimientoTextBox.Text, Convert.ToInt32(TiempoTextBox.Text)));

           
 

            Actualizar();

         
        }

        private void RemoverButton_Click(object sender, RoutedEventArgs e)
        {
            proyecto.ProyectoDetalles.RemoveAt(DetallesDataGrid.FrozenColumnCount);
          
            Actualizar();
        }

    }

}
