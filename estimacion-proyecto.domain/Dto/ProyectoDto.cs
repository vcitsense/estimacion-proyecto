using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace estimacion_proyecto.domain.Dto
{
    [Table("tbl_proyecto")]
    public class ProyectoDto : AuditoriaDto
    {
        public ProyectoDto()
        {

        }

        [Key]
        [Column("id_proyecto")]

        public int IdProyecto { get; set; }

        [Column("nombre_proyecto")]
        public string NombreProyecto { get; set; }

        [Column("descripcion")]
        public string Descripcion { get; set; }

        [Column("id_entidad")]
        public int IdEntidad { get; set; }


    }
}
