using Proyecto_Tokens.Models;
using System.Collections.Generic;

namespace Proyecto_Tokens.Constants
{
    public static class UserConstans
    {
        public static List<UserModels> User = new List<UserModels>()
        {
            new UserModels()
            {
                ID = 1,
                Nombre_Usuario = "admin",
                Contraseña = "admin123",
                Correo_Electronico = "admin@gmail.com",
                Rol = "Administrador"

                
            },
            new UserModels
            {
                ID = 2,
                Nombre_Usuario = "cliente",
                Contraseña = "cliente123",
                Correo_Electronico = "cliente@gmail.com",
                Rol = "Cliente"
            }
            
        };
    }
}
