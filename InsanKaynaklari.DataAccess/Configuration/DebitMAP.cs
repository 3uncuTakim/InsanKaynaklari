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
    public class DebitMAP : BaseMap<Debit>, IEntityTypeConfiguration<Debit>
    {
        public void Configure(EntityTypeBuilder<Debit> builder)
        {
            builder.Property(x => x.DebitName).IsRequired().HasMaxLength(50);
            builder.Property(x => x.DebitCode).HasMaxLength(50);
            builder.Property(x => x.DateOfIssue).IsRequired().HasDefaultValueSql("getdate()");
            builder.Property(x => x.DateOfReturn).IsRequired().HasDefaultValueSql("getdate()");
            builder.Property(x => x.Description).HasMaxLength(250);
        }
    }
}
