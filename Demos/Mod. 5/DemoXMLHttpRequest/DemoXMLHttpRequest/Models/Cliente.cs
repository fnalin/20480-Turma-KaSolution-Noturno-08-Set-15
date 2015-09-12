using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DemoXMLHttpRequest.Models
{
    public class Cliente
    {
        public string ID { get; set; }
        public string Nome { get; set; }


        public static List<Cliente> GetClientes()
        {
            return new List<Cliente> { 
                new Cliente{ID="1",Nome="Fabiano"},
                new Cliente{ID="2",Nome="Raphael"},
                new Cliente{ID="3",Nome="Priscila"},
                new Cliente{ID="4",Nome="André"},
                new Cliente{ID="5",Nome="Eduardo"},
                new Cliente{ID="6",Nome="Gil"},
                new Cliente{ID="7",Nome="Filipe"},
            };
        }



    }
}