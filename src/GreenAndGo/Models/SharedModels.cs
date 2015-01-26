using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GreenAndGo.Models
{
    public static class Constants
    {
        //GBP
        public const int Currency = 826;
        //UK
        public const int CountryIso = 826;
        public const string Country = "UK";
    }

    public class Parcel
    {
        [Required]
        public decimal Weight { get; set; }
        public decimal Length { get; set; }
        public decimal Width { get; set; }
        public decimal Height { get; set; }
        public string Description { get; set; }
        public decimal Value { get; set; }
    }

    public class Contact
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public Address Address { get; set; }
        [Phone]
        public string Telephone { get; set; }
        [EmailAddress]
        public string Email { get; set; }
    }

    public class Address
    {
        [Required]
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        [Required]
        public string Town { get; set; }
        public string County { get; set; }
        [Required]
        public string Postcode { get; set; }
    }
}