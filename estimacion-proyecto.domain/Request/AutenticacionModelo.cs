using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace estimacion_proyecto.domain.Request
{
    public class AutenticacionModelo
    {
        public AutenticacionModelo()
        {
                
        }

        public string Usuario { get; set; }
        public string Contrasena { get; set; }
    }
}
