using InsanKaynaklari.DataAccess.Configuration;
using InsanKaynaklari.Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace InsanKaynaklari.DataAccess.Context
{
    public class DatabaseContext :DbContext
    {
        public DatabaseContext()
        {

        }
        public DatabaseContext(DbContextOptions<DatabaseContext>options):base(options)
        {

        }
        public DbSet<Event> Events { get; set; }
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
        public DbSet<PersonelEvent> PersonelEvents { get; set; }
        

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=sql.bsite.net\\MSSQL2016; Database=takim3ik_; User Id=takim3ik_; Password=Ad19955991;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Personel>().HasOne(p => p.PersonelDetail).WithOne(p => p.Personel).HasForeignKey<PersonelDetail>(p => p.ID);
            modelBuilder.ApplyConfiguration(new LeaveTypeMAP());
            modelBuilder.ApplyConfiguration(new LeaveMAP());
            modelBuilder.ApplyConfiguration(new PersonelMAP());
            modelBuilder.ApplyConfiguration(new PersonelDetailsMAP());
            modelBuilder.ApplyConfiguration(new DebitMAP());
            modelBuilder.ApplyConfiguration(new ExpenseMAP());
            modelBuilder.ApplyConfiguration(new ExpenseTypeMAP());
            modelBuilder.ApplyConfiguration(new ShiftMAP());
            modelBuilder.ApplyConfiguration(new AdvancePaymentMAP());
            modelBuilder.ApplyConfiguration(new CompanyMAP());
            modelBuilder.ApplyConfiguration(new PersonelEventMAP());

            


        }

    }
}