using Expenditure.Common.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Expenditure.Common.Services
{
    public interface IApiService
    {
        Task<Response> GetListAsync<T>(string urlBase, string servicePrefix, string controller);
    }
}
