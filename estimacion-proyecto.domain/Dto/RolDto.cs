using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace estimacion_proyecto.domain.Dto
{
    [Table("tbl_rol")]
    public class RolDto : AuditoriaDto
    {

        public RolDto()
        {

        }

        [Key]
        [Column("id_rol")]
        public int Id { get; set; }

        [Column("nombre_rol")]
        public string NombreRol { get; set; }



    }
}
