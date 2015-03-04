using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GreenAndGo.Properties;

namespace GreenAndGo.Controllers
{
    public class QuoteController : Controller
    {
      
        public ActionResult Index(Models.QueryViewModel query)
        {
            if (!query.Collection.HasValue)
            {
                query.Collection = DateTime.Now.AddDays(1);
            }

            var client = Services.Sendvia.Client;
            var sQuote = client.Quote_Create(new Net.Sendvia.Models.Query
            {
                Id = Guid.NewGuid(),
                Currency = Models.Constants.Currency,
                Shipments = new List<Net.Sendvia.Models.Shipment>
                {
                    new Net.Sendvia.Models.Shipment
                    {
                        Collection = query.Collection.Value,
                        Parcels = query.Parcels.Select(x=>
                            {
                                return new Net.Sendvia.Models.Parcel
                                {
                                   Weight = (int) x.Weight *1000, //Kg to g
                                   Size = (x.Length.HasValue && x.Height.HasValue && x.Width.HasValue) ?
                                   new Net.Sendvia.Models.Dimension
                                   {
                                       Length = (int)x.Length *10, //cm to mm
                                       Height = (int)x.Height *10,//cm to mm
                                       Width = (int)x.Width * 10,//cm to mm
                                   }
                                   :null
                                };
                            }).ToList(),
                        Sender = new Net.Sendvia.Models.Contact
                        {
                            Address = new Net.Sendvia.Models.Address
                            {
                                PostalArea= query.OriginPostcode,
                                CountryIso = Models.Constants.CountryIso
                            }
                        },
                        Recipient = new Net.Sendvia.Models.Contact
                        {
                            Address = new Net.Sendvia.Models.Address
                            {
                                PostalArea = query.DestinationPostcode,
                                CountryIso =  Models.Constants.CountryIso
                            }
                        }
                    }
                }
            }, null);

            var quote = new Models.QuoteViewModel
            {
                DestinationPostcode = query.DestinationPostcode,
                OriginPostcode = query.OriginPostcode,
                Collection = query.Collection,
                Parcels = query.Parcels,
                Quotes = sQuote.QuoteShipments.Select(qs =>
                    {
                        return new Models.Quote
                        {
                            ServiceId = qs.Service.Id.Value,
                            Service = qs.Service.Name, 
                            Carrier = qs.Carrier.Name,
                            Cost = qs.Cost
                        };
                    }
                    ).OrderBy(x=>x.Cost).ToArray()
            };

            return View(quote);
        }
	}
}