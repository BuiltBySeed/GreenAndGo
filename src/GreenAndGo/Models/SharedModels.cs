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
        [Display(Name = "Parcel Weight (Kg)")]
        public decimal Weight { get; set; }
        [Display(Name = "Parcel Length (cm)")]
        public decimal Length { get; set; }
        [Display(Name = "Parcel Width (cm)")]
        public decimal Width { get; set; }
        [Display(Name = "Parcel Height (cm)")]
        public decimal Height { get; set; }
        [Display(Name = "Parcel Contents")]
        public string Description { get; set; }
        [Display(Name = "Parcel Value (£)")]
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