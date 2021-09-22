using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Test.Domain.Entities;

namespace Test.Infrastructure.DataAccess.Configurations
{
    public class AsignaturaAlumnoConfiguration : IEntityTypeConfiguration<AsignaturaAlumno>
    {
        public void Configure(EntityTypeBuilder<AsignaturaAlumno> builder)
        {
            builder.ToTable("AsignaturasAlumno");

            builder.HasOne(d => d.IdAlumnoNavigation)
                .WithMany(p => p.AsignaturasAlumno)
                .HasForeignKey(d => d.IdAlumno)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AsignaturasAlumno_Alumnos");

            builder.HasOne(d => d.IdAsignaturaNavigation)
                .WithMany(p => p.AsignaturasAlumno)
                .HasForeignKey(d => d.IdAsignatura)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AsignaturasAlumno_Asignaturas");
        }
    }
}