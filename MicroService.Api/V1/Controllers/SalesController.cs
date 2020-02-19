using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MicroService.Api.V1.Controllers
{
    [ApiController]
    public class SalesController : ControllerBase
    {
        private readonly Services.ISalesService _salesService;

        public SalesController(Services.ISalesService salesService)
        {
            this._salesService = salesService;
        }

        [HttpPost(Routes.Sales.PostItem)]
        [Produces(typeof(Schema.UpdateSalesItem))]
        public async Task<IActionResult> PostItem([FromBody] Schema.CreateSalesItem request, CancellationToken cancellationToken)
        {
            var model = new Models.SalesItem
            {
                ArticleNumber = request.ArticleNumber,
                DateTime = request.DateTime,
                SalesPrice = request.SalesPrice,
            };

            var id = await this._salesService.AddSalesItemAsync(model, cancellationToken);

            var response = new Schema.UpdateSalesItem
            {
                Id = id,
                ArticleNumber = model.ArticleNumber,
                DateTime = model.DateTime,
                SalesPrice = model.SalesPrice,
            };

            return Ok(response);
        }

        [HttpGet(Routes.Sales.GetTotalRevenuesPerDay)]
        [Produces(typeof(Schema.TotalRevenuePerDay[]))]
        public async Task<IActionResult> GetTotalRevenuesPerDay(CancellationToken cancellationToken)
        {
            var models = await this._salesService.GetTotalRevenuesPerDayAsync(cancellationToken);

            var response = (
                from model in models
                select new Schema.TotalRevenuePerDay
                {
                    Date = model.Date,
                    Value = model.Value,
                });

            return Ok(response);
        }

        [HttpGet(Routes.Sales.GetTotalRevenuesPerSalesItem)]
        [Produces(typeof(Schema.TotalRevenuePerSalesItem[]))]
        public async Task<IActionResult> GetTotalRevenuesPerSalesItem(CancellationToken cancellationToken)
        {
            var models = await this._salesService.GetTotalRevenuesPerSalesItemAsync(cancellationToken);

            var response = (
                from model in models
                select new Schema.TotalRevenuePerSalesItem
                {
                    ArticleNumber = model.ArticleNumber,
                    Value = model.Value,
                });

            return Ok(response);
        }

        [HttpGet(Routes.Sales.GetTotalSalesItemsPerDay)]
        [Produces(typeof(Schema.TotalSalesItemPerDay[]))]
        public async Task<IActionResult> GetTotalSalesItemsPerDay(CancellationToken cancellationToken)
        {
            var models = await this._salesService.GetTotalSalesItemsPerDayAsync(cancellationToken);

            var response = (
                from model in models
                select new Schema.TotalSalesItemPerDay
                {
                    Date = model.Date,
                    Count = model.Count,
                });

            return Ok(models);
        }
    }
}
