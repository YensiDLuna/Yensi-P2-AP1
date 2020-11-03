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
 
        Proyecto proyecto;
        public Registro_de_Proyectos()
        {
            InitializeComponent();
            proyecto = new Proyecto();
          DataContext = proyecto;
            TipoIdComboBox.ItemsSource = TipoBLL.GetList();
            TipoIdComboBox.SelectedValuePath = "TipoID";
            TipoIdComboBox.DisplayMemberPath = "tipo";

            //  DetallesDataGrid.ItemsSource = new List<ProyectoDetalle>();
        }
        public bool Existe()
        {
            var proyecto = ProyectoBLL.Buscar(Convert.ToInt32(ProyectoIdTextBox.Text));

            return proyecto != null;
        }

       

        private void Limpiar()
        {
            this.proyecto = new Proyecto();
            this.DataContext = this.proyecto;

            DetallesDataGrid.ItemsSource = new List<ProyectoDetalle>();
           
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
                this.proyecto = anterior;
                this.DataContext = null;
                this.DataContext = proyecto;

                MessageBox.Show("Exito!!");
            }
            else
            {
                MessageBox.Show("No existe.");
            }
        }
        public void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            Proyecto existe = ProyectoBLL.Buscar(this.proyecto.ProyectoID);

            if (existe == null)
            {
                MessageBox.Show("Proyecto no encontrado", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            else
            {
                ProyectoBLL.Eliminar(this.proyecto.ProyectoID);
                MessageBox.Show("Eliminado", "Exito",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                Limpiar();
            }
        }
        private void NuevoButton_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }

        private void AgregarButton_Click(object sender, RoutedEventArgs e)
        {
            proyecto.Tiempo += Convert.ToInt32(TiempoTextBox.Text);
            proyecto.ProyectoDetalles.Add(new ProyectoDetalle(Utilidades.ToInt(TipoIdComboBox.SelectedValue.ToString()), proyecto.ProyectoID, RequerimientoTextBox.Text, Convert.ToInt32(TiempoTextBox.Text)));
            this.DataContext = null;
            this.DataContext = proyecto;
           

         
        }
        private void TiempoTextBox_TextChanged(object sender, RoutedEventArgs e)
        {
            try
            {
                if (TiempoTextBox.Text.Any(char.IsLetter))
                {
                    TiempoTextBox.BorderBrush = new SolidColorBrush(Colors.Red);
                    MessageBox.Show("En el tiempo solo debe ingresar numeros", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    TiempoTextBox.BorderBrush = new SolidColorBrush(Colors.Yellow);
                }
            }
            catch
            {
                TiempoTextBox.Foreground = SystemColors.ControlTextBrush;
            }
        }

        private void RemoverButton_Click(object sender, RoutedEventArgs e)
        {

            if (DetallesDataGrid.Items.Count >= 1 && DetallesDataGrid.SelectedIndex <= DetallesDataGrid.Items.Count - 1)
            {
                ProyectoDetalle project = (ProyectoDetalle)DetallesDataGrid.SelectedValue;
                
                proyecto.ProyectoDetalles.RemoveAt(DetallesDataGrid.SelectedIndex);
                this.DataContext = null;
                this.DataContext = proyecto;
            }


        }

    }

}
