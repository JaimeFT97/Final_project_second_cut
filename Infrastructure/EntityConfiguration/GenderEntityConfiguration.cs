using FinalProjectSecondCut.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProjectSecondCut.Infrastructure.EntityConfiguration
{
    public class GenderEntityConfiguration : IEntityTypeConfiguration<Gender>
    {
        public void Configure(EntityTypeBuilder<Gender> GenderConfiguration)
        {
            GenderConfiguration.HasKey(g => g.Id);
            GenderConfiguration.Property(g => g.Gender_name)
                .HasMaxLength(30)
                .IsRequired();
        }
    }
}
