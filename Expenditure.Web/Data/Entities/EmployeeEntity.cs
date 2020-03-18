using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Expenditure.Web.Data.Entities
{
    public class EmployeeEntity
    {

        public int Id { get; set; }

        [MaxLength(30, ErrorMessage = "The {0} field can not have more than {1} characters.")]
        [Required(ErrorMessage = "The field {0} is mandatory.")]
        public string FirstName { get; set; }

        [MaxLength(30, ErrorMessage = "The {0} field can not have more than {1} characters.")]
        [Required(ErrorMessage = "The field {0} is mandatory.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "The field {0} is mandatory.")]
        public string PhotoPath { get; set; }

        public ICollection<TravelEntity> Travels { get; set; }
    }
}
