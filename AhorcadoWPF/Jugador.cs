using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;
//Cambios
namespace AhorcadoWPF
{
    public class Jugador
    {
        private int idJugador;

        private string nombre;

        private int errores;

        private int puntuacion;

        private int tiempo;

        public Jugador()
        {
            idJugador = -1;
            nombre = "";
            puntuacion = 0;
            errores = 0;
            tiempo = 60;
        }

        public Jugador(string nombre)
        {
            idJugador = -1;
            Nombre = nombre;
            puntuacion = 0;
            errores = 0;
            tiempo = 60;
        }

        public string Nombre
        {
            get => nombre;
            set
            {
                string msjError = ValidarNombre(value);

                if (!String.IsNullOrEmpty(msjError))
                {
                    throw new Exception(msjError);
                }

                nombre = value;

            }
        }
        public int Errores
        {
            get => errores;
            set
            {

                if (errores > 0)
                {
                    errores = value;
                }

            }
        }
        public int Puntuacion
        {
            get => puntuacion;
            set
            {

                if (puntuacion > 0)
                {
                    puntuacion = value;
                }

            }
        }

        public int Tiempo { get => tiempo; set => tiempo = value; }

        /// <summary>
        /// Inserta un jugador en la BD
        /// </summary>
        public void InsertarJugador()
        {

            string consulta = "Insert into TJugador (Nombre) VALUES ('" + nombre + "')";

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
            
        }

        /// <summary>
        /// Comprueba la existencia de un jugador con el mismo nombre
        /// </summary>
        /// <returns>True si existe, false si no</returns>
        public bool ComprobarExistencia()
        {
            string consulta = "select Nombre from TJugador where Nombre = '" + nombre + "';";

            bool existe;

            ConexionBD conexion = new ConexionBD();

            SqlDataAdapter dataAdapt = new SqlDataAdapter(consulta, conexion.MySqlconexion);

            DataTable dt = new DataTable();

            try
            {

                dataAdapt.Fill(dt);

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);

            }

            return existe = (dt.Rows.Count > 0 ? true : false);

        }

        /// <summary>
        /// Comprueba el acierto y actualiza la puntuación y los fallos.
        /// </summary>
        /// <param name="acierto"></param>
        /// <param name="txtFallos"></param>
        /// <param name="txtPuntos"></param>
        /// <param name="muñecoAhorcado"></param>
        public void comprobarAcierto(bool acierto, TextBlock txtFallos, TextBlock txtPuntos, Grid muñecoAhorcado)
        {

            if (puntuacion > 0)
            {
                txtPuntos.Text = (puntuacion = (acierto == true ? puntuacion += 100 : puntuacion -= 50)).ToString();
            }
            else
            {
                txtPuntos.Text = (puntuacion = (acierto == true ? puntuacion += 100 : puntuacion)).ToString();
            }

            txtFallos.Text = "FALLOS: " + (errores = (acierto == true ? errores : errores += 1)).ToString() + "/7";

            if (!acierto)
            {

                restarIntentos(muñecoAhorcado);

            }

        }

        /// <summary>
        /// Dibuja cada parte del ahorcado según el fallo
        /// </summary>
        /// <param name="muñecoAhorcado"></param>
        public void restarIntentos(Grid muñecoAhorcado)
        {

            List<Rectangle> listaErrores = new List<Rectangle>();

            foreach (Rectangle rc in muñecoAhorcado.Children)
            {

                listaErrores.Add(rc);

            }

            if (errores > 0)
            {

                for (int i = 0; i < errores; i++)
                {

                    listaErrores[i].Visibility = Visibility.Visible;

                }

            }

        }

        /// <summary>
        /// Guarda la estadistica del jugador en la BD
        /// </summary>
        /// <param name="idTematica"></param>
        public void GuardarEstadisticas(int idTematica)
        {
            string consulta = "Insert into TPartida (IdJugador, IdTematica, Puntos) " +
            "VALUES (" + obtenerId() + ", " + idTematica + ", " + puntuacion + ")";

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
        /// Obtiene la Id del jugador mediante el nombre del jugador
        /// </summary>
        /// <returns>Id del Jugador</returns>
        public int obtenerId()
        {
            string consulta = "Select IdJugador From TJugador Where Nombre = '" + nombre + "'";

            ConexionBD conexion = new ConexionBD();

            conexion.Abrir();

            SqlCommand comando = new SqlCommand(consulta, conexion.MySqlconexion);

            try
            {

                idJugador = Convert.ToInt32(comando.ExecuteScalar().ToString());

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);

            }

            conexion.Cerrar();

            return idJugador;

        }

        /// <summary>
        /// Validación de tamaño del nombre
        /// </summary>
        /// <param name="entrada"></param>
        /// <returns></returns>
        public string ValidarNombre(string entrada)
        {
            entrada = entrada.Trim();

            if (entrada.Length < 3)
            {
                return "El número de dígitos del nombre debe ser mayor a 3";
            }

            return "";

        }

    }
}
