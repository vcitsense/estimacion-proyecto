using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace estimacion_proyecto.domain.Dto
{
    [Table("tbl_entidad")]
    public class EntidadDto : AuditoriaDto
    {
        public EntidadDto()
        {

        }

        [Key]
        [Column("id_entidad")]

        public int IdEntidad { get; set; }

        [Column("nit")]
        public string Nit { get; set; }

        [Column("nombre_entidad")]
        public string NombreEntidad { get; set; }

        [Column("url_imagen")]
        public string UrlImagen { get; set; }

    }
}
