using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;

namespace DemoXMLHttpRequest.Controllers
{
    public class DadosController : Controller
    {
        // GET: Dados
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetClientesJson()
        {
            System.Threading.Thread.Sleep(5000);
            return Json(Models.Cliente.GetClientes(), JsonRequestBehavior.AllowGet);
        }

        public ActionResult CliXML()
        {
            var dados = Models.Cliente.GetClientes();

            //var xmlLINQ = new XElement("Clientes",
            //    from cli in dados
            //    select new XElement("Cliente",
            //                    new XAttribute("ID", cli.ID),
            //                    new XElement("Nome", cli.Nome)
            //               ));

            var xmlLambda = new XElement("Clientes", dados.Select(cli => new XElement("Cliente",
                                new XAttribute("ID", cli.ID),
                                new XAttribute("Nome", cli.Nome)
                //new XElement("Nome", cli.Nome),
                           )));
            System.Threading.Thread.Sleep(3000);
            return Content(xmlLambda.ToString(), "text/xml");
        }
    }
}