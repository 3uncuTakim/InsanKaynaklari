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
    public class LeaveMAP : BaseMap<Leave>, IEntityTypeConfiguration<Leave>
    {      
        public  void Configure(EntityTypeBuilder<Leave> builder)
        {
            builder.Property(x => x.TotalDaysOff).IsRequired();
            builder.Property(x => x.LeaveDocument).HasMaxLength(100);
            builder.Property(x => x.StartLeaveDate).IsRequired();
            builder.Property(x => x.EndLeaveDate).IsRequired();
            builder.Property(x => x.Description).HasMaxLength(250);
            builder.Property(x => x.TaskStatus).IsRequired();
        }
    }
}
