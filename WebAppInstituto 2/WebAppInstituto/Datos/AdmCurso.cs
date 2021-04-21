using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebAppInstituto.Modelo;

namespace WebAppInstituto.Datos
{
    public class AdmCurso
    {
        private AccesoDatos AccesoDatos;

        public AdmCurso()
        {
            AccesoDatos = new AccesoDatos("DESKTOP-V3AVL63\\MATIAS", "", "", "Instituto3");
        }

        public bool agregarCursoDB(Curso curso)
        {
            string insertQuery = "insert into Cursos(Nombre, FechaInicio, Hora, Precio, IdProfesor) ";
            insertQuery += $"values('{curso.Nombre}', '{curso.FechaInicio.ToString("yyyyMMdd")}', '{curso.Hora}', '{curso.Precio}', '{curso.Profesor.Id}')";

            SqlCommand command = new SqlCommand(insertQuery);

            int resultado = this.AccesoDatos.ejecQueryDevuelveInt(command);

            if (resultado == 1)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public bool editarCursoDB(Curso curso)
        {
            //TODO
            //string updateQuery = "";
            string updateQuery = $"update Cursos set Nombre='{curso.Nombre}', FechaInicio='{curso.FechaInicio}', Hora='{curso.Hora}', Precio='{curso.Precio}', IdProfesor='{curso.Profesor.Id}' ";
            updateQuery += $" where id={curso.Id}";

            SqlCommand command = new SqlCommand(updateQuery);

            int resultado = this.AccesoDatos.ejecQueryDevuelveInt(command);

            if (resultado == 1)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        //cargar cursos
        public List<Curso> obtenerCursosDB()
        {
            List<Curso> cursos = new List<Curso>();

            string selectQuery = "select * from cursos";

            SqlCommand command = new SqlCommand(selectQuery);

            SqlDataReader reader2 = AccesoDatos.ExecuteReader(command);
            while (reader2.Read())
            {
                Curso cursoAuxiliar = new Curso();
                cursoAuxiliar.Id = Convert.ToInt16(reader2[0]);
                cursoAuxiliar.Nombre = reader2[1].ToString();
                cursoAuxiliar.FechaInicio = Convert.ToDateTime(reader2[2]);
                cursoAuxiliar.Hora = reader2[3].ToString();
                cursoAuxiliar.Precio =  Convert.ToDecimal(reader2[4]);

                int idProfesor = Convert.ToInt32(reader2[5]);
                //tengo que construir el profesor y pbtener sus datos

                AdmProfesores admProfesores = new AdmProfesores();

                cursoAuxiliar.Profesor = admProfesores.obtenerProfesorDBPorId(idProfesor);

                cursos.Add(cursoAuxiliar);
                //Console.WriteLine(reader[0] + " " + reader[1] + " " + reader[2]);
            }
            reader2.Close();
            AccesoDatos.DesConectar();

            return cursos;
        }

        public Curso obtenerCursoDBPorId(int IdCurso)
        {
            Curso cursoAuxiliar = new Curso();

            string selectQuery = "select * from cursos where id= " + IdCurso;

            SqlCommand command = new SqlCommand(selectQuery);

            SqlDataReader reader2 = AccesoDatos.ExecuteReader(command);
            while (reader2.Read())
            {
                
                cursoAuxiliar.Id = Convert.ToInt16(reader2[0]);
                cursoAuxiliar.Nombre = reader2[1].ToString();
                cursoAuxiliar.FechaInicio = Convert.ToDateTime(reader2[2]);
                cursoAuxiliar.Hora = reader2[3].ToString();
                cursoAuxiliar.Precio = Convert.ToDecimal(reader2[4]);

                int idProfesor = Convert.ToInt32(reader2[5]);
                //tengo que construir el profesor y pbtener sus datos

                AdmProfesores admProfesores = new AdmProfesores();

                cursoAuxiliar.Profesor = admProfesores.obtenerProfesorDBPorId(idProfesor);
            }
            reader2.Close();
            AccesoDatos.DesConectar();

            return cursoAuxiliar;
        }

        public bool agregarAlumnoACursoDB(int IdCurso, int IdAlumno)
        {
            string insertQuery = "insert into CursosAlumnos(IdAlumno, IdCurso) ";
            insertQuery += $"values('{IdAlumno}', '{IdCurso}')";

            SqlCommand command = new SqlCommand(insertQuery);

            int resultado = this.AccesoDatos.ejecQueryDevuelveInt(command);

            if (resultado == 1)
            {
                return true;
            }
            else
            {
                return false;
            }

        }


        public bool eliminarCursoDB(int IdCurso)
        {
            string insertQuery = $"Delete cursos where id=" + IdCurso;


            SqlCommand command = new SqlCommand(insertQuery);

            int resultado = this.AccesoDatos.ejecQueryDevuelveInt(command);

            if (resultado == 1)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public List<Alumno> ObtenerAlumnosPorCurso(int IdCurso)
        {
            List<Alumno> alumnos = new List<Alumno>();
            //Seleccionar todos los alumnos (donde Id del Alumno sea = al CursosAlumnos.IdAlumno donde CursosAlumnos.IdCurso = IdCurso)
            string selectQuery = $"select * from alumnos a join CursosAlumnos ca on a.Id = ca.IdAlumno where ca.IdCurso = {IdCurso} ";

            SqlCommand command = new SqlCommand(selectQuery);

            SqlDataReader reader2 = AccesoDatos.ExecuteReader(command);
            while (reader2.Read())
            {
                Alumno alumnoAuxiliar = new Alumno();
                alumnoAuxiliar.Id = Convert.ToInt16(reader2[0]);
                alumnoAuxiliar.Nombre = reader2[1].ToString();
                alumnoAuxiliar.Apellido = reader2[2].ToString();
                alumnoAuxiliar.DNI = reader2[3].ToString();

                alumnos.Add(alumnoAuxiliar);
                //Console.WriteLine(reader[0] + " " + reader[1] + " " + reader[2]);
            }
            reader2.Close();
            AccesoDatos.DesConectar();

            return alumnos;
        }
    }
}