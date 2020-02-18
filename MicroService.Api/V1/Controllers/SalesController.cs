using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MicroService.Api.V1.Controllers
{
    [ApiController]
    public class SalesController : ControllerBase
    {
        private Services.ISalesService _salesService;

        public SalesController(Services.ISalesService salesService)
        {
            this._salesService = salesService;
        }

        [HttpPost(Routes.Sales.PostItem)]
        [Produces(typeof(string))]
        public async Task<IActionResult> PostItem([FromBody] Models.SalesItem salesItem, CancellationToken cancellationToken)
        {
            var id = await this._salesService.AddSalesItemAsync(salesItem, cancellationToken);
            return Ok(id);
        }

        [HttpGet(Routes.Sales.GetTotalRevenuesPerDay)]
        [Produces(typeof(Models.TotalRevenuePerDay[]))]
        public async Task<IActionResult> GetTotalRevenuesPerDay(CancellationToken cancellationToken)
        {
            var query = await this._salesService.GetTotalRevenuesPerDayAsync(cancellationToken);
            return Ok(query);
        }

        [HttpGet(Routes.Sales.GetTotalRevenuesPerSalesItem)]
        [Produces(typeof(Models.TotalRevenuePerSalesItem[]))]
        public async Task<IActionResult> GetTotalRevenuesPerSalesItem(CancellationToken cancellationToken)
        {
            var query = await this._salesService.GetTotalRevenuesPerSalesItemAsync(cancellationToken);
            return Ok(query);
        }

        [HttpGet(Routes.Sales.GetTotalSalesItemsPerDay)]
        [Produces(typeof(Models.TotalSalesItemPerDay[]))]
        public async Task<IActionResult> GetTotalSalesItemsPerDay(CancellationToken cancellationToken)
        {
            var query = await this._salesService.GetTotalSalesItemsPerDayAsync(cancellationToken);
            return Ok(query);
        }
    }
}
