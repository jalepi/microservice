using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MicroService.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SalesController : ControllerBase
    {
        private Services.ISalesService _salesService;

        public SalesController(Services.ISalesService salesService)
        {
            this._salesService = salesService;
        }

        [HttpPost("item")]
        public async Task<string> PostItem([FromBody] Models.SalesItem salesItem, CancellationToken cancellationToken)
        {
            return await this._salesService.AddSalesItemAsync(salesItem, cancellationToken);
        }

        [HttpGet("revenue-per-day")]
        public async Task<IEnumerable<Models.TotalRevenuePerDay>> GetTotalRevenuesPerDay(CancellationToken cancellationToken)
        {
            return await this._salesService.GetTotalRevenuesPerDayAsync(cancellationToken);
        }

        [HttpGet("revenue-per-item")]
        public async Task<IEnumerable<Models.TotalRevenuePerSalesItem>> GetTotalRevenuesPerSalesItem(CancellationToken cancellationToken)
        {
            return await this._salesService.GetTotalRevenuesPerSalesItemAsync(cancellationToken);
        }

        [HttpGet("item-per-day")]
        public async Task<IEnumerable<Models.TotalSalesItemPerDay>> GetTotalSalesItemsPerDay(CancellationToken cancellationToken)
        {
            return await this._salesService.GetTotalSalesItemsPerDayAsync(cancellationToken);
        }
    }
}
