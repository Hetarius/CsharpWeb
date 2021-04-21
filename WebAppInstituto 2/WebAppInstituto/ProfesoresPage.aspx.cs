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
    public partial class ProfesoresPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            cargarProfesores();


        }
        public void cargarProfesores()
        {
            AdmProfesores admProfesores = new AdmProfesores();
            List<Profesor> profesors = admProfesores.obtenerProfesoresDB();

            foreach (Profesor profesor in profesors)
            {
                //litTablaAlumno.Text += "<tr>";
                //litTablaAlumno.Text += "<th scope=\"row\">" + alumno.Id + "</th>";
                //litTablaAlumno.Text += "<td>" + alumno.Nombre + "</td>";
                //litTablaAlumno.Text += "<td>" + alumno.Apellido + "</td>";
                //litTablaAlumno.Text += "</tr>";
                this.litTablaProfesor.Text += profesor.MostrarProfesorHTML();
            }

        }
    }
}