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
    /// Lógica de interacción para PantallaLetra.xaml
    /// </summary>
    public partial class PantallaLetra : UserControl
    {
        string letra;
        public PantallaLetra(string letra = null)
        {
            InitializeComponent();

            this.letra = letra;

            lblLetra.Content = letra;
        }
    }
}
