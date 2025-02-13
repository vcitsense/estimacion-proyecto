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
        public List<ModuloModel> Modulos { get; set; }
    }
}
