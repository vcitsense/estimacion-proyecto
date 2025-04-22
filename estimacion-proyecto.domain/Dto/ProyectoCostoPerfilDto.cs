using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace estimacion_proyecto.domain.Dto
{
    [Table("tbl_proyecto_costo_perfil")]
    public class ProyectoCostoPerfilDto
    {
        public ProyectoCostoPerfilDto()
        {
                
        }

        [Key]
        [Column("id_costo")]

        public int IdCosto { get; set; }

        [Column("id_proyecto")]

        public int IdProyecto { get; set; }

        [Column("perfil")]
        public int Perfil { get; set; }

        [Column("cantidad")]
        public int Cantidad { get; set; }

        [Column("costo_hora")]
        public decimal CostoHora { get; set; }

        [Column("porcentaje_asignacion")]
        public int PorcentajeAsignacion { get; set; }

        [Column("costo_total")]
        public decimal CostoTotal { get; set; }

    }
}
