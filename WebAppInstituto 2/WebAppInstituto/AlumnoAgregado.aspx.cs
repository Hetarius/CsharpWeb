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
    public partial class AlumnoAgregado : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            int idAlumno = Convert.ToInt32(Request.QueryString["idAlumno"]);

            int idCurso = Convert.ToInt32(Request.QueryString["idCurso"]);

            AdmCurso admCurso = new AdmCurso();
            bool resultado = admCurso.agregarAlumnoACursoDB(idCurso, idAlumno);

            AdmAlumnos admAlumnos = new AdmAlumnos();
            Alumno alumno = new Alumno();
            alumno = admAlumnos.obtenerAlumnosDBPorId(Convert.ToInt32(idAlumno));

            Curso curso = new Curso();
            curso = admCurso.obtenerCursoDBPorId(Convert.ToInt32(idCurso));

            if (resultado==true)
            {
                LitResultado.Text = "El Alumno: " + alumno.Nombre +" "+ alumno.Apellido  + " a sido agregado al Curso: " + curso.Nombre;
            }
            else
            {
                LitResultado.Text = "No se pudo agregar el Alumno al Curso";
            }
        }
    }
}