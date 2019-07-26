using System;
using System.Net.Http;


namespace RESTExchangeRate.BusinessLayer
{
    public class ExchangeRateAPI
    {
        public string ExchangeRateApi(string startDate, string endDate, string currentBase, string currentTarget)
        {
            string url = "https://api.exchangeratesapi.io/";
            string queryString = "history?start_at=" + startDate + "&end_at=" + endDate + "&base=" + currentBase + "&symbols=" + currentTarget;
            string stringRates = "";


            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(url);

                var responseTask = client.GetAsync(queryString);
                responseTask.Wait();
 
                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsStringAsync();

                    readTask.Wait();
                    stringRates = readTask.Result;

                }
                else
                {
                    stringRates = null;
                    throw new Exception(result.ReasonPhrase);
                }
            }

            return stringRates;
        }
    }
}