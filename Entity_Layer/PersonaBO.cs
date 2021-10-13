using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_Layer
{
    public class PersonaBO    
    {
        public string DNI { get; set; }
        public string NOMBRE_APELLIDO { get; set; }
        public string EMAIL { get; set; }
        public string TELEFONO { get; set; }
        public string FECHA_NACIMIENTO{ get; set; }
    }
}
