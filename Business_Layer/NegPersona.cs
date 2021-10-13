using Entity_Layer;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Layer
{
    public class NegPersona
    {
        public string Actualizar(PersonaBO dto)
        {
            daoPersona dao = new daoPersona();
            return dao.Actualizar(dto);
        }

        public string Eliminar(string dto)
        {
            daoPersona dao = new daoPersona();
            return dao.Eliminar(dto);
        }

        public string Insert(PersonaBO dto)
        {
            daoPersona dao = new daoPersona();
            return dao.Insertar(dto);
        }

        public List<PersonaBO> Listar()
        {
            daoPersona dao = new daoPersona();
            return dao.Listar();
        }



    }
}
