using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GreenAndGo.Properties;

namespace GreenAndGo.Controllers
{
    public class BookController : Controller
    {
        //
        // GET: /Book/
        public ActionResult Index(Models.BookingViewModel booking)
        {
            if (this.ModelState.IsValid)
            {
                var client = new Net.Sendvia.Client(Settings.Default.Client_Id, Settings.Default.Client_Secret);
                var receipt = client.Booking_Create(new Net.Sendvia.Models.Booking
                {
                    PaymentMethod = "Paypal",
                    Currency = 826,
                    BookingShipments = new List<Net.Sendvia.Models.BookingShipment>
                    {
                        new Net.Sendvia.Models.BookingShipment()
                        {
                            ServiceId = booking.ServiceId,
                            Shipment = new Net.Sendvia.Models.Shipment()
                            {
                                Sender = new Net.Sendvia.Models.Contact
                                {
                                    Surname = booking.Sender.Name,
                                    PhoneNumber = booking.Sender.Telephone,
                                    Email = booking.Sender.Email,
                                    Address = new Net.Sendvia.Models.Address
                                    {
                                        Street = booking.Sender.Address.AddressLine1,
                                        Locality = booking.Sender.Address.AddressLine2,
                                        City = booking.Sender.Address.Town,
                                        GoverningDistrict  = booking.Sender.Address.County,
                                        PostalArea = booking.Sender.Address.Postcode,
                                        CountryIso  = 826,
                                        Country = "UK"
                                    }
                                },
                                Recipient = new Net.Sendvia.Models.Contact
                                {
                                    Surname = booking.Recipient.Name,
                                    PhoneNumber = booking.Recipient.Telephone,
                                    Email = booking.Recipient.Email,
                                    Address = new Net.Sendvia.Models.Address
                                    {
                                        Street = booking.Recipient.Address.AddressLine1,
                                        Locality = booking.Recipient.Address.AddressLine2,
                                        City = booking.Recipient.Address.Town,
                                        GoverningDistrict  = booking.Recipient.Address.County,
                                        PostalArea = booking.Recipient.Address.Postcode,
                                        CountryIso  = 826,
                                        Country = "UK"
                                    }
                                },
                                Collection = booking.Collection,
                                Parcels = booking.Parcels.Select(x=>
                                {
                                    return new Net.Sendvia.Models.Parcel
                                    {
                                       Weight = (int) x.Weight *1000, //Kg to g
                                       Size = new Net.Sendvia.Models.Dimension
                                       {
                                           Length = (int)x.Length *10, //cm to mm
                                           Height = (int)x.Height *10,//cm to mm
                                           Width = (int)x.Width * 10,//cm to mm
                                       },
                                       Description = x.Description
                                    };
                                }).ToList()
                            }
                        }
                    }
                });
               
                return Redirect(receipt.PaymentUrl);
            }
            else
            {
                if (this.User.Identity.IsAuthenticated)
                {
                    //TODO fill in sender information from User's address.
                }
                return View(booking);
            }
        }

        public ActionResult Complete(Guid receiptId, bool success)
        {
            return View();
        }
	}
}