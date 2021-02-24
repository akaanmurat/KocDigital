using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using KocDigitalPOC.Data.Filters;
using KocDigitalPOC.Data.Entities;
using KocDigitalPOC.WebApi.Services.DataFrameService;

namespace KocDigitalPOC.WebApi.Controllers
{
    [Route("api/dataframe")]
    public class DataFrameController : Controller
    {
        private readonly IDataFrameService _dataFrameService;

        public DataFrameController(IDataFrameService dataFrameService)
        {
            _dataFrameService = dataFrameService;
        }

        [HttpGet]
        public async Task<IActionResult> Get(DataFrameFilter filter)
        {
            var result = await _dataFrameService.Get(filter);

            return Ok(result);
        }

        [HttpGet]
        [Route("getCount")]
        public async Task<IActionResult> GetCount()
        {
            var result = await _dataFrameService.GetCount();

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] DataFrame dataFrame)
        {
            await _dataFrameService.Add(dataFrame);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] DataFrame dataFrame)
        {
            await _dataFrameService.Update(dataFrame);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] DataFrame dataFrame)
        {
            await _dataFrameService.Remove(dataFrame);
            return Ok();
        }
    }
}