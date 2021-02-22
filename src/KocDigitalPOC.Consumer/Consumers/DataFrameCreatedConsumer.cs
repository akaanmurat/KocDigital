using MassTransit;
using System.Net.Http;
using System.Threading.Tasks;
using KocDigitalPOC.Core.MessageContracts;
using System.Text;
using Newtonsoft.Json;

namespace KocDigitalPOC.Consumer.Consumers
{
    public class DataFrameCreatedConsumer : IConsumer<IDataFrameCreated>
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public DataFrameCreatedConsumer(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task Consume(ConsumeContext<IDataFrameCreated> context)
        {
            var dataFrame = context.Message;
            var client = _httpClientFactory.CreateClient();
            var content = new StringContent(JsonConvert.SerializeObject(dataFrame), Encoding.UTF8, "application/json");
            await client.PostAsync("http://kocdigitalpoc.webapi/api/dataframe", content);
        }
    }
}