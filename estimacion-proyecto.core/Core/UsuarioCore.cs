using estimacion_proyecto.data;
using estimacion_proyecto.domain.Dto;
using estimacion_proyecto.domain.Response;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace estimacion_proyecto.core.Core
{
    public class UsuarioCore : IUsuarioCore
    {
        private readonly IConfiguration _configuration;
        private readonly IUsuarioDatos _usuarioDatos;
        private readonly ILogger<UsuarioCore> _logger;

        public UsuarioCore(
            ILogger<UsuarioCore> logger,
            IConfiguration configuration,
            IUsuarioDatos usuarioDatos)
        {
            _configuration = configuration;
            _logger = logger;
            _usuarioDatos = usuarioDatos;
        }

        #region Token

        /// <summary>
        /// Autenticar Usuario
        /// </summary>
        /// <param name="usuario"></param>
        /// <param name="contrasena"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public GeneralResponse AutenticacionUsuario(string usuario, string contrasena)
        {

            var userDb = _usuarioDatos.AutenticacionUsuario(usuario, contrasena);

            if (userDb == null)
            {
                throw new ArgumentException("Usuario Invalido");
            }
            var oReturn = new GeneralResponse();

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(this._configuration["JWT:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[] {
                        new Claim("UserName", usuario)
                    };

            var currentDate = DateTime.UtcNow;

            var token = new System.IdentityModel.Tokens.Jwt.JwtSecurityToken(
                claims: claims,
                expires: currentDate.AddMinutes(int.Parse(this._configuration["JWT:Expire"])),
                signingCredentials: credentials);


            string tokenString = new JwtSecurityTokenHandler().WriteToken(token);


            var userData = new
            {
                Token = tokenString,
                IdUsuario = userDb.IdUsuario,
                Usuario = userDb.Usuario,
                IdRol = userDb.IdRol,
                endSessionDate = DateTime.Now.AddMinutes(int.Parse(this._configuration["JWT:Expire"])),
                generatedTokenDate = DateTime.Now
            };

            oReturn.Data = userData;

            return oReturn;
        }

        #endregion

    }
}
