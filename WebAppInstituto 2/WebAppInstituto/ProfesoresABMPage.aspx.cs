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
    public partial class ProfesoresABMPage : System.Web.UI.Page
    {

        private int accionp;
        private string idProfesor;
        protected void Page_Load(object sender, EventArgs e)
        {
            this.accionp = Convert.ToInt32(Request.QueryString["accion"]);
            idProfesor = Request.QueryString["idProfesor"];
            if (IsPostBack == false)//postaback ==> cuando vuelvo sobre la misma pagina
            {
                CargarProfesor(idProfesor);
            }

        }
        private void CargarProfesor(string idProfesorr)
        {
            AdmProfesores admProfesores = new AdmProfesores();

            Profesor profesor = new Profesor();
            profesor = admProfesores.obtenerProfesorDBPorId(Convert.ToInt32(idProfesorr));

            txptNombre.Text = profesor.Nombre;
            txtpApellido.Text = profesor.Apellido;
            txtpSueldo.Text = profesor.Sueldo.ToString().Replace(",", ".");
            txtpDni.Text = profesor.DNI;
            txtpMAil.Text = profesor.Mail;
            txtpTelefono.Text = profesor.Telefono;

        }

   

        protected void btnpGuardar_Click1(object sender, EventArgs e)
        {

            //tomo los datos de la pantalla
            string nombre = txptNombre.Text;
            string apellido = txtpApellido.Text;
            string dni = txtpDni.Text;
            string telefono = txtpTelefono.Text;
            string mail = txtpMAil.Text;
            string sueldo = txtpSueldo.Text;

            Profesor profesor = new Profesor(nombre, apellido, dni, mail, telefono, Convert.ToDecimal(sueldo));

            //instancio al admALumnos
            AdmProfesores administrador = new AdmProfesores();

            if (this.accionp == 1)
            {
                bool respuesta = administrador.agregarProfesorDB(profesor);
                if (respuesta)
                {
                    labelProfesor.Text = "Profesor agregado a la DB";
                }
                else
                {
                    labelProfesor.Text = "No se pudo guardar Profesor";
                }
            }
            else
            {
                //codigo para editar
                profesor.Id = Convert.ToInt32(this.idProfesor);
                bool respuesta = administrador.editarProfesorDB(profesor);
                if (respuesta)
                {
                    labelProfesor.Text = "Profesor editado en la DB";
                }
                else
                {
                    labelProfesor.Text = "No se pudo editar Profesor";
                }
            }

            //string infoAlumno = profesor.MostrarProfesor(true);

            //labelProfesor.Text = infoAlumno;

        }

            protected void btnEliminar_Click(object sender, EventArgs e)
        {
            //instancio al admALumnos
            AdmProfesores admProfesores = new AdmProfesores();
            bool respuesta = admProfesores.eliminarProfesorDB(Convert.ToInt32(this.idProfesor));

            if (respuesta)
            {
                labelProfesor.Text = "Profesor Eliminado en la DB";
            }
            else
            {
                labelProfesor.Text = "No se pudo eliminar profesor";
            }
        }
    }






    //protected void btnEliminar_Click(object sender, EventArgs e)
    //{
    //    //instancio al admALumnos
    //    AdmAlumnos administrador = new AdmAlumnos();
    //    bool respuesta = administrador.eliminarAlumnoDB(Convert.ToInt32(this.idAlumno));

    //    if (respuesta)
    //    {
    //        labelProfesor.Text = "Alumnos Eliminado en la DB";
    //    }
    //    else
    //    {
    //        labelProfesor.Text = "No se pudo eliminar alumno";
    //    }
    //}


}