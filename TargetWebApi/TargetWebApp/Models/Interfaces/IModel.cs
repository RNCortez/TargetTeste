using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TargetWebApp.Models.Base;
using TargetWebApp.Results;

namespace TargetWebApp.Models.Interfaces
{
    public interface IModel<T> where T : BaseModel
    {
        List<T> ListarTodos();
        T Buscar(int id);
        T Registrar(T mod);
        T Atualizar(T mod);
        ResultAllServices Remover(int id);
    }
}
