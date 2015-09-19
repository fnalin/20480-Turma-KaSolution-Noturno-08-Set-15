using DemoTurma480.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace DemoTurma480.DataEF.Contexto
{
    public class DemoCliDBInitializer<TContext> : CreateDatabaseIfNotExists<TContext> where TContext : DbContext
    {
        protected override void Seed(TContext context)
        {
            var clientes =
                new List<Cliente> { 
                    new Cliente 
                    { Nome="Fabiano Nalin",
                        Nascimento = new DateTime(1978,10,12), 
                        Sexo = Dominio.Enums.Sexo.Masculino,
                        Telefones = new List<Telefone>(){
                            new Telefone{CodArea=11,Numero="31577266",Descricao="Telefone residencial"},
                            new Telefone{CodArea=11,Numero="876038670",Descricao="Telefone celular da Claro"},
                            new Telefone{CodArea=11,Numero="96214228",Descricao="recados"},
                        }
                    },
                    new Cliente { Nome="Priscila Nalin",Nascimento = new DateTime(1979,07,8), Sexo = Dominio.Enums.Sexo.Feminino},
                    new Cliente { Nome="Raphael Nalin",Nascimento = new DateTime(1998,09,21), Sexo = Dominio.Enums.Sexo.Feminino},
                };

            (context as DemoCliContexto).Clientes.AddRange(clientes);

            base.Seed(context);
        }
    }
}
