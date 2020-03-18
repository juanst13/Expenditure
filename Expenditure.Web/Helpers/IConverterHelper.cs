using Expenditure.Web.Data.Entities;
using Expenditure.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Expenditure.Web.Helpers
{
    public interface IConverterHelper
    {
        ExpenditureEntity ToExpenditureEntity(ExpenditureViewModel model, string path, bool isNew);

        ExpenditureViewModel ToExpenditureViewModel(ExpenditureEntity ExpenditureEntity);
    }
}
