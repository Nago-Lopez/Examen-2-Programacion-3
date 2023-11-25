using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace Examen2.Clases
{
    public class ClaseUsuario
    {

        public static int ID { get; set; }
        public static string Nombre { get; set; }
        public static string CorreoElectronico { get; set; }
        public static string Telefono { get; set; }

        public ClaseUsuario(int Id, string nombre, string Correo, string Tel)
        {

            ID = Id;
            Nombre = nombre;
            CorreoElectronico = Correo;
            Telefono = Tel;

        }

        public ClaseUsuario() { }

    

       public static int Agregar(string texto, string text1, string text2)
        {
            int retorno = 0;

            SqlConnection Conn = new SqlConnection();
            try
            {
                using (Conn = DBConn.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("AGREGARUSUARIOS", Conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@NOMBRE", texto));
                    cmd.Parameters.Add(new SqlParameter("@CORREO", text1));
                    cmd.Parameters.Add(new SqlParameter("@TELEFONO", text2));


                    retorno = cmd.ExecuteNonQuery();
                }
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                retorno = -1;
            }
            finally
            {
                Conn.Close();
            }

            return retorno;

        }

        public static int Borrar(int cod)
        {
            int retorno = 0;

            SqlConnection Conn = new SqlConnection();
            try
            {
                using (Conn = DBConn.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("BORRARUSUARIOS", Conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@CODIGO", cod));



                    retorno = cmd.ExecuteNonQuery();
                }
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                retorno = -1;
            }
            finally
            {
                Conn.Close();
            }

            return retorno;

        }

        public static int Modificar(int cod, string texto, string text1, string text2)
        {
            int retorno = 0;

            SqlConnection Conn = new SqlConnection();
            try
            {
                using (Conn = DBConn.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("ACTUALIZARUSUARIOS", Conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@ID", cod));
                    cmd.Parameters.Add(new SqlParameter("@NOMBRE", texto));
                    cmd.Parameters.Add(new SqlParameter("@CORREO", text1));
                    cmd.Parameters.Add(new SqlParameter("@TELEFONO", text2));


                    retorno = cmd.ExecuteNonQuery();
                }
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                retorno = -1;
            }
            finally
            {
                Conn.Close();
            }

            return retorno;

        }

       /* public static List<ClaseUsuario> consultaFiltro(int id)
        {
            int retorno = 0;

            SqlConnection Conn = new SqlConnection();
            List<ClaseUsuario> usuarios = new List<ClaseUsuario>();
            try
            {

                using (Conn = DBConn.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("CONSULTAR_FILTROUSUARIOS", Conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@id", id));
                    retorno = cmd.ExecuteNonQuery();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ClaseUsuario ClaseUsuario = new ClaseUsuario(reader.GetInt32(0), reader.GetString(1));  // instancia
                            usuarios.Add(ClaseUsuario);

                        }


                    }
                }
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                return usuarios;
            }
            finally
            {
                Conn.Close();
                Conn.Dispose();
            }

            return usuarios;
        }*/

    }
}