using estimacion_proyecto.domain.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace estimacion_proyecto.data
{
    public class UsuarioDatos : IUsuarioDatos
    {
        private readonly ProyectoDbContext _DbContext;

        public UsuarioDatos(ProyectoDbContext dbContext)
        {
            _DbContext = dbContext;
        }

        /// <summary>
        /// Valida usuario y password para autenticacion
        /// </summary>
        /// <param name="usuario"></param>
        /// <param name="contrasena"></param>
        /// <returns>UsuarioDto</returns>
        public UsuarioDto AutenticacionUsuario(string usuario, string contrasena)
        {
            try
            {
                return _DbContext.Usuarios.Where(x => x.Usuario == usuario && x.Contrasena == contrasena).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw;

            }
        }
    }
}