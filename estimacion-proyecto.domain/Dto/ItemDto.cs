using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace estimacion_proyecto.domain.Dto
{
    [Table("tbl_item")]
    public class ItemDto
    {
        public ItemDto()
        {

        }

        [Key]
        [Column("id_item")]

        public int IdItem { get; set; }

        [Column("id_catalogo")]
        public int IdCatalogo { get; set; }

        [Column("nombre")]
        public string Nombre { get; set; }

        [Column("activo")]
        public bool Activo { get; set; }

        [Column("fecha_creacion")]
        public DateTime FechaCreacion { get; set; }

        [Column("fecha_actualizacion")]
        public DateTime FechaActualizacion { get; set; }



    }
}
