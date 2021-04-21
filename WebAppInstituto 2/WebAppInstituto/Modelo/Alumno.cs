using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAppInstituto.Modelo
{
    public class Alumno
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string DNI { get; set; }
        public string Mail { get; set; }
        public string Telefono { get; set; }
        public decimal Cuota { get; set; }

        public Alumno()
        {

        }

        public Alumno(string nombre, string apellido, string dni, string mail, string telefono, decimal cuota)
        {
            Nombre = nombre;
            Apellido = apellido;
            DNI = dni;
            Mail = mail;
            Telefono = telefono;
            Cuota = cuota;
        }

        //public string MostrarAlumno(bool mostrarCompleto)
        //{
        //    if (mostrarCompleto == true)
        //    {
        //        return Nombre + " " +
        //            Apellido + ": Documento " + DNI + " " + Cuota
        //            + " " + Telefono + " " + Mail;
        //    }
        //    else//me piden alumno simple
        //    {
        //        return Nombre + " " + Apellido + " " + Telefono;
        //    }

        //}

        public string MostrarAlumnoHTML(int mostrarSelccionar, int idCurso)
        {

            string html = "<tr>";
            html += $"<th scope=\"row\">{this.Id}</th>";
            html += $"<td>{this.Nombre}</td>";
            html += $"<td>{this.Apellido}</td>";
            html += $"<td>{this.DNI}</td>";
             
           
            if (mostrarSelccionar==2)
            {
                html += $"<td><a class=\"btn btn-primary\"" +
           $" href=\"AlumnoAgregado.aspx?idCurso={idCurso}&idAlumno={this.Id}\">Seleccionar</a></td>";

            }
            else
            {
                //mostrarSelccionar es distinto de de 3 me gregue el boton
                if (mostrarSelccionar!=3)
                {
                    html += $"<td><a class=\"btn btn-primary\"" +
              $" href=\"AlumnosABMPage.aspx?accion=2&idAlumno={this.Id}\">Editar</a></td>";
                }
               

                //html += $"<td><a class=\"btn btn-primary\"" +
                //   $" href=\"AlumnosABMPage.aspx?accion=1\">Agregar</a></td>";
            }
            html += "</tr>";
            return html;

        }

    }
}