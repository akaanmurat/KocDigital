using System.Threading.Tasks;
using KocDigitalPOC.Data.Filters;
using System.Collections.Generic;
using KocDigitalPOC.Data.Entities;

namespace KocDigitalPOC.WebApi.Services.DataFrameService
{
    public interface IDataFrameService
    {
        Task Add(DataFrame dataFrame);

        Task Remove(DataFrame dataFrame);

        Task Update(DataFrame dataFrame);

        Task<List<DataFrame>> Get(DataFrameFilter filter);

        Task<int> GetCount();
    }
}