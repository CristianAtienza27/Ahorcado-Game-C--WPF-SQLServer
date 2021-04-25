using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        LogicaInterfaz interfaz;

        Jugador jugador1;

        Palabras palabra;

        Temporizador tiempo;

        int numTematica;

        bool fin;

        public MainWindow(int numTematica)
        {

            InitializeComponent();

            this.numTematica = numTematica;

            interfaz = new LogicaInterfaz();

            jugador1 = new Jugador();

            palabra = new Palabras(numTematica);

            tiempo = new Temporizador(lblTimer, Barra, btnPista);

            gridPantallaCompleta.Opacity = 0.5;

            panelCentral.Children.Add(new NombreJugador(jugador1, panelCentral, gbJugador, tiempo, gridPantallaCompleta));

        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {

            gbJugador.Header = jugador1.Nombre;

            interfaz.colocarCuadros(palabra.Nombre, PanelRespuesta);

            palabra.RefrescarCuadroRespuesta(PanelRespuesta);

        }

        private void Pulsar_A(object sender, RoutedEventArgs e)
        {
            palabra.RefrescarCuadroRespuesta(PanelRespuesta, "A", sender);
            btnA.IsEnabled = false;
            jugador1.comprobarAcierto(btnA.Background == Brushes.Green, txtFallos, txtPuntuacion, muñecoAhorcado);
            
            fin = interfaz.acabarPartida(jugador1, palabra.ListaPantallasLetra, palabra.Nombre);

            if (fin)
            {
                PantallaInicio pi = new PantallaInicio();
                pi.Show();
                this.Close();
            }
            
        }

        private void Pulsar_B(object sender, RoutedEventArgs e)
        {
            palabra.RefrescarCuadroRespuesta(PanelRespuesta, "B", sender);
            btnB.IsEnabled = false;
            jugador1.comprobarAcierto(btnB.Background == Brushes.Green, txtFallos, txtPuntuacion, muñecoAhorcado);

            fin = interfaz.acabarPartida(jugador1, palabra.ListaPantallasLetra, palabra.Nombre);

            if (fin)
            {
                PantallaInicio pi = new PantallaInicio();
                pi.Show();
                this.Close();
            }

        }

        private void Pulsar_C(object sender, RoutedEventArgs e)
        {
            palabra.RefrescarCuadroRespuesta(PanelRespuesta, "C", sender);
            btnC.IsEnabled = false;
            jugador1.comprobarAcierto(btnC.Background == Brushes.Green, txtFallos, txtPuntuacion, muñecoAhorcado);         

            fin = interfaz.acabarPartida(jugador1, palabra.ListaPantallasLetra, palabra.Nombre);

            if (fin)
            {
                PantallaInicio pi = new PantallaInicio();
                pi.Show();
                this.Close();
            }

        }

        private void Pulsar_D(object sender, RoutedEventArgs e)
        {
            palabra.RefrescarCuadroRespuesta(PanelRespuesta, "D", sender);
            btnD.IsEnabled = false;
            jugador1.comprobarAcierto(btnD.Background == Brushes.Green, txtFallos, txtPuntuacion, muñecoAhorcado);

            fin = interfaz.acabarPartida(jugador1, palabra.ListaPantallasLetra, palabra.Nombre);

            if (fin)
            {
                PantallaInicio pi = new PantallaInicio();
                pi.Show();
                this.Close();
            }

        }

        private void Pulsar_E(object sender, RoutedEventArgs e)
        {
            palabra.RefrescarCuadroRespuesta(PanelRespuesta, "E", sender);
            btnE.IsEnabled = false;
            jugador1.comprobarAcierto(btnE.Background == Brushes.Green, txtFallos, txtPuntuacion, muñecoAhorcado);

            fin = interfaz.acabarPartida(jugador1, palabra.ListaPantallasLetra, palabra.Nombre);

            if (fin)
            {
                PantallaInicio pi = new PantallaInicio();
                pi.Show();
                this.Close();
            }

        }

        private void Pulsar_F(object sender, RoutedEventArgs e)
        {
            palabra.RefrescarCuadroRespuesta(PanelRespuesta, "F", sender);
            btnF.IsEnabled = false;
            jugador1.comprobarAcierto(btnF.Background == Brushes.Green, txtFallos, txtPuntuacion, muñecoAhorcado);

            fin = interfaz.acabarPartida(jugador1, palabra.ListaPantallasLetra, palabra.Nombre);

            if (fin)
            {
                PantallaInicio pi = new PantallaInicio();
                pi.Show();
                this.Close();
            }

        }

        private void Pulsar_G(object sender, RoutedEventArgs e)
        {
            palabra.RefrescarCuadroRespuesta(PanelRespuesta, "G", sender);
            btnG.IsEnabled = false;
            jugador1.comprobarAcierto(btnG.Background == Brushes.Green, txtFallos, txtPuntuacion, muñecoAhorcado);

            fin = interfaz.acabarPartida(jugador1, palabra.ListaPantallasLetra, palabra.Nombre);

            if (fin)
            {
                PantallaInicio pi = new PantallaInicio();
                pi.Show();
                this.Close();
            }

        }

        private void Pulsar_H(object sender, RoutedEventArgs e)
        {
            palabra.RefrescarCuadroRespuesta(PanelRespuesta, "H", sender);
            btnH.IsEnabled = false;
            jugador1.comprobarAcierto(btnH.Background == Brushes.Green, txtFallos, txtPuntuacion, muñecoAhorcado);

            fin = interfaz.acabarPartida(jugador1, palabra.ListaPantallasLetra, palabra.Nombre);

            if (fin)
            {
                PantallaInicio pi = new PantallaInicio();
                pi.Show();
                this.Close();
            }

        }

        private void Pulsar_I(object sender, RoutedEventArgs e)
        {
            palabra.RefrescarCuadroRespuesta(PanelRespuesta, "I", sender);
            btnI.IsEnabled = false;
            jugador1.comprobarAcierto(btnI.Background == Brushes.Green, txtFallos, txtPuntuacion, muñecoAhorcado);

            fin = interfaz.acabarPartida(jugador1, palabra.ListaPantallasLetra, palabra.Nombre);

            if (fin)
            {
                PantallaInicio pi = new PantallaInicio();
                pi.Show();
                this.Close();
            }

        }

        private void Pulsar_J(object sender, RoutedEventArgs e)
        {
            palabra.RefrescarCuadroRespuesta(PanelRespuesta, "J", sender);
            btnJ.IsEnabled = false;
            jugador1.comprobarAcierto(btnJ.Background == Brushes.Green, txtFallos, txtPuntuacion, muñecoAhorcado);

            fin = interfaz.acabarPartida(jugador1, palabra.ListaPantallasLetra, palabra.Nombre);

            if (fin)
            {
                PantallaInicio pi = new PantallaInicio();
                pi.Show();
                this.Close();
            }

        }

        private void Pulsar_K(object sender, RoutedEventArgs e)
        {

            palabra.RefrescarCuadroRespuesta(PanelRespuesta, "K", sender);
            btnK.IsEnabled = false;
            jugador1.comprobarAcierto(btnK.Background == Brushes.Green, txtFallos, txtPuntuacion, muñecoAhorcado);

            fin = interfaz.acabarPartida(jugador1, palabra.ListaPantallasLetra, palabra.Nombre);

            if (fin)
            {
                PantallaInicio pi = new PantallaInicio();
                pi.Show();
                this.Close();
            }

        }

        private void Pulsar_L(object sender, RoutedEventArgs e)
        {
            palabra.RefrescarCuadroRespuesta(PanelRespuesta, "L", sender);
            btnL.IsEnabled = false;
            jugador1.comprobarAcierto(btnL.Background == Brushes.Green, txtFallos, txtPuntuacion, muñecoAhorcado);

            fin = interfaz.acabarPartida(jugador1, palabra.ListaPantallasLetra, palabra.Nombre);

            if (fin)
            {
                PantallaInicio pi = new PantallaInicio();
                pi.Show();
                this.Close();
            }

        }

        private void Pulsar_M(object sender, RoutedEventArgs e)
        {
            palabra.RefrescarCuadroRespuesta(PanelRespuesta, "M", sender);
            btnM.IsEnabled = false;
            jugador1.comprobarAcierto(btnM.Background == Brushes.Green, txtFallos, txtPuntuacion, muñecoAhorcado);

            fin = interfaz.acabarPartida(jugador1, palabra.ListaPantallasLetra, palabra.Nombre);

            if (fin)
            {
                PantallaInicio pi = new PantallaInicio();
                pi.Show();
                this.Close();
            }

        }

        private void Pulsar_N(object sender, RoutedEventArgs e)
        {
            palabra.RefrescarCuadroRespuesta(PanelRespuesta, "N", sender);
            btnN.IsEnabled = false;
            jugador1.comprobarAcierto(btnN.Background == Brushes.Green, txtFallos, txtPuntuacion, muñecoAhorcado);

            fin = interfaz.acabarPartida(jugador1, palabra.ListaPantallasLetra, palabra.Nombre);

            if (fin)
            {
                PantallaInicio pi = new PantallaInicio();
                pi.Show();
                this.Close();
            }

        }

        private void Pulsar_Ñ(object sender, RoutedEventArgs e)
        {
            palabra.RefrescarCuadroRespuesta(PanelRespuesta, "Ñ", sender);
            btnÑ.IsEnabled = false;
            jugador1.comprobarAcierto(btnÑ.Background == Brushes.Green, txtFallos, txtPuntuacion, muñecoAhorcado);

            fin = interfaz.acabarPartida(jugador1, palabra.ListaPantallasLetra, palabra.Nombre);

            if (fin)
            {
                PantallaInicio pi = new PantallaInicio();
                pi.Show();
                this.Close();
            }

        }

        private void Pulsar_O(object sender, RoutedEventArgs e)
        {
            palabra.RefrescarCuadroRespuesta(PanelRespuesta, "O",sender);
            btnO.IsEnabled = false;
            jugador1.comprobarAcierto(btnO.Background == Brushes.Green, txtFallos, txtPuntuacion, muñecoAhorcado);

            fin = interfaz.acabarPartida(jugador1, palabra.ListaPantallasLetra, palabra.Nombre);

            if (fin)
            {
                PantallaInicio pi = new PantallaInicio();
                pi.Show();
                this.Close();
            }

        }

        private void Pulsar_P(object sender, RoutedEventArgs e)
        {
            palabra.RefrescarCuadroRespuesta(PanelRespuesta, "P", sender);
            btnP.IsEnabled = false;
            jugador1.comprobarAcierto(btnP.Background == Brushes.Green, txtFallos, txtPuntuacion, muñecoAhorcado);

            fin = interfaz.acabarPartida(jugador1, palabra.ListaPantallasLetra, palabra.Nombre);

            if (fin)
            {
                PantallaInicio pi = new PantallaInicio();
                pi.Show();
                this.Close();
            }

        }

        private void Pulsar_Q(object sender, RoutedEventArgs e)
        {
            palabra.RefrescarCuadroRespuesta(PanelRespuesta, "Q", sender);
            btnQ.IsEnabled = false;
            jugador1.comprobarAcierto(btnQ.Background == Brushes.Green, txtFallos, txtPuntuacion, muñecoAhorcado);

            fin = interfaz.acabarPartida(jugador1, palabra.ListaPantallasLetra, palabra.Nombre);

            if (fin)
            {
                PantallaInicio pi = new PantallaInicio();
                pi.Show();
                this.Close();
            }

        }

        private void Pulsar_R(object sender, RoutedEventArgs e)
        {
            palabra.RefrescarCuadroRespuesta(PanelRespuesta, "R", sender);
            btnR.IsEnabled = false;
            jugador1.comprobarAcierto(btnR.Background == Brushes.Green, txtFallos, txtPuntuacion, muñecoAhorcado);

            fin = interfaz.acabarPartida(jugador1, palabra.ListaPantallasLetra, palabra.Nombre);

            if (fin)
            {
                PantallaInicio pi = new PantallaInicio();
                pi.Show();
                this.Close();
            }

        }

        private void Pulsar_S(object sender, RoutedEventArgs e)
        {
            palabra.RefrescarCuadroRespuesta(PanelRespuesta, "S", sender);
            btnS.IsEnabled = false;
            jugador1.comprobarAcierto(btnS.Background == Brushes.Green, txtFallos, txtPuntuacion, muñecoAhorcado);

            fin = interfaz.acabarPartida(jugador1, palabra.ListaPantallasLetra, palabra.Nombre);

            if (fin)
            {
                PantallaInicio pi = new PantallaInicio();
                pi.Show();
                this.Close();
            }

        }

        private void Pulsar_T(object sender, RoutedEventArgs e)
        {
            palabra.RefrescarCuadroRespuesta(PanelRespuesta, "T", sender);
            btnT.IsEnabled = false;
            jugador1.comprobarAcierto(btnT.Background == Brushes.Green, txtFallos, txtPuntuacion, muñecoAhorcado);

            fin = interfaz.acabarPartida(jugador1, palabra.ListaPantallasLetra, palabra.Nombre);

            if (fin)
            {
                PantallaInicio pi = new PantallaInicio();
                pi.Show();
                this.Close();
            }

        }

        private void Pulsar_U(object sender, RoutedEventArgs e)
        {
            palabra.RefrescarCuadroRespuesta(PanelRespuesta, "U", sender);
            btnU.IsEnabled = false;
            jugador1.comprobarAcierto(btnU.Background == Brushes.Green, txtFallos, txtPuntuacion, muñecoAhorcado);

            fin = interfaz.acabarPartida(jugador1, palabra.ListaPantallasLetra, palabra.Nombre);

            if (fin)
            {
                PantallaInicio pi = new PantallaInicio();
                pi.Show();
                this.Close();
            }

        }

        private void Pulsar_V(object sender, RoutedEventArgs e)
        {
            palabra.RefrescarCuadroRespuesta(PanelRespuesta, "V", sender);
            btnV.IsEnabled = false;
            jugador1.comprobarAcierto(btnV.Background == Brushes.Green, txtFallos, txtPuntuacion, muñecoAhorcado);

            fin = interfaz.acabarPartida(jugador1, palabra.ListaPantallasLetra, palabra.Nombre);

            if (fin)
            {
                PantallaInicio pi = new PantallaInicio();
                pi.Show();
                this.Close();
            }

        }

        private void Pulsar_W(object sender, RoutedEventArgs e)
        {
            palabra.RefrescarCuadroRespuesta(PanelRespuesta, "W", sender);
            btnW.IsEnabled = false;
            jugador1.comprobarAcierto(btnW.Background == Brushes.Green, txtFallos, txtPuntuacion, muñecoAhorcado);

            fin = interfaz.acabarPartida(jugador1, palabra.ListaPantallasLetra, palabra.Nombre);

            if (fin)
            {
                PantallaInicio pi = new PantallaInicio();
                pi.Show();
                this.Close();
            }

        }

        private void Pulsar_X(object sender, RoutedEventArgs e)
        {
            palabra.RefrescarCuadroRespuesta(PanelRespuesta, "X", sender);
            btnX.IsEnabled = false;
            jugador1.comprobarAcierto(btnX.Background == Brushes.Green, txtFallos, txtPuntuacion, muñecoAhorcado);

            fin = interfaz.acabarPartida(jugador1, palabra.ListaPantallasLetra, palabra.Nombre);

            if (fin)
            {
                PantallaInicio pi = new PantallaInicio();
                pi.Show();
                this.Close();
            }

        }

        private void Pulsar_Y(object sender, RoutedEventArgs e)
        {
            palabra.RefrescarCuadroRespuesta(PanelRespuesta, "Y", sender);
            btnY.IsEnabled = false;
            jugador1.comprobarAcierto(btnY.Background == Brushes.Green, txtFallos, txtPuntuacion, muñecoAhorcado);

            fin = interfaz.acabarPartida(jugador1, palabra.ListaPantallasLetra, palabra.Nombre);

            if (fin)
            {
                PantallaInicio pi = new PantallaInicio();
                pi.Show();
                this.Close();
            }

        }

        private void Pulsar_Z(object sender, RoutedEventArgs e)
        {
            palabra.RefrescarCuadroRespuesta(PanelRespuesta, "Z", sender);
            btnZ.IsEnabled = false;
            jugador1.comprobarAcierto(btnZ.Background == Brushes.Green, txtFallos, txtPuntuacion, muñecoAhorcado);

            fin = interfaz.acabarPartida(jugador1, palabra.ListaPantallasLetra, palabra.Nombre);

            if (fin)
            {
                PantallaInicio pi = new PantallaInicio();
                pi.Show();
                this.Close();
            }

        }
        private void btnPista_Click(object sender, RoutedEventArgs e)
        {
  
            btnPista.IsEnabled = false;

            gridPantallaCompleta.Opacity = 0.5;

            panelCentral.Children.Add(new Pista(palabra.Descripcion, panelCentral, gridPantallaCompleta, panelLetras));
         
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {

            //TODO guardar puntuacion y nombre del jugador 
            jugador1.GuardarEstadisticas(numTematica);


        }

        private void ValorTiempo(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (Barra.Value == 100)
            {
                MessageBox.Show("SE AGOTÓ EL TIEMPO");
                PantallaInicio pi = new PantallaInicio();
                pi.Show();
                this.Close();
            }
        }
    }

}
