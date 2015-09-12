using DemoAjaxjQuery.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace DemoAjaxjQuery.Controllers
{
    public class DadosController : Controller
    {
        private List<Pessoa> pessoas;
        public DadosController()
        {
            pessoas = new List<Pessoa>
                {
                new Pessoa { ID = 1, Nome = "Raphael Nalin", Sexo = 1 },
                new Pessoa { ID = 2, Nome = "Fausto Silva", Sexo = 1 },
                new Pessoa { ID = 6, Nome = "Ademir Pereira", Sexo = 1 },
                new Pessoa { ID = 8, Nome = "Fabiano Nalin", Sexo = 1 },
                new Pessoa { ID = 10, Nome = "Rubens dos Santos", Sexo = 1 },
                new Pessoa { ID = 3, Nome = "Priscila Nalin", Sexo = 0 },
                new Pessoa { ID = 4, Nome = "Marcia Silva", Sexo = 0 },
                new Pessoa { ID = 5, Nome = "Stephanie Santos", Sexo = 0 },
                new Pessoa { ID = 7, Nome = "Renata Pereira", Sexo = 0 },
                new Pessoa { ID = 9, Nome = "Fernanda dos Santos Pereira da Silva", Sexo = 0 }
                };
        }

        public ActionResult Index()
        {
            return View();
        }

        public JsonResult ListaPessoas(int sexo)
        {
            System.Threading.Thread.Sleep(2000);
            var dados = GetPessoas(sexo);
            return Json(dados,JsonRequestBehavior.AllowGet);
        }

        private object GetPessoas(int sexo)
        {
            return pessoas.Where(d=>d.Sexo==sexo);
        }


        protected override void Dispose(bool disposing)
        {
            pessoas = null;
        }



    }
}