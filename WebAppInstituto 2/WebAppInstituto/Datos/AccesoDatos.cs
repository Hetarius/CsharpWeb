using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Transactions;
using System.Web;

namespace WebAppInstituto.Datos
{
    public class AccesoDatos
    {

        //Representa una conexión a una base de datos de SQL Server. No se puede heredar esta clase.
        //Un objeto/clase SqlConnection representa una sesión única para un origen de datos de SQL Server. Con un sistema de base de datos cliente/servidor, es equivalente a una conexión de red al servidor. 

        private SqlConnection ConnectionBD = new SqlConnection();
        public string strcondatos;
        //public string strcondatosSucursal;
       
        //datos de conexion
        private string serverBD;
        private string usuarioBD;
        private string PasswordBD;
        private string basedatos;

        public AccesoDatos(string server, string usuario, string password,
            string baseDatos)
        {
            //cargo las variables desde el xml de configuración
            this.serverBD = server;
            this.usuarioBD = usuario;
            this.PasswordBD = password;
            this.basedatos = baseDatos;

            //this.serverBD = "timesolution.database.windows.net";
            //this.usuarioBD = "TSAdmin";
            //this.PasswordBD = "Timesol1";
            //this.basedatos = "gestion_gestion";

            //armo conexion a la BD
            //strcondatos = @"Data Source=" + this.serverBD + ";Initial Catalog=" + this.basedatos + ";User ID=" + usuarioBD + ";Password=" + this.PasswordBD;
            //Initial Cataloges el nombre de la base de datos que utilizará la cadena de conexión, que se encuentra en el servidor que se especificó en la Data Sourceparte de la cadena de conexión.
            strcondatos = $"Data Source=" + this.serverBD + ";Initial Catalog=" + this.basedatos + ";Integrated Security=true";


        }
        public AccesoDatos()
        {

        }

        public void Conectar()
        {
            try
            {
                if (this.ConnectionBD.State == 0)
                {

                    ConnectionBD.ConnectionString = strcondatos;
                    ConnectionBD.Open();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public bool ComprobarConexion()
        {
            try
            {
                if (!ComprobarConexionADO())
                    return false;
                else
                    return true;

            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool ComprobarConexionADO()
        {
            try
            {
                if (this.ConnectionBD.State == 0)
                {
                    ConnectionBD.ConnectionString = strcondatos;
                    ConnectionBD.Open();
                }
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }


        /// <summary>
        /// Desconecta la conexión
        /// </summary>
        public void DesConectar()
        {
            try
            {
                ConnectionBD.Close();
            }
            catch (Exception e)
            {
                throw e;
            }
        }


        /// <summary>
        /// Ejecuta un string Command de selección y devuelve un OdbcDataReader.
        /// Aclaración: Luego de recorrer el DataReader, recordar cerrar la conexión (AccesoDatosOdbc.DesConectar())
        /// </summary>
        /// <param name="Command"></param>
        /// <returns></returns>
        public SqlDataReader ExecuteReader(SqlCommand Command)
        {
            try
            {
                Command.Connection = ConnectionBD;
                //Da.CommandTimeout = 0; //Para que no se vaya por timeout la conexión
                Conectar();
                SqlDataReader Dr = Command.ExecuteReader();
                return Dr;
            }
            catch (Exception e)
            {

                DesConectar();
                throw e;
            }
            finally
            {

            }
        }

        //PAra update o insert
        public SqlCommand ejecQuery(SqlCommand cmd)
        {
            int resp = 0;
            try
            {

                cmd.Connection = this.ConnectionBD;
                cmd.CommandTimeout = 60;
                Conectar();
                resp = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                DesConectar();
            }
            return cmd;
        }

        public int ejecQueryDevuelveInt(SqlCommand cmd)
        {
            int resp = 0;
            try
            {
                cmd.Connection = this.ConnectionBD;
                cmd.CommandTimeout = 60;
                Conectar();
                resp = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                DesConectar();
            }
            return resp;
        }

        public SqlCommand ejecQueryCommit(SqlCommand cmd, CommittableTransaction TRANS)
        {
            int resp = 0;
            try
            {
                cmd.Connection = this.ConnectionBD;
                cmd.CommandTimeout = 180;
                //Conectar();
                cmd.Connection.EnlistTransaction(TRANS);
                resp = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                TRANS.Rollback();
                throw;
            }
            finally
            {
                //DesConectar();
            }
            return cmd;
        }

        public DataTable execDTCommit(SqlCommand Command, CommittableTransaction TRANS)
        {
            try
            {
                Command.Connection = this.ConnectionBD;
                Conectar();
                Command.Connection.EnlistTransaction(TRANS);
                SqlDataAdapter da = new SqlDataAdapter(Command);

                DataTable dt = new DataTable();
                da.Fill(dt);

                return dt;
            }
            catch (Exception e)
            {
                DesConectar();
                throw e;
            }
            finally
            {
                //todo Rodrigo
                DesConectar();
            }
        }

        /// <summary>
        /// Ejecuta un sqlCommand de store y lo devuelve
        /// </summary>
        /// <param name="cmd"></param>
        /// <returns></returns>
        public SqlCommand ejecCommand(SqlCommand cmd)
        {
            try
            {
                cmd.Connection = this.ConnectionBD;

                Conectar();
                int resp = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                DesConectar();
            }
            return cmd;
        }

        public DataTable execDT(SqlCommand Command)
        {
            try
            {
                Command.Connection = this.ConnectionBD;
                Conectar();
                SqlDataAdapter da = new SqlDataAdapter(Command);

                DataTable dt = new DataTable();
                da.Fill(dt);

                return dt;
            }
            catch (Exception e)
            {
                DesConectar();
                throw e;
            }
            finally
            {
                //todo Rodrigo
                DesConectar();
            }
        }

        public DataTable execDT2(SqlCommand Command)
        {
            try
            {
                Command.Connection = this.ConnectionBD;

                Conectar();
                SqlDataAdapter da = new SqlDataAdapter(Command);

                DataTable dt = new DataTable();
                da.Fill(dt);

                return dt;
            }
            catch (Exception e)
            {
                //DesConectar();
                throw e;
            }
            finally
            {
                DesConectar();
            }
        }
    }
}