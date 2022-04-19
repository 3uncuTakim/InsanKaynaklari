using InsanKaynaklari.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsanKaynaklari.DataAccess.Configuration
{
    public class PersonelMAP : BaseMap<Personel>, IEntityTypeConfiguration<Personel>
    {
        public void Configure(EntityTypeBuilder<Personel> builder)
        {
            builder.HasIndex(p => p.Email).IsUnique();
            builder.Property(p => p.Activation).IsRequired();
            builder.Property(p => p.Email).IsRequired().HasMaxLength(50);
            builder.Property(p => p.Password).HasMaxLength(50).IsRequired();
            builder.Property(p => p.CompanyID).IsRequired();
        }
    }
}
