using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Test.Domain.Entities;

namespace Test.Infrastructure.DataAccess.Configurations
{
	public class AsignaturaConfiguration : IEntityTypeConfiguration<Asignatura>
	{
		public void Configure(EntityTypeBuilder<Asignatura> builder)
		{
			builder.ToTable("Asignaturas");
			 
			builder.Property(e => e.Nombre)
				.IsRequired()
				.HasMaxLength(20)
				.IsUnicode(false);
		}
	}
}