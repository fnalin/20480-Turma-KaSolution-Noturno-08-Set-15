using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DemoGetPostjQuery.Controllers
{
    public class DadosController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetClientes()
        {

            if (Request.IsAjaxRequest())
            {
                System.Threading.Thread.Sleep(5000);

                var dados = new List<Models.Cliente> {
                new Models.Cliente{ID=1,Nome="Fabiano"},
                new Models.Cliente{ID=2,Nome="Raphael"},
                new Models.Cliente{ID=3,Nome="Priscila"},
                new Models.Cliente{ID=4,Nome="Robson"},
                new Models.Cliente{ID=5,Nome="Vinicius"},
                new Models.Cliente{ID=6,Nome="Murilo"},
                new Models.Cliente{ID=7,Nome="Daniel"},
            };
                return Json(dados, JsonRequestBehavior.AllowGet);

            }

            //localhost:5009/Dados/GetClientes - direto pelo browser dá esse erro
            throw new Exception("Ação não permitida");
        }

    }
}