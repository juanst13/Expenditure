using System;
using System.ComponentModel.DataAnnotations;

namespace Expenditure.Web.Data.Entities
{
    public class ExpenditureEntity
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "The field {0} is mandatory.")]
        [Display(Name = "Expense type")]
        public string ExpenseType { get; set; }

        [Required(ErrorMessage = "The field {0} is mandatory.")]
        [Display(Name = "Expenditure Date")]
        public DateTime ExpenditureDate { get; set; }

        [Required(ErrorMessage = "The field {0} is mandatory.")]
        [Display(Name = "Expense value")]
        public int ExpenseValue { get; set; }

        [Required(ErrorMessage = "The field {0} is mandatory.")]
        [Display(Name = "Photo")]
        public string PhotoPath { get; set; }
    }
}
