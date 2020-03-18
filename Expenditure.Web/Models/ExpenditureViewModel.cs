using Expenditure.Web.Data.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Expenditure.Web.Models
{
    public class ExpenditureViewModel : ExpenditureEntity
    {
        [Display(Name = "Photo")]
        public IFormFile PhotoFile { get; set; }

    }
}
