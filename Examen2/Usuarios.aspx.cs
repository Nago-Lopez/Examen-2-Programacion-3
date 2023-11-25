using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Examen2.Clases;

namespace Examen2
{
    public partial class Usuarios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LlenarGrid();
            }
        }

        protected void LlenarGrid()
        {
            string constr = ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT *  FROM  Usuarios"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            datagrid.DataSource = dt;
                            datagrid.DataBind();  // actualizar el grid view
                        }
                    }
                }
            }
        }

        public void alertas(String texto)
        {
            string message = texto;
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("<script type = 'text/javascript'>");
            sb.Append("window.onload=function(){");
            sb.Append("alert('");
            sb.Append(message);
            sb.Append("')};");
            sb.Append("</script>");
            ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", sb.ToString());

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            int resultado = Clases.ClaseUsuario.Agregar(tnombre.Text, tcorreo.Text, ttelefono.Text);

            if (resultado > 0)
            {
                alertas("Usuario agregado con exito");
                tnombre.Text = string.Empty;
                tcorreo.Text = string.Empty;
                ttelefono.Text = string.Empty;
                LlenarGrid();
            }
            else
            {
                alertas("Error al ingresar usuario");

            }


            /*
          

            /*protected void Bconsulta_Click(object sender, EventArgs e)
            {
                {
                    int codigo = int.Parse(tcodigo.Text);
                    string constr = ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString;
                    using (SqlConnection con = new SqlConnection(constr))
                    {
                        using (SqlCommand cmd = new SqlCommand("SELECT * FROM Usuarios WHERE ID ='" + codigo + "'"))


                        using (SqlDataAdapter sda = new SqlDataAdapter())
                        {
                            cmd.Connection = con;
                            sda.SelectCommand = cmd;
                            using (DataTable dt = new DataTable())
                            {
                                sda.Fill(dt);
                                datagrid.DataSource = dt;
                                datagrid.DataBind();  // actualizar el grid view
                            }
                        }
                    }
                }
            }*/
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            int resultado = Clases.ClaseUsuario.Borrar(int.Parse(tcodigo.Text));

            if (resultado > 0)
            {
                alertas("Usuario ha sido borrado con exito");
                tcodigo.Text = string.Empty;
                LlenarGrid();
            }
            else
            {
                alertas("Error al usuario tecnico");

            }
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            int resultado = Clases.ClaseUsuario.Modificar(int.Parse(tcodigo.Text), tnombre.Text, tcorreo.Text, ttelefono.Text);

            if (resultado > 0)
            {
                alertas("Usuario ha sido modificado con exito");
                tcodigo.Text = string.Empty;
                tnombre.Text = string.Empty;
                tcorreo.Text = string.Empty;
                ttelefono.Text = string.Empty;
                LlenarGrid();
            }
            else
            {
                alertas("Error al modificar Usuario");

            }

        }

        protected void Bconsulta_Click(object sender, EventArgs e)
        {

        }
    }
}