using MicroService.Models;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MicroService.Services
{
    public class InMemorySalesService : ISalesService
    {
        readonly private ConcurrentDictionary<string, SalesItem> _salesItems = new ConcurrentDictionary<string, SalesItem>();
        readonly private ConcurrentDictionary<DateTime, decimal> _totalRevenuePerDay = new ConcurrentDictionary<DateTime, decimal>();
        readonly private ConcurrentDictionary<string, decimal> _totalRevenuePerSalesItem = new ConcurrentDictionary<string, decimal>();
        readonly private ConcurrentDictionary<DateTime, long> _totalSalesPerDay = new ConcurrentDictionary<DateTime, long>();

        public async Task<string> AddSalesItemAsync(SalesItem salesItem, CancellationToken cancellationToken)
        {
            var id = await Task.FromResult($"{Guid.NewGuid()}");
            var date = salesItem.DateTime.Date;
            var price = salesItem.SalesPrice;

            _salesItems.TryAdd(id, salesItem);
            _totalRevenuePerDay.AddOrUpdate(date, price, (k, v) => v + price);
            _totalRevenuePerSalesItem.AddOrUpdate(salesItem.ArticleNumber, price, (k, v) => v + price);
            _totalSalesPerDay.AddOrUpdate(date, 1L, (k, v) => v + 1L);

            return id;
        }

        public Task<IEnumerable<TotalRevenuePerDay>> GetTotalRevenuePerDaysAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TotalRevenuePerSalesItem>> GetTotalRevenuePerSalesItemsAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TotalSalesPerDay>> GetTotalSalesPerDaysAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
