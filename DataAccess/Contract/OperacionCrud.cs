using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Contract
{
    public interface OperacionCrud<T>
    {
        string Insertar(T dto);
        string Actualizar(T dto);
        string Eliminar(string dto);

        List<T> Listar();
    }
}
