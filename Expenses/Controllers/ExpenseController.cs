using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Expenses.Models;
using Expenses.Data;

namespace Expenses.Controllers
{
    public class ExpenseController : ApiController
    {
        private ExpensesContext db = new ExpensesContext();

        [HttpGet]
        public IEnumerable<ExpenseModel> Get()
        {
            List<ExpenseModel> expenses = new List<ExpenseModel>();
            foreach (DbExpense expense in db.Expenses.ToList())
            {
                expenses.Add(new ExpenseModel()
                {
                    ExpenseDate = expense.ExpenseDate,
                    Description = expense.Description,
                    Category = expense.Category,
                    SubCategory = expense.SubCategory,
                    ExpenseAmount = Convert.ToDouble(expense.ExpenseAmount)
                });
            }
            return expenses;
        }

        [HttpPost]
        public string Post(ExpenseModel model)
        {
            if (model != null)
            {
                try
                {
                    DbExpense dbExp = new DbExpense()
                    {
                        Category = model.Category,
                        Description = model.Description,
                        ExpenseAmount = Convert.ToDecimal(model.ExpenseAmount),
                        ExpenseDate = model.ExpenseDate,
                        SubCategory = model.SubCategory,
                        UserCreated = "UserID",//If this is new record
                        UserModified = "UserID",
                        DateCreated = DateTime.Now,
                        DateModified = DateTime.Now

                    };
                    //db.Expenses.Add(new DbExpense()
                    //{
                    //    Category = model.Category,
                    //    Description = model.Description,
                    //    ExpenseAmount = Convert.ToDecimal(model.ExpenseAmount),
                    //    ExpenseDate = model.ExpenseDate,
                    //    SubCategory = model.SubCategory,
                    //    UserCreated = "UserID",//If this is new record
                    //    UserModified = "UserID"
                    //});
                    //db.SaveChangesAsync();
                    //return "success";

                    db.Entry(dbExp).State = System.Data.Entity.EntityState.Added;
                    db.SaveChanges();
                    return "success";

                }
                catch (Exception ex)
                {
                    //Handle or Log
                    return "Error";
                }
            }
            else
            {
                return "Enter Values";
            }
        }
    }
}
