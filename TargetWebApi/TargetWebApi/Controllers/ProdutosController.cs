using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TargetWebApi.Models;
using TargetWebApi.Business;
using TargetWebApi.Data.VO;

namespace TargetWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProdutosController : ControllerBase
    {
        private readonly ILogger<ProdutosController> _logger;
        private IProdutoBusiness _produtoBusiness;

        public ProdutosController(ILogger<ProdutosController> logger, IProdutoBusiness produtoBusiness)
        {
            _logger = logger;
            _produtoBusiness = produtoBusiness;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_produtoBusiness.FindAll());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var produto = _produtoBusiness.FindByID(id);
            if(produto != null)
            {
                return Ok(produto);
            }
            return NotFound();
        }

        [HttpPost]
        public IActionResult Post([FromBody] ProdutoVO produto)
        {
            if(produto != null){
                return Ok(_produtoBusiness.Create(produto));
            }
            return BadRequest();
        }

        [HttpPut]
        public IActionResult Put([FromBody] ProdutoVO produto)
        {
            if (produto != null)
            {
                return Ok(_produtoBusiness.Update(produto));
            }
            return BadRequest();
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            _produtoBusiness.Delete(id);
           
            return NotFound();
        }
    }
}
