using InsanKaynaklari.DataAccess.Configuration;
using InsanKaynaklari.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsanKaynaklari.DataAccess.Context
{
    public class DatabaseContext :DbContext
    {
        public DbSet<Company> Companies { get; set; }
        public DbSet<Personel> Personels { get; set; }
        public DbSet<PersonelDetail> PersonelDetails { get; set; }
        public DbSet<AdvancePayment> AdvancePayments { get; set; }
        public DbSet<Debit> Debits { get; set; }
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<ExpenseType> ExpenseTypes { get; set; }
        public DbSet<Shift> Shifts { get; set; }
        public DbSet<Leave> Leaves { get; set; }
        public DbSet<LeaveType> LeaveTypes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=kolayikdb.database.windows.net; Database=HumanResources; User Id=Takim3ik; Password=Ad19955991;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Personel>().HasOne(p => p.PersonelDetail).WithOne(p => p.Personel).HasForeignKey<PersonelDetail>(p => p.ID);
            modelBuilder.ApplyConfiguration(new LeaveTypeMAP());
            modelBuilder.ApplyConfiguration(new LeaveMAP());
            modelBuilder.ApplyConfiguration(new PersonelDetailsMAP());
        }

    }
}
