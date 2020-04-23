using Expenditure.Common;
using Expenditure.Web.Data.Entities;
using Expenditure.Web.Models;
using System.Collections.Generic;
using System.Linq;

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
                StartDate = travelEntity.StartDate,
                Observation = travelEntity.Observation,
                Id = travelEntity.Id,
                IsActive = travelEntity.IsActive,
                LogoPath = travelEntity.LogoPath,
                Expenses = travelEntity.Expenses,
                City = travelEntity.City
            };
        }

        public TravelsResponse ToTravelResponse(TravelEntity travelEntity)
        {
            return new TravelsResponse
            {
                EndDate = travelEntity.EndDate,
                StartDate = travelEntity.StartDate,
                Observation = travelEntity.Observation,
                Id = travelEntity.Id,
                IsActive = travelEntity.IsActive,
                LogoPath = travelEntity.LogoPath,
                City = travelEntity.City,
                Expenses = travelEntity.Expenses.Select(g => new ExpenseResponse
                {
                    Id = g.Id,
                    ExpenseType = g.ExpenseType,
                    ExpenditureDate = g.ExpenditureDate,
                    ExpenseValue = g.ExpenseValue,
                    PhotoPath = g.PhotoPath,
                }).ToList()
            };
        }

        public List<TravelsResponse> ToTravelResponse(List<TravelEntity> travelEntities)
        {
            List<TravelsResponse> list = new List<TravelsResponse>();
            foreach (TravelEntity tournamentEntity in travelEntities)
            {
                list.Add(ToTravelResponse(tournamentEntity));
            }

            return list;
        }

        private UserResponse ToUserResponse(UserEntity user)
        {
            if (user == null)
            {
                return null;
            }

            return new UserResponse
            {
                Address = user.Address,
                Document = user.Document,
                Email = user.Email,
                FirstName = user.FirstName,
                Id = user.Id,
                LastName = user.LastName,
                PhoneNumber = user.PhoneNumber,
                PicturePath = user.PicturePath,
                UserType = user.UserType
            };
        }

        private ExpenseResponse ToExpenseResponse(ExpenditureEntity expenditure)
        {
            if (expenditure == null)
            {
                return null;
            }

            return new ExpenseResponse
            {
                Id = expenditure.Id,
                PhotoPath = expenditure.PhotoPath,
                ExpenditureDate = expenditure.ExpenditureDate,
                ExpenseType = expenditure.ExpenseType,
                ExpenseValue = expenditure.ExpenseValue

            };
        }


    }
}

