using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TargetWebApp.Models;
using TargetWebApp.Models.Implementations;
using TargetWebApp.Models.Interfaces;
using TargetWebApp.Util;

namespace TargetWebApp.Controllers
{
    public class ProdutosController : Controller
    {
        Utils utils = new Utils();

        // GET: Produtos
        public ActionResult Index()
        {
            ViewBag.Fornecedores = new GenericImplementation<FornecedorModel>("Fornecedores").ListarTodos();

            return View();
        }
        
        public ActionResult ObterPorId(int id)
        {
            var dados = new GenericImplementation<ProdutoModel>("Produtos").Buscar(id);
            dados.ValorCompraVisualizacao = Utils.DecimalToString(dados.ValorCompra);
            dados.ValorVendaVisualizacao = Utils.DecimalToString(dados.ValorVenda);

            return Json(dados, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetProdutosCadastrados()
        {
            ViewBag.produtos = new GenericImplementation<ProdutoModel>("Produtos").ListarTodos();

            ViewBag.Fornecedores = new GenericImplementation<FornecedorModel>("Fornecedores").ListarTodos();

            return View("_ProdutosCadastrados");
        }
        
        [HttpPost]
        public ActionResult Gravar(FormCollection form)
        {
            if (form.Keys.Count > 0)
            {
                ProdutoModel produto = new ProdutoModel()
                {
                    ID = utils.ValueIntForm(form, "Id"),
                    Descricao = utils.ValueStringForm(form, "Descricao"),
                    CodBarras = utils.ValueStringForm(form, "CodBarras"),
                    DataCadastro = DateTime.Now,
                    EstoqueMaximo = utils.ValueIntForm(form, "EstoqueMaximo"),
                    EstoqueMinimo = utils.ValueIntForm(form, "EstoqueMinimo"),
                    ID_Fornecedor = utils.ValueIntForm(form, "IdFornecedor"),
                    ValorCompra = utils.ValueDecimalForm(form, "valorCompra"),
                    ValorVenda = utils.ValueDecimalForm(form, "valorVenda")
                };
                

                if (produto.ID > 0)
                {
                    var dados = new GenericImplementation<ProdutoModel>("Produtos").Atualizar(produto);

                    return Json(dados, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    var dados = new GenericImplementation<ProdutoModel>("Produtos").Registrar(produto);

                    return Json(dados, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                return Json("O formulário submetido não contem valores válidos.");
            }
        }

        [HttpPost]
        public ActionResult Excluir(int id)
        {
            if(id > 0)
            {
                var dados = new GenericImplementation<ProdutoModel>("Produtos").Remover(id);

                return Json(dados);
            }
            else
            {
                return Json("Não foi possível excluir o registro selecionado.");
            }
        }
    }
}