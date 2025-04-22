using estimacion_proyecto.domain.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace estimacion_proyecto.domain.Response
{
    public class CostoPerfilModelo
    {
        public CostoPerfilModelo()
        {
                
        }

        public CostoPerfilModelo(ProyectoCostoPerfilDto dto, List<ItemDto> items)
        {
               this.IdCosto = dto.IdCosto;
            this.IdProyecto = dto.IdProyecto;
            this.Perfil = dto.Perfil;
            this.PerfilNombre = items.Where(x => x.IdItem == dto.Perfil).Select(x => x.Nombre).FirstOrDefault();
            this.Cantidad = dto.Cantidad;
            this.CostoHora = dto.CostoHora;
            this.PorcentajeAsignacion = dto.PorcentajeAsignacion;
            this.CostoTotal = dto.CostoTotal;           
        }

        public int IdCosto { get; set; }
        public int IdProyecto { get; set; }
        public int Perfil { get; set; }
        public string? PerfilNombre { get; set; }
        public int Cantidad { get; set; }

        public decimal CostoHora { get; set; }

        public int PorcentajeAsignacion { get; set; }

        public decimal CostoTotal { get; set; }

        public decimal Total { get; set; }
    }
}
