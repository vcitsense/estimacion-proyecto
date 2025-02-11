using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace estimacion_proyecto.domain.Dto
{
    [Table("tbl_proyecto_navegador")]
    public class ProyectoNavegadorDto : AuditoriaDto
    {
        public ProyectoNavegadorDto()
        {

        }

        [Key]
        [Column("id_proyecto_navegador")]

        public int IdProyectoNavegador { get; set; }

        [Column("id_proyecto")]
        public string IdProyecto { get; set; }

        [Column("navegador_item")]
        public int NavegadorItem { get; set; }

        [Column("windows")]
        public bool Windows { get; set; }

        [Column("macos")]
        public bool Macos { get; set; }

        [Column("MobileAndroid")]
        public bool mobile_android { get; set; }

        [Column("mobile_ios")]
        public bool MobileIos { get; set; }

        [Column("tablet_ios")]
        public bool TabletIos { get; set; }


    }
}
