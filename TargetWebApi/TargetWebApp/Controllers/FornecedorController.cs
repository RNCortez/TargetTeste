using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TargetWebApp.Models;
using TargetWebApp.Models.Implementations;

namespace TargetWebApp.Controllers
{
    public class FornecedorController : Controller
    {
        // GET: Fornecedor
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ObterPorId(int id)
        {
            var dados = new GenericImplementation<ProdutoModel>("Fornecedores").Buscar(id);

            return Json(dados, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ObterTodos()
        {
            var dados = new GenericImplementation<ProdutoModel>("Fornecedores").ListarTodos();

            if (dados.Count > 0)
                return Json(dados, JsonRequestBehavior.AllowGet);
            else
                return Json("", JsonRequestBehavior.AllowGet);
        }
    }
}