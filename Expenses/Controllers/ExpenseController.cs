using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Expenses.Models;

namespace Expenses.Controllers
{
    public class ExpenseController : ApiController
    {
        [HttpGet]
        public IEnumerable<ExpenseModel> Get()
        {
            List<ExpenseModel> expenses = new List<ExpenseModel>();

            try
            {
                using (var db = new ExpensesContext())
                {
                    foreach (Expens expense in db.Expenses.ToList())
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
                }
            }
            catch (Exception ex)
            {
                //Handler
            }

            return expenses;
        }

        [HttpPost]
        public string Post(ExpenseModel model)
        {
            try
            {
                using (var db = new ExpensesContext())
                {
                    db.Expenses.Add(new Expens()
                    {
                        Category = model.Category,
                        Description = model.Description,
                        ExpenseAmount = Convert.ToDecimal(model.ExpenseAmount),
                        ExpenseDate = model.ExpenseDate,
                        SubCategory = model.SubCategory,
                        UserCreated = "UserID",//If this is new record
                        UserModified = "UserID"
                    });
                }
            }
            catch (Exception ex)
            {
                //Handle
            }
            return "success";
        }
    }
}
