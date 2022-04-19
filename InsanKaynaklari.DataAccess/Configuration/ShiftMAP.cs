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
    public class ShiftMAP : BaseMap<Shift>, IEntityTypeConfiguration<Shift>
    {
        public void Configure(EntityTypeBuilder<Shift> builder)
        {
            builder.Property(s => s.ShiftDay).IsRequired().HasDefaultValueSql("getdate()");
            builder.Property(s => s.StartOfShift).IsRequired().HasDefaultValueSql("getdate()");
            builder.Property(s => s.EndOfShift).IsRequired().HasDefaultValueSql("getdate()");
            builder.Property(s => s.Description).IsRequired().HasMaxLength(500);
        }
    }
}
