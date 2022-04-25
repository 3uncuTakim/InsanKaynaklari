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
    public class PersonelEventMAP : IEntityTypeConfiguration<PersonelEvent>
    {
        public void Configure(EntityTypeBuilder<PersonelEvent> builder)
        {
            builder.HasKey(p => new { p.EventID, p.PersonelID });
            builder.HasOne(p => p.Event).WithMany(p => p.PersonelEvents).HasForeignKey(p => p.EventID);
            builder.HasOne(p => p.Personel).WithMany(p => p.PersonelEvents).HasForeignKey(p => p.PersonelID);
        }
    }
}
