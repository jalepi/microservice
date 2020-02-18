using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicroService.Api.V1
{
    static public class Routes
    {
        public const string Base = "api/v1";

        static public class Sales
        {
            public const string PostItem = Base + "/sales/item";
            public const string GetTotalRevenuesPerDay = Base + "/sales/revenue-per-day";
            public const string GetTotalRevenuesPerSalesItem = Base + "/sales/revenue-per-item";
            public const string GetTotalSalesItemsPerDay = Base + "/sales/item-per-day";
        }
    }
}
