using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAppInstituto.Modelo
{
    public class Curso
    {
        public int Id { get; set; }

        public string Nombre { get; set; }

        public DateTime FechaInicio { get; set; }

        public string Hora { get; set; }

        public decimal Precio { get; set; }

        public Profesor Profesor { get; set; }

        public List<Alumno> Alumnos = new List<Alumno>();

        public string MostrarCursoHTML()
        {

            string html = "<tr>";
            html += $"<th scope=\"row\">{this.Id}</th>";
            html += $"<td>{this.Nombre}</td>";
            html += $"<td>{this.FechaInicio.ToString("dd/MM/yyyy")}</td>";
            html += $"<td>{this.Hora}</td>";
            html += $"<td>{this.Precio}</td>";
            html += $"<td>{this.Profesor.Nombre} {this.Profesor.Apellido}</td>";
            html += $"<td><a class=\"btn btn-primary\"" +
                    $" href=\"CursosABMPage.aspx?accion=2&idCurso={this.Id}\">Editar</a></td>";
            //if (true)
            //{
            //    html += $"<td>< a class=\"btn btn-primary\" href=\"AlumnosABMPage.aspx?accion=1\">Agregar</a></td>";
            //}
            html += $"<td><a class=\"btn btn-primary\"" +
                    $" href=\"AlumnosPage.aspx?accion=2&idCurso={this.Id}\">AgregarAlumno</a></td>";


            html += $"<td><a class=\"btn btn-primary\"" +
                   $" href=\"AlumnosPage.aspx?accion=3&idCurso={this.Id}\">Ver Alumnos</a></td>";
            html += "</tr>";

            return html;

        }
    }
}