using BLS_API_Example.Payload;
using BLS_API_Example.Response;
using System.Collections.Generic;
using RestSharp;
using System.Linq;
using System;
using BLS_API_Example.ReportFormat;
using System.IO;
using System.Reflection;

namespace BLS_API_Example
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = createClient();

            //singleSeriesTest(client);
            //multipleSeriesTest(client);
            //multipleSeriesAndYearsTest(client);
            ellpalTest(client);
        }

        static void singleSeriesTest(IRestClient restClient)
        {
            const string seriesID = "LAUCN040010000000005";
            var request = new RestRequest(seriesID, Method.GET);

            var response = restClient.Execute<BLSResponse>(request);

            if (response.IsSuccessful)
            {

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
                var results = response.Data.Results;
            }
        }

        static void ellpalTest(IRestClient restClient)
        {
            var listOfSeries = new List<string>()
            {
                "ENU420031051011"
                ,"ENU420031051012"
                ,"ENU420031051013"
                ,"ENU420031051021"
                ,"ENU420031051022"
                ,"ENU420031051023"
                ,"ENU420031051024"
                ,"ENU420031051025"
                ,"ENU420031051026"
                ,"ENU420031051027"
                ,"ENU420051051011"
                ,"ENU420051051012"
                ,"ENU420051051013"
                ,"ENU420051051021"
                ,"ENU420051051022"
                ,"ENU420051051023"
                ,"ENU420051051024"
                ,"ENU420051051025"
                ,"ENU420051051026"
                ,"ENU420051051027"
                ,"ENU420071051011"
                ,"ENU420071051012"
                ,"ENU420071051013"
                ,"ENU420071051021"
                ,"ENU420071051022"
                ,"ENU420071051023"
                ,"ENU420071051024"
                ,"ENU420071051025"
                ,"ENU420071051026"
                ,"ENU420071051027"
                ,"ENU420191051011"
                ,"ENU420191051012"
                ,"ENU420191051013"
                ,"ENU420191051021"
                ,"ENU420191051022"
                ,"ENU420191051023"
                ,"ENU420191051024"
                ,"ENU420191051025"
                ,"ENU420191051026"
                ,"ENU420191051027"
                ,"ENU420511051011"
                ,"ENU420511051012"
                ,"ENU420511051013"
                ,"ENU420511051021"
                ,"ENU420511051022"
                ,"ENU420511051023"
                ,"ENU420511051024"
                ,"ENU420511051025"
                ,"ENU420511051026"
                ,"ENU420511051027"
                ,"ENU420591051011"
                ,"ENU420591051012"
                ,"ENU420591051013"
                ,"ENU420591051021"
                ,"ENU420591051022"
                ,"ENU420591051023"
                ,"ENU420591051024"
                ,"ENU420591051025"
                ,"ENU420591051026"
                ,"ENU420591051027"
                ,"ENU420631051011"
                ,"ENU420631051012"
                ,"ENU420631051013"
                ,"ENU420631051021"
                ,"ENU420631051022"
                ,"ENU420631051023"
                ,"ENU420631051024"
                ,"ENU420631051025"
                ,"ENU420631051026"
                ,"ENU420631051027"
                ,"ENU420731051011"
                ,"ENU420731051012"
                ,"ENU420731051013"
                ,"ENU420731051021"
                ,"ENU420731051022"
                ,"ENU420731051023"
                ,"ENU420731051024"
                ,"ENU420731051025"
                ,"ENU420731051026"
                ,"ENU420731051027"
                ,"ENU421251051011"
                ,"ENU421251051012"
                ,"ENU421251051013"
                ,"ENU421251051021"
                ,"ENU421251051022"
                ,"ENU421251051023"
                ,"ENU421251051024"
                ,"ENU421251051025"
                ,"ENU421251051026"
                ,"ENU421251051027"
                ,"ENU421291051011"
                ,"ENU421291051012"
                ,"ENU421291051013"
                ,"ENU421291051021"
                ,"ENU421291051022"
                ,"ENU421291051023"
                ,"ENU421291051024"
                ,"ENU421291051025"
                ,"ENU421291051026"
                ,"ENU421291051027"
            };

            const int startYear = 2010;
            const int endYear = 2017;

            var responseSeries = new List<Series>();

            const int seriesPayloadLimit = 25;
            for (int ii = 0; ii < listOfSeries.Count / seriesPayloadLimit; ii++)
            {
                var currentSeriesSlice = listOfSeries.Skip(ii * seriesPayloadLimit).Take(seriesPayloadLimit);
                

                var seriesPayload = new SeriesAndYearsPayload()
                {
                    seriesid = currentSeriesSlice.ToList(),
                    startyear = startYear,
                    endyear = endYear
                };

                var request = new RestRequest(Method.POST);
                request.AddJsonBody(seriesPayload);

                var response = restClient.Execute<BLSResponse>(request);

                if (response.IsSuccessful)
                {
                    var blsResponse = response.Data;
                    var results = blsResponse.Results.Single();
                    var series = results.Series;

                    responseSeries.AddRange(series);
                }
            }

            var dataList = new List<EllenFormat>();
            foreach (var serie in responseSeries)
            {

                foreach (var datum in serie.Data)
                {

                    var reportData = new EllenFormat()
                    {
                        SeriesID = serie.seriesID,
                        Year = datum.Year,
                        Period = datum.Period,
                        PeriodName = datum.PeriodName,
                        Value = datum.Value
                    };

                    dataList.Add(reportData);
                }

            }

            const string path = @"C:\Users\adjec\Desktop\EllenBLSInfo.csv";
            var type = typeof(EllenFormat);
            var props = type.GetProperties(BindingFlags.Public | BindingFlags.Instance);

            using (var writer = new StreamWriter(path))
            {
                writer.WriteLine(string.Join(", ", props.Select(p => p.Name)));

                foreach (var item in dataList)
                {
                    writer.WriteLine(string.Join(", ", props.Select(p => p.GetValue(item, null))));
                }
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
