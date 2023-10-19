using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRUDsql.Clases
{
    class ConexionSqlServer
    {
        SqlConnection conex = new SqlConnection();

        static String servidor = "localhost";
        static String bd = "alumnosDB";
        static String usuario = "root";
        static String contrasenia = "root";
        static String puerto = "1433";

        String cadenaConexion = "Data Source=" + servidor + "," + puerto +";" + "user id="+ usuario +";" + "password="+ contrasenia +";" +"Initial Catalog=" + bd + ";" +"Persist Security info = true";

        public SqlConnection establecerConexion()
        {
            try
            {
                conex.ConnectionString = cadenaConexion;
                conex.Open();
                
            }
            catch (Exception e)
            {
                MessageBox.Show("No se realizo la conexion a la bd");
            }

            return conex;
        }

        public void cerrarCoxion()
        {
            conex.Close();
        }
    }
}
