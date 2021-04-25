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

namespace AhorcadoWPF
{
    /// <summary>
    /// Lógica de interacción para NombreJugador.xaml
    /// </summary>
    public partial class NombreJugador : UserControl
    {
        Jugador jugador;

        StackPanel panelCentral;

        GroupBox gbJugador;

        Temporizador tiempo;

        Grid pantalla;

        bool existe;
        public NombreJugador(Jugador jugador, StackPanel panelCentral, GroupBox gbJugador, Temporizador tiempo, Grid pantalla)
        {

            InitializeComponent();

            this.jugador = jugador;

            this.panelCentral = panelCentral;

            this.gbJugador = gbJugador;

            this.tiempo = tiempo;

            this.pantalla = pantalla;

        }

        private void Aceptar(object sender, RoutedEventArgs e)
        {

            try
            {

                jugador.Nombre = txtNombre.Text;

                existe = jugador.ComprobarExistencia();

                if (!existe)
                {

                    jugador.InsertarJugador();
                    panelCentral.Children.Clear();
                    gbJugador.Header = "JUGADOR: " + jugador.Nombre;
                    pantalla.Opacity = 1;
                    tiempo.Start();
                }
                else
                {

                    MessageBoxResult result = MessageBox.Show("¿Eres " + jugador.Nombre + "?\n" +
                        "Si no es así, introduce otro nombre", "El jugador ya existe", MessageBoxButton.YesNo, MessageBoxImage.Information);

                    if (result == MessageBoxResult.Yes)
                    {

                        panelCentral.Children.Clear();
                        gbJugador.Header = "JUGADOR: " + jugador.Nombre;
                        pantalla.Opacity = 1;
                        tiempo.Start();


                    }

                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);

            }

            

        }
    }
}
