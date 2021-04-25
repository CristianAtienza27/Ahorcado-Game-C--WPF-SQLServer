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
    /// Lógica de interacción para PantallaTematica.xaml
    /// </summary>
    public partial class PantallaTematica : Window
    {

        Palabras palabras;
        public PantallaTematica()
        {

            InitializeComponent();

            palabras = new Palabras();

        }

        private void btnProgramacion_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow(1);
            mw.Show();
            this.Close();
        }

        private void btnBD_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow(2);
            mw.Show();
            this.Close();
        }

        private void btnLM_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow(3);
            mw.Show();
            this.Close();
        }

        private void btnSI_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow(9);
            mw.Show();
            this.Close();
        }

        private void btnEntorno_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow(10);
            mw.Show();
            this.Close();
        }

        private void btnSQL_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow(11);
            mw.Show();
            this.Close();
        }

        private void btnAtras_Click(object sender, RoutedEventArgs e)
        {
            PantallaInicio pi = new PantallaInicio();
            pi.Show();
            this.Close();
        }

    }
}
