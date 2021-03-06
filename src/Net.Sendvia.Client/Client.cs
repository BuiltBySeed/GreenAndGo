﻿
//------------------------------------------------------------------------------
// <auto-generated>
// Hello
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using RestSharp;
using Net.Sendvia.Models;

namespace Net.Sendvia
{

	public class Client : RestClient
	{

        private const string BaseUri = "https://www.sendvia.co.uk/rest/alpha5/";

        public Client(string client_Id, string client_secret) : base(BaseUri) 
        {
            this.Authenticator = new OAuth2Authenticator(client_Id, client_secret);
        }
	
		public Area Area_ReadFromCountryISO(int countryIso)
		{
			var request = new RestRequest("/areas", Method.GET){ RequestFormat = DataFormat.Json };
				request.AddParameter("countryIso", countryIso.ToString());
				
			return Execute<Area>(request).Data;
		}

		public List<Area> Area_Search(string search)
		{
			var request = new RestRequest("/areas", Method.GET){ RequestFormat = DataFormat.Json };
				request.AddParameter("search", search.ToString());
				
			return Execute<List<Area>>(request).Data;
		}

		public Area Area_ReadFromCountryISOWithFormat(int countryIso, string format)
		{
			var request = new RestRequest("/areas", Method.GET){ RequestFormat = DataFormat.Json };
				request.AddParameter("countryIso", countryIso.ToString());
					request.AddParameter("format", format.ToString());
				
			return Execute<Area>(request).Data;
		}

		public string Area_Create(Area area)
		{
			var request = new RestRequest("/areas", Method.POST){ RequestFormat = DataFormat.Json };
				request.AddBody(area);
			
			return Execute(request).Content;
		}

		public string Area_Delete(Guid id)
		{
			var request = new RestRequest("/areas/{id}", Method.DELETE){ RequestFormat = DataFormat.Json };
				request.AddUrlSegment("id", id.ToString());
			
			return Execute(request).Content;
		}

		public Area Area_Read(Guid id)
		{
			var request = new RestRequest("/areas/{id}", Method.GET){ RequestFormat = DataFormat.Json };
				request.AddUrlSegment("id", id.ToString());
			
			return Execute<Area>(request).Data;
		}

		public Area Area_ReadWithFormat(Guid id, string format)
		{
			var request = new RestRequest("/areas/{id}", Method.GET){ RequestFormat = DataFormat.Json };
				request.AddUrlSegment("id", id.ToString());
				request.AddParameter("format", format.ToString());
				
			return Execute<Area>(request).Data;
		}

		public string Area_Update(Guid id, Area area)
		{
			var request = new RestRequest("/areas/{id}", Method.PUT){ RequestFormat = DataFormat.Json };
				request.AddUrlSegment("id", id.ToString());
				request.AddBody(area);
			
			return Execute(request).Content;
		}

		public Receipt Booking_Create(Booking booking)
		{
			var request = new RestRequest("/bookings", Method.POST){ RequestFormat = DataFormat.Json };
				request.AddBody(booking);
			
			return Execute<Receipt>(request).Data;
		}

		public Receipt Booking_Get(Guid id)
		{
			var request = new RestRequest("/bookings/{id}", Method.GET){ RequestFormat = DataFormat.Json };
				request.AddUrlSegment("id", id.ToString());
			
			return Execute<Receipt>(request).Data;
		}

		public List<Carrier> Carrier_Read(bool? whitelist, string include)
		{
			var request = new RestRequest("/carriers", Method.GET){ RequestFormat = DataFormat.Json };
			if(whitelist.HasValue)
			{
				request.AddParameter("whitelist", whitelist.ToString());
				}
				request.AddParameter("include", include.ToString());
				
			return Execute<List<Carrier>>(request).Data;
		}

		public string Carrier_Create(Carrier carrier)
		{
			var request = new RestRequest("/carriers", Method.POST){ RequestFormat = DataFormat.Json };
				request.AddBody(carrier);
			
			return Execute(request).Content;
		}

		public string Carrier_Delete(Guid id)
		{
			var request = new RestRequest("/carriers/{id}", Method.DELETE){ RequestFormat = DataFormat.Json };
				request.AddUrlSegment("id", id.ToString());
			
			return Execute(request).Content;
		}

		public Carrier Carrier_Read(Guid id)
		{
			var request = new RestRequest("/carriers/{id}", Method.GET){ RequestFormat = DataFormat.Json };
				request.AddUrlSegment("id", id.ToString());
			
			return Execute<Carrier>(request).Data;
		}

		public string Carrier_Update(Guid id, Carrier carrier)
		{
			var request = new RestRequest("/carriers/{id}", Method.PUT){ RequestFormat = DataFormat.Json };
				request.AddUrlSegment("id", id.ToString());
				request.AddBody(carrier);
			
			return Execute(request).Content;
		}

		public string Carrier_SetEndpoint(Guid id, Guid endpointId)
		{
			var request = new RestRequest("/carriers/{id}/endpoint", Method.POST){ RequestFormat = DataFormat.Json };
				request.AddUrlSegment("id", id.ToString());
				request.AddBody(endpointId);
			
			return Execute(request).Content;
		}

		public string Carrier_UpdateLogo(Guid id, string size, byte[] logo)
		{
			var request = new RestRequest("/carriers/{id}/logos/{size}", Method.PUT){ RequestFormat = DataFormat.Json };
				request.AddUrlSegment("id", id.ToString());
				request.AddUrlSegment("size", size.ToString());
				request.AddBody(logo);
			
			return Execute(request).Content;
		}

		public string Carrier_RemoveFromWhitelist(List<Guid> ids)
		{
			var request = new RestRequest("/carriers/whitelist", Method.DELETE){ RequestFormat = DataFormat.Json };
				request.AddBody(ids);
			
			return Execute(request).Content;
		}

		public string Carrier_AddToWhitelist(List<Guid> ids)
		{
			var request = new RestRequest("/carriers/whitelist", Method.POST){ RequestFormat = DataFormat.Json };
				request.AddBody(ids);
			
			return Execute(request).Content;
		}

		public List<Country> Country_Get()
		{
			var request = new RestRequest("/countries", Method.GET){ RequestFormat = DataFormat.Json };
			
			return Execute<List<Country>>(request).Data;
		}

		public List<Country> Country_Get(Guid serviceId)
		{
			var request = new RestRequest("/countries", Method.GET){ RequestFormat = DataFormat.Json };
				request.AddParameter("serviceId", serviceId.ToString());
				
			return Execute<List<Country>>(request).Data;
		}

		public List<Markup> Markup_Read()
		{
			var request = new RestRequest("/markups", Method.GET){ RequestFormat = DataFormat.Json };
			
			return Execute<List<Markup>>(request).Data;
		}

		public string Markup_Create(Markup endpoint)
		{
			var request = new RestRequest("/markups", Method.POST){ RequestFormat = DataFormat.Json };
				request.AddBody(endpoint);
			
			return Execute(request).Content;
		}

		public string Markup_Delete(Guid id)
		{
			var request = new RestRequest("/markups/{id}", Method.DELETE){ RequestFormat = DataFormat.Json };
				request.AddUrlSegment("id", id.ToString());
			
			return Execute(request).Content;
		}

		public Markup Markup_Read(Guid id)
		{
			var request = new RestRequest("/markups/{id}", Method.GET){ RequestFormat = DataFormat.Json };
				request.AddUrlSegment("id", id.ToString());
			
			return Execute<Markup>(request).Data;
		}

		public string Markup_Update(Guid id, Markup endpoint)
		{
			var request = new RestRequest("/markups/{id}", Method.PUT){ RequestFormat = DataFormat.Json };
				request.AddUrlSegment("id", id.ToString());
				request.AddBody(endpoint);
			
			return Execute(request).Content;
		}

		public List<Milestone> Parcel_GetTracking(Guid id)
		{
			var request = new RestRequest("/parcels/{id}/milestones", Method.GET){ RequestFormat = DataFormat.Json };
				request.AddUrlSegment("id", id.ToString());
			
			return Execute<List<Milestone>>(request).Data;
		}

		public string Parcel_UpdateTracking(Guid id, List<Milestone> milestones)
		{
			var request = new RestRequest("/parcels/{id}/milestones", Method.PUT){ RequestFormat = DataFormat.Json };
				request.AddUrlSegment("id", id.ToString());
				request.AddBody(milestones);
			
			return Execute(request).Content;
		}

		public List<Quote> Quote_ReadQuotes(Guid queryId)
		{
			var request = new RestRequest("/quotes", Method.GET){ RequestFormat = DataFormat.Json };
				request.AddParameter("queryId", queryId.ToString());
				
			return Execute<List<Quote>>(request).Data;
		}

		public Quote Quote_Create(Query query, List<Guid> serviceIds)
		{
			var request = new RestRequest("/quotes", Method.POST){ RequestFormat = DataFormat.Json };
				request.AddBody(query);
			if(serviceIds != default(List<Guid>))
				{	
					foreach(var p in serviceIds )
					{
						request.AddParameter("serviceIds[]", p.ToString());
					}	
				}				
				
			return Execute<Quote>(request).Data;
		}

		public Quote Quote_Read(Guid id)
		{
			var request = new RestRequest("/quotes/{id}", Method.GET){ RequestFormat = DataFormat.Json };
				request.AddUrlSegment("id", id.ToString());
			
			return Execute<Quote>(request).Data;
		}

		public List<Rate> Rate_Read(Guid carrierId, Guid serviceId, Guid routeId)
		{
			var request = new RestRequest("/carriers/{carrierId}/services/{serviceId}/routes/{routeId}/rates", Method.GET){ RequestFormat = DataFormat.Json };
				request.AddUrlSegment("carrierId", carrierId.ToString());
				request.AddUrlSegment("serviceId", serviceId.ToString());
				request.AddUrlSegment("routeId", routeId.ToString());
			
			return Execute<List<Rate>>(request).Data;
		}

		public string Rate_Create(Guid carrierId, Guid serviceId, Guid routeId, List<Rate> rates)
		{
			var request = new RestRequest("/carriers/{carrierId}/services/{serviceId}/routes/{routeId}/rates", Method.POST){ RequestFormat = DataFormat.Json };
				request.AddUrlSegment("carrierId", carrierId.ToString());
				request.AddUrlSegment("serviceId", serviceId.ToString());
				request.AddUrlSegment("routeId", routeId.ToString());
				request.AddBody(rates);
			
			return Execute(request).Content;
		}

		public string Rate_Delete(Guid carrierId, Guid serviceId, Guid routeId, Guid id)
		{
			var request = new RestRequest("/carriers/{carrierId}/services/{serviceId}/routes/{routeId}/rates/{id}", Method.DELETE){ RequestFormat = DataFormat.Json };
				request.AddUrlSegment("carrierId", carrierId.ToString());
				request.AddUrlSegment("serviceId", serviceId.ToString());
				request.AddUrlSegment("routeId", routeId.ToString());
				request.AddUrlSegment("id", id.ToString());
			
			return Execute(request).Content;
		}

		public Rate Rate_Read(Guid carrierId, Guid serviceId, Guid routeId, Guid id)
		{
			var request = new RestRequest("/carriers/{carrierId}/services/{serviceId}/routes/{routeId}/rates/{id}", Method.GET){ RequestFormat = DataFormat.Json };
				request.AddUrlSegment("carrierId", carrierId.ToString());
				request.AddUrlSegment("serviceId", serviceId.ToString());
				request.AddUrlSegment("routeId", routeId.ToString());
				request.AddUrlSegment("id", id.ToString());
			
			return Execute<Rate>(request).Data;
		}

		public string Rate_Update(Guid carrierId, Guid serviceId, Guid routeId, Guid id, Rate rate)
		{
			var request = new RestRequest("/carriers/{carrierId}/services/{serviceId}/routes/{routeId}/rates/{id}", Method.PUT){ RequestFormat = DataFormat.Json };
				request.AddUrlSegment("carrierId", carrierId.ToString());
				request.AddUrlSegment("serviceId", serviceId.ToString());
				request.AddUrlSegment("routeId", routeId.ToString());
				request.AddUrlSegment("id", id.ToString());
				request.AddBody(rate);
			
			return Execute(request).Content;
		}

		public Receipt Receipt_GetReceipt(Guid id)
		{
			var request = new RestRequest("/receipts/{id}", Method.GET){ RequestFormat = DataFormat.Json };
				request.AddUrlSegment("id", id.ToString());
			
			return Execute<Receipt>(request).Data;
		}

		public byte[] Receipt_GetManifest(Guid id)
		{
			var request = new RestRequest("/receipts/{id}/manifest", Method.GET){ RequestFormat = DataFormat.Json };
				request.AddUrlSegment("id", id.ToString());
			
			return Execute<List<byte>>(request).Data.ToArray();
		}

		public void Receipt_AddManifest(Guid id, Guid serviceId, byte[] pdf)
		{
			var request = new RestRequest("/receipts/{id}/manifest/{serviceId}", Method.POST){ RequestFormat = DataFormat.Json };
				request.AddUrlSegment("id", id.ToString());
				request.AddUrlSegment("serviceId", serviceId.ToString());
				request.AddBody(pdf);
			
			Execute(request);
		}

		public List<Route> Route_ReadAll(Guid carrierId, Guid serviceId)
		{
			var request = new RestRequest("/carriers/{carrierId}/services/{serviceId}/routes", Method.GET){ RequestFormat = DataFormat.Json };
				request.AddUrlSegment("carrierId", carrierId.ToString());
				request.AddUrlSegment("serviceId", serviceId.ToString());
			
			return Execute<List<Route>>(request).Data;
		}

		public string Route_Create(Guid carrierId, Guid serviceId, Route route)
		{
			var request = new RestRequest("/carriers/{carrierId}/services/{serviceId}/routes", Method.POST){ RequestFormat = DataFormat.Json };
				request.AddUrlSegment("carrierId", carrierId.ToString());
				request.AddUrlSegment("serviceId", serviceId.ToString());
				request.AddBody(route);
			
			return Execute(request).Content;
		}

		public string Route_Delete(Guid carrierId, Guid serviceId, Guid id)
		{
			var request = new RestRequest("/carriers/{carrierId}/services/{serviceId}/routes/{id}", Method.DELETE){ RequestFormat = DataFormat.Json };
				request.AddUrlSegment("carrierId", carrierId.ToString());
				request.AddUrlSegment("serviceId", serviceId.ToString());
				request.AddUrlSegment("id", id.ToString());
			
			return Execute(request).Content;
		}

		public Route Route_Read(Guid carrierId, Guid serviceId, Guid id)
		{
			var request = new RestRequest("/carriers/{carrierId}/services/{serviceId}/routes/{id}", Method.GET){ RequestFormat = DataFormat.Json };
				request.AddUrlSegment("carrierId", carrierId.ToString());
				request.AddUrlSegment("serviceId", serviceId.ToString());
				request.AddUrlSegment("id", id.ToString());
			
			return Execute<Route>(request).Data;
		}

		public string Route_Update(Guid carrierId, Guid serviceId, Guid id, Route route)
		{
			var request = new RestRequest("/carriers/{carrierId}/services/{serviceId}/routes/{id}", Method.PUT){ RequestFormat = DataFormat.Json };
				request.AddUrlSegment("carrierId", carrierId.ToString());
				request.AddUrlSegment("serviceId", serviceId.ToString());
				request.AddUrlSegment("id", id.ToString());
				request.AddBody(route);
			
			return Execute(request).Content;
		}

		public string Route_Union(Guid carrierId, Guid serviceId, List<Guid> guids)
		{
			var request = new RestRequest("/carriers/{carrierId}/services/{serviceId}/routes/union", Method.POST){ RequestFormat = DataFormat.Json };
				request.AddUrlSegment("carrierId", carrierId.ToString());
				request.AddUrlSegment("serviceId", serviceId.ToString());
				request.AddBody(guids);
			
			return Execute(request).Content;
		}

		public List<Service> Service_Read(Guid carrierId)
		{
			var request = new RestRequest("/carriers/{carrierId}/services", Method.GET){ RequestFormat = DataFormat.Json };
				request.AddUrlSegment("carrierId", carrierId.ToString());
			
			return Execute<List<Service>>(request).Data;
		}

		public string Service_Create(Guid carrierId, Service service)
		{
			var request = new RestRequest("/carriers/{carrierId}/services", Method.POST){ RequestFormat = DataFormat.Json };
				request.AddUrlSegment("carrierId", carrierId.ToString());
				request.AddBody(service);
			
			return Execute(request).Content;
		}

		public string Service_Delete(Guid carrierId, Guid id)
		{
			var request = new RestRequest("/carriers/{carrierId}/services/{id}", Method.DELETE){ RequestFormat = DataFormat.Json };
				request.AddUrlSegment("carrierId", carrierId.ToString());
				request.AddUrlSegment("id", id.ToString());
			
			return Execute(request).Content;
		}

		public Service Service_Read(Guid carrierId, Guid id)
		{
			var request = new RestRequest("/carriers/{carrierId}/services/{id}", Method.GET){ RequestFormat = DataFormat.Json };
				request.AddUrlSegment("carrierId", carrierId.ToString());
				request.AddUrlSegment("id", id.ToString());
			
			return Execute<Service>(request).Data;
		}

		public string Service_Update(Guid carrierId, Guid id, Service service)
		{
			var request = new RestRequest("/carriers/{carrierId}/services/{id}", Method.PUT){ RequestFormat = DataFormat.Json };
				request.AddUrlSegment("carrierId", carrierId.ToString());
				request.AddUrlSegment("id", id.ToString());
				request.AddBody(service);
			
			return Execute(request).Content;
		}

		public string Service_SetEndpoint(Guid carrierId, Guid id, Guid endpointId)
		{
			var request = new RestRequest("/carriers/{carrierId}/services/{id}/endpoint", Method.POST){ RequestFormat = DataFormat.Json };
				request.AddUrlSegment("carrierId", carrierId.ToString());
				request.AddUrlSegment("id", id.ToString());
				request.AddBody(endpointId);
			
			return Execute(request).Content;
		}

		public string Shipment_Create(Shipment endpoint)
		{
			var request = new RestRequest("/shipments", Method.POST){ RequestFormat = DataFormat.Json };
				request.AddBody(endpoint);
			
			return Execute(request).Content;
		}

		public string Shipment_Delete(Guid id)
		{
			var request = new RestRequest("/shipments/{id}", Method.DELETE){ RequestFormat = DataFormat.Json };
				request.AddUrlSegment("id", id.ToString());
			
			return Execute(request).Content;
		}

		public Shipment Shipment_Read(Guid id)
		{
			var request = new RestRequest("/shipments/{id}", Method.GET){ RequestFormat = DataFormat.Json };
				request.AddUrlSegment("id", id.ToString());
			
			return Execute<Shipment>(request).Data;
		}

		public string Shipment_Update(Guid id, Shipment endpoint)
		{
			var request = new RestRequest("/shipments/{id}", Method.PUT){ RequestFormat = DataFormat.Json };
				request.AddUrlSegment("id", id.ToString());
				request.AddBody(endpoint);
			
			return Execute(request).Content;
		}

		public List<Status> Shipment_ReadAlerts(Guid id)
		{
			var request = new RestRequest("/shipments/{id}/alerts", Method.GET){ RequestFormat = DataFormat.Json };
				request.AddUrlSegment("id", id.ToString());
			
			return Execute<List<Status>>(request).Data;
		}

		public string Shipment_AddAlert(Guid id, Status alert)
		{
			var request = new RestRequest("/shipments/{id}/alerts", Method.POST){ RequestFormat = DataFormat.Json };
				request.AddUrlSegment("id", id.ToString());
				request.AddBody(alert);
			
			return Execute(request).Content;
		}

		public Pdf Shipment_ReadLabel(Guid id)
		{
			var request = new RestRequest("/shipments/{id}/label", Method.GET){ RequestFormat = DataFormat.Json };
				request.AddUrlSegment("id", id.ToString());
			
			return Execute<Pdf>(request).Data;
		}

		public string Shipment_AddLabel(Guid id, byte[] label)
		{
			var request = new RestRequest("/shipments/{id}/label", Method.POST){ RequestFormat = DataFormat.Json };
				request.AddUrlSegment("id", id.ToString());
				request.AddBody(label);
			
			return Execute(request).Content;
		}

		public Pdf Shipment_ReadLabel(List<Guid> ids)
		{
			var request = new RestRequest("/shipments/labels", Method.POST){ RequestFormat = DataFormat.Json };
				request.AddBody(ids);
			
			return Execute<Pdf>(request).Data;
		}

		public List<Status> Shipment_ReadStatus()
		{
			var request = new RestRequest("/shipments/status", Method.GET){ RequestFormat = DataFormat.Json };
			
			return Execute<List<Status>>(request).Data;
		}

	
		private class OAuth2Authenticator :IAuthenticator
		{

			private const string BaseUri = "https://www.sendvia.co.uk/alpha5";

			private string _client_Id;
			private string _client_Secret;
			private OAuth2AuthorizationRequestHeaderAuthenticator _authenticator;
			private DateTime _expiry;

			public OAuth2Authenticator(string client_Id, string client_Secret)
			{
				this._client_Id = client_Id;
				this._client_Secret = client_Secret;
			}

			void IAuthenticator.Authenticate(IRestClient client, IRestRequest request)
			{
				if (_authenticator == null || DateTime.UtcNow > _expiry)
				{
					var authRequest = new RestRequest("/token", Method.POST);
					authRequest.AddParameter("client_id", _client_Id);
					authRequest.AddParameter("client_secret", _client_Secret);
					authRequest.AddParameter("grant_type", "client_credentials");
					authRequest.AddParameter("response_type", "token");
					RestClient rs = new RestClient(BaseUri);                
					var restResponse = rs.Post<OAuthTokens>(authRequest);
					_expiry = DateTime.UtcNow.AddSeconds(restResponse.Data.expires_in);
					_authenticator = new RestSharp.OAuth2AuthorizationRequestHeaderAuthenticator(restResponse.Data.access_token, restResponse.Data.token_type);              
				}
				_authenticator.Authenticate(client, request);
             
			}
		}

		 private class OAuthTokens
		{
			public string access_token { get; set; }
			public int expires_in { get; set; }
			public string refresh_token { get; set; }
			public string token_type { get; set; }
		}
	}
}