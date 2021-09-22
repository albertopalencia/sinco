using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Test.Domain.Entities;

namespace Test.Infrastructure.DataAccess.Configurations
{
    public class ProfesorConfiguration : IEntityTypeConfiguration<Profesor>
    { 
        public void Configure(EntityTypeBuilder<Profesor> builder)
        {
            builder.ToTable("Profesores");

            builder.Property(e => e.Apellido)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.Direccion)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false);

            builder.Property(e => e.Identificacion)
                .IsRequired()
                .HasMaxLength(20)
                .IsUnicode(false);

            builder.Property(e => e.Nombre)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.Telefono)
                .IsRequired()
                .HasMaxLength(20)
                .IsUnicode(false);
        }
    }
}