﻿using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace MicroService.Models
{
    /// <summary>
    /// Total Revenue of the day
    /// </summary>
    [DataContract]
    public class TotalRevenuePerDay
    {
        /// <summary>
        /// Date of the sales revenue
        /// </summary>
        [DataMember]
        public DateTime Date { get; set; }

        /// <summary>
        /// Revenue total value of the day
        /// </summary>
        [DataMember]
        public decimal Value { get; set; }
    }
}