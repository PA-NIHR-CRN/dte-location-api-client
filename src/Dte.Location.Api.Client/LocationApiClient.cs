using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Dte.Common.Http;
using Dte.Location.Api.Client.Models;
using Microsoft.Extensions.Logging;

namespace Dte.Location.Api.Client
{
    public interface ILocationApiClient
    {
        // Health
        Task<HealthModel> GetHealthAsync(bool includeReady);
        
        // Addresses
        Task<IEnumerable<PostcodeAddressModel>> GetAddressesByPostcodeAsync(string postcode);
    }

    public class LocationApiClient : BaseHttpClient, ILocationApiClient
    {
        private readonly ILogger<LocationApiClient> _logger;

        public LocationApiClient(HttpClient httpClient, IHeaderService headerService, ILogger<LocationApiClient> logger) 
            : base(httpClient, headerService, logger, ApiClientConfiguration.Default)
        {
            _logger = logger;
        }

        protected override string ServiceName => "LocationService";

        public async Task<HealthModel> GetHealthAsync(bool includeReady)
        {
            var httpRequest = new HttpRequestMessage
            {
                RequestUri = new Uri($"api/health/{(includeReady ? "ready" : "")}", UriKind.Relative),
                Method = HttpMethod.Get
            };
            
            var response = await SendAsync<HealthModel>(httpRequest);

            return response;
        }

        public async Task<IEnumerable<PostcodeAddressModel>> GetAddressesByPostcodeAsync(string postcode)
        {
            var httpRequest = new HttpRequestMessage
            {
                RequestUri = new Uri($"api/address/postcode/{postcode}", UriKind.Relative),
                Method = HttpMethod.Get,
                //Content = new StringContent(JsonConvert.SerializeObject(request.RequestBody), Encoding.UTF8, "application/json")
            };
            
            var response = await SendAsync<IEnumerable<PostcodeAddressModel>>(httpRequest);

            return response;
        }
    }
}
