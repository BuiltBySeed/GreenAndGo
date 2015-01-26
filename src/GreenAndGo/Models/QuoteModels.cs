﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GreenAndGo.Models
{
    public class QueryViewModel
    {
        public string DestinationPostcode { get; set; }
        public string OriginPostcode { get; set; }
        public Parcel[] Parcels { get; set; }
        public DateTime? Collection { get; set; }
    }

    public class QuoteViewModel :QueryViewModel
    {
        public Quote[] Quotes { get; set; }
    }

    public class Quote
    {
        public string Carrier { get; set; }
        public string Service { get; set; }
        public Guid ServiceId { get; set; }
        public decimal Cost { get; set; }
    }

   
}