using estimacion_proyecto.domain.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace estimacion_proyecto.core.Core
{
    public interface IUsuarioCore
    {

        /// <summary>
        /// Autenticar Usuario
        /// </summary>
        /// <param name="usuario"></param>
        /// <param name="contrasena"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public GeneralResponse AutenticacionUsuario(string usuario, string contrasena);
    }
}
