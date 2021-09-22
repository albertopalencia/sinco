using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Test.Domain.Entities;

namespace Test.Infrastructure.DataAccess.Configurations
{
    public class AsignaturaProfesorConfiguration : IEntityTypeConfiguration<AsignaturaProfesor>
    {
        public void Configure(EntityTypeBuilder<AsignaturaProfesor> builder)
        {
            builder.ToTable("AsignaturaProfesor");

            builder.HasIndex(e => new { e.IdAsignatura, e.IdProfesor }, "uq_AsiganturaProfesor")
                .IsUnique();

            builder.HasOne(d => d.IdAsignaturaNavigation)
                .WithMany(p => p.AsiganturaProfesor)
                .HasForeignKey(d => d.IdAsignatura)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AsiganturaProfesor_Asignaturas");

            builder.HasOne(d => d.IdProfesorNavigation)
                .WithMany(p => p.AsiganturaProfesor)
                .HasForeignKey(d => d.IdProfesor)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AsiganturaProfesor_Profesores");
        }
    }
}