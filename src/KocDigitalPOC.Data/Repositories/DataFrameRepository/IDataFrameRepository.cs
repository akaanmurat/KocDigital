using System.Threading.Tasks;
using System.Collections.Generic;
using KocDigitalPOC.Data.Entities;
using KocDigitalPOC.Data.Filters;

namespace KocDigitalPOC.Data.Repositories.DataFrameRepository
{
    public interface IDataFrameRepository
    {
        Task Add(DataFrame dataFrame);

        Task Remove(DataFrame dataFrame);

        Task Update(DataFrame dataFrame);

        Task<List<DataFrame>> Get(DataFrameFilter filter);
    }
}