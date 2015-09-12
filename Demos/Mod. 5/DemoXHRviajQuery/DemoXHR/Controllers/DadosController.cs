using DemoXHR.Models.Entidades;
using System.Web.Mvc;

namespace DemoXHR.Controllers
{
    public class DadosController : Controller
    {
        // GET: Dados
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Form1(Cliente cliente)
        {

            var msg = "";
            var erro = false;
            
            if (string.IsNullOrEmpty(cliente.Nome))
            {
                msg = string.Format("Erro - cliente de id: {0} inválido!",cliente.ID);
                erro = true;
            }
            else
            {
                //código para salvar na base
            }
            var retorno = new { msg, erro };

            System.Threading.Thread.Sleep(2000);
            return Json(retorno, JsonRequestBehavior.AllowGet);
        }


        public JsonResult Form2(Cliente cliente2)
        {
            var msg = "";
            var erro = false;

            if (string.IsNullOrEmpty(cliente2.Nome))
            {
                msg = string.Format("Erro - cliente de id: {0} inválido!", cliente2.ID);
                erro = true;
            }
            else
            {
                //código para salvar na base
            }
            var retorno = new { msg, erro };

            System.Threading.Thread.Sleep(2000);
            return Json(retorno, JsonRequestBehavior.AllowGet);

        }

    }
}