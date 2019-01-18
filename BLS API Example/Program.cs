using BLS_API_Example.Payload;
using BLS_API_Example.Response;
using System.Collections.Generic;
using System.Threading.Tasks;
using RestSharp;

namespace BLS_API_Example
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = createClient();

            singleSeriesTest(client);
        }

        static void singleSeriesTest(IRestClient client)
        {
            const string seriesID = "LAUCN040010000000005";
            var request = new RestRequest(seriesID, Method.GET);

            var response = client.Execute<BLSResponse>(request);

            if (response.IsSuccessful)
            {
                var results = response.Data.Results;
            }
        }

        #region Helpers

        static IRestClient createClient()
        {
            var baseUrl = @"https://api.bls.gov/publicAPI/v1/timeseries/data/";
            var client = new RestClient(baseUrl);
            return client;
        }

        static void addPayload(IRestRequest request, object body)
        {
            request.AddHeader("Content-Type", "application/json");
            request.RequestFormat = DataFormat.Json;
            request.AddBody(body);
        }

        #endregion
    }
}
