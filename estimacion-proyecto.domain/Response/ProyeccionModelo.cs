using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace estimacion_proyecto.domain.Response
{
    public class ProyeccionModelo
    {
        public ProyeccionModelo()
        {
            this.Modulos = new List<ModuloModel>();   
        }

        public decimal Total { get; set; }


        public decimal TotalDevops { get; set; }

        public decimal TotalDeveloper { get; set; }

        public decimal TotalTester { get; set; }
        public decimal TotalProjectManager { get; set; }
        public decimal TotalDisenadorGrafico { get; set; }
        public List<ModuloModel> Modulos { get; set; }
    }
}
