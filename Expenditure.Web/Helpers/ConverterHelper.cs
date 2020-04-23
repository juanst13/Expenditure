using Expenditure.Web.Data.Entities;
using Expenditure.Web.Models;

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

        public TravelEntity ToTravelEntity(TravelViewModel model, string path, bool isNew)
        {
            return new TravelEntity
            {
                EndDate = model.EndDate.ToUniversalTime(),
                Expenses = model.Expenses,
                Id = isNew ? 0 : model.Id,
                IsActive = model.IsActive,
                LogoPath = path,
                City = model.City,
                Observation = model.Observation,
                StartDate = model.StartDate.ToUniversalTime()
            };
        }

        public TravelViewModel ToTravelViewModel(TravelEntity travelEntity)
        {
            return new TravelViewModel
            {
                EndDate = travelEntity.EndDate,
                Expenses = travelEntity.Expenses,
                Id = travelEntity.Id,
                IsActive = travelEntity.IsActive,
                LogoPath = travelEntity.LogoPath,
                City = travelEntity.City,
                Observation = travelEntity.Observation,
                StartDate = travelEntity.StartDate
            };
        }

    }
}

