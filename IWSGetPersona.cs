using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace WSDataCredito
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IWSValidarPersonas" en el código y en el archivo de configuración a la vez.
    [ServiceContract] public interface IWSValidarPersonas
    {
        [OperationContract] Dictionary<string, string> Login(string IdPersona, string Password);
        [OperationContract] Dictionary<string, string> ObtenerPersona(string IdPersona);
    }
}
