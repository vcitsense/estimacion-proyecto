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
                var result = new List<ModuloModel>();
                var data = _proyectoDatos.ConsultarModulosPorProyecto(idProyecto);

                data?.All(x =>
                {
                    result.Add(new ModuloModel(x, ConsultarHistoriasUsuario(x.IdModulo).Data));
                    return true;
                });
                oReturn.Data = result;
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

        /// <summary>
        /// Consultar consultar proyeccion proyecto
        /// </summary>
        /// <param name="idProyecto"></param>
        /// <returns>ProyeccionModelo</returns>
        public GeneralResponse ConsutarProyeccion(int idProyecto)
        {
            var oReturn = new GeneralResponse();

            try
            {
                oReturn.Data = _proyectoDatos.ConsutarProyeccion(idProyecto);
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
                var result = new List<HistoriaUsuarioModel>();
                var data = _proyectoDatos.ConsultarHistoriasUsuario(idModulo);

                data?.All(x =>
                {
                    result.Add(new HistoriaUsuarioModel(x, _proyectoDatos.ConsultarActividadesPorHistoriaUsuario(x.IdHistoriaUsuario)));
                    return true;
                });

                oReturn.Data = result;


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
                var result = new List<HistoriaUsuarioModel>();
                var data = _proyectoDatos.UpsertHistoriaUsuario(input);

                data?.All(x =>
                {
                    result.Add(new HistoriaUsuarioModel(x, _proyectoDatos.ConsultarActividadesPorHistoriaUsuario(x.IdHistoriaUsuario)));
                    return true;
                });

                oReturn.Data = result;
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
            {   var result = new List<ActividadModel>();

                var data = _proyectoDatos.ConsultarActividadesPorHistoriaUsuario(idHistoriaUsuario);

                data?.All(x =>
                {
                    result.Add(new ActividadModel(x));
                    return true;
                });

                oReturn.Data = result;
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
                var result = new List<ActividadModel>();

                oReturn.Data = _proyectoDatos.UpsertActividad(input);

                var data = _proyectoDatos.UpsertActividad(input);

                data?.All(x =>
                {
                    result.Add(new ActividadModel(x));
                    return true;
                });

                oReturn.Data = result;
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


        #region ProyectoCosto


        /// <summary>
        /// Consultar costo por proyecto
        /// </summary>
        /// <param name="idEntidad"></param>
        /// <returns>List<ProyectoCostoPerfilDto</returns>
        public GeneralResponse ConsultarCostoPerfilPorProyecto(int idProyecto)
        {
            var oReturn = new GeneralResponse();

            try
            {
                var dataDb = _proyectoDatos.ConsultarCostoPerfilPorProyecto(idProyecto);

                List<CostoPerfilModelo> oResult = new List<CostoPerfilModelo>();

                if (dataDb.Count > 0)
                {
                    var itemsPerfil = _proyectoDatos.ConsultarItemsPorCatalogo(1);

                    dataDb?.All(x =>
                    {
                        oResult.Add(new CostoPerfilModelo(x, itemsPerfil));
                        return true;
                    });

                    oResult.FirstOrDefault().Total = oResult.Sum(x => x.CostoTotal);
                }


                oReturn.Data = oResult;


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
        /// UpsertrCostoPerfilPorProyecto
        /// </summary>
        /// <param name="input"></param>
        /// <returns>List<ProyectoCostoPerfilDto></returns>
        public GeneralResponse UpsertCostoPerfilPorProyecto(ProyectoCostoPerfilDto input)
        {
            var oReturn = new GeneralResponse();

            try
            {
                List<CostoPerfilModelo> oResult = new List<CostoPerfilModelo>();

                var dataDb = _proyectoDatos.UpsertCostoPerfilPorProyecto(input);

                if (dataDb.Count > 0)
                {
                    var itemsPerfil = _proyectoDatos.ConsultarItemsPorCatalogo(1);

                    dataDb?.All(x =>
                    {
                        oResult.Add(new CostoPerfilModelo(x, itemsPerfil));
                        return true;
                    });

                    oResult.FirstOrDefault().Total = oResult.Sum(x => x.CostoTotal);
                }

                oReturn.Data = oResult;
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


        #region Catalogos

        /// <summary>
        /// ConsultarItemsPorCatalogo
        /// </summary>
        /// <param name="idCatalogo">idCatalogo</param>
        /// <returns>List<ItemDto</returns>
        public GeneralResponse ConsultarItemsPorCatalogo(int idCatalogo)
        {
            var oReturn = new GeneralResponse();

            try
            {
                oReturn.Data = _proyectoDatos.ConsultarItemsPorCatalogo(idCatalogo);

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
