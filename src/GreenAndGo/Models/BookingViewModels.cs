using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GreenAndGo.Models
{
    public class BookingViewModel
    {
        public Guid ServiceId { get; set; }
        public Contact Sender { get; set; }
        public Contact Recipient { get; set; }
        public Parcel[] Parcels { get; set; }
        public DateTime Collection { get; set; }
    }

    public class Contact
    {
        public string Name { get; set; }
        public Address Address { get; set; }
        public string Telephone { get; set; }
        public string Email { get; set; }
    }

    public class Address
    {
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string Town { get; set; }
        public string County { get; set; }
        public string Postcode { get; set; }
    }
}