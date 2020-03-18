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

        [DataType(DataType.DateTime)]
        [Display(Name = "Expenditure Date")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = false)]
        public DateTime ExpenditureDate { get; set; }

        [Required(ErrorMessage = "The field {0} is mandatory.")]
        [Display(Name = "Expense value")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public int ExpenseValue { get; set; }

        [Display(Name = "Photo")]
        public string PhotoPath { get; set; }

        public TravelEntity Travels { get; set; }
    }
}
