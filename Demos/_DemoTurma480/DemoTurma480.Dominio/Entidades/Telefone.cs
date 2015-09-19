using DemoTurma480.Dominio.Enums;
using System.Collections.Generic;

namespace DemoTurma480.Dominio.Entidades
{
    public class Telefone
    {

        public Telefone()
        {
            Clientes = new List<Cliente>();
        }

        public int ID { get; set; }
        public int CodArea { get; set; }
        public string Numero { get; set; }
        public string Descricao { get; set; }
        public virtual ICollection<Cliente> Clientes { get; set; }


    }
}
