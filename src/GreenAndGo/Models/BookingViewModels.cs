using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GreenAndGo.Models
{
    public class BookingViewModel
    {
        [Required]
        public Guid ServiceId { get; set; }
        [Required]
        public Contact Sender { get; set; }
        [Required]
        public Contact Recipient { get; set; }
        [Required]
        public Parcel[] Parcels { get; set; }
        [Required]
        public DateTime Collection { get; set; }
    }
}