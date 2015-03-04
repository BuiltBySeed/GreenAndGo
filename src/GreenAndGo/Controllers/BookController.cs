using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GreenAndGo.Properties;
using GreenAndGo.Helpers;
using Microsoft.AspNet.Identity;
using System.ComponentModel.DataAnnotations;

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
                if (this.User.Identity.IsAuthenticated)
                {
                    using (var db = new Models.Data.ModelContainer())
                    {
                        //If a user is signed in and have no contact information let's assume the first booking 
                        //they do is from their address/contact
                        var id = Guid.Parse(User.Identity.GetUserId());
                        Models.Data.User user = db.Users.First(x => x.Id == id);
                        if (user.Contact == null)
                        {
                            user.Contact = booking.Sender;
                        }
                        if (user.Contact.Address == null)
                        {
                            user.Contact.Address = booking.Sender.Address;
                        }
                        db.SaveChanges();
                    }
                }
                var client = Services.Sendvia.Client;
                var receipt = client.Booking_Create(new Net.Sendvia.Models.Booking
                {
                    PaymentMethod = "Paypal",
                    Currency = Models.Constants.Currency,
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
                                        CountryIso  = Models.Constants.CountryIso,
                                        Country = Models.Constants.Country
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
                                        CountryIso  = Models.Constants.CountryIso,
                                        Country = Models.Constants.Country
                                    }
                                },
                                Collection = booking.Collection,
                                Parcels = booking.Parcels.Select(x=>
                                {
                                    return new Net.Sendvia.Models.Parcel
                                    {
                                       Weight = (int) x.Weight *1000, //Kg to g
                                       Size = (x.Length.HasValue && x.Height.HasValue && x.Width.HasValue) ?
                                       new Net.Sendvia.Models.Dimension
                                       {
                                           Length = (int)x.Length * 10, //cm to mm
                                           Height = (int)x.Height * 10,//cm to mm
                                           Width = (int)x.Width * 10,//cm to mm
                                       }
                                       : null,
                                       Description = x.Description,
                                       Value = x.Value,
                                       Currency = Models.Constants.Currency
                                    };
                                }).ToList()
                            }
                        }
                    }
                });
               
                return Redirect(string.Format("{0}?clientid={1}", receipt.PaymentUrl, Settings.Default.Client_Id));
            }
            else
            {
                if (this.User.Identity.IsAuthenticated)
                {
                    using (var db = new Models.Data.ModelContainer())
                    {
                        var id =Guid.Parse(User.Identity.GetUserId());
                        Models.Data.User user = db.Users.First(x => x.Id == id);
                        if (Validator.TryValidateObject(booking.Sender, new ValidationContext(booking.Sender, null, null), null))
                        {
                            if (user.Contact == null)
                            {
                                user.Contact = booking.Sender;
                            }
                            if (user.Contact.Address == null)
                            {
                                user.Contact.Address = booking.Sender.Address;
                            } 
                        }
                        if (booking.Sender == null || (booking.Sender!=null && user.Contact != null && user.Contact.Address !=null && user.Contact.Address.IsTheSame(booking.Sender.Address)))
                        {
                            booking.Sender = user.Contact;
                        }
                        try
                        {
                            db.SaveChanges();
                        }
                        catch (Exception ex)
                        {
                            throw ex;
                        }
                    }
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