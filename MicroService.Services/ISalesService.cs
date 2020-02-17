using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MicroService.Services
{
    public interface ISalesService
    {
        Task<string> AddSalesItemAsync(Models.SalesItem salesItem, CancellationToken cancellationToken);

        Task<IEnumerable<Models.TotalRevenuePerDay>> GetTotalRevenuesPerDayAsync(CancellationToken cancellationToken);

        Task<IEnumerable<Models.TotalRevenuePerSalesItem>> GetTotalRevenuesPerSalesItemAsync(CancellationToken cancellationToken);

        Task<IEnumerable<Models.TotalSalesItemPerDay>> GetTotalSalesItemsPerDayAsync(CancellationToken cancellationToken);
    }
}
