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
    public class FornecedorBusinessImplementation : IFornecedorBusiness
    {
        private readonly IRepository<Fornecedor> _repository;
        private readonly FornecedorConverter _converter;

        public FornecedorBusinessImplementation(IRepository<Fornecedor> repository)
        {
            _repository = repository;
            _converter = new FornecedorConverter();
        }
        public List<FornecedorVO> FindAll()
        {
            return _converter.Parse(_repository.FindAll());
        }

        public FornecedorVO FindByID(int id)
        {
            return _converter.Parse(_repository.FindByID(id));
        }
    }
}
