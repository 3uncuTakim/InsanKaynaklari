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
    public class EventMAP : BaseMap<Event>, IEntityTypeConfiguration<Event>
    {
        public void Configure(EntityTypeBuilder<Event> builder)
        {
            builder.Property(x => x.Title).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Start).IsRequired().HasDefaultValueSql("getdate()");
            builder.Property(x => x.End).IsRequired().HasDefaultValueSql("getdate()");
            builder.Property(x => x.Color).IsRequired().HasMaxLength(10); 
            builder.Property(x => x.TextColor).IsRequired().HasMaxLength(10);
        }
    }
}
