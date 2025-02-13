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
    public class ModuloModel
    {
        public ModuloModel()
        {

        }

        public ModuloModel(ModuloDto context, List<HistoriaUsuarioModel> hu)
        {
            this.IdModulo = context.IdModulo;
            this.NombreModulo = context.NombreModulo;
            this.Descripcion = context.Descripcion;
            this.IdProyecto = context.IdProyecto;
            this.Total = 0;
            this.HistoriasUsuario = new List<HistoriaUsuarioModel>();

            hu?.All(x =>
            {
                this.Total += x.Total;
                return true;
            });

        }

        public int IdModulo { get; set; }

        public string NombreModulo { get; set; }
        public string Descripcion { get; set; }

        public int IdProyecto { get; set; }
        public decimal Total { get; set; }
        public List<HistoriaUsuarioModel> HistoriasUsuario { get; set; }
    }
}
