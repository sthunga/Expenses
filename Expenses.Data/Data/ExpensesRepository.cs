using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expenses.Data
{
    public class ExpensesRepository
    {
        public IEnumerable<DbExpense> GetExpenses()
        {
            using (var context = new ExpensesContext())
            {
                return context.Expenses.ToList();
            }
        }

        public DbExpense GetExpense(int expenseId)
        {
            using (var context = new ExpensesContext())
            {
                return context.Expenses.SingleOrDefault(e => e.ExpenseId == expenseId);
            }
        }

        public DbExpense SaveExpense(DbExpense expense)
        {
            using (var context = new ExpensesContext())
            {
                context.Expenses.Add(expense);
                context.SaveChanges();
                return expense;
            }
        }

        public void CleanRepository()
        {
            using (var context = new ExpensesContext())
            {
                context.Expenses.RemoveRange(context.Expenses);
                context.SaveChanges();
            }
        }

    }
}
