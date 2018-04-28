using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace WSDataCredito
{
    public class WSValidarPersonas : IWSValidarPersonas
    {
        private MySqlConnection db = new MySqlConnection();

        private MySqlConnection MySqlConnection()
        {
            string host = "127.0.0.1";
            string usr  = "root";
            string pwd  = "";
            string dbName = "datacredito";

            db.ConnectionString = "Server = " + host + "; database = " + dbName + "; uid = " + usr + "; pwd = " + pwd + ";";

            try
            {
                db.Open();
                return db;
            }
            catch (Exception e)
            {

            }
            return db;
        }
        public Dictionary<string, string> ObtenerPersona(string IdPersona)
        {
            MySqlConnection db = MySqlConnection();
            string query = String.Format("SELECT id, nombre, apellidos, idCiudad, edad, score, telefono, celular, date_format(fecha_registro, '%Y-%m-%d') as fecha_registro, observaciones, direccion FROM `personas` where id = '{0}'", IdPersona);
            MySqlCommand _query = new MySqlCommand(query, db);
            MySqlDataReader datos = _query.ExecuteReader();
            Dictionary<string, string> _usuario = new Dictionary<string, string>();

            
            if (datos.HasRows)
            {
                while (datos.Read())
                {
                    _usuario["Id"]              = datos.GetString(0);
                    _usuario["Nombre"]          = datos.GetString(1);
                    _usuario["Apellidos"]       = datos.GetString(2);
                    _usuario["Cargo"]           = datos.GetString(6);
                    _usuario["Direccion"]       = datos.GetString(10);
                    _usuario["Celular"]         = datos.GetString(6);
                    _usuario["Telefono"]        = datos.GetString(7);
                    _usuario["fechaRegistro"]   = datos.GetString(8);
                    _usuario["Observaciones"]   = datos.GetString(9);
                    _usuario["idCiudad"]        = datos.GetString(3);
                    _usuario["Edad"]            = datos.GetInt16(4).ToString();
                    _usuario["Score"]           = datos.GetUInt16(5).ToString();
                }
            }
            else
            {
                _usuario["Error"] = "Usuario no encontrado";
            }
            return _usuario;
        }
        public Dictionary<string, string> Login(string IdPersona, string Password)
        {
            MySqlConnection db = MySqlConnection();
            string query = String.Format("SELECT id, nombre, apellidos direccion FROM `personas` where id = '{0}' and clave = '{1}'", IdPersona, Password);

            MySqlCommand _query = new MySqlCommand(query, db);
            MySqlDataReader datos = _query.ExecuteReader();
            Dictionary<string, string> datosUsuario = new Dictionary<string, string>();

            if (datos.HasRows)
            {
                System.Diagnostics.Debug.WriteLine("Inicio de la validación");

                while (datos.Read())
                {
                    datosUsuario["id"]              = datos.GetValue(0).ToString();
                    datosUsuario["nombre"]          = datos.GetValue(1).ToString();
                    datosUsuario["apellidos"]       = datos.GetValue(2).ToString();
                    datosUsuario["id_respuesta"]    = "101";
                    datosUsuario["des_respuesta"]   = "Login exitoso";

                }
            }
            else
            {
                datosUsuario["id_resultado"]  = "100";
                datosUsuario["des_resultado"] = "Usuario no encontrado";
            }

            return datosUsuario;

        }
        public bool ModificarPersona(string idPersona)
        {
            MySqlConnection db = MySqlConnection();
            string query = String.Format("SELECT id, nombre, apellidos, idCiudad, edad, score, telefono, celular, date_format(fecha_registro, '%Y-%m-%d') as fecha_registro, observaciones, direccion FROM `personas` where id = '{0}'", IdPersona);
            MySqlCommand _query = new MySqlCommand(query, db);
            MySqlDataReader datos = _query.ExecuteReader();
            return true;
        }
    }
}
