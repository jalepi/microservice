namespace MicroService.Api.V1
{
    /// <summary>
    /// Specification of routes of API version 1
    /// </summary>
    static public class Routes
    {
        /// <summary>
        /// Base route for ALL version 1 routes
        /// </summary>
        public const string Base = "api/v1";

        /// <summary>
        /// Sales routes @refer=""
        /// </summary>
        static public class Sales
        {
            /// <summary>
            /// Route for posting Sales Item. <see cref="Controllers.SalesController.PostItem(Schema.CreateSalesItem, System.Threading.CancellationToken)"/>
            /// </summary>
            public const string PostItem = Base + "/sales/item";

            /// <summary>
            /// Route for getting Total Revenues per Day. <see cref="Controllers.SalesController.GetTotalRevenuesPerDay(System.Threading.CancellationToken)"/>
            /// </summary>
            public const string GetTotalRevenuesPerDay = Base + "/sales/revenue-per-day";

            /// <summary>
            /// Route for getting Total Revenues per Sales Item. <see cref="Controllers.SalesController.GetTotalRevenuesPerSalesItem(System.Threading.CancellationToken)"/>
            /// </summary>
            public const string GetTotalRevenuesPerSalesItem = Base + "/sales/revenue-per-item";

            /// <summary>
            /// Route for getting Total Sales Items per Day. <see cref="Controllers.SalesController.GetTotalSalesItemsPerDay(System.Threading.CancellationToken)"/>
            /// </summary>
            public const string GetTotalSalesItemsPerDay = Base + "/sales/item-per-day";
        }
    }
}
