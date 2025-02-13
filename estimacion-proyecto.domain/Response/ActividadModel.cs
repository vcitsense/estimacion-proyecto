using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using estimacion_proyecto.domain.Dto;

namespace estimacion_proyecto.domain.Response
{
    public class ActividadModel
    {

        public ActividadModel()
        {

        }

        public ActividadModel(ActividadDto context)
        {
            this.IdActividad = context.IdActividad;
            this.Descripcion = context.Descripcion;
            this.IdHistoriaUsuario = context.IdHistoriaUsuario;
            this.Analisis = context.Analisis;
            this.Documentacion = context.Documentacion;
            this.Pruebas = context.Pruebas;
            this.Devops = context.Devops;
            this.DisenoGrafico = context.DisenoGrafico;
            this.Total = context.Analisis + context.Documentacion + context.Pruebas + context.Devops + context.DisenoGrafico;
        }

        public int IdActividad { get; set; }
        public string Descripcion { get; set; }
        public int IdHistoriaUsuario { get; set; }
        public decimal Analisis { get; set; }
        public decimal Documentacion { get; set; }
        public decimal Pruebas { get; set; }
        public decimal Devops { get; set; }
        public decimal DisenoGrafico { get; set; }
        public decimal Total { get; set; }
    }
}
