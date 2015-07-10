using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Expenses.Models;
using Expenses.DataAccess;

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
                    foreach (Expense expense in db.Expenses.ToList())
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
            

            if (model != null)
            {
                try
                {
                    using (var db = new ExpensesContext())
                    {
                        db.Expenses.Add(new Expense()
                        {
                            Category = model.Category,
                            Description = model.Description,
                            ExpenseAmount = Convert.ToDecimal(model.ExpenseAmount),
                            ExpenseDate = model.ExpenseDate,
                            SubCategory = model.SubCategory,
                            UserCreated = "UserID",//If this is new record
                            UserModified = "UserID"
                        });
                        if (db.SaveChanges() > 0)
                        {
                            return "success";
                        }
                        else
                        {
                            return "No new expense item added";
                        }
                    }
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
