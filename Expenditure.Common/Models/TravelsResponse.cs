using System;
using System.Collections.Generic;
using System.Text;

namespace Expenditure.Common
{
    public class TravelsResponse
    {

        public int Id { get; set; }

        public string Observation { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime StartDateLocal => StartDate.ToLocalTime();

        public DateTime EndDate { get; set; }

        public DateTime EndDateLocal => EndDate.ToLocalTime();

        public string City { get; set; }

        public bool IsActive { get; set; }

        public string LogoPath { get; set; }

        public ICollection<ExpenseResponse> Expenses { get; set; }
    }
}