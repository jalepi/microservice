using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MicroService.IntegrationTests
{
    public class SalesControllerTests
    {
        private readonly HttpClient client;

        public SalesControllerTests()
        {
            var factory = new WebApplicationFactory<Api.Startup>();
            this.client = factory.CreateClient();
        }

        [Fact]
        public async Task BasicTest()
        {
            var requestValue = new Api.V1.Schema.CreateSalesItem
            {
                ArticleNumber = "abc123",
                DateTime = DateTime.Now,
                SalesPrice = 100.0M,
            };

            var requestJson = Newtonsoft.Json.JsonConvert.SerializeObject(requestValue);
            var httpContent = new StringContent(requestJson, Encoding.UTF8, "application/json");
            var response = await client.PostAsync(Api.V1.Routes.Sales.PostItem, httpContent);

            Assert.Equal(System.Net.HttpStatusCode.OK, response.StatusCode);

            var responseJson = await response.Content.ReadAsStringAsync();
            var responseValue = Newtonsoft.Json.JsonConvert.DeserializeObject<Api.V1.Schema.UpdateSalesItem>(responseJson);

            Assert.False(String.IsNullOrEmpty(responseValue.Id));
            Assert.Equal(requestValue.ArticleNumber, responseValue.ArticleNumber);
            Assert.Equal(requestValue.DateTime, responseValue.DateTime);
            Assert.Equal(requestValue.SalesPrice, responseValue.SalesPrice);
        }

        [Fact]
        public async Task Http_get_methods_response_status_should_be_ok()
        {
            HttpResponseMessage response;
            response = await client.GetAsync(Api.V1.Routes.Sales.GetTotalRevenuesPerDay);
            Assert.True(response.IsSuccessStatusCode);

            response = await client.GetAsync(Api.V1.Routes.Sales.GetTotalRevenuesPerSalesItem);
            Assert.True(response.IsSuccessStatusCode);

            response = await client.GetAsync(Api.V1.Routes.Sales.GetTotalSalesItemsPerDay);
            Assert.True(response.IsSuccessStatusCode);
        }
    }
}
