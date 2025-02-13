using estimacion_proyecto.domain.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace estimacion_proyecto.domain.Response
{
    public class HistoriaUsuarioModel
    {

        public HistoriaUsuarioModel()
        {
                
        }

        public HistoriaUsuarioModel(HistoriaUsuarioDto context, List<ActividadDto> actividades)
        {
            this.IdHistoriaUsuario = context.IdHistoriaUsuario;
            this.Nombre = context.Nombre;
            this.Descripcion = context.Descripcion;
            this.IdModulo = context.IdModulo;
            this.IdHistoriaUsuario = context.IdHistoriaUsuario;

            this.Total = 0;
            this.Actividades = new List<ActividadModel>();

            actividades?.All(x =>
            {
                this.Total = (this.Total + x.Analisis + x.Documentacion + x.Pruebas + x.Devops + x.DisenoGrafico);
                return true;
            });

        }


        public int IdHistoriaUsuario { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }

        public int IdModulo { get; set; }
        public decimal Total { get; set; }
        public List<ActividadModel>  Actividades { get; set; }
    }
}
