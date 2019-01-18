using BLS_API_Example.Payload;
using BLS_API_Example.Response;
using System.Collections.Generic;
using RestSharp;

namespace BLS_API_Example
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = createClient();

            singleSeriesTest(client);
            multipleSeriesTest(client);
            multipleSeriesAndYearsTest(client);
        }

        static void singleSeriesTest(IRestClient restClient)
        {
            const string seriesID = "LAUCN040010000000005";
            var request = new RestRequest(seriesID, Method.GET);

            var response = restClient.Execute<BLSResponse>(request);

            if (response.IsSuccessful)
            {
                var results = response.Data.Results;
            }
        }

        static void multipleSeriesTest(IRestClient restClient)
        {
            var listOfSeries = new List<string>()
            {
                "LAUCN040010000000005",
                "LAUCN040010000000006"
            };

            var seriesPayload = new SeriesPayload()
            {
                seriesid = listOfSeries
            };

            var request = new RestRequest(Method.POST);
            request.AddJsonBody(seriesPayload);

            var response = restClient.Execute<BLSResponse>(request);

            if (response.IsSuccessful)
            {
                var result = response.Data.Results;
            }
        }

        static void multipleSeriesAndYearsTest(IRestClient restClient)
        {
            var listOfSeries = new List<string>()
            {
                "LAUCN040010000000005",
                "LAUCN040010000000006"
            };

            const int startYear = 2010;
            const int endYear = 2012;

            var seriesAndYearsPayload = new SeriesAndYearsPayload()
            {
                seriesid = listOfSeries,
                startyear = startYear,
                endyear = endYear
            };

            var request = new RestRequest(Method.POST);
            request.AddJsonBody(seriesAndYearsPayload);

            var response = restClient.Execute<BLSResponse>(request);

            if (response.IsSuccessful)
            {
                var result = response.Data.Results;
            }
        }

        #region Helpers

        static IRestClient createClient()
        {
            var baseUrl = @"https://api.bls.gov/publicAPI/v1/timeseries/data/";
            var client = new RestClient(baseUrl);
            return client;
        }

        #endregion
    }
}
