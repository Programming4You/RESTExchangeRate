using Newtonsoft.Json;
using RESTExchangeRate.BusinessLayer;
using RESTExchangeRate.Models;
using System.Web.Mvc;
using System;

namespace RESTExchangeRate.Controllers
{
    public class ExchangeRateController : Controller
    {
    
        public ActionResult Index()
        {
            string stringRates = "";

            //Input values from User
            string currentBase = "SEK";
            string currentTarget = "NOK";
            string[] dates = new string[] { "2018-02-01", "2018-02-15", "2018-03-01" };

            DateTime minDate = DateTime.MaxValue;
            DateTime maxDate = DateTime.MinValue;

            foreach (string dateString in dates)
            {
                DateTime date = DateTime.Parse(dateString);
                if (date < minDate)
                    minDate = date;
                if (date > maxDate)
                    maxDate = date;
            }

            string startDate = minDate.ToString("yyyy-MM-dd");
            string endDate = maxDate.ToString("yyyy-MM-dd");

            ExchangeRate exchangeRateModel = null;
            ExchangeRateAPI exchangeRateAPI = new ExchangeRateAPI();
            ParseExchangeRateJson parseExchangeRateJSON = new ParseExchangeRateJson();
  
            stringRates = exchangeRateAPI.ExchangeRateApi(startDate, endDate, currentBase, currentTarget);
            exchangeRateModel = JsonConvert.DeserializeObject<ExchangeRate>(stringRates);

            ExchangeRateOutput exchangeRateResult = parseExchangeRateJSON.ParseExchangeRateJSON(stringRates, currentBase, currentTarget);
            exchangeRateAPI = null;
            return View(exchangeRateResult);


        }
    }
}