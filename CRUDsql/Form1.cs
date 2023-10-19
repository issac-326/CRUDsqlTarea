using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRUDsql
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Clases.ClassAlumno objetoAlumno = new Clases.ClassAlumno();
            objetoAlumno.mostrarAlumnos(mostrarAlumnos);

            codigo.Enabled = false;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Clases.ClassAlumno objetoAlumno = new Clases.ClassAlumno();
            objetoAlumno.guardarAlumno(nombre, apellido, cuenta, edad, telefono);
            objetoAlumno.mostrarAlumnos(mostrarAlumnos);

            codigo.Text = "";
            nombre.Text = "";
            apellido.Text = "";
            edad.Text = "";
            telefono.Text = "";
            cuenta.Text = "";
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void mostrarAlumnos_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            Clases.ClassAlumno objetoAlumno = new Clases.ClassAlumno();
            objetoAlumno.seleccionarAlumno(mostrarAlumnos, codigo, nombre, apellido, cuenta, edad, telefono);
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            Clases.ClassAlumno objetoAlumno = new Clases.ClassAlumno();
            objetoAlumno.editarAlumno( codigo, nombre, apellido, cuenta, edad, telefono);
            objetoAlumno.mostrarAlumnos(mostrarAlumnos);
            codigo.Text = "";
            nombre.Text = "";
            apellido.Text = "";
            edad.Text = "";
            telefono.Text = "";
            cuenta.Text = "";
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            Clases.ClassAlumno objetoAlumno = new Clases.ClassAlumno();
            objetoAlumno.borrarAlumno(codigo);
            objetoAlumno.mostrarAlumnos(mostrarAlumnos);
            codigo.Text = "";
            nombre.Text = "";
            apellido.Text = "";
            edad.Text = "";
            telefono.Text = "";
            cuenta.Text = "";
        }
    }
}
