using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TargetWebApi.Data.VO;
using TargetWebApi.Models;

namespace TargetWebApi.Business
{
    public interface IFornecedorBusiness
    {
        FornecedorVO FindByID(int id);
        List<FornecedorVO> FindAll();
    }
}
