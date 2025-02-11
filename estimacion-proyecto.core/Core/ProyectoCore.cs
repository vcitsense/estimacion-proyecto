using estimacion_proyecto.data;
using estimacion_proyecto.domain.Dto;
using estimacion_proyecto.domain.Response;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace estimacion_proyecto.core.Core
{
    public class ProyectoCore : IProyectoCore
    {
        private readonly IConfiguration _configuration;
        private readonly IProyectoDatos _proyectoDatos;
        private readonly ILogger<ProyectoCore> _logger;

        public ProyectoCore(
            ILogger<ProyectoCore> logger,
            IConfiguration configuration,
            IProyectoDatos proyectoDatos)
        {
            _configuration = configuration;
            _logger = logger;
            _proyectoDatos = proyectoDatos;
        }


        #region Entidades

        /// <summary>
        /// Consultar listado de entidades
        /// </summary>
        /// <returns>List<EntidadDto></returns>
        public GeneralResponse ConsultarEntidades()
        {
            var oReturn = new GeneralResponse();

            try
            {
                oReturn.Data = _proyectoDatos.ConsultarEntidades();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                oReturn.Message = "Error Procesando Solicitud";
                oReturn.Status = (int)Enumerations.enumTypeMessageResponse.Error;
            }

            return oReturn;
        }

        /// <summary>
        /// Crea o actualiza entidad
        /// </summary>
        /// <returns>List<EntidadDto></returns>
        public GeneralResponse UpsertEntidad(EntidadDto input)
        {
            var oReturn = new GeneralResponse();

            try
            {
                oReturn.Data = _proyectoDatos.UpsertEntidad(input);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                oReturn.Message = "Error Procesando Solicitud";
                oReturn.Status = (int)Enumerations.enumTypeMessageResponse.Error;
            }

            return oReturn;
        }



        #endregion

        #region Proyectos

        /// <summary>
        /// Consultar proyectos por entidad
        /// </summary>
        /// <param name="idEntidad"></param>
        /// <returns>List<ProyectoDto</returns>
        public GeneralResponse ConsultarProyectosPorEntidad(int idEntidad)
        {
            var oReturn = new GeneralResponse();

            try
            {
                oReturn.Data = _proyectoDatos.ConsultarProyectosPorEntidad(idEntidad);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                oReturn.Message = "Error Procesando Solicitud";
                oReturn.Status = (int)Enumerations.enumTypeMessageResponse.Error;
            }

            return oReturn;
        }

        /// <summary>
        /// Crea o actualiza proyecto
        /// </summary>
        /// <returns>List<ProyectoDto</returns>
        public GeneralResponse UpsertProyecto(ProyectoDto input)
        {
            var oReturn = new GeneralResponse();

            try
            {
                oReturn.Data = _proyectoDatos.UpsertProyecto(input);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                oReturn.Message = "Error Procesando Solicitud";
                oReturn.Status = (int)Enumerations.enumTypeMessageResponse.Error;
            }

            return oReturn;
        }



        #endregion

        #region Modulos

        /// <summary>
        /// Consultar modulos por proyecto
        /// </summary>
        /// <param name="idEntidad"></param>
        /// <returns>List<ProyectoDto</returns>
        public GeneralResponse ConsultarModulosPorProyecto(int idProyecto)
        {
            var oReturn = new GeneralResponse();

            try
            {
                oReturn.Data = _proyectoDatos.ConsultarModulosPorProyecto(idProyecto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                oReturn.Message = "Error Procesando Solicitud";
                oReturn.Status = (int)Enumerations.enumTypeMessageResponse.Error;
            }

            return oReturn;
        }

        /// <summary>
        /// Crea o actualiza modulo
        /// </summary>
        /// <returns>List<ProyectoDto</returns>
        public GeneralResponse UpsertModulo(ModuloDto input)
        {
            var oReturn = new GeneralResponse();

            try
            {
                oReturn.Data = _proyectoDatos.UpsertModulo(input);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                oReturn.Message = "Error Procesando Solicitud";
                oReturn.Status = (int)Enumerations.enumTypeMessageResponse.Error;
            }

            return oReturn;
        }



        #endregion

        #region HistoriasUsuario

        /// <summary>
        /// Consultar historias de usuario por modulo
        /// </summary>
        /// <returns>List<HistoriaUsuarioDto</returns>
        public GeneralResponse ConsultarHistoriasUsuario(int idModulo)
        {
            var oReturn = new GeneralResponse();

            try
            {
                oReturn.Data = _proyectoDatos.ConsultarHistoriasUsuario(idModulo);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                oReturn.Message = "Error Procesando Solicitud";
                oReturn.Status = (int)Enumerations.enumTypeMessageResponse.Error;
            }

            return oReturn;
        }

        /// <summary>
        /// Crea o actualiza historia de usuario
        /// </summary>
        /// <returns>List<HistoriaUsuarioDto</returns>
        public GeneralResponse UpsertHistoriaUsuario(HistoriaUsuarioDto input)
        {
            var oReturn = new GeneralResponse();

            try
            {
                oReturn.Data = _proyectoDatos.UpsertHistoriaUsuario(input);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                oReturn.Message = "Error Procesando Solicitud";
                oReturn.Status = (int)Enumerations.enumTypeMessageResponse.Error;
            }

            return oReturn;
        }



        #endregion

        #region Actividades

        /// <summary>
        /// Consultar actividades por historia de usuario
        /// </summary>
        /// <returns>List<ActividadDto</returns>
        public GeneralResponse ConsultarActividadesPorHistoriaUsuario(int idHistoriaUsuario)
        {
            var oReturn = new GeneralResponse();

            try
            {
                oReturn.Data = _proyectoDatos.ConsultarActividadesPorHistoriaUsuario(idHistoriaUsuario);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                oReturn.Message = "Error Procesando Solicitud";
                oReturn.Status = (int)Enumerations.enumTypeMessageResponse.Error;
            }

            return oReturn;
        }

        /// <summary>
        /// Crea o actualiza actividad
        /// </summary>
        /// <returns>List<ActividadDto</returns>
        public GeneralResponse UpsertActividad(ActividadDto input)
        {
            var oReturn = new GeneralResponse();

            try
            {
                oReturn.Data = _proyectoDatos.UpsertActividad(input);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                oReturn.Message = "Error Procesando Solicitud";
                oReturn.Status = (int)Enumerations.enumTypeMessageResponse.Error;
            }

            return oReturn;
        }



        #endregion

    }
}
