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

        Task<IEnumerable<Models.TotalRevenuePerDay>> GetTotalRevenuePerDaysAsync(CancellationToken cancellationToken);

        Task<IEnumerable<Models.TotalRevenuePerSalesItem>> GetTotalRevenuePerSalesItemsAsync(CancellationToken cancellationToken);

        Task<IEnumerable<Models.TotalSalesPerDay>> GetTotalSalesPerDaysAsync(CancellationToken cancellationToken);
    }
}
