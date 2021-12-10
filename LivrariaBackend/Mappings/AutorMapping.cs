using LivrariaBackend.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LivrariaBackend.Mappings
{
    public class AutorMapping : IEntityTypeConfiguration<Autor>
    {
        public void Configure(EntityTypeBuilder<Autor> builder)
        {
            builder.HasKey(x=>x.Id);
            builder.Property(x => x.Nome).HasColumnType("varchar(60)").IsRequired();
            builder.Property(x => x.SobreNome).HasColumnType("varchar(60)").IsRequired();
            builder.Property(x => x.CriadoEm);
            builder.ToTable("autores");
                }
    }
}
