using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Threading;

namespace AhorcadoWPF
{
    public class Temporizador
    {
        private float increment = 0;

        private int increment2 = 50;

        private DispatcherTimer timer;

        private DispatcherTimer timer2;

        private Label lblSegundos;

        private ProgressBar barra;

        private Button btnPista;

        public DispatcherTimer Timer { get => timer; set => timer = value; }
        public float Increment { get => increment; set => increment = value; }
        public Label LblSegundos { get => lblSegundos; set => lblSegundos = value; }
        public ProgressBar Barra { get => barra; set => barra = value; }

        public Temporizador(Label lblSegundos, ProgressBar barra, Button btnPista)
        {

            this.lblSegundos = lblSegundos;

            this.barra = barra;

            this.btnPista = btnPista;

            timer = new DispatcherTimer();

            timer.Interval = TimeSpan.FromSeconds(0.1552);

            timer.Tick += dtTicker;

            timer2 = new DispatcherTimer();

            timer2.Interval = TimeSpan.FromSeconds(1.5);

            timer2.Tick += dtTicker2;

        }

        public void Start()
        {

            timer.Start();
            timer2.Start();

        }

        public void Stop()
        {

            timer.Stop();
            timer2.Stop();

        }
            

        private void dtTicker2(object sender, EventArgs e)
        {

            lblSegundos.Content = (increment2--).ToString();

        }

        private void dtTicker(object sender, EventArgs e)
        {

            increment = increment + 0.5f;

            barra.Value = increment;

            if (barra.Value == 100)
            {
                timer.Stop();
                timer2.Stop();
            }

            if(barra.Value > 50)
            {
                btnPista.IsEnabled = true;
            }


        }
    }
}