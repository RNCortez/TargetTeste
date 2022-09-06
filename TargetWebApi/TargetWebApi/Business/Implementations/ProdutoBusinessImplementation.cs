using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TargetWebApi.Data.Converter.Implementations;
using TargetWebApi.Data.VO;
using TargetWebApi.Models;
using TargetWebApi.Models.Context;
using TargetWebApi.Repository;

namespace TargetWebApi.Business.Implementations
{
    public class ProdutoBusinessImplementation : IProdutoBusiness
    {
        private readonly IRepository<Produto> _repository;
        private readonly ProdutoConverter _converter;
        public ProdutoBusinessImplementation(IRepository<Produto> repository)
        {
            _repository = repository;
            _converter = new ProdutoConverter();
        }
        
        public List<ProdutoVO> FindAll()
        {
            return _converter.Parse(_repository.FindAll());
        }

        public ProdutoVO FindByID(int id)
        {
            return _converter.Parse(_repository.FindByID(id));
        }

        public ProdutoVO Create(ProdutoVO produto)
        {
            var produtoEntity = _converter.Parse(produto);
            return _converter.Parse(_repository.Create(produtoEntity));
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        public ProdutoVO Update(ProdutoVO produto)
        {
            var produtoEntity = _converter.Parse(produto);
            return _converter.Parse(_repository.Update(produtoEntity));
        }
    }
}
