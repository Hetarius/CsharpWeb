using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAppInstituto.Modelo
{
    public class Profesor
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string DNI { get; set; }
        public string Mail { get; set; }
        public string Telefono { get; set; }
        public decimal Sueldo { get; set; }

        public Profesor()
        {

        }

        public Profesor(string nombre, string apellido, string dni, string mail, string telefono, decimal sueldo)
        {
            Nombre = nombre;
            Apellido = apellido;
            DNI = dni;
            Mail = mail;
            Telefono = telefono;
            Sueldo = sueldo;
        }

        public string MostrarProfesor(bool mostrarCompleto)
        {
            if (mostrarCompleto == true)
            {
                return this.Nombre + " " + this.Apellido + " " + this.DNI + " " + this.Mail + " " + this.Sueldo;
            }
            else
            {
                return this.Nombre + " " + this.Apellido;
            }

        }


        public string MostrarProfesorHTML()
        {
            string html = "<tr>";
            html += $"<th scope=\"row\">{this.Id}</th>";
            html += $"<td>{this.Nombre}</td>";
            html += $"<td>{this.Apellido}</td>";
            html += $"<td>{this.DNI}</td>";
            html += $"<td><a class=\"btn btn-primary\"" +
                $" href=\"ProfesoresABMPage.aspx?accion=2&idProfesor={this.Id}\">Editar</a></td>";
            html += "</tr>";

            return html;

        }
    }
}