﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace estimacion_proyecto.domain.Response
{
    public class Enumerations
    {
        public enum enumTypeMessageResponse
        {
            Success = 200,
            Error = 500,
            BadRequest = 400
        }

        public enum enumPerfil
        {
            Devops = 1,
            Developer =	2,
            Tester = 3,
            ProjectManager	= 4,
            DisenadorGrafico = 5
        }
    }
}
