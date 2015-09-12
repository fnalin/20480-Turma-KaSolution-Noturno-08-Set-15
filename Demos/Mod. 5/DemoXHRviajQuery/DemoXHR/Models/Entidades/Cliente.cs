using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DemoXHR.Models.Entidades
{
    public class Cliente
    {
        public int ID { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
    }
}