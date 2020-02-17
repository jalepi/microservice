using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace MicroService.Models
{
    /// <summary>
    /// Number of sales of a given day
    /// </summary>
    [DataContract]
    public class TotalSalesPerDay
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
