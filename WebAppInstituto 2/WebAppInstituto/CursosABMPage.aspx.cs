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
    public partial class CursosABMPage : System.Web.UI.Page
    {
        AdmProfesores administradorProfesores = new AdmProfesores();
        AdmCurso administradorCursos = new AdmCurso();
        private int accion;
        private string idCurso;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.accion = Convert.ToInt32(Request.QueryString["accion"]);
            this.idCurso = Request.QueryString["idCurso"];

            if (IsPostBack == false)//postaback ==> cuando vuelvo sobre la misma pagina
            {
                cargarListaProfesor();
                CargarCurso(idCurso);
            }
        }

        private void cargarListaProfesor()
        {
            List<Profesor> profesores = new List<Profesor>();
            profesores = administradorProfesores.obtenerProfesoresDB();
            //La propiedad DataSource permite el enlace de datos (Su origen de datos osea los datos que deveria mostrar(en este caso seria los profesores))
            //Con él, vinculamos una matriz a un ListBox en la pantalla y mostramos todas las cadenas. A medida que se realizan cambios en la Lista, actualizamos el control en la pantalla.
            DropListProfesor.DataSource = profesores;
            //Vincula una fuente de datos al control del servidor invocado y a todos sus controles secundarios.
            //DataBind (Lee los profesores y los carga a la lista profesor)

            DropListProfesor.DataBind();
            //(Obtiene de la lista de profesores y que solo muestre el campo "Apellido")
            DropListProfesor.DataTextField = "Apellido";
            //(Obtiene un valor agregado de la lista de profesores,en este caso el es el ID de cada uno de los profesores)
            DropListProfesor.DataValueField = "Id";
            DropListProfesor.DataBind();
        }



        private void CargarCurso(string idCurso)
        {
            AdmCurso administrador = new AdmCurso();

            Curso curso = new Curso();
            curso = administrador.obtenerCursoDBPorId(Convert.ToInt32(idCurso));

            txtNombre.Text = curso.Nombre;
            txtFechaInicio.Text = Convert.ToString(curso.FechaInicio);
            txtHora.Text = curso.Hora;
            txtPrecio.Text =curso.Precio.ToString().Replace(",", ".");
        }



        protected void btnGuardar_OnClick(object sender, EventArgs e)
        {
            //tomo los datos de la pantalla
            string nombre = txtNombre.Text;
            string FechaInicio = txtFechaInicio.Text;
            string Hora = txtHora.Text;
            string precio = txtPrecio.Text;
            string idProfesor = DropListProfesor.SelectedValue;
            //SelectedValue obtienen el valor del elemneto seleccionado

            Curso curso = new Curso();
            curso.Nombre = nombre;
            curso.FechaInicio = Convert.ToDateTime(FechaInicio);
            curso.Hora = Hora;
            curso.Precio = Convert.ToDecimal(precio);

            curso.Profesor = new Profesor();
            curso.Profesor.Id = Convert.ToInt32(idProfesor);
            

            if (this.accion == 1)
            {
                bool respuesta = administradorCursos.agregarCursoDB(curso);
                if (respuesta)
                {
                    labelCurso.Text = "Curso agregado a la DB";
                }
                else
                {
                    labelCurso.Text = "No se pudo guardar Curso";
                }
            }
            else
            {
                //codigo para editar
                curso.Id = Convert.ToInt32(this.idCurso);
                bool respuesta = administradorCursos.editarCursoDB(curso);
                if (respuesta)
                {
                    labelCurso.Text = "curso editado en la DB";
                }
                else
                {
                    labelCurso.Text = "No se pudo editar curso";
                }
            }

            //string infoAlumno = alumno1.MostrarAlumno(true);

            //labelAlumno.Text = infoAlumno;
        }

        protected void btnEliminar_OnClick(object sender, EventArgs e)
        {
            //instancio al admALumnos
            AdmCurso administrador = new AdmCurso();
            bool respuesta = administrador.eliminarCursoDB(Convert.ToInt32(this.idCurso));

            if (respuesta)
            {
                labelCurso.Text = "Curso Eliminado en la DB";
            }
            else
            {
                labelCurso.Text = "No se pudo eliminar Curso";
            }
        }
    }
}