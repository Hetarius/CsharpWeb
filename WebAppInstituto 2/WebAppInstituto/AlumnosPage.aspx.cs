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
    public partial class AlumnosPage : System.Web.UI.Page
    {

        int accion;
        int idCurso;
        protected void Page_Load(object sender, EventArgs e)
        {

            accion = Convert.ToInt32(Request.QueryString["accion"]);
            idCurso = Convert.ToInt32(Request.QueryString["idCurso"]);
          

            if (accion == 2 || accion == 3)
            {
                Panel1.Visible = false;
            }
            //litTablaAlumno.Text = "<tr>";
            //litTablaAlumno.Text += "<th scope=\"row\">1</th>";
            //litTablaAlumno.Text += "<td>Rodrigo</td>";
            //litTablaAlumno.Text += "<td>Moreiras</td>";
            //litTablaAlumno.Text += "</tr>";

            if (accion==3)
            {
                cargarAlumnosCurso();
            }
            else
            {
                cargarAlumnos();
            }
           
        }
        
        public void cargarAlumnos()
        {
            AdmAlumnos admin = new AdmAlumnos();
            List<Alumno> alumnos = admin.obtenerAlumnosDB();
            //Por cada uno de los "Alumno" que ay en "alumnos" cargame una variable que se llame "alumno"
            foreach (Alumno alumno in alumnos)
            {
                //litTablaAlumno.Text += "<tr>";
                //litTablaAlumno.Text += "<th scope=\"row\">" + alumno.Id + "</th>";
                //litTablaAlumno.Text += "<td>" + alumno.Nombre + "</td>";
                //litTablaAlumno.Text += "<td>" + alumno.Apellido + "</td>";
                //litTablaAlumno.Text += "</tr>";
                this.litTablaAlumno.Text += alumno.MostrarAlumnoHTML(accion, idCurso);
            }
            
        }


        public void cargarAlumnosCurso()
        {
            AdmCurso admCurso = new AdmCurso();
            List<Alumno> alumnos = admCurso.ObtenerAlumnosPorCurso(this.idCurso);
            //Por cada uno de los Alumno que ay en alumnos cargame una variable que se llame alumno 
            foreach (Alumno alumno in alumnos)
            {
                //litTablaAlumno.Text += "<tr>";
                //litTablaAlumno.Text += "<th scope=\"row\">" + alumno.Id + "</th>";
                //litTablaAlumno.Text += "<td>" + alumno.Nombre + "</td>";
                //litTablaAlumno.Text += "<td>" + alumno.Apellido + "</td>";
                //litTablaAlumno.Text += "</tr>";
                this.litTablaAlumno.Text += alumno.MostrarAlumnoHTML(accion, idCurso);
            }

        }


    }
}