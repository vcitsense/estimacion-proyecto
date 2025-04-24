using estimacion_proyecto.core.Core;
using estimacion_proyecto.domain.Dto;
using estimacion_proyecto.domain.Request;
using estimacion_proyecto.domain.Response;
using Microsoft.AspNetCore.Mvc;

namespace estimacion_proyecto.Controllers
{
    [Route("api/[controller]")]
    public class ProyectoController : ControllerBase
    {
        private readonly IProyectoCore _proyectoCore;
        private readonly ILogger<UsuarioController> _logger;

        public ProyectoController(IProyectoCore proyectoCore, ILogger<UsuarioController> logger)
        {
            _proyectoCore = proyectoCore;
            _logger = logger;
        }

        #region Entidades

        /// <summary>
        /// Consultar listado de entidades
        /// </summary>
        /// <returns>List<EntidadDto></returns>
        [HttpGet]
        [Route("ConsultarEntidades")]
        public async Task<ActionResult<GeneralResponse>> ConsultarEntidades()
        {
            return Ok(_proyectoCore.ConsultarEntidades());
        }


        /// <summary>
        /// Crea o actualiza entidad
        /// </summary>
        /// <returns>List<EntidadDto></returns>
        [HttpPost]
        [Route("UpsertEntidad")]
        public async Task<ActionResult<GeneralResponse>> UpsertEntidad([FromBody] EntidadDto input)
        {
            try
            {
                return Ok(_proyectoCore.UpsertEntidad(input));
            }
            catch (Exception ex)
            {

                return Unauthorized("Usuario invalido"); ;
            }
        }


        #endregion


        #region Proyectos

        /// <summary>
        /// Consultar proyectos por entidad
        /// </summary>
        /// <param name="idEntidad"></param>
        /// <returns>List<ProyectoDto</returns>
        [HttpGet]
        [Route("ConsultarProyectosPorEntidad")]
        public async Task<ActionResult<GeneralResponse>> ConsultarProyectosPorEntidad(int idEntidad)
        {
            return Ok(_proyectoCore.ConsultarProyectosPorEntidad(idEntidad));
        }


        /// <summary>
        /// Crea o actualiza proyecto
        /// </summary>
        /// <returns>List<ProyectoDto</returns>
        [HttpPost]
        [Route("UpsertProyecto")]
        public async Task<ActionResult<GeneralResponse>> UpsertProyecto([FromBody] ProyectoDto input)
        {
            try
            {
                return Ok(_proyectoCore.UpsertProyecto(input));
            }
            catch (Exception ex)
            {

                return Unauthorized("Usuario invalido"); ;
            }
        }


        #endregion

        #region Modulos

        /// <summary>
        /// Consultar modulos por proyecto
        /// </summary>
        /// <param name="idEntidad"></param>
        /// <returns>List<ProyectoDto</returns>
        [HttpGet]
        [Route("ConsultarModulosPorProyecto")]
        public async Task<ActionResult<GeneralResponse>> ConsultarModulosPorProyecto(int idProyecto)
        {
            return Ok(_proyectoCore.ConsultarModulosPorProyecto(idProyecto));
        }


        /// <summary>
        /// Crea o actualiza modulo
        /// </summary>
        /// <returns>List<ProyectoDto</returns>
        [HttpPost]
        [Route("UpsertModulo")]
        public async Task<ActionResult<GeneralResponse>> UpsertModulo([FromBody] ModuloDto input)
        {
            try
            {
                return Ok(_proyectoCore.UpsertModulo(input));
            }
            catch (Exception ex)
            {

                return Unauthorized("Usuario invalido"); ;
            }
        }

        /// <summary>
        /// Consultar consultar proyeccion proyecto
        /// </summary>
        /// <param name="idProyecto"></param>
        /// <returns>ProyeccionModelo</returns>
        [HttpGet]
        [Route("ConsutarProyeccion")]
        public async Task<ActionResult<GeneralResponse>> ConsutarProyeccion(int idProyecto)
        {
            return Ok(_proyectoCore.ConsutarProyeccion(idProyecto));
        }


        #endregion

        #region HistoriasUsuario

        /// <summary>
        /// Consultar historias de usuario por modulo
        /// </summary>
        /// <returns>List<HistoriaUsuarioDto</returns>
        [HttpGet]
        [Route("ConsultarHistoriasUsuario")]
        public async Task<ActionResult<GeneralResponse>> ConsultarHistoriasUsuario(int idModulo)
        {
            return Ok(_proyectoCore.ConsultarHistoriasUsuario(idModulo));
        }


        /// <summary>
        /// Crea o actualiza historia de usuario
        /// </summary>
        /// <returns>List<HistoriaUsuarioDto</returns>
        [HttpPost]
        [Route("UpsertHistoriaUsuario")]
        public async Task<ActionResult<GeneralResponse>> UpsertHistoriaUsuario([FromBody] HistoriaUsuarioDto input)
        {
            try
            {
                return Ok(_proyectoCore.UpsertHistoriaUsuario(input));
            }
            catch (Exception ex)
            {

                return Unauthorized("Usuario invalido"); ;
            }
        }


        #endregion

        #region Actividades

        /// <summary>
        /// Consultar actividades por historia de usuario
        /// </summary>
        /// <returns>List<ActividadDto</returns>
        [HttpGet]
        [Route("ConsultarActividadesPorHistoriaUsuario")]
        public async Task<ActionResult<GeneralResponse>> ConsultarActividadesPorHistoriaUsuario(int idHistoriaUsuario)
        {
            return Ok(_proyectoCore.ConsultarActividadesPorHistoriaUsuario(idHistoriaUsuario));
        }


        /// <summary>
        /// Crea o actualiza actividad
        /// </summary>
        /// <returns>List<ActividadDto</returns>
        [HttpPost]
        [Route("UpsertActividad")]
        public async Task<ActionResult<GeneralResponse>> UpsertActividad([FromBody] ActividadDto input)
        {
            try
            {
                return Ok(_proyectoCore.UpsertActividad(input));
            }
            catch (Exception ex)
            {

                return Unauthorized("Usuario invalido"); ;
            }
        }


        #endregion

        #region ProyectoCosto

        /// <summary>
        /// Consultar costo por proyecto
        /// </summary>
        /// <param name="idEntidad"></param>
        /// <returns>List<ProyectoCostoPerfilDto</returns>
        [HttpGet]
        [Route("ConsultarCostoPerfilPorProyecto")]
        public async Task<ActionResult<GeneralResponse>> ConsultarCostoPerfilPorProyecto(int idProyecto)
        {
            return Ok(_proyectoCore.ConsultarCostoPerfilPorProyecto(idProyecto));
        }


        /// <summary>
        /// UpsertrCostoPerfilPorProyecto
        /// </summary>
        /// <param name="input"></param>
        /// <returns>List<ProyectoCostoPerfilDto></returns>
        [HttpPost]
        [Route("UpsertCostoPerfilPorProyecto")]
        public async Task<ActionResult<GeneralResponse>> UpsertCostoPerfilPorProyecto([FromBody] ProyectoCostoPerfilDto input)
        {
            try
            {
                return Ok(_proyectoCore.UpsertCostoPerfilPorProyecto(input));
            }
            catch (Exception ex)
            {

                return Unauthorized("Usuario invalido"); ;
            }
        }


        /// <summary>
        /// Generar informe proyecto
        /// </summary>
        /// <param name="idProyecto"></param>
        /// <returns>String Base 64</returns>
        [HttpGet]
        [Route("GenerarInformeProyecto")]
        public async Task<ActionResult<GeneralResponse>> GenerarInformeProyecto(int idProyecto)
        {
            return Ok(_proyectoCore.GenerarInformeProyecto(idProyecto));
        }


        #endregion

        #region Catalogo

        /// <summary>
        /// ConsultarItemsPorCatalogo
        /// </summary>
        /// <param name="idCatalogo">idCatalogo</param>
        /// <returns>List<ItemDto</returns>
        [HttpGet]
        [Route("ConsultarItemsPorCatalogo")]
        public async Task<ActionResult<GeneralResponse>> ConsultarItemsPorCatalogo(int idCatalogo)
        {
            return Ok(_proyectoCore.ConsultarItemsPorCatalogo(idCatalogo));
        }


        #endregion


    }
}
