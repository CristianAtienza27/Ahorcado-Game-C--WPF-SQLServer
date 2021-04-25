using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace AhorcadoWPF
{
    class LogicaInterfaz
    {
        public void colocarCuadros(string palabra, StackPanel panel)
        {
            switch (palabra.Length)
            {
                case 1:
                    panel.Margin = new Thickness(145, 379, -236, -129);
                    break;
                case 2:
                    panel.Margin = new Thickness(110, 379, -236, -129);
                    break;
                case 3:
                    panel.Margin = new Thickness(71, 379, -236, -129);
                    break;
                case 4:
                    panel.Margin = new Thickness(36, 379, -236, -129);
                    break;
                case 5:
                    panel.Margin = new Thickness(1, 379, -236, -129);
                    break;
                case 6:
                    panel.Margin = new Thickness(-35, 379, -236, -129);
                    break;
                case 7:
                    panel.Margin = new Thickness(-75, 379, -236, -129);
                    break;
                case 8:
                    panel.Margin = new Thickness(-95, 379, -236, -129);
                    break;
                case 9:
                    panel.Margin = new Thickness(-135, 379, -236, -129);
                    break;
                case 10:
                    panel.Margin = new Thickness(-165, 379, -236, -129);
                    break;
                case 11:
                    panel.Margin = new Thickness(-200, 379, -236, -129);
                    break;
                case 12:
                    panel.Margin = new Thickness(-240, 379, -236, -129);
                    break;
            }
        }


        /// <summary>
        /// Comprueba si se han acertado todas o si se han cometido 7 errores
        /// </summary>
        /// <param name="jugador1"></param>
        /// <param name="listaPantallasLetra"></param>
        /// <param name="palabra"></param>
        /// <returns>True si acabó la partida, false si sigue en curso</returns>
        public bool acabarPartida(Jugador jugador1, List<PantallaLetra> listaPantallasLetra, string palabra)
        {
            string palabraAcertada = "";

            bool fin = false;

            if (jugador1.Errores == 7)
            {

                MessageBox.Show("GAME OVER");

                fin = true;

            }
            else
            {

                for (int i = 0; i < listaPantallasLetra.Count; i++)
                {

                    palabraAcertada += listaPantallasLetra[i].lblLetra.Content;

                }

                if (palabraAcertada == palabra)
                {

                    MessageBox.Show("¡GANASTE!");

                    fin = true;

                }

            }

            return fin;

        }
    }
}
