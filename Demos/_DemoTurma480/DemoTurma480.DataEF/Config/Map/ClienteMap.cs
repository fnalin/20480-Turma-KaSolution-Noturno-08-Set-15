using DemoTurma480.Dominio.Entidades;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;

namespace DemoTurma480.DataEF.Config.Map
{
    public class ClienteMap : EntityTypeConfiguration<Cliente>
    {

        public ClienteMap()
        {


            //Tabela
            ToTable("Cliente");

            //PK
            HasKey(key => key.ID);

            //Campos
            Property(col => col.ID)
                .HasColumnName("ID")
                .HasColumnType("int")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);


            this.Property(c => c.Nome).HasColumnName("Nome")
                .HasColumnType("varchar")
                .HasMaxLength(150).IsRequired()
                .HasColumnAnnotation(
                    IndexAnnotation.AnnotationName,
                    new IndexAnnotation(new IndexAttribute("UQ_dbo.Cliente.Nome-Nascimento", 0) { IsUnique = true }));

            this.Property(c => c.Nascimento)
                .HasColumnName("Nascimento")
                .HasColumnType("date").IsRequired()
                .HasColumnAnnotation(
                    IndexAnnotation.AnnotationName,
                    new IndexAnnotation(new IndexAttribute("UQ_dbo.Cliente.Nome-Nascimento", 1) { IsUnique = true }));


            this.Property(c => c.Sexo).HasColumnName("Sexo").HasColumnType("smallint");


        }


    }
}
