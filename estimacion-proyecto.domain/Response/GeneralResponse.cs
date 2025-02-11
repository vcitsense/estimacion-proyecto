using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace estimacion_proyecto.domain.Response
{
    public class GeneralResponse
    {

        public GeneralResponse()
        {

        }
        public int Status { get; set; } = (int)Enumerations.enumTypeMessageResponse.Success;
        public dynamic? Data { get; set; }
        public string Message { get; set; } = "Proceso Realizado exitosamente";
    };
}
