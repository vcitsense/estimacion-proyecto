using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace estimacion_proyecto.domain.Dto
{

    [Table("tbl_modulo")]
    public class ModuloDto : AuditoriaDto
    {
        public ModuloDto()
        {

        }

        [Key]
        [Column("id_modulo")]

        public int IdModulo { get; set; }

        [Column("nombre_modulo")]
        public string NombreModulo { get; set; }

        [Column("descripcion")]
        public string Descripcion { get; set; }

        [Column("id_proyecto")]
        public int IdProyecto { get; set; }


    }
}

