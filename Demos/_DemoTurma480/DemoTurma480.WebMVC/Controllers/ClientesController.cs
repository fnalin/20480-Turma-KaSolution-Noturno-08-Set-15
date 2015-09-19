using DemoTurma480.DataEF.Contexto;
using DemoTurma480.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DemoTurma480.WebMVC.Controllers
{
    public class ClientesController : Controller
    {
        private DemoCliContexto _ctx = new DemoCliContexto();

        public ActionResult Index()
        {
            List<Cliente> clientes = _ctx.Clientes.ToList();
            return View(clientes);
        }

        public ActionResult Create() {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Cliente cli)
        {
            _ctx.Clientes.Add(cli);
            _ctx.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var cli = _ctx.Clientes.First(dados=>dados.ID==id);
            return View(cli);
        }

        [HttpPost]
        public ActionResult Edit(Cliente cli)
        {

            var cliUpdate = _ctx.Clientes.First(dados => dados.ID == cli.ID);
            cliUpdate.Nome = cli.Nome;
            cliUpdate.Nascimento = cli.Nascimento;
            cliUpdate.Sexo = cli.Sexo;
            _ctx.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var cli = _ctx.Clientes.First(dados => dados.ID == id);
            return View(cli);
        }

        [HttpPost]
        public ActionResult Delete(Cliente cli)
        {
            var cliDelete = _ctx.Clientes.First(dados => dados.ID == cli.ID);
            _ctx.Clientes.Remove(cliDelete);
            _ctx.SaveChanges();
            return RedirectToAction("Index");
            
        }



    }
}