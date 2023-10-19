using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRUDsql.Clases
{
    class ClassAlumno
    {
        public void mostrarAlumnos(DataGridView tablaAlumnos)
        {
            ConexionSqlServer objectConexion = new ConexionSqlServer();
            try
            {
                tablaAlumnos.DataSource = null;
                SqlDataAdapter adapter = new SqlDataAdapter("select * from alumnos;", objectConexion.establecerConexion());
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                tablaAlumnos.DataSource = dt;

                objectConexion.cerrarCoxion();
            
            }
            catch (Exception e)
            {
                MessageBox.Show("error al cargar los registros: " + e.ToString());
            }
        }

        public void guardarAlumno(TextBox nombre, TextBox apellido, TextBox cuenta, TextBox edad, TextBox telefono)
        {
            ConexionSqlServer objectConexion = new ConexionSqlServer();
            try
            {
                String query = "insert into alumnos(nombre, apellido, cuenta, edad, telefono)"+
                                "values('"+nombre.Text+"','"+apellido.Text+"','"+cuenta.Text+"','"+edad.Text+"','"+telefono.Text+"');";

                SqlCommand comando = new SqlCommand(query, objectConexion.establecerConexion());
                SqlDataReader myReader;

                myReader = comando.ExecuteReader();

                while (myReader.Read())
                {

                }
                MessageBox.Show("Se guardo alumno");
                objectConexion.cerrarCoxion();

            }
            catch (Exception e)
            {
                MessageBox.Show("error al guardar el registro: " + e.ToString());
            }
        }

        public void seleccionarAlumno(DataGridView tablaAlumnos,TextBox codigo, TextBox nombre, TextBox apellido, TextBox cuenta, TextBox edad, TextBox telefono)
        {
            try
            {
                codigo.Text = tablaAlumnos.CurrentRow.Cells[0].Value.ToString();
                nombre.Text = tablaAlumnos.CurrentRow.Cells[1].Value.ToString();
                apellido.Text = tablaAlumnos.CurrentRow.Cells[2].Value.ToString();
                cuenta.Text = tablaAlumnos.CurrentRow.Cells[3].Value.ToString();
                edad.Text = tablaAlumnos.CurrentRow.Cells[4].Value.ToString();
                telefono.Text = tablaAlumnos.CurrentRow.Cells[5].Value.ToString();
            }
            catch (Exception e)
            {
                MessageBox.Show("No se logro selecionar, error: " + e);
            }
        }

        public void editarAlumno(TextBox codigo, TextBox nombre, TextBox apellido, TextBox cuenta, TextBox edad, TextBox telefono)
        {
            ConexionSqlServer objectConexion = new ConexionSqlServer();
            try
            {
                String query = "UPDATE alumnos set alumnos.nombre ='"+
                                nombre.Text + "', alumnos.apellido='" + apellido.Text + "', alumnos.cuenta ='" + cuenta.Text + "', alumnos.edad=" + edad.Text + ", alumnos.telefono='" + telefono.Text + "' WHERE alumnos.codigo = " + codigo.Text +";";

                SqlCommand comando = new SqlCommand(query, objectConexion.establecerConexion());
                SqlDataReader myReader;

                myReader = comando.ExecuteReader();

                while (myReader.Read())
                {

                }
                MessageBox.Show("Se modifico alumno");
                objectConexion.cerrarCoxion();

            }
            catch (Exception e)
            {
                MessageBox.Show("error al modificar el registro: " + e.ToString());
            }
        }

        public void borrarAlumno(TextBox codigo)
        {
            ConexionSqlServer objectConexion = new ConexionSqlServer();
            try
            {
                String query = "DELETE FROM alumnos WHERE alumnos.codigo = " + codigo.Text + ";";

                SqlCommand comando = new SqlCommand(query, objectConexion.establecerConexion());
                SqlDataReader myReader;

                myReader = comando.ExecuteReader();

                while (myReader.Read())
                {

                }
                MessageBox.Show("Se elimino alumno");
                objectConexion.cerrarCoxion();

            }
            catch (Exception e)
            {
                MessageBox.Show("error al eliminar el registro: " + e.ToString());
            }
        }
    }
}
