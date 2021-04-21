using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebAppInstituto.Modelo;

namespace WebAppInstituto.Datos
{
    public class AdmProfesores
    {
        private AccesoDatos AccesoDatos;

        public AdmProfesores()
        {
            AccesoDatos = new AccesoDatos("DESKTOP-V3AVL63\\MATIAS", "", "", "Instituto3");
        }

        public bool agregarProfesorDB(Profesor profesor)
        {
            string insertQuery = "insert into Profesores (Nombre, Apellido, DNI, Mail, Telefono, Sueldo) ";
            insertQuery += $"values('{profesor.Nombre}', '{profesor.Apellido}', '{profesor.DNI}', '{profesor.Mail}', '{profesor.Telefono}', {profesor.Sueldo})";

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

        public List<Profesor> obtenerProfesoresDB()
        {
            List<Profesor> profesores = new List<Profesor>();

            string selectQuery = "select * from profesores order by nombre ";

            SqlCommand command = new SqlCommand(selectQuery);

            SqlDataReader reader2 = AccesoDatos.ExecuteReader(command);
            while (reader2.Read())
            {
                Profesor profesorAuxiliar = new Profesor();
                profesorAuxiliar.Id = Convert.ToInt16(reader2[0]);
                profesorAuxiliar.Nombre = reader2[1].ToString();
                profesorAuxiliar.Apellido = reader2[2].ToString();
                profesorAuxiliar.DNI = reader2[3].ToString();
                profesorAuxiliar.Mail = reader2[4].ToString();
                profesorAuxiliar.Telefono = reader2[5].ToString();
                profesorAuxiliar.Sueldo = Convert.ToDecimal(reader2[6]);

                profesores.Add(profesorAuxiliar);
                //Console.WriteLine(reader[0] + " " + reader[1] + " " + reader[2]);
            }
            reader2.Close();
            AccesoDatos.DesConectar();

            return profesores;
        }

        public bool eliminarProfesorDB(int idProfesor)
        {
            string insertQuery = $"Delete profesores where id=" + idProfesor;


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
        public Profesor obtenerProfesorDBPorId(int IdProfesor)
        {
            Profesor profesorAuxiliar = new Profesor();

            string selectQuery = "select * from profesores where id= " + IdProfesor;

            SqlCommand command = new SqlCommand(selectQuery);

            SqlDataReader reader2 = AccesoDatos.ExecuteReader(command);
            while (reader2.Read())
            {
                profesorAuxiliar.Id = Convert.ToInt16(reader2[0]);
                profesorAuxiliar.Nombre = reader2[1].ToString();
                profesorAuxiliar.Apellido = reader2[2].ToString();
                profesorAuxiliar.DNI = reader2[3].ToString();
                profesorAuxiliar.Mail = reader2[4].ToString();
                profesorAuxiliar.Telefono = reader2[5].ToString();
                profesorAuxiliar.Sueldo = Convert.ToDecimal(reader2[6]);
                //Console.WriteLine(reader[0] + " " + reader[1] + " " + reader[2]);
            }
            reader2.Close();
            AccesoDatos.DesConectar();

            return profesorAuxiliar;
        }


        public bool editarProfesorDB(Profesor profesor)
        {
            string insertQuery = $"update profesores set Nombre='{profesor.Nombre}', Apellido='{profesor.Apellido}', DNI='{profesor.DNI}', mail='{profesor.Mail}', Telefono='{profesor.Telefono}', Sueldo='{profesor.Sueldo}' ";
            insertQuery += $" where id={profesor.Id}";

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
    }
}