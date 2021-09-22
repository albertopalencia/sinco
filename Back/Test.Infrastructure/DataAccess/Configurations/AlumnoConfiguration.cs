using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Test.Domain.Entities;

namespace Test.Infrastructure.DataAccess.Configurations
{
    public class AlumnoConfiguration : IEntityTypeConfiguration<Alumno>
    {
        public void Configure(EntityTypeBuilder<Alumno> builder)
        {
            builder.ToTable("Alumnos");

            builder.Property(e => e.Apellido)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

            builder.Property(e => e.Direccion)
                    .IsRequired()
                    .HasMaxLength(50)
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