using DemoTurma480.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoTurma480.DataEF.Contexto
{
    public class DemoCliContexto : DbContext
    {


        static DemoCliContexto()
        {
            //Database.SetInitializer<DemoCliContexto>(null);
            Database.SetInitializer<DemoCliContexto>(new DemoCliDBInitializer<DemoCliContexto>());
            //Database.SetInitializer<DemoCliContexto>(new CreateDatabaseIfNotExists<DemoCliContexto>());
            //Database.SetInitializer<DemoCliContexto>(new DropCreateDatabaseIfModelChanges<DemoCliContexto>());
            //Database.SetInitializer<DemoCadCliContexto>(new DropCreateDatabaseAlways<DemoCadCliContexto>());
        }

        public DemoCliContexto()
            //: base("Name=DemoCadCliLocalDB")
            : base(@"Data Source=(localdb)\v11.0;Initial Catalog=DemoCadCli;Integrated Security=True")
        { }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Telefone> Telefones { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new Config.Map.ClienteMap());
            modelBuilder.Configurations.Add(new Config.Map.TelefoneMap());
        }

    }

}
