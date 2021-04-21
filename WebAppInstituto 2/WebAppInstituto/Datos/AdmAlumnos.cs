using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebAppInstituto.Modelo;

namespace WebAppInstituto.Datos
{
    public class AdmAlumnos
    {
        private AccesoDatos AccesoDatos;

        public AdmAlumnos()
        {
            AccesoDatos = new AccesoDatos("DESKTOP-V3AVL63\\MATIAS", "", "", "Instituto3");
        }
        //CREO UN METODO QUE AGREGUE LOS ALUMNOS A LA BD
        //lO CREO PUBLICO(PARA QUE PUEDAN LLAMAR A ESE METODO)
        //Le voy a poner que me devuelva un bool (OSEA UN VERDADERO O FALSO, SO LO PUDO AGREGAR A LA BD)
        //Como parametro va a recir el Alumno que tiene que agregar, por lo tanto LE AGREGAMOS LA CLASE ALUMNO CON TODOS LOS DATOS YA CARGADOS Y COMO NOMBRE LE PONEMOS alumno
        public bool agregarAlumnoDB(Alumno alumno)
        {
            string insertQuery = "insert into alumnos (Nombre, Apellido, DNI, Mail, Telefono, Cuota) ";
            insertQuery += $"values('{alumno.Nombre}', '{alumno.Apellido}', '{alumno.DNI}', '{alumno.Mail}', '{alumno.Telefono}', {alumno.Cuota})";
            //SqlCommand se encarga de ejecutar consultas contra la BD.
            SqlCommand command = new SqlCommand(insertQuery);

            int resultado = this.AccesoDatos.ejecQueryDevuelveInt(command);

            if(resultado==1)
            {
                return true;
            }
            else
            {
                return false;
            }
            
        }

        public bool editarAlumnoDB(Alumno alumno)
        {
            string insertQuery = $"update Alumnos set Nombre='{alumno.Nombre}', Apellido='{alumno.Apellido}', DNI='{alumno.DNI}', mail='{alumno.Mail}', Telefono='{alumno.Telefono}', Cuota='{alumno.Cuota}' ";
            insertQuery += $" where id={alumno.Id}";

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

        public bool eliminarAlumnoDB(int idAlumno)
        {
            string insertQuery = $"Delete alumnos where id=" + idAlumno;
            

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

        public List<Alumno> obtenerAlumnosDB()
        {
            List<Alumno> alumnos = new List<Alumno>();
            string selectQuery = "select * from alumnos ";
            SqlCommand command = new SqlCommand(selectQuery);
            SqlDataReader reader2 = AccesoDatos.ExecuteReader(command);
            //Read te lee TODA LA PRIMERA LINEA
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

        public Alumno obtenerAlumnosDBPorId(int IdAlumno)
        {
            Alumno alumnoAuxiliar = new Alumno();

            string selectQuery = "select * from alumnos where id= " + IdAlumno;

            SqlCommand command = new SqlCommand(selectQuery);

            SqlDataReader reader2 = AccesoDatos.ExecuteReader(command);
            while (reader2.Read())
            {
                alumnoAuxiliar.Id = Convert.ToInt16(reader2[0]);
                alumnoAuxiliar.Nombre = reader2[1].ToString();
                alumnoAuxiliar.Apellido = reader2[2].ToString();
                alumnoAuxiliar.DNI = reader2[3].ToString();
                alumnoAuxiliar.Mail = reader2[4].ToString();
                alumnoAuxiliar.Telefono = reader2[5].ToString();
                alumnoAuxiliar.Cuota = Convert.ToDecimal(reader2[6]);
                //Console.WriteLine(reader[0] + " " + reader[1] + " " + reader[2]);
            }
            reader2.Close();
            AccesoDatos.DesConectar();

            return alumnoAuxiliar;
        }
    }
}