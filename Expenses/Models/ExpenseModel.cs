using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Expenses.Models
{
    public class ExpenseModel
    {
        public DateTime ExpenseDate;
        public string Description;
        public string Category;
        public string SubCategory;
        public double ExpenseAmount;
    }
}