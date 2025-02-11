using estimacion_proyecto.domain.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace estimacion_proyecto.data
{
    public interface IUsuarioDatos
    {

        /// <summary>
        /// Valida usuario y password para autenticacion
        /// </summary>
        /// <param name="usuario"></param>
        /// <param name="contrasena"></param>
        /// <returns>UsuarioDto</returns>
        public UsuarioDto AutenticacionUsuario(string usuario, string contrasena);
    }
}
