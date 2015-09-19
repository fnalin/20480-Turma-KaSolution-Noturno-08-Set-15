using DemoTurma480.Dominio.Enums;
using System.Collections.Generic;
using System;

namespace DemoTurma480.Dominio.Entidades
{
    public class Cliente
    {

        public Cliente()
        {
            Telefones = new List<Telefone>();
        }


        public int ID { get; set; }
        public string Nome { get; set; }
        public virtual ICollection<Telefone> Telefones { get; set; }
        public Sexo Sexo { get; set; }
        public DateTime Nascimento { get; set; }
        public string NascFormatado { get { return Nascimento.ToShortDateString(); } }
    }
}
