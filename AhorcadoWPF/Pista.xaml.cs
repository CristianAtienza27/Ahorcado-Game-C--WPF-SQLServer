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
    /// Lógica de interacción para Pista.xaml
    /// </summary>
    public partial class Pista : UserControl
    {
        string pista;

        StackPanel panelPista;

        Grid pantalla;

        StackPanel panelLetras;

        public Pista(String pista, StackPanel panelPista, Grid pantalla, StackPanel panelLetras)
        {
            InitializeComponent();

            this.pista = pista;

            this.panelPista = panelPista;

            this.pantalla = pantalla;

            this.panelLetras = panelLetras;

        }

        private void Pista_Loaded(object sender, RoutedEventArgs e)
        {
            txtPista.Text = pista;

            foreach (Button botonesLetras in panelLetras.Children)
            {
                botonesLetras.IsEnabled = false;
            }         

        }

        private void btnAtras_Click(object sender, RoutedEventArgs e)
        {

            foreach (Button botonesLetras in panelLetras.Children)
            {

                if (botonesLetras.Background == null)
                {
                    botonesLetras.IsEnabled = true;
                }
               
            }

            panelPista.Children.Clear();

            pantalla.Opacity = 1;
        }

    }
}
