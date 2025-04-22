using estimacion_proyecto.domain.Dto;
using estimacion_proyecto.domain.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace estimacion_proyecto.data
{
    public class ProyectoDatos : IProyectoDatos
    {
        private readonly ProyectoDbContext _DbContext;

        public ProyectoDatos(ProyectoDbContext dbContext)
        {
            _DbContext = dbContext;
        }

        #region Entidaes

        /// <summary>
        /// Consultar listado de entidades
        /// </summary>
        /// <returns>List<EntidadDto></returns>
        public List<EntidadDto> ConsultarEntidades()
        {
            try
            {
                return _DbContext.Entidades.ToList();
            }
            catch (Exception ex)
            {
                throw;

            }
        }


        /// <summary>
        /// Crea o actualiza entidad
        /// </summary>
        /// <returns>List<EntidadDto></returns>
        public List<EntidadDto> UpsertEntidad(EntidadDto input)
        {
            try
            {
                if (input.IdEntidad == 0)
                {
                    input.NombreEntidad = input.NombreEntidad.ToUpper();
                    input.FechaCreacion = DateTime.Now;
                    input.FechaActualizacion = DateTime.Now;
                    input.Activo = true;
                    _DbContext.Entidades.Add(input);
                }
                else
                {
                    var consultaDb = _DbContext.Entidades.Where(x => x.IdEntidad == input.IdEntidad).First();
                    consultaDb.Nit = input.Nit;
                    consultaDb.NombreEntidad = input.NombreEntidad.ToUpper();
                    consultaDb.UrlImagen = input.UrlImagen;
                    consultaDb.Activo = input.Activo;
                    consultaDb.ActualizadoPor = input.ActualizadoPor;
                    consultaDb.FechaActualizacion = DateTime.Now;
                }

                _DbContext.SaveChanges();

                return _DbContext.Entidades.ToList();
            }
            catch (Exception ex)
            {
                throw;

            }
        }

        #endregion

        #region Proyectos

        /// <summary>
        /// Consultar proyectos por entidad
        /// </summary>
        /// <param name="idEntidad"></param>
        /// <returns>List<ProyectoDto</returns>
        public List<ProyectoDto> ConsultarProyectosPorEntidad(int idEntidad)
        {
            try
            {
                return _DbContext.Proyectos.Where(x => x.IdEntidad == idEntidad).ToList();
            }
            catch (Exception ex)
            {
                throw;

            }
        }


        /// <summary>
        /// Crea o actualiza proyecto
        /// </summary>
        /// <returns>List<ProyectoDto</returns>
        public List<ProyectoDto> UpsertProyecto(ProyectoDto input)
        {
            try
            {
                if (input.IdProyecto == 0)
                {
                    input.NombreProyecto = input.NombreProyecto.ToUpper();
                    input.Descripcion = input.Descripcion.ToUpper();
                    input.FechaCreacion = DateTime.Now;
                    input.FechaActualizacion = DateTime.Now;
                    input.Activo = true;
                    _DbContext.Proyectos.Add(input);
                }
                else
                {
                    var consultaDb = _DbContext.Proyectos.Where(x => x.IdProyecto == input.IdProyecto).First();
                    consultaDb.NombreProyecto = input.NombreProyecto.ToUpper();
                    consultaDb.Descripcion = input.Descripcion.ToUpper();
                    consultaDb.Activo = input.Activo;
                    consultaDb.ActualizadoPor = input.ActualizadoPor;
                    consultaDb.FechaActualizacion = DateTime.Now;
                }

                _DbContext.SaveChanges();

                return _DbContext.Proyectos.Where(x => x.IdEntidad == input.IdEntidad).ToList();
            }
            catch (Exception ex)
            {
                throw;

            }
        }

        #endregion

        #region Modulos

        /// <summary>
        /// Consultar modulos por proyecto
        /// </summary>
        /// <param name="idEntidad"></param>
        /// <returns>List<ProyectoDto</returns>
        public List<ModuloDto> ConsultarModulosPorProyecto(int idProyecto)
        {
            try
            {
                return _DbContext.Modulos.Where(x => x.IdProyecto == idProyecto).ToList();
            }
            catch (Exception ex)
            {
                throw;

            }
        }


        /// <summary>
        /// Crea o actualiza modulo
        /// </summary>
        /// <returns>List<ProyectoDto</returns>
        public List<ModuloDto> UpsertModulo(ModuloDto input)
        {
            try
            {
                if (input.IdModulo == 0)
                {
                    input.NombreModulo = input.NombreModulo.ToUpper();
                    input.Descripcion = input.Descripcion.ToUpper();
                    input.FechaCreacion = DateTime.Now;
                    input.FechaActualizacion = DateTime.Now;
                    input.Activo = true;
                    _DbContext.Modulos.Add(input);
                }
                else
                {
                    var consultaDb = _DbContext.Modulos.Where(x => x.IdModulo == input.IdModulo).First();
                    consultaDb.NombreModulo = input.NombreModulo.ToUpper();
                    consultaDb.Descripcion = input.Descripcion.ToUpper();
                    consultaDb.Activo = input.Activo;
                    consultaDb.ActualizadoPor = input.ActualizadoPor;
                    consultaDb.FechaActualizacion = DateTime.Now;
                }

                _DbContext.SaveChanges();

                return _DbContext.Modulos.Where(x => x.IdProyecto == input.IdProyecto).ToList();
            }
            catch (Exception ex)
            {
                throw;

            }
        }

        /// <summary>
        /// Consultar consultar proyeccion proyecto
        /// </summary>
        /// <param name="idProyecto"></param>
        /// <returns>ProyeccionModelo</returns>
        public ProyeccionModelo ConsutarProyeccion(int idProyecto)
        {
            try
            {
                var result = new ProyeccionModelo();

                var modulosDb = _DbContext.Modulos.Where(x => x.IdProyecto == idProyecto).ToList();

                modulosDb?.All(x =>
                {
                    var huDb = _DbContext.HistoriasUsuario.Where(w => w.IdModulo == x.IdModulo).ToList();
                    var huResultList = new List<HistoriaUsuarioModel>();                

                    huDb?.All(hu =>
                    {
                        var actividadesDb = _DbContext.Actividades.Where(a => a.IdHistoriaUsuario == hu.IdHistoriaUsuario).ToList();
                        var huActual = new HistoriaUsuarioModel(hu, actividadesDb);
                        huActual.Actividades = new List<ActividadModel>();

                        actividadesDb?.All(a =>
                        {
                            huActual.Actividades.Add(new ActividadModel(a));
                            return true;
                        });

                        huResultList.Add(huActual);

                        return true;
                    });

                    var module = new ModuloModel(x, huResultList);
                    module.HistoriasUsuario = huResultList;
                    result.Modulos.Add(module);
                    result.Total += module.Total;
                    return true;
                });

                return result;
            }
            catch (Exception ex)
            {
                throw;

            }
        }

        #endregion

        #region HistoriasUsuario

        /// <summary>
        /// Consultar historias de usuario por modulo
        /// </summary>
        /// <returns>List<HistoriaUsuarioDto</returns>
        public List<HistoriaUsuarioDto> ConsultarHistoriasUsuario(int idModulo)
        {
            try
            {
                return _DbContext.HistoriasUsuario.Where(x => x.IdModulo == idModulo).ToList();
            }
            catch (Exception ex)
            {
                throw;

            }
        }


        /// <summary>
        /// Crea o actualiza historia de usuario
        /// </summary>
        /// <returns>List<HistoriaUsuarioDto</returns>
        public List<HistoriaUsuarioDto> UpsertHistoriaUsuario(HistoriaUsuarioDto input)
        {
            try
            {
                if (input.IdHistoriaUsuario == 0)
                {
                    input.Nombre = input.Nombre.ToUpper();
                    input.Descripcion = input.Descripcion.ToUpper();
                    input.FechaCreacion = DateTime.Now;
                    input.FechaActualizacion = DateTime.Now;
                    input.Activo = true;
                    _DbContext.HistoriasUsuario.Add(input);
                }
                else
                {
                    var consultaDb = _DbContext.HistoriasUsuario.Where(x => x.IdHistoriaUsuario == input.IdHistoriaUsuario).First();
                    consultaDb.Nombre = input.Nombre.ToUpper();
                    consultaDb.Descripcion = input.Descripcion.ToUpper();
                    consultaDb.Activo = input.Activo;
                    consultaDb.ActualizadoPor = input.ActualizadoPor;
                    consultaDb.FechaActualizacion = DateTime.Now;
                }

                _DbContext.SaveChanges();

                return _DbContext.HistoriasUsuario.Where(x => x.IdModulo == input.IdModulo).ToList();
            }
            catch (Exception ex)
            {
                throw;

            }
        }

        #endregion

        #region Actividades

        /// <summary>
        /// Consultar actividades por historia de usuario
        /// </summary>
        /// <returns>List<ActividadDto</returns>
        public List<ActividadDto> ConsultarActividadesPorHistoriaUsuario(int idHistoriaUsuario)
        {
            try
            {
                return _DbContext.Actividades.Where(x => x.IdHistoriaUsuario == idHistoriaUsuario).ToList();
            }
            catch (Exception ex)
            {
                throw;

            }
        }


        /// <summary>
        /// Crea o actualiza actividad
        /// </summary>
        /// <returns>List<ActividadDto</returns>
        public List<ActividadDto> UpsertActividad(ActividadDto input)
        {
            try
            {
                if (input.IdActividad == 0)
                {
                    input.Descripcion = input.Descripcion.ToUpper();
                    input.FechaCreacion = DateTime.Now;
                    input.FechaActualizacion = DateTime.Now;
                    input.Activo = true;
                    _DbContext.Actividades.Add(input);
                }
                else
                {
                    var consultaDb = _DbContext.Actividades.Where(x => x.IdActividad == input.IdActividad).First();
                    consultaDb.Descripcion = input.Descripcion.ToUpper();
                    consultaDb.Analisis = input.Analisis;
                    consultaDb.Documentacion = input.Documentacion;
                    consultaDb.Pruebas = input.Pruebas;
                    consultaDb.Devops = input.Devops;
                    consultaDb.DisenoGrafico = input.DisenoGrafico;
                    consultaDb.Activo = input.Activo;
                    consultaDb.ActualizadoPor = input.ActualizadoPor;
                    consultaDb.FechaActualizacion = DateTime.Now;
                }

                _DbContext.SaveChanges();

                return _DbContext.Actividades.Where(x => x.IdHistoriaUsuario == input.IdHistoriaUsuario).ToList();
            }
            catch (Exception ex)
            {
                throw;

            }
        }

        #endregion

        #region Navegadores

        /// <summary>
        /// Consultar actividades por historia de usuario
        /// </summary>
        /// <returns>List<ActividadDto</returns>
        public List<ActividadDto> ConsultarNavegadoresProyecto(int idHistoriaUsuario)
        {
            try
            {

                //var navegadores =  _DbContext.cata
                return _DbContext.Actividades.Where(x => x.IdHistoriaUsuario == idHistoriaUsuario).ToList();
            }
            catch (Exception ex)
            {
                throw;

            }
        }


        #endregion

        #region ProyectoCosto


        /// <summary>
        /// Consultar costo por proyecto
        /// </summary>
        /// <param name="idEntidad"></param>
        /// <returns>List<ProyectoCostoPerfilDto</returns>
        public List<ProyectoCostoPerfilDto> ConsultarCostoPerfilPorProyecto(int idProyecto)
        {
            try
            {
                return _DbContext.ProyectoCostoPerfil.Where(x => x.IdProyecto == idProyecto).ToList();
            }
            catch (Exception ex)
            {
                throw;

            }
        }

        /// <summary>
        /// UpsertrCostoPerfilPorProyecto
        /// </summary>
        /// <param name="input"></param>
        /// <returns>List<ProyectoCostoPerfilDto></returns>
        public List<ProyectoCostoPerfilDto> UpsertCostoPerfilPorProyecto(ProyectoCostoPerfilDto input)
        {
            try
            {
                if (input.IdCosto == 0)
                {
                    _DbContext.ProyectoCostoPerfil.Add(input);
                }
                else
                {
                    var consultaDb = _DbContext.ProyectoCostoPerfil.Where(x => x.IdCosto == input.IdCosto).First();
                    consultaDb.IdProyecto = input.IdProyecto;
                    consultaDb.Perfil = input.Perfil;
                    consultaDb.Cantidad = input.Cantidad;
                    consultaDb.CostoHora = input.CostoHora;
                    consultaDb.CostoTotal = input.CostoTotal;
                    consultaDb.PorcentajeAsignacion = input.PorcentajeAsignacion;
                }

                _DbContext.SaveChanges();

                return _DbContext.ProyectoCostoPerfil.Where(x => x.IdProyecto == input.IdProyecto).ToList();
            }
            catch (Exception ex)
            {
                throw;

            }
        }

        #endregion

        #region Catalogos

        /// <summary>
        /// ConsultarItemsPorCatalogo
        /// </summary>
        /// <param name="idCatalogo">idCatalogo</param>
        /// <returns>List<ItemDto</returns>
        public List<ItemDto> ConsultarItemsPorCatalogo(int idCatalogo)
        {
            try
            {
                return _DbContext.Items.Where(x => x.IdCatalogo == idCatalogo).ToList();
            }
            catch (Exception ex)
            {
                throw;

            }
        }

        #endregion



    }

}
