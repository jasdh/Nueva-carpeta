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
        try
        {
            Dictionary<string, string> persona = validarPersonas.ObtenerPersona(IDPersonaText.Text);

            Score.Text = String.Format("Información para <b>{0} {1}</b><br>" +
                "<b>ID:</b> {2} <br> " +
                "<b>Cargo</b> {3} <br> " +
                "<b>Direccion</b> {4} <br> " +
                "<b>Telefono</b> {5} <br> " +
                "<b>Celular</b> {6} <br> " +
                "<b>Fecha de registro</b> {7} <br> " +
                "<b>Observaciones</b> {8} <br> " +
                "<b>ID de ciudad</b> {9} <br> " +
                "<b>Edad</b> {10} <br> " +
                "<b>Score: {3}</b>", persona["Nombre"], persona["Apellidos"], persona["Id"], persona["Cargo"], persona["Direccion"], persona["Telefono"], persona["Celular"], persona["fechaRegistro"], persona["Observaciones"], persona["idCiudad"], persona["Edad"], persona["Score"]);
        }
        catch (Exception ex)
        {
            Score.Text = "Información para el usuario no encontrada." + ex.GetType().ToString();
        }
    }
}