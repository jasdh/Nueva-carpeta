using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class index : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Submit_Click(object sender, EventArgs e)
    {
        WSDatacredito.WSValidarPersonasClient validarPersonas = new WSDatacredito.WSValidarPersonasClient();
        Dictionary<string, string> datosUsuario = validarPersonas.Login(IDPersonaText.Text, PwdText.Text);

        if(datosUsuario.ContainsKey("id_respuesta") && datosUsuario["id_respuesta"] != "100")
        {
            Score.Text = datosUsuario["id"] + " " + datosUsuario["nombre"];
            Response.Redirect("reporte.aspx");
        }
        else
        {
            Score.Text = "usuario no encontrado";
        }
    }
}