using estimacion_proyecto.domain.Dto;
using estimacion_proyecto.domain.Response;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace estimacion_proyecto.data
{
    public interface IProyectoDatos
    {
        #region Entidades

        /// <summary>
        /// Consultar listado de entidades
        /// </summary>
        /// <returns>List<EntidadDto></returns>
        List<EntidadDto> ConsultarEntidades();

        /// <summary>
        /// Crea o actualiza entidad
        /// </summary>
        /// <returns>List<EntidadDto></returns>
        List<EntidadDto> UpsertEntidad(EntidadDto input);


        #endregion

        #region Proyectos

        /// <summary>
        /// Consultar proyectos por entidad
        /// </summary>
        /// <param name="idEntidad"></param>
        /// <returns>List<ProyectoDto</returns>
        List<ProyectoDto> ConsultarProyectosPorEntidad(int idEntidad);


        /// <summary>
        /// Crea o actualiza proyecto
        /// </summary>
        /// <returns>List<ProyectoDto</returns>
        List<ProyectoDto> UpsertProyecto(ProyectoDto input);

        #endregion

        #region Modulos

        /// <summary>
        /// Consultar modulos por proyecto
        /// </summary>
        /// <param name="idEntidad"></param>
        /// <returns>List<ProyectoDto</returns>
        List<ModuloDto> ConsultarModulosPorProyecto(int idProyecto);

        /// <summary>
        /// Crea o actualiza modulo
        /// </summary>
        /// <returns>List<ProyectoDto</returns>
        public List<ModuloDto> UpsertModulo(ModuloDto input);

        /// <summary>
        /// Consultar consultar proyeccion proyecto
        /// </summary>
        /// <param name="idProyecto"></param>
        /// <returns>ProyeccionModelo</returns>
        public ProyeccionModelo ConsutarProyeccion(int idProyecto);


        #endregion

        #region HistoriasUsuario

        /// <summary>
        /// Consultar historias de usuario por modulo
        /// </summary>
        /// <returns>List<HistoriaUsuarioDto</returns>
        List<HistoriaUsuarioDto> ConsultarHistoriasUsuario(int idModulo);


        /// <summary>
        /// Crea o actualiza historia de usuario
        /// </summary>
        /// <returns>List<HistoriaUsuarioDto</returns>
        List<HistoriaUsuarioDto> UpsertHistoriaUsuario(HistoriaUsuarioDto input);

        #endregion

        #region Actividades

        /// <summary>
        /// Consultar actividades por historia de usuario
        /// </summary>
        /// <returns>List<ActividadDto</returns>
        List<ActividadDto> ConsultarActividadesPorHistoriaUsuario(int idHistoriaUsuario);


        /// <summary>
        /// Crea o actualiza actividad
        /// </summary>
        /// <returns>List<ActividadDto</returns>
        List<ActividadDto> UpsertActividad(ActividadDto input);

        #endregion

        #region ProyectoCosto


        /// <summary>
        /// Consultar costo por proyecto
        /// </summary>
        /// <param name="idEntidad"></param>
        /// <returns>List<ProyectoCostoPerfilDto</returns>
        List<ProyectoCostoPerfilDto> ConsultarCostoPerfilPorProyecto(int idProyecto);

        /// <summary>
        /// UpsertrCostoPerfilPorProyecto
        /// </summary>
        /// <param name="input"></param>
        /// <returns>List<ProyectoCostoPerfilDto></returns>
        List<ProyectoCostoPerfilDto> UpsertCostoPerfilPorProyecto(ProyectoCostoPerfilDto input);

        #endregion

        #region Catalogos

        /// <summary>
        /// ConsultarItemsPorCatalogo
        /// </summary>
        /// <param name="idCatalogo">idCatalogo</param>
        /// <returns>List<ItemDto</returns>
        List<ItemDto> ConsultarItemsPorCatalogo(int idCatalogo);

        #endregion
    }
}
