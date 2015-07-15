using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expenses.Data
{
    public static class ExpensesData
    {
        public static IEnumerable<DbExpense> CreateDefaultExpenses()
        {
            var repository = new ExpensesRepository();
            DbExpense expense = new DbExpense()
                {
                    Category = "Hardware",
                    Description = "Hardware Expenses",
                    ExpenseAmount = 12.20M,
                    ExpenseDate = DateTime.Now,
                    DateModified = DateTime.Now,
                    DateCreated = DateTime.Now,
                    SubCategory = "RAM",
                    UserCreated = "sthunga",
                    UserModified = "sthunga"

                };
            expense = repository.SaveExpense(expense);

            DbExpense expense1 = new DbExpense()
            {
                Category = "Hardware",
                Description = "Hardware Expenses",
                ExpenseAmount = 20.00M,
                ExpenseDate = DateTime.Now,
                DateModified = DateTime.Now,
                DateCreated = DateTime.Now,
                SubCategory = "Monitor",
                UserCreated = "User55",
                UserModified = "User55"

            };
            repository.SaveExpense(expense1);

            DbExpense expense2 = new DbExpense()
            {
                Category = "Software",
                Description = "Software Expenses",
                ExpenseAmount = 100.20M,
                ExpenseDate = DateTime.Now,
                DateModified = DateTime.Now,
                DateCreated = DateTime.Now,
                SubCategory = "OS",
                UserCreated = "sthunga",
                UserModified = "sthunga"

            };
            repository.SaveExpense(expense2);

            DbExpense expense3 = new DbExpense()
            {
                Category = "Software",
                Description = "Software Expenses",
                ExpenseAmount = 302.0M,
                ExpenseDate = DateTime.Now,
                DateModified = DateTime.Now,
                DateCreated = DateTime.Now,
                SubCategory = "Maya",
                UserCreated = "sthunga",
                UserModified = "sthunga"

            };
            repository.SaveExpense(expense3);

            DbExpense expense4 = new DbExpense()
            {
                Category = "Food",
                Description = "Miscellaneous Expenses",
                ExpenseAmount = 30.02M,
                ExpenseDate = DateTime.Now,
                DateModified = DateTime.Now,
                DateCreated = DateTime.Now,
                SubCategory = "Lunch",
                UserCreated = "User2",
                UserModified = "User2"

            };
            repository.SaveExpense(expense4);

            return repository.GetExpenses();
        }
    }
}
