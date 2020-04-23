using Expenditure.Web.Data.Entities;
using Expenditure.Web.Migrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Expenditure.Web.Data
{
    public class SeedDb
    {

        private readonly DataContext _context;

        public SeedDb(DataContext context)
        {
            _context = context;
        }

        public async Task SeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();
            await CheckExpensesAsync();
            await CheckTravelsAsync();
        }

        private async Task CheckExpensesAsync()
        {
            if (!_context.Expenses.Any())
            {
                AddExpense("Alimentación", Convert.ToDateTime("2000/10/15"),35700,"TurbacoA");
                AddExpense("Transporte", Convert.ToDateTime("2000/10/14"), 250000,"TurbacoT");
                AddExpense("Hospedaje", Convert.ToDateTime("2000/10/17"), 190000,"TurbacoH");
                AddExpense("Representación", Convert.ToDateTime("2000/10/16"), 340000,"TurbacoR");
                AddExpense("Hospedaje", Convert.ToDateTime("2001/02/1"), 80000,"ArmeniaH");
                AddExpense("Transporte", Convert.ToDateTime("2001/02/3"), 80000,"ArmeniaT");
                AddExpense("Alimentación", Convert.ToDateTime("2001/02/2"), 180000, "ArmeniaA");
                AddExpense("Alimentación", Convert.ToDateTime("2002/5/30"), 70000,"AmazonasA");
                AddExpense("Hospedaje", Convert.ToDateTime("2002/6/1"), 70000,"AmazonasH");
                AddExpense("Transporte", Convert.ToDateTime("2002/6/2"), 70000,"AmazonasT");
                AddExpense("Alimentación", Convert.ToDateTime("2002/7/2"), 70000,"MetaA");
                AddExpense("Hospedaje", Convert.ToDateTime("2002/7/3"), 70000,"MetaH");
                AddExpense("Transporte", Convert.ToDateTime("2002/7/3"), 70000,"MetaT");
                await _context.SaveChangesAsync();
            }
        }

            private void AddExpense(string ExpenseType, DateTime ExpenditureDate, int ExpenseValue, string PhotoPath)
            {
                _context.Expenses.Add(new ExpenditureEntity { ExpenseType = ExpenseType, ExpenditureDate = ExpenditureDate, ExpenseValue = ExpenseValue, PhotoPath = $"~/images/Expenses/{PhotoPath}.jpg" });
            }

        private async Task CheckTravelsAsync()
        {
            if (!_context.Travels.Any())
            {
                var startDate = Convert.ToDateTime("2000/10/13");
                var endDate = Convert.ToDateTime("2000/10/20");

                _context.Travels.Add(new TravelEntity
                {
                    StartDate = startDate,
                    EndDate = endDate,
                    City = "Turbaco",
                    IsActive = true,
                    Expenses = new List<ExpenditureEntity>
                    {
                        new ExpenditureEntity
                        {
                            ExpenseType = "Alimentación",
                            ExpenditureDate = Convert.ToDateTime("2000/10/15"),
                            ExpenseValue = 35700,
                            PhotoPath = $"~/images/Expenses/TurbacoR.jpg" ,
                        },
                        new ExpenditureEntity
                        {
                            ExpenseType = "Transporte",
                            ExpenditureDate = Convert.ToDateTime("2000/10/14"),
                            ExpenseValue = 250000,
                            PhotoPath = $"~/images/Expenses/TurbacoT.jpg" ,
                        },
                        new ExpenditureEntity
                        {
                            ExpenseType = "Hospedaje",
                            ExpenditureDate = Convert.ToDateTime("2000/10/17"),
                            ExpenseValue = 190000,
                            PhotoPath = $"~/images/Expenses/TurbacoH.jpg" ,
                        },
                        new ExpenditureEntity
                        {
                            ExpenseType = "Representación",
                            ExpenditureDate = Convert.ToDateTime("2000/10/16"),
                            ExpenseValue = 340000,
                            PhotoPath = $"~/images/Expenses/TurbacoR.jpg" ,
                        }
                    }
                });

                startDate = Convert.ToDateTime("2002/5/30");
                endDate = Convert.ToDateTime("2002/6/2");

                _context.Travels.Add(new TravelEntity
                {
                    StartDate = startDate,
                    EndDate = endDate,
                    City = "Amazonas",
                    IsActive = true,
                    Expenses = new List<ExpenditureEntity>
                    {

                        new ExpenditureEntity
                        {
                            ExpenseType = "Alimentación",
                            ExpenditureDate = Convert.ToDateTime("2002/5/30"),
                            ExpenseValue = 70000,
                            PhotoPath = $"~/images/Expenses/AmazonasA.jpg" ,
                        },
                        new ExpenditureEntity
                        {
                            ExpenseType = "Transporte",
                            ExpenditureDate = Convert.ToDateTime("2002/6/2"),
                            ExpenseValue = 70000,
                            PhotoPath = $"~/images/Expenses/AmazonasT.jpg" ,
                        },
                        new ExpenditureEntity
                        {
                            ExpenseType = "Hospedaje",
                            ExpenditureDate = Convert.ToDateTime("2002/6/1"),
                            ExpenseValue = 70000,
                            PhotoPath = $"~/images/Expenses/AmazonasH.jpg" ,
                        }
                    }
                });

                startDate = Convert.ToDateTime("2001/2/1");
                endDate = Convert.ToDateTime("2001/2/3");

                _context.Travels.Add(new TravelEntity
                {
                    StartDate = startDate,
                    EndDate = endDate,
                    City = "Armenia",
                    IsActive = true,
                    Expenses = new List<ExpenditureEntity>
                    {

                        new ExpenditureEntity
                        {
                            ExpenseType = "Alimentación",
                            ExpenditureDate = Convert.ToDateTime("2001/2/2"),
                            ExpenseValue = 180000,
                            PhotoPath = $"~/images/Expenses/ArmeniaA.jpg" ,
                        },
                        new ExpenditureEntity
                        {
                            ExpenseType = "Transporte",
                            ExpenditureDate = Convert.ToDateTime("2001/2/3"),
                            ExpenseValue = 80000,
                            PhotoPath = $"~/images/Expenses/ArmeniaT.jpg" ,
                        },
                        new ExpenditureEntity
                        {
                            ExpenseType = "Hospedaje",
                            ExpenditureDate = Convert.ToDateTime("2001/2/1"),
                            ExpenseValue = 80000,
                            PhotoPath = $"~/images/Expenses/ArmeniaH.jpg" ,
                        }
                    }
                });

                startDate = Convert.ToDateTime("2002/7/2");
                endDate = Convert.ToDateTime("2002/7/3");

                _context.Travels.Add(new TravelEntity
                {
                    StartDate = startDate,
                    EndDate = endDate,
                    City = "Meta",
                    IsActive = true,
                    Expenses = new List<ExpenditureEntity>
                    {

                        new ExpenditureEntity
                        {
                            ExpenseType = "Alimentación",
                            ExpenditureDate = Convert.ToDateTime("2002/7/2"),
                            ExpenseValue = 70000,
                            PhotoPath = $"~/images/Expenses/MetaA.jpg" ,
                        },
                        new ExpenditureEntity
                        {
                            ExpenseType = "Transporte",
                            ExpenditureDate = Convert.ToDateTime("2002/7/3"),
                            ExpenseValue = 70000,
                            PhotoPath = $"~/images/Expenses/MetaT.jpg" ,
                        },
                        new ExpenditureEntity
                        {
                            ExpenseType = "Hospedaje",
                            ExpenditureDate = Convert.ToDateTime("2002/7/3"),
                            ExpenseValue = 70000,
                            PhotoPath = $"~/images/Expenses/MetaH.jpg" ,
                        }
                    }
                });
                await _context.SaveChangesAsync();
            }
        }

    }
}

