using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UDV_WebApp.DataAccess.Entities;

namespace UDV_WebApp.DataAccess.Configurations
{
    public class CountResultConfiguration : IEntityTypeConfiguration<CountResultEntity>
    {
        public void Configure(EntityTypeBuilder<CountResultEntity> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(c => c.LettersCount)
                .IsRequired();
        }
    }
}
