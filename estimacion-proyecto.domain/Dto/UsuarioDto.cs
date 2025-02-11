using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace estimacion_proyecto.domain.Dto
{
    [Table("tbl_usuario")]
    public class UsuarioDto : AuditoriaDto
    {
        public UsuarioDto()
        {
                
        }

        [Key]
        [Column("id_usuario")]
        public int IdUsuario { get; set; }

        [Column("usuario")]
        public string Usuario { get; set; }

        [Column("contrasena")]
        public string Contrasena { get; set; }

        [Column("id_entidad")]
        public int Identidad { get; set; }

        [Column("id_rol")]
        public int IdRol { get; set; }

    }
}
