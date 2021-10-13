using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Models
{
    public class Personas
    {
        public int DNI { get; set; }
        public string NOMBRE_APELLIDO { get; set; }

        public string EMAIL { get; set; }

        public DateTime FECHA { get; set; }

        public DateTime TELEFONO { get; set; }

    }
}
