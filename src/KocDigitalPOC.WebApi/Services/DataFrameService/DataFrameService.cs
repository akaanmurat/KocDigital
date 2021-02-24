using System.Threading.Tasks;
using KocDigitalPOC.Data.Filters;
using System.Collections.Generic;
using KocDigitalPOC.Data.Entities;
using KocDigitalPOC.Data.Repositories.DataFrameRepository;

namespace KocDigitalPOC.WebApi.Services.DataFrameService
{
    public class DataFrameService : IDataFrameService
    {
        private readonly IDataFrameRepository _dataFrameRepository;

        public DataFrameService(IDataFrameRepository dataFrameRepository)
        {
            _dataFrameRepository = dataFrameRepository;
        }

        public async Task Add(DataFrame dataFrame)
        {
            await _dataFrameRepository.Add(dataFrame);
        }

        public async Task Remove(DataFrame dataFrame)
        {
            await _dataFrameRepository.Remove(dataFrame);
        }

        public async Task Update(DataFrame dataFrame)
        {
            await _dataFrameRepository.Update(dataFrame);
        }

        public async Task<List<DataFrame>> Get(DataFrameFilter filter)
        {
            return await _dataFrameRepository.Get(filter);
        }

        public async Task<int> GetCount()
        {
            return await _dataFrameRepository.GetCount();
        }
    }
}