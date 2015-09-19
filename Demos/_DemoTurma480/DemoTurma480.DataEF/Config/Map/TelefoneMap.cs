using DemoTurma480.Dominio.Entidades;
using System.Data.Entity.ModelConfiguration;

namespace DemoTurma480.DataEF.Config.Map
{
    public class TelefoneMap : EntityTypeConfiguration<Telefone>
    {
        public TelefoneMap()
        {
            //Tabela
            this.ToTable("Telefone");

            // Primary Key
            this.HasKey(t => t.ID);

            // Colunas
            this.Property(t => t.Numero)
                .IsRequired()
                .HasMaxLength(9);

            this.Property(t => t.Descricao)
                .HasMaxLength(150);

            // Table & Column Mappings
            
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.CodArea).HasColumnName("DDD");
            this.Property(t => t.Numero).HasColumnName("Numero");
            this.Property(t => t.Descricao).HasColumnName("Descricao");

            // Relationships
                HasMany<Cliente>(s => s.Clientes)
                   .WithMany(c => c.Telefones)
                   .Map(cs =>
                   {
                       cs.MapLeftKey("ClienteID");
                       cs.MapRightKey("TelefoneID");
                       cs.ToTable("ClienteTelefone");
                   });

        }
    }
}
