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
    public class PersonelDetailsMAP : BaseMap<PersonelDetail>, IEntityTypeConfiguration<PersonelDetail>
    {
        public void Configure(EntityTypeBuilder<PersonelDetail> builder)
        {
            builder.Property(x => x.FirstName).IsRequired().HasMaxLength(50); 
            builder.Property(x => x.LastName).IsRequired().HasMaxLength(50); 
            builder.Property(x => x.StartDate).IsRequired().HasDefaultValueSql("getdate()"); 
            builder.Property(x => x.EndDate).IsRequired().HasDefaultValueSql("getdate()");
            builder.Property(x => x.Wage).IsRequired();
            builder.Property(x => x.WorkStyle).HasMaxLength(20);
        }
    }
}
