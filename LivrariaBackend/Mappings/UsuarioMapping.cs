using LivrariaBackend.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LivrariaBackend.Mappings
{
    public class UsuarioMapping : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Email).HasColumnType("varchar(60)").IsRequired();
            builder.Property(x => x.Senha).HasColumnType("varchar(20)").IsRequired();
            builder.HasOne(x => x.RolesUsuario)
                .WithMany()
                .HasForeignKey(x => x.Role);
            builder.ToTable("usuarios");

        }
    }
}
