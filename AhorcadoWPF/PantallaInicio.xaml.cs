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
    /// Lógica de interacción para PantallaInicio.xaml
    /// </summary>
    public partial class PantallaInicio : Window
    {
        public PantallaInicio()
        {
            InitializeComponent();
        }

        private void btnJugar_Click(object sender, RoutedEventArgs e)
        {
            PantallaTematica pt = new PantallaTematica();
            pt.Show();
            this.Close();
        }

        private void btnAñadir_Click(object sender, RoutedEventArgs e)
        {
            PantallaAñadir añadir = new PantallaAñadir();
            añadir.Show();
            this.Close();
               
        }
    }
}
