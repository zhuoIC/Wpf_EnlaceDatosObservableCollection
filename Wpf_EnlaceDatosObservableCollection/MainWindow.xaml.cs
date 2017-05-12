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
using System.Windows.Navigation;
using System.Windows.Shapes;
//------------------------------
using NHJ.Wpf_DataContext_ClasePersonas;
namespace Wpf_EnlaceDatosObservableCollection
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ListaPersonas _listaPersonas = null;

        public MainWindow()
        {
            InitializeComponent();
            _listaPersonas = new ListaPersonas();
            // Pongo los datos a disposicion de la lista que los muestra
            //livNombres.DataContext = _listaPersonas;
            livNombres.ItemsSource = _listaPersonas;
        }

        private void btnAnadir_Click(object sender, RoutedEventArgs e)
        {
            // Añadir los datos de los textBox a la lista de personas
            try
            {
                if (tbxNombre.Text.Length != 0 || tbxapellidos.Text.Length != 0)
                {
                    _listaPersonas.Add(new Persona(tbxNombre.Text, tbxapellidos.Text, DateTime.Parse(tbxFechaNac.Text), double.Parse(tbxEstatura.Text)));
                    tbxNombre.Clear();
                    tbxapellidos.Clear();
                    tbxFechaNac.Clear();
                    tbxEstatura.Clear();
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Los datos no son correctos", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnBorrar_Click(object sender, RoutedEventArgs e)
        {
            //Borra el dato de la persona seleccionada
            if (livNombres.SelectedIndex != -1)
            {
                _listaPersonas.RemoveAt(livNombres.SelectedIndex);
            }
        }

        private void btnCambiarFeNac_Click(object sender, RoutedEventArgs e)
        {
            Persona unaPersona = livNombres.SelectedItem as Persona;
            if (unaPersona != null)
            {
                int posPersona = livNombres.SelectedIndex;
                unaPersona.FechaNacimiento = DateTime.Now;
                _listaPersonas.RemoveAt(posPersona);
                _listaPersonas.Insert(posPersona, unaPersona);
            }
        }
    }
}
