using estimacion_proyecto.data;
using estimacion_proyecto.domain.Dto;
using estimacion_proyecto.domain.Response;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static iTextSharp.text.pdf.AcroFields;

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
                oReturn.Data = CalcularCostoPerfilPorProyecto(idProyecto);
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
        /// Calcular costo por proyecto
        /// </summary>
        /// <param name="idEntidad"></param>
        /// <returns>List<ProyectoCostoPerfilDto</returns>
        public List<CostoPerfilModelo> CalcularCostoPerfilPorProyecto(int idProyecto)
        {
            List<CostoPerfilModelo> oResult = new List<CostoPerfilModelo>();

            try
            {
                var dataDb = _proyectoDatos.ConsultarCostoPerfilPorProyecto(idProyecto);


                #region Crear perfiles base

                if (dataDb.Count == 0)
                {
                    #region Documentacion

                    ProyectoCostoPerfilDto perfilDocumentacion = new ProyectoCostoPerfilDto()
                    {
                        IdProyecto = idProyecto,
                        Perfil = (int)Enumerations.enumPerfil.ProjectManager,
                        Cantidad = 1,
                        CostoHora = 100000,
                        PorcentajeAsignacion = 1,
                        CantidadHoras = 1,
                    };

                    _proyectoDatos.UpsertCostoPerfilPorProyecto(perfilDocumentacion);

                    #endregion

                    #region Diseno Grafico

                    ProyectoCostoPerfilDto disenoGrafico = new ProyectoCostoPerfilDto()
                    {
                        IdProyecto = idProyecto,
                        Perfil = (int)Enumerations.enumPerfil.DisenadorGrafico,
                        Cantidad = 1,
                        CostoHora = 100000,
                        PorcentajeAsignacion = 1,
                        CantidadHoras = 1,
                    };

                    _proyectoDatos.UpsertCostoPerfilPorProyecto(disenoGrafico);

                    #endregion

                    #region Desarrollo

                    ProyectoCostoPerfilDto desarrollo = new ProyectoCostoPerfilDto()
                    {
                        IdProyecto = idProyecto,
                        Perfil = (int)Enumerations.enumPerfil.Developer,
                        Cantidad = 1,
                        CostoHora = 100000,
                        PorcentajeAsignacion = 1,
                        CantidadHoras = 1,
                    };

                    _proyectoDatos.UpsertCostoPerfilPorProyecto(desarrollo);

                    #endregion

                    #region Pruebas

                    ProyectoCostoPerfilDto pruebas = new ProyectoCostoPerfilDto()
                    {
                        IdProyecto = idProyecto,
                        Perfil = (int)Enumerations.enumPerfil.Tester,
                        Cantidad = 1,
                        CostoHora = 100000,
                        PorcentajeAsignacion = 1,
                        CantidadHoras = 1,
                    };

                    _proyectoDatos.UpsertCostoPerfilPorProyecto(pruebas);

                    #endregion

                    #region Devops

                    ProyectoCostoPerfilDto devops = new ProyectoCostoPerfilDto()
                    {
                        IdProyecto = idProyecto,
                        Perfil = (int)Enumerations.enumPerfil.Devops,
                        Cantidad = 1,
                        CostoHora = 100000,
                        PorcentajeAsignacion = 1,
                        CantidadHoras = 1,
                    };

                    _proyectoDatos.UpsertCostoPerfilPorProyecto(devops);

                    #endregion

                    dataDb = _proyectoDatos.ConsultarCostoPerfilPorProyecto(idProyecto);
                }

                #endregion
                

                if (dataDb.Count > 0)
                {
                    var proyeccion = _proyectoDatos.ConsutarProyeccion(idProyecto);

                    var itemsPerfil = _proyectoDatos.ConsultarItemsPorCatalogo(1);

                    //Calcular porcentajes
                    dataDb?.All(x =>
                    {
                        CalcularPorcentajeAsignacion(x, proyeccion);
                        return true;
                    });

                    dataDb = _proyectoDatos.ConsultarCostoPerfilPorProyecto(idProyecto);

                    dataDb?.All(x =>
                    {
                        oResult.Add(new CostoPerfilModelo(x, itemsPerfil));
                        return true;
                    });

                    oResult.FirstOrDefault().Total = oResult.Sum(x => x.CostoTotal);
                }




            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                
            }

            return oResult;
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

                _proyectoDatos.UpsertCostoPerfilPorProyecto(input);

                var dataDb = _proyectoDatos.ConsultarCostoPerfilPorProyecto(input.IdProyecto);

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



        public void CalcularPorcentajeAsignacion(ProyectoCostoPerfilDto perfil, ProyeccionModelo proyeccion)
        {

            if (perfil.Perfil == (int)Enumerations.enumPerfil.DisenadorGrafico)
            {
                perfil.CantidadHoras = proyeccion.TotalDisenadorGrafico;
            }
            else if (perfil.Perfil == (int)Enumerations.enumPerfil.ProjectManager)
            {
                perfil.CantidadHoras = proyeccion.TotalProjectManager;
            }
            else if (perfil.Perfil == (int)Enumerations.enumPerfil.Tester)
            {
                perfil.CantidadHoras = proyeccion.TotalTester;
            }
            else if (perfil.Perfil == (int)Enumerations.enumPerfil.Developer)
            {
                perfil.CantidadHoras = proyeccion.TotalDeveloper;
            }
            else if (perfil.Perfil == (int)Enumerations.enumPerfil.Devops)
            {
                perfil.CantidadHoras = proyeccion.TotalDevops;
            }

            if (perfil.CantidadHoras > 0)
            {
                var porcentaje = (100 / proyeccion.Total) * perfil.CantidadHoras;
                perfil.PorcentajeAsignacion = Convert.ToInt32(porcentaje);
                perfil.CostoTotal = perfil.CantidadHoras * perfil.CostoHora * perfil.Cantidad;
            }
            else
            {
                perfil.Cantidad = 0;
                perfil.CostoHora = 0;
                perfil.PorcentajeAsignacion = 0;
                perfil.CantidadHoras = 0;
            }

            _proyectoDatos.UpsertCostoPerfilPorProyecto(perfil);


        }

        /// <summary>
        /// Generar informe proyecto
        /// </summary>
        /// <param name="idProyecto"></param>
        /// <returns>String Base 64</returns>
        public GeneralResponse GenerarInformeProyecto(int idProyecto)
        {
            var oReturn = new GeneralResponse();

            try
            {
                var costo = CalcularCostoPerfilPorProyecto(idProyecto);
                var culture = new System.Globalization.CultureInfo("es-CO");

                Document pdfDoc = new Document(PageSize.A4.Rotate(), 25, 25, 25, 25);

                using (MemoryStream ms = new MemoryStream())
                {
                    PdfWriter writer = PdfWriter.GetInstance(pdfDoc, ms);
                    pdfDoc.Open();

                    PdfPTable table = new PdfPTable(3);
                    table.WidthPercentage = 100;
                    table.HorizontalAlignment = 1;
                    table.SpacingBefore = 20f;
                    table.SpacingAfter = 30f;
                    table.DefaultCell.Border = Rectangle.NO_BORDER;

                    //Title
                    Paragraph parrafo = new Paragraph("INFORME ESTIMACIÓN PROYECTO", FontFactory.GetFont("Arial", 14, Font.BOLD, new BaseColor(0, 102, 204)));
                    parrafo.Alignment = Element.ALIGN_CENTER;

                    // Create cell from paragraph
                    PdfPCell tituloCell = new PdfPCell(parrafo);
                    tituloCell.Border = Rectangle.NO_BORDER;
                    tituloCell.Colspan = 3; // Span all 3 columns
                    tituloCell.HorizontalAlignment = Element.ALIGN_CENTER;

                    table.AddCell(tituloCell);
                    pdfDoc.Add(table);

                    table = new PdfPTable(1);
                    table.WidthPercentage = 100;
                    table.HorizontalAlignment = 1;
                    table.SpacingBefore = 5f;
                    table.SpacingAfter = 5f;
                    table.DefaultCell.Border = Rectangle.NO_BORDER;

                    parrafo = new Paragraph("COSTOS", FontFactory.GetFont("Arial", 14, Font.BOLD, new BaseColor(0, 102, 204)));
                    parrafo.Alignment = Element.ALIGN_CENTER;

                    // Create cell from paragraph
                    tituloCell = new PdfPCell(parrafo);
                    tituloCell.Border = Rectangle.NO_BORDER;
                    tituloCell.Colspan = 3; // Span all 3 columns
                    tituloCell.HorizontalAlignment = Element.ALIGN_CENTER;

                    table.AddCell(tituloCell);
                    pdfDoc.Add(table);



                    // Insertamos salto de linea
                    Paragraph saltoDeLinea = new Paragraph("");
                    pdfDoc.Add(saltoDeLinea);
                    saltoDeLinea = new Paragraph("");
                    pdfDoc.Add(saltoDeLinea);
                    saltoDeLinea = new Paragraph("");
                    pdfDoc.Add(saltoDeLinea);


                    #region Seccion Costo



                    table = new PdfPTable(3);
                    table.WidthPercentage = 100;
                    table.HorizontalAlignment = 1;
                    table.SpacingBefore = 20f;
                    table.SpacingAfter = 30f;
                    table.DefaultCell.Border = Rectangle.NO_BORDER;

                    //Table
                    table = new PdfPTable(6);
                    table.WidthPercentage = 100;
                    //0=Left, 1=Centre, 2=Right
                    table.HorizontalAlignment = 1;
                    table.SpacingBefore = 20f;
                    table.SpacingAfter = 30f;

                    string[] headers = { "Perfil", "Cant Personas", "Costo Hora", "Cantidad Horas", "% Asignación", "Costo Total" };

                    foreach (var header in headers)
                    {
                        PdfPCell celda = new PdfPCell(new Phrase(header));
                        celda.BackgroundColor = new BaseColor(0, 102, 204);
                        celda.HorizontalAlignment = Element.ALIGN_CENTER;
                        celda.Colspan = 1;
                        table.AddCell(celda);
                    }

                    //Datos tabla
                    foreach (var item in costo)
                    {
                        table.AddCell(item.PerfilNombre);
                        table.AddCell(item.Cantidad.ToString());
                        table.AddCell(item.CostoHora.ToString("C", culture));
                        table.AddCell(item.CantidadHoras.ToString().Replace(".00",""));
                        table.AddCell(item.PorcentajeAsignacion.ToString() + "%");
                        table.AddCell(item.CostoTotal.ToString("C", culture));
                    }

                    pdfDoc.Add(table);

                    pdfDoc.Add(saltoDeLinea);



                    //Total Costo
                    table = new PdfPTable(2);
                    table.WidthPercentage = 100;
                    table.HorizontalAlignment = 1;
                    table.SpacingBefore = 20f;
                    table.SpacingAfter = 30f;
                    table.DefaultCell.Border = Rectangle.NO_BORDER;
                    parrafo = new Paragraph("Total Costo: " + costo.FirstOrDefault().Total.ToString("C", culture), FontFactory.GetFont("Arial", 12, Font.BOLD, new BaseColor(0, 102, 204)));
                    parrafo.Alignment = Element.ALIGN_LEFT;
                    tituloCell = new PdfPCell(parrafo);
                    tituloCell.Border = Rectangle.NO_BORDER;
                    tituloCell.Colspan = 1; // Span all 3 columns
                    tituloCell.HorizontalAlignment = Element.ALIGN_CENTER;
                    table.AddCell(tituloCell);

                    #endregion

                    #region Seccion HU




                    var proyeccion = _proyectoDatos.ConsutarProyeccion(idProyecto);


                    //Total Horas
                    parrafo = new Paragraph("Total Horas: " + proyeccion.Total.ToString().Replace(".00",""), FontFactory.GetFont("Arial", 12, Font.BOLD, new BaseColor(0, 102, 204)));
                    parrafo.Alignment = Element.ALIGN_LEFT;
                    tituloCell = new PdfPCell(parrafo);
                    tituloCell.Border = Rectangle.NO_BORDER;
                    tituloCell.Colspan = 1; // Span all 3 columns
                    tituloCell.HorizontalAlignment = Element.ALIGN_CENTER;
                    table.AddCell(tituloCell);
                    pdfDoc.Add(table);


                    //Modulos
                    foreach (var modulo in proyeccion.Modulos)
                    {
                        table = new PdfPTable(3);
                        table.WidthPercentage = 100;
                        table.HorizontalAlignment = 1;
                        table.SpacingBefore = 5f;
                        table.SpacingAfter = 5f;

                        parrafo = new Paragraph("MÓDULO " + modulo.NombreModulo, FontFactory.GetFont("Arial", 14, Font.BOLD, new BaseColor(0, 102, 204)));
                        parrafo.Alignment = Element.ALIGN_CENTER;

                        // Create cell from paragraph
                        tituloCell = new PdfPCell(parrafo);
                        tituloCell.Border = Rectangle.NO_BORDER;
                        tituloCell.Colspan = 4; // Span all 3 columns
                        tituloCell.HorizontalAlignment = Element.ALIGN_CENTER;

                        table.AddCell(tituloCell);

                        pdfDoc.Add(table);


                        table = new PdfPTable(5);
                        table.WidthPercentage = 100;
                        table.HorizontalAlignment = 1;
                        table.SpacingBefore = 5f;
                        table.SpacingAfter = 5f;

                        string[] headersHU = { "Historia Usuario", "Descripción", "Horas HU", "Actividad", "Horas Act"};

                        table.SetWidths(new float[] { 3f, 4f, 1f, 5f, 1f });

                        foreach (var header in headersHU)
                        {
                            PdfPCell celda = new PdfPCell(new Phrase(header));
                            celda.BackgroundColor = new BaseColor(0, 102, 204);
                            celda.HorizontalAlignment = Element.ALIGN_CENTER;
                            celda.Colspan = 1;

                            table.AddCell(celda);
                        }

                        //Historias de Usuario
                        foreach (var historiaUsuario in modulo.HistoriasUsuario)
                        {                            

                            //Actividades
                            foreach (var actividades in historiaUsuario.Actividades)
                            {
                                PdfPCell cellNombre = new PdfPCell(new Phrase(historiaUsuario.Nombre.ToString()));
                                cellNombre.HorizontalAlignment = Element.ALIGN_CENTER;
                                table.AddCell(cellNombre);

                                PdfPCell cellDescripcion = new PdfPCell(new Phrase(historiaUsuario.Descripcion.ToString()));
                                cellDescripcion.HorizontalAlignment = Element.ALIGN_CENTER;
                                table.AddCell(cellDescripcion);

                                PdfPCell cellTotal = new PdfPCell(new Phrase(historiaUsuario.Total.ToString().Replace(".00", "")));
                                cellTotal.HorizontalAlignment = Element.ALIGN_CENTER;
                                table.AddCell(cellTotal);

                                // Para actividades también:
                                PdfPCell cellActDescripcion = new PdfPCell(new Phrase(actividades.Descripcion.ToString()));
                                cellActDescripcion.HorizontalAlignment = Element.ALIGN_CENTER;
                                table.AddCell(cellActDescripcion);

                                PdfPCell cellActTotal = new PdfPCell(new Phrase(actividades.Total.ToString().Replace(".00", "")));
                                cellActTotal.HorizontalAlignment = Element.ALIGN_CENTER;
                                table.AddCell(cellActTotal);
                            }
                        }

                        pdfDoc.Add(table);
                    }


                    #endregion




                    //var FontColour = new BaseColor(255, 255, 255);
                    //var Calibri8 = FontFactory.GetFont("Calibri", 12, FontColour);
                    //PdfPCell cell = new PdfPCell(new Paragraph("Total", Calibri8));
                    //cell.BackgroundColor = new iTextSharp.text.BaseColor(34, 36, 38);
                    //cell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                    //cell.Colspan = 6;
                    //table.AddCell(cell);

                    pdfDoc.Add(table);

                    Paragraph parrafofinal = new Paragraph();
                    parrafofinal.Alignment = Element.ALIGN_CENTER;
                    parrafofinal.Font = FontFactory.GetFont("Arial", 18);
                    parrafofinal.Font.SetStyle(Font.BOLD);
                    parrafofinal.Font.SetColor(0, 0, 0);
                    pdfDoc.Add(parrafofinal);

                    pdfDoc.Close();
                    byte[] bytes = ms.ToArray();

                    string base64String = Convert.ToBase64String(bytes);
                    return new GeneralResponse()
                    {
                        Data = base64String,
                        Message = "Reporte generado correctamente"
                    };

                }
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
