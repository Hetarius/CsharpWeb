using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebAppInstituto.Datos;
using WebAppInstituto.Modelo;

namespace WebAppInstituto
{
    public partial class AlumnosABMPage : System.Web.UI.Page
    {
        private int accion;
        private string idAlumno;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.accion = Convert.ToInt32(Request.QueryString["accion"]);
            this.idAlumno = Request.QueryString["idAlumno"];
            if(IsPostBack==false)//postaback ==> cuando vuelvo sobre la misma pagina
            {
                CargarAlumno(idAlumno);
            }
        }
     
        private void CargarAlumno(string idAlumno)
        {
            AdmAlumnos administrador = new AdmAlumnos();

            Alumno alumno1 = new Alumno();
            alumno1 = administrador.obtenerAlumnosDBPorId(Convert.ToInt32(idAlumno));

            txtNombre.Text = alumno1.Nombre;
            txtApellido.Text = alumno1.Apellido;
            txtCuota.Text = alumno1.Cuota.ToString().Replace(",",".");
            txtDni.Text = alumno1.DNI;
            txtMAil.Text = alumno1.Mail;
            txtTelefono.Text = alumno1.Telefono;

        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        { 
            //tomo los datos de la pantalla
            string nombre = txtNombre.Text;
            string apellido = txtApellido.Text;
            string dni = txtDni.Text;
            string telefono = txtTelefono.Text;
            string mail = txtMAil.Text;
            string cuota = txtCuota.Text;

            Alumno alumno1 = new Alumno(nombre, apellido, dni, mail, telefono, Convert.ToDecimal(cuota));

            //instancio al admALumnos
            AdmAlumnos administrador = new AdmAlumnos();

            if (this.accion == 1)
            {
                //El metodo agregarAlumnoDB me devolvia un "bool"
                //Entonces agregamos una variable booleana(respuesta)

                bool respuesta = administrador.agregarAlumnoDB(alumno1);
                if (respuesta)
                {
                    labelAlumno.Text = "Alumnos agregado a la DB";
                }
                else
                {
                    labelAlumno.Text = "No se pudo guardar alumno";
                }
            }
            else
            {
                //codigo para editar
                alumno1.Id = Convert.ToInt32(this.idAlumno);
                bool respuesta = administrador.editarAlumnoDB(alumno1);
                if (respuesta)
                {
                    labelAlumno.Text = "Alumnos editado en la DB";
                }
                else
                {
                    labelAlumno.Text = "No se pudo editar alumno";
                }
            }

            //string infoAlumno = alumno1.MostrarAlumno(true);

            //labelAlumno.Text = infoAlumno;
        }

        protected void BtnEliminar_Click(object sender, EventArgs e)
        {
            //instancio al admALumnos
            AdmAlumnos administrador = new AdmAlumnos();
            bool respuesta = administrador.eliminarAlumnoDB(Convert.ToInt32(this.idAlumno));

            if (respuesta)
            {
                labelAlumno.Text = "Alumnos Eliminado en la DB";
            }
            else
            {
                labelAlumno.Text = "No se pudo eliminar alumno";
            }
        }
    }
}