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
    public class ExpenseMAP : BaseMap<Expense>, IEntityTypeConfiguration<Expense>
    {
        public void Configure(EntityTypeBuilder<Expense> builder)
        {
            builder.Property(x => x.CheckDocument).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Amount).IsRequired();
            builder.Property(x => x.Explanation).IsRequired().HasMaxLength(250);
            builder.Property(x => x.ConfirmStatus).IsRequired();
            builder.Property(x => x.ExpenseTypeID).IsRequired();
            builder.Property(x => x.PersonelID).IsRequired();
        }
    }
}
