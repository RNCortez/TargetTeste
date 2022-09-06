using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TargetWebApi.Data.VO;
using TargetWebApi.Models;

namespace TargetWebApi.Business
{
    public interface IProdutoBusiness
    {
        ProdutoVO Create(ProdutoVO produto);
        ProdutoVO FindByID(int id);
        List<ProdutoVO> FindAll();
        ProdutoVO Update(ProdutoVO produto);
        void Delete(int id);
       

    }
}
