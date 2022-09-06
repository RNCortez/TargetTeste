using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TargetWebApi.Business;

namespace TargetWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FornecedoresController : ControllerBase
    {
        private readonly ILogger<FornecedoresController> _logger;
        private IFornecedorBusiness _fornecedorBusiness;

        public FornecedoresController(ILogger<FornecedoresController> logger, IFornecedorBusiness fornecedorBusiness)
        {
            _logger = logger;
            _fornecedorBusiness = fornecedorBusiness;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_fornecedorBusiness.FindAll());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var fornecedor = _fornecedorBusiness.FindByID(id);
            if (fornecedor != null)
            {
                return Ok(fornecedor);
            }
            return NotFound();
        }
    }
}
