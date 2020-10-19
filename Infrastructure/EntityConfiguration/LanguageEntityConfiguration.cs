using FinalProjectSecondCut.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProjectSecondCut.Infrastructure.EntityConfiguration
{
    public class LanguageEntityConfiguration : IEntityTypeConfiguration<Language>
    {
        public void Configure(EntityTypeBuilder<Language> LanguageConfiguration)
        {
            LanguageConfiguration.HasKey(l => l.Id);
            LanguageConfiguration.Property(l => l.Language_name)
                .HasMaxLength(30)
                .IsRequired();
        }
    }
}
