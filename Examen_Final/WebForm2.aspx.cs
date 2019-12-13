using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Examen_Final
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        //Boton de agregar
        protected void Unnamed1_Click(object sender, EventArgs e)
        {
            BdComun _BdComun = new BdComun();
            _BdComun.ObtenerConexion();
            List<string> aux = new List<string>();

            if (_BdComun.AbrirConexion() == true)
            {
                ClientScript.RegisterStartupScript(GetType(), "msgcreat", "msgcreat();", true);
                aux.Add(txtNombre.Text);
                aux.Add(txtApellido.Text);
                aux.Add(txtDireccion.Text);
                _BdComun.Agregar(int.Parse(txtrut.Text), aux);

            }
        }
        //Boton de buscar
        protected void Unnamed3_Click(object sender, EventArgs e)
        {
            BdComun _BdComun = new BdComun();
            _BdComun.ObtenerConexion();
            List<string> regid = null;
            Boolean conec = _BdComun.AbrirConexion();

            _BdComun.CerraConexion();

            _BdComun.CerraConexion();
            if (_BdComun.AbrirConexion() == true)
            {
                List<string> regi = _BdComun.Consulta(int.Parse(txtrut.Text));
                if (regi != null)
                {
                    txtNombre.Text = regi[0];
                    txtApellido.Text = regi[1];
                    txtDireccion.Text = regi[2];

                }
                else
                {
                    ClientScript.RegisterStartupScript(GetType(), "Mensaje", "mensaje();", true);
                    txtNombre.Text = "";
                    txtApellido.Text = "";
                    txtDireccion.Text = "";
                }
            }
        }
        //Boton de modificar
        protected void Button1_Click(object sender, EventArgs e)
        {
            BdComun _BdComun = new BdComun();
            _BdComun.ObtenerConexion();
            List<string> aux = new List<string>();
            if (_BdComun.AbrirConexion() == true)
            {
                ClientScript.RegisterStartupScript(GetType(), "msgupdea", "msgupdea();", true);
                aux.Add(txtNombre.Text);
                aux.Add(txtApellido.Text);
                aux.Add(txtDireccion.Text);
                _BdComun.Actualizar(int.Parse(txtrut.Text), aux);

            }
        }
        //Boton de eliminar
        protected void Button2_Click(object sender, EventArgs e)
        {
            BdComun _BdComun = new BdComun();
            _BdComun.ObtenerConexion();
            if (_BdComun.AbrirConexion() == true)
            {
                ClientScript.RegisterStartupScript(GetType(), "msgdelet", "msgdelet();", true);
                _BdComun.Borrar(int.Parse(txtrut.Text));
            }

        }
        //Boton de Volver
        protected void Unnamed2_Click(object sender, EventArgs e)
        {
            ClientScript.RegisterStartupScript(GetType(), "Volver", "volver();", true);
        }

    }
}