using Expenditure.Web.Data.Entities;
using Expenditure.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Expenditure.Web.Helpers
{
    public class ConverterHelper : IConverterHelper
    {
        public ExpenditureEntity ToExpenditureEntity(ExpenditureViewModel model, string path, bool isNew)
        {
            return new ExpenditureEntity
            {
                Id = isNew ? 0 : model.Id,
                ExpenseType = model.ExpenseType,
                ExpenditureDate = model.ExpenditureDate,
                ExpenseValue = model.ExpenseValue,
                PhotoPath = path
            };
        }

        public ExpenditureViewModel ToExpenditureViewModel(ExpenditureEntity ExpenditureEntity)
        {
            return new ExpenditureViewModel
            {
                Id = ExpenditureEntity.Id,
                ExpenseType = ExpenditureEntity.ExpenseType,
                ExpenditureDate = ExpenditureEntity.ExpenditureDate,
                ExpenseValue = ExpenditureEntity.ExpenseValue,
                PhotoPath = ExpenditureEntity.PhotoPath
            };
        }
    }
}

