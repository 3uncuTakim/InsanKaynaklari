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
    public class AdvancePaymentMAP : BaseMap<AdvancePayment>, IEntityTypeConfiguration<AdvancePayment>
    {
        public void Configure(EntityTypeBuilder<AdvancePayment> builder)
        {
            builder.Property(x => x.Amount).IsRequired();
            builder.Property(x => x.DateOfIssue).IsRequired().HasDefaultValueSql("getdate()");
            builder.Property(x => x.Description).IsRequired().HasMaxLength(500);
            builder.Property(x => x.ConfirmStatus).IsRequired();
            builder.Property(x => x.PersonelID).IsRequired();           
        }
    }
}
