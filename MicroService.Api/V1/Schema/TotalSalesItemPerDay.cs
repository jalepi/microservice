using System;
using System.Runtime.Serialization;

namespace MicroService.Api.V1.Schema
{
    /// <summary>
    /// Number of sales of a given day
    /// </summary>
    [DataContract]
    public class TotalSalesItemPerDay
    {
        /// <summary>
        /// Date of the sales
        /// </summary>
        [DataMember]
        public DateTime Date { get; set; }

        /// <summary>
        /// Total number of items sold in the day
        /// </summary>
        [DataMember]
        public long Count { get; set; }
    }
}
