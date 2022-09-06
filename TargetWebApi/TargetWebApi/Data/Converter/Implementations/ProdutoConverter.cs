using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TargetWebApi.Data.Converter.Contract;
using TargetWebApi.Data.VO;
using TargetWebApi.Models;

namespace TargetWebApi.Data.Converter.Implementations
{
    public class ProdutoConverter : IParser<ProdutoVO, Produto>, IParser<Produto, ProdutoVO>
    {
        public ProdutoVO Parse(Produto origin)
        {
            if(origin != null)
            {
                return new ProdutoVO()
                {
                    ID = origin.ID,
                    Descricao = origin.Descricao,
                    CodBarras = origin.CodBarras,
                    DataCadastro = origin.DataCadastro,
                    EstoqueMaximo = origin.EstoqueMaximo,
                    EstoqueMinimo = origin.EstoqueMinimo,
                    ValorCompra = origin.ValorCompra,
                    ValorVenda = origin.ValorVenda,
                    ID_Fornecedor = origin.ID_Fornecedor
                };
            }
            return null;
        }

        public List<ProdutoVO> Parse(List<Produto> origin)
        {
            if (origin != null)
            {
                return origin.Select(l => Parse(l)).ToList();
            }
            return null;
        }

        public Produto Parse(ProdutoVO origin)
        {
            if (origin != null)
            {
                return new Produto()
                {
                    ID = origin.ID,
                    Descricao = origin.Descricao,
                    CodBarras = origin.CodBarras,
                    DataCadastro = origin.DataCadastro,
                    EstoqueMaximo = origin.EstoqueMaximo,
                    EstoqueMinimo = origin.EstoqueMinimo,
                    ValorCompra = origin.ValorCompra,
                    ValorVenda = origin.ValorVenda,
                    ID_Fornecedor = origin.ID_Fornecedor
                };
            }
            return null;
        }

        public List<Produto> Parse(List<ProdutoVO> origin)
        {
            if (origin != null)
            {
                return origin.Select(l => Parse(l)).ToList();
            }
            return null;
        }
    }
}
