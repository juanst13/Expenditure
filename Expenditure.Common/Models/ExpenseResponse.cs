using System;
using System.Collections.Generic;
using System.Text;

namespace Expenditure.Common
{
    public class ExpenseResponse
    {
        public int Id { get; set; }

        public string ExpenseType { get; set; }

        public DateTime ExpenditureDate { get; set; }

        public int ExpenseValue { get; set; }

        public string PhotoPath { get; set; }

    }
}