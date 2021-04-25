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

namespace AhorcadoWPF
{
    /// <summary>
    /// Lógica de interacción para PantallaAñadir.xaml
    /// </summary>
    public partial class PantallaAñadir : Window
    {
        Palabras palabras;

        int idTema;
        public PantallaAñadir()
        {
            InitializeComponent();

            Palabras.CargarCBoxTema(cbTema);
        }

        private void Añadir(object sender, RoutedEventArgs e)
        {
            bool todoOk = true;

            //TODO Comprobar
            if (cbTema.SelectedItem == null)
            {

                MessageBox.Show("Debes seleccionar una temática");
                todoOk = false;

            }
            else
            {

                idTema = Palabras.ObtenerIdTema(cbTema.SelectedItem.ToString());

            }

            if (txtPalabra.Text == "")
            {

                MessageBox.Show("Debes escribir una palabra");
                txtPalabra.Focus();
                todoOk = false;

            }
            else if (txtDescripcion.Text == "")
            {

                MessageBox.Show("El texto debe tener una descripción");
                txtDescripcion.Focus();
                todoOk = false;
            }

            if (todoOk)
            {

                palabras = new Palabras(txtPalabra.Text, txtDescripcion.Text, idTema);

                palabras.InsertarPalabra(); 

            }

        }

        private void btnAtras_Click(object sender, RoutedEventArgs e)
        {
            PantallaInicio pi = new PantallaInicio();
            pi.Show();
            this.Close();

        }
    }
}
