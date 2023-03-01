using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Dte.Common.Exceptions;
using Dte.Common.Http;
using Microsoft.Extensions.Logging;

namespace Dte.Location.Api.Client.Console
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var httpClient = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:4001/")
            };
            var authString = "Basic " + Convert.ToBase64String(Encoding.GetEncoding("ISO-8859-1").GetBytes("nihr-dte-study-management-api" + ":" + ""));
            httpClient.DefaultRequestHeaders.Add("Authorization", authString);

            var headerService = new HeaderService();
            headerService.SetHeader("ConversationId", new[] { Guid.NewGuid().ToString() });
            
            var client = new LocationApiClient(httpClient, headerService, new Logger<LocationApiClient>(new LoggerFactory()));

            try
            {
                // var addressesByPostcode = await client.GetAddressesByPostcodeAsync("w53ta");
                //
                // System.Console.WriteLine($"Success: {addressesByPostcode.Count()} records");
                //
                // addressesByPostcode.ToList().ForEach(a =>
                // {
                //     System.Console.WriteLine($"{a.FullAddress}");
                //     System.Console.WriteLine($"{a.NameNumber} {a.Street}, {a.LocalityTown ?? ""} {a.PostTown} {a.Postcode}");
                //     System.Console.WriteLine("");
                // });

                foreach (var (key, value) in (await client.GetHealthAsync(false)).Results)
                {
                    System.Console.WriteLine($"Success: {key} {value.Status} : {value.Description} : {value.Tags}");
                }
            }
            catch (HttpServiceException ex)
            {
                System.Console.WriteLine($"HttpServiceException ({ex.ServiceName}): " + ex.Message);
            }
            catch (HttpRequestException ex)
            {
                System.Console.WriteLine("HttpRequestException: " + ex);
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("Exception: " + ex);
            }
        }
    }
}