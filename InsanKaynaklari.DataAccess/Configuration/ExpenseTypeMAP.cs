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
    public class ExpenseTypeMAP: BaseMap<ExpenseType>, IEntityTypeConfiguration<ExpenseType>
    {
        public void Configure(EntityTypeBuilder<ExpenseType> builder)
        {
            builder.Property(x => x.ExpenseTypeName).IsRequired().HasMaxLength(50);
           
        }
    }
}
