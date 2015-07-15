using System.Data.Entity;

namespace Expenses.Data
{
    public class ExpensesContext : DbContext
    {
        public ExpensesContext()
            : base("name=DefaultConnection")
        {
            Database.SetInitializer<ExpensesContext>(new ExpensesContextInitializer());
        }

        protected override void Dispose(bool disposing)
        {
            this.Configuration.LazyLoadingEnabled = false;
            base.Dispose(disposing);
        }

        public virtual DbSet<DbExpense> Expenses { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<DbExpense>()
                .Property(e => e.ExpenseAmount)
                .HasPrecision(10, 2);
        }

    }
}
