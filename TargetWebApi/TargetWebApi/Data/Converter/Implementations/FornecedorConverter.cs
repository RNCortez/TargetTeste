using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TargetWebApi.Data.Converter.Contract;
using TargetWebApi.Data.VO;
using TargetWebApi.Models;

namespace TargetWebApi.Data.Converter.Implementations
{
    public class FornecedorConverter : IParser<FornecedorVO, Fornecedor>, IParser<Fornecedor, FornecedorVO>
    {
        public Fornecedor Parse(FornecedorVO origin)
        {
            if (origin != null)
            {
                return new Fornecedor()
                {
                    ID = origin.ID,
                    Descricao = origin.Descricao
                };
            }
            return null;
        }

        public List<Fornecedor> Parse(List<FornecedorVO> origin)
        {
            if (origin != null)
            {
                return origin.Select(l => Parse(l)).ToList();
            }
            return null;
        }

        public FornecedorVO Parse(Fornecedor origin)
        {
            if (origin != null)
            {
                return new FornecedorVO()
                {
                    ID = origin.ID,
                    Descricao = origin.Descricao
                };
            }
            return null;
        }

        public List<FornecedorVO> Parse(List<Fornecedor> origin)
        {
            if (origin != null)
            {
                return origin.Select(l => Parse(l)).ToList();
            }
            return null;
        }
    }
}
