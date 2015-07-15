using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Expenses.Data
{
    [DataContract(Name = "Expense", IsReference = true)]
    public class DbExpense
    {
        [DataMember]
        [Key]
        public int ExpenseId { get; set; }

        [DataMember]
        [Required]
        [StringLength(50)]
        public string Category { get; set; }

        [DataMember]
        [Required]
        [StringLength(50)]
        public string SubCategory { get; set; }

        [DataMember]
        [Required]
        [StringLength(50)]
        public string Description { get; set; }

        [DataMember]
        [Required]
        public System.DateTime ExpenseDate { get; set; }

        [DataMember]
        [Required]
        public decimal ExpenseAmount { get; set; }

        [DataMember]
        public System.DateTime DateCreated { get; set; }

        [DataMember]
        public string UserCreated { get; set; }

        [DataMember]
        public System.DateTime DateModified { get; set; }

        [DataMember]
        public string UserModified { get; set; }
    }
}
