using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GreenAndGo.Models
{
    public class QueryViewModel
    {
        [Required]
        [Display(Name = "To Postcode")]
        public string DestinationPostcode { get; set; }
        [Required]
        [Display(Name = "From Postcode")]
        public string OriginPostcode { get; set; }
        [Required]
        public Parcel[] Parcels { get; set; }
        [Display(Name = "Time to Collect")]
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