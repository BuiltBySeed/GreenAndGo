using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GreenAndGo.Helpers
{
    public static class AddressHelper
    {
        public static bool IsTheSame(this Models.Address address1, Models.Address address2)
        {
            return address1.Postcode == address2.Postcode
                && (string.IsNullOrEmpty(address1.AddressLine1) || string.IsNullOrEmpty(address2.AddressLine1));
        }
    }
}