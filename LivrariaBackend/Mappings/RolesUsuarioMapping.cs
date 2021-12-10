using LivrariaBackend.Services.Auth;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LivrariaBackend.Mappings
{
    public class RolesUsuarioMapping : IEntityTypeConfiguration<RolesUsuario>
    {
        public void Configure(EntityTypeBuilder<RolesUsuario> builder)
        {
            builder.HasKey(x=>x.Id);
            builder.Property(x => x.Nome).HasColumnType("varchar(20)");
        }
    }
}
