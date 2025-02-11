using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace estimacion_proyecto.domain.Dto
{
    [Table("tbl_actividad")]
    public class ActividadDto : AuditoriaDto
    {
        public ActividadDto()
        {

        }

        [Key]
        [Column("id_actividad")]

        public int IdActividad { get; set; }

        [Column("descripcion")]
        public string Descripcion { get; set; }

        [Column("id_historia_usuario")]
        public int IdHistoriaUsuario { get; set; }

        [Column("analisis")]
        public decimal Analisis { get; set; }

        [Column("documentacion")]
        public decimal Documentacion { get; set; }

        [Column("pruebas")]
        public decimal Pruebas { get; set; }

        [Column("devops")]
        public decimal Devops { get; set; }

        [Column("diseno_grafico")]
        public decimal DisenoGrafico { get; set; }


    }

}
