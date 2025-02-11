using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace estimacion_proyecto.domain.Dto
{
    [Table("tbl_historia_usuario")]
    public class HistoriaUsuarioDto : AuditoriaDto
    {
        public HistoriaUsuarioDto()
        {

        }

        [Key]
        [Column("id_historia_usuario")]

        public int IdHistoriaUsuario { get; set; }

        [Column("nombre")]
        public string Nombre { get; set; }

        [Column("descripcion")]
        public string Descripcion { get; set; }

        [Column("id_modulo")]
        public int IdModulo { get; set; }

    }
}
