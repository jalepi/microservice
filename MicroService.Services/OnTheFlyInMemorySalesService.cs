using MicroService.Models;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MicroService.Services
{
    public class OnTheFlyInMemorySalesService : ISalesService
    {
        readonly private ConcurrentDictionary<string, SalesItem> _salesItems = new ConcurrentDictionary<string, SalesItem>();

        public async Task<string> AddSalesItemAsync(SalesItem salesItem, CancellationToken cancellationToken)
        {
            var id = await Task.FromResult($"{Guid.NewGuid()}");

            _salesItems.TryAdd(id, salesItem);

            return id;
        }

        public async Task<IEnumerable<TotalRevenuePerDay>> GetTotalRevenuePerDaysAsync(CancellationToken cancellationToken)
        {
            var query = from kvp in _salesItems
                        let salesItem = kvp.Value
                        group salesItem by salesItem.DateTime.Date into @group
                        select new TotalRevenuePerDay
                        {
                            Date = @group.Key,
                            Value = @group.Sum(item => item.SalesPrice),
                        };

            return await Task.FromResult(query);
        }

        public async Task<IEnumerable<TotalRevenuePerSalesItem>> GetTotalRevenuePerSalesItemsAsync(CancellationToken cancellationToken)
        {
            var query = from kvp in _salesItems
                        let salesItem = kvp.Value
                        group salesItem by salesItem.ArticleNumber into @group
                        select new TotalRevenuePerSalesItem
                        {
                            ArticleNumber = @group.Key,
                            Value = @group.Sum(item => item.SalesPrice),
                        };

            return await Task.FromResult(query);
        }

        public async Task<IEnumerable<TotalSalesPerDay>> GetTotalSalesPerDaysAsync(CancellationToken cancellationToken)
        {
            var query = from kvp in _salesItems
                        let salesItem = kvp.Value
                        group salesItem by salesItem.DateTime.Date into @group
                        select new TotalSalesPerDay
                        {
                            Date = @group.Key,
                            Count = @group.LongCount(),
                        };

            return await Task.FromResult(query);
        }
    }
}
