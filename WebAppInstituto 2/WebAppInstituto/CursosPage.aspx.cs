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
    public partial class CursosPage : System.Web.UI.Page
    {
        AdmCurso admin = new AdmCurso();

        protected void Page_Load(object sender, EventArgs e)
        {
            cargarCurso();
        }

        public void cargarCurso()
        {
            List<Curso> cursos = new List<Curso>();

            cursos = admin.obtenerCursosDB();

            foreach (Curso curso in cursos)
            {
                this.litTablaCurso.Text += curso.MostrarCursoHTML();
            }

        }

       
    }
}