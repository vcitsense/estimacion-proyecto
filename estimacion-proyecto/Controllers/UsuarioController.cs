using estimacion_proyecto.core.Core;
using estimacion_proyecto.domain.Request;
using estimacion_proyecto.domain.Response;
using Microsoft.AspNetCore.Mvc;

namespace estimacion_proyecto.Controllers
{
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioCore _usuarioCore;
        private readonly ILogger<UsuarioController> _logger;

        public UsuarioController(IUsuarioCore usuarioCore, ILogger<UsuarioController> logger)
        {
            _usuarioCore = usuarioCore;
            _logger = logger;
        }

        /// <summary>
        /// Create or Update user
        /// </summary>
        /// <param name="input">UserDto</param>
        /// <returns> List<UserDto></returns>
        [HttpPost]
        [Route("AutenticacionUsuario")]
        public async Task<ActionResult<GeneralResponse>> AutenticacionUsuario([FromBody] AutenticacionModelo input)
        {
            try
            {
                return Ok(_usuarioCore.AutenticacionUsuario(input.Usuario, input.Contrasena));
            }
            catch (Exception ex)
            {

                return Unauthorized("Usuario invalido"); ;
            }           
        }
    }
}
