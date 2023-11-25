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
    public partial class Equipos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LlenarGrid();
        }

        protected void LlenarGrid()
        {
            string constr = ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT *  FROM  Equipos"))
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
            int resultado = Clases.ClaseEquipo.Agregar((ttipo.Text), tmodelo.Text);

            if (resultado > 0)
            {
                alertas("Equipo agregado con exito");
                ttipo.Text = string.Empty;
                tmodelo.Text = string.Empty;
                LlenarGrid();
            }
            else
            {
                alertas("Error al ingresar Equipo");

            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            int resultado = Clases.ClaseEquipo.Borrar(int.Parse(tcodigo.Text));

            if (resultado > 0)
            {
                alertas("Equipo ha sido borrado con exito");
                tcodigo.Text = string.Empty;
                LlenarGrid();
            }
            else
            {
                alertas("Error al borrar Equipo");

            }
        }


    
        protected void Button4_Click1(object sender, EventArgs e)
        {
            int resultado = Clases.ClaseEquipo.Modificar(int.Parse(tcodigo.Text), ttipo.Text, tmodelo.Text);

            if (resultado > 0)
            {
                alertas("Equipo ha sido modificado con exito");
                tcodigo.Text = string.Empty;
                ttipo.Text = string.Empty;
                tmodelo.Text = string.Empty;
                LlenarGrid();
            }
            else
            {
                alertas("Error al modificar Equipo");

            }
        }

        /*protected void Button4_Click(object sender, EventArgs e)
        {
            int resultado = Clases.ClaseEquipo.Modificar(int.Parse(ttipo.Text), tmodelo.Text);

            if (resultado > 0)
            {
                alertas("Equipo ha sido modificado con exito");
                ttipo.Text = string.Empty;
                tmodelo.Text = string.Empty;
                LlenarGrid();
            }
            else
            {
                alertas("Error al modificar Equipo");

            }
        }

        /*protected void Bconsulta_Click(object sender, EventArgs e)
        {
            {
                int codigo = int.Parse(tcodigo.Text);
                string constr = ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString;
                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand("SELECT * FROM Equipos WHERE ID ='" + codigo + "'"))


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
}