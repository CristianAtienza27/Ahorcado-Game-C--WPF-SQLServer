using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace AhorcadoWPF
{
    class Palabras
    {
        private string nombre;

        private string descripcion;

        private int idTema;

        private List<PantallaLetra> listaPantallasLetra;

        public Palabras()
        {
            nombre = "";
            descripcion = "";
            idTema = -1;
        }

        public Palabras(int numTema)
        {
            nombre = CargarPalabraBD(numTema);
            descripcion = ObtenerDescripcion(nombre);
            listaPantallasLetra = new List<PantallaLetra>();
        }

        public Palabras(string nombre, string descripcion, int idTema)
        {

            this.nombre = nombre;
            this.descripcion = descripcion;
            this.idTema = idTema;

        }

        public string Nombre { get => nombre; set => nombre = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public int Tema { get => idTema; set => idTema = value; }
        public List<PantallaLetra> ListaPantallasLetra { get => listaPantallasLetra; set => listaPantallasLetra = value; }

        /// <summary>
        /// Inserta una palabra en la BD
        /// </summary>
        public void InsertarPalabra()
        {

            string consulta = "insert into TPalabra (Palabra, Descripcion, IdTematica)" +
            " VALUES ('" + nombre + "','" + descripcion + "'," + idTema + ")";

            ConexionBD conexion = new ConexionBD();

            conexion.Abrir();

            SqlCommand comando = new SqlCommand(consulta, conexion.MySqlconexion);

            try
            {

                comando.ExecuteNonQuery();

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);

            }

            conexion.Cerrar();

        }

        /// <summary>
        /// Carga en el comboBox los temas a los que se pueden añadir palabras
        /// </summary>
        /// <param name="cBox"></param>
        public static void CargarCBoxTema(ComboBox cBox)
        {
            string consulta = "select Tema from TTematica";

            ConexionBD conexion = new ConexionBD();

            DataTable dt;

            try
            {

                SqlDataAdapter dataAdapt = new SqlDataAdapter(consulta, conexion.MySqlconexion);

                dt = new DataTable();

                dataAdapt.Fill(dt);

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);

            }

            foreach (DataRow item in dt.Rows)
            {

                cBox.Items.Add(item.ItemArray[0].ToString());

            }

        }

        /// <summary>
        /// Carga las palabras de la BD según el tema seleccionado 
        /// </summary>
        /// <param name="numTem"></param>
        /// <returns></returns>
        public string CargarPalabraBD(int numTem)
        {
            string consulta = "select TP.Palabra " +
            "from TPalabra as TP inner join TTematica as TT " +
            "on (TP.IdTematica = TT.IdTematica) " +
            "where TT.IdTematica = " + numTem + ";";

            int tamañoTema = TotalPalabras(numTem);

            ConexionBD conexion = new ConexionBD();

            DataTable dt;

            try
            {

                SqlDataAdapter dataAdapt = new SqlDataAdapter(consulta, conexion.MySqlconexion);

                dt = new DataTable();

                dataAdapt.Fill(dt);

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);

            }

            return PalabraAlAzar(dt, tamañoTema);

        }

        /// <summary>
        /// Escoge al azar una palabra de la BD
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="tamañoTema"></param>
        /// <returns>Una palabra al azar</returns>
        public string PalabraAlAzar(DataTable dt, int tamañoTema)
        {

            Random aleat = new Random();
            int n = aleat.Next(0, tamañoTema);

            return dt.Rows[n].ItemArray[0].ToString();

        }

        /// <summary>
        /// Establece el tamaño del temario según el número de preguntas,
        /// posteriormente se usará para sacar una palabra al azar
        /// </summary>
        /// <param name="numTema"></param>
        /// <returns>Tamaño total</returns>
        public int TotalPalabras(int numTema)
        {

            string consulta = "select COUNT(*) " +
            "from TPalabra as TP inner join TTematica as TT  " +
            "on (TP.IdTematica = TT.IdTematica)  " +
            "where TT.IdTematica = "+ numTema;

            string totalPalabras;

            ConexionBD conexion = new ConexionBD();

            conexion.Abrir();

            SqlCommand comando = new SqlCommand(consulta, conexion.MySqlconexion);

            try
            {

                totalPalabras = comando.ExecuteScalar().ToString();         
                
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);

            }

            conexion.Cerrar();

            return Convert.ToInt32(totalPalabras);

        }

        /// <summary>
        /// Obtiene el id de la temática
        /// </summary>
        /// <param name="tematica"></param>
        /// <returns></returns>
        public static int ObtenerIdTema(string tematica)
        {
            string consulta = "select IdTematica " +
            "from TTematica where Tema = '" + tematica + "';";

            int idTema;

            ConexionBD conexion = new ConexionBD();

            conexion.Abrir();

            SqlCommand comando = new SqlCommand(consulta, conexion.MySqlconexion);

            try
            {

                idTema = Convert.ToInt32(comando.ExecuteScalar().ToString());

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);

            }

            conexion.Cerrar();

            return idTema;

        }

        /// <summary>
        /// Obtiene la descripción de la palabra que haya salido al azar,
        /// se usará en la pista.
        /// </summary>
        /// <param name="nombre"></param>
        /// <returns>Descripción de la palabra</returns>
        public string ObtenerDescripcion(string nombre)
        {

            string consulta = "Select Descripcion from TPalabra where Palabra = '" + nombre + " '"; 

            ConexionBD conexion = new ConexionBD();

            conexion.Abrir();

            SqlCommand comando = new SqlCommand(consulta, conexion.MySqlconexion);

            try
            {

               return comando.ExecuteScalar().ToString();

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);

            }

        }

        /// <summary>
        /// Se añadirá a la pantalla principal una serie de cuadros según 
        /// el número de letras de la palabra, si se acierta, se refresca añadiendo 
        /// la letra acertada y se coloreará cada letra respondida (Verde/Rojo)
        /// </summary>
        /// <param name="panel"></param>
        /// <param name="letra"></param>
        /// <param name="sender"></param>
        public void RefrescarCuadroRespuesta(StackPanel panel, string letra = null, object sender = null)
        {

            if (letra == null)
            {

                for (int i = 0; i < nombre.Length; i++)
                {

                    panel.Children.Add(new PantallaLetra());

                }

                foreach (PantallaLetra item in panel.Children)
                {

                    listaPantallasLetra.Add(item);

                }

            }
            else
            {

                Button botonPresionado = (Button)sender;

                bool correcto = false;

                for (int i = 0; i < nombre.Length; i++)
                {

                    if (nombre[i].ToString() == letra)
                    {

                        listaPantallasLetra[i].lblLetra.Content = letra;

                        correcto = true;
                    }

                }

                botonPresionado.Background = (correcto == true ? Brushes.Green : Brushes.Red);

            }

        }

    }
}
