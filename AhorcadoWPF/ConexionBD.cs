using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AhorcadoWPF
{
    class ConexionBD
    {
        private SqlConnection mySqlconexion;
        public ConexionBD()
        {
            this.mySqlconexion = new SqlConnection(@"Data Source=LAPTOP-NSJ9HOLA\DAM1SQLSERVER;Initial Catalog=Ahorcado;Integrated Security=True;Pooling=False");
        }

        public SqlConnection MySqlconexion { get => mySqlconexion; set => mySqlconexion = value; }

        public void Abrir()
        {
            try
            {
                mySqlconexion.Open();
            }
            catch (Exception)
            {
                throw new Exception("Ocurrió un error al abrir conexión");
            }
        }

        public void Cerrar()
        {
            try
            {
                mySqlconexion.Close();
            }
            catch (Exception)
            {
                throw new Exception("Ocurrió un error al cerrar conexión");
            }
        }

        public SqlCommand EjecutarConsulta(string consulta)
        {

            try
            {
                return new SqlCommand(consulta, mySqlconexion);
            }
            catch (Exception)
            {
                throw new Exception("Ocurrió un error al ejecutar la consulta");
            }

        }
    }
}
