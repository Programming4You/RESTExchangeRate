using Newtonsoft.Json.Linq;
using RESTExchangeRate.Models;


namespace RESTExchangeRate.BusinessLayer
{
    public class ParseExchangeRateJson
    {
        public ExchangeRateOutput ParseExchangeRateJSON(string stringRates, string currentBase, string currentTarget)
        {
            int count = 0;
            decimal sumRate = 0;
            decimal avgRate = 0;
            dynamic rates = null;
            dynamic value = null;
            dynamic min = 0;
            dynamic max = 0;

            dynamic data = JObject.Parse(stringRates);
            dynamic dataRates = data.rates;

            foreach (var rate in dataRates)
            {
                rates = rate.Value;

                foreach (var key in rates)
                {
                    value = key.Value;
                    if (count == 0)
                    {
                        min = value;
                        max = value;
                    }

                    sumRate += (decimal)value;
                    min = value < min ? value : min;
                    max = value > max ? value : max;
                    count++;
                }

            }

            avgRate = sumRate / count;
            ExchangeRateOutput exchangeRateOutput = new ExchangeRateOutput();
            exchangeRateOutput.Minimum = min;
            exchangeRateOutput.Maximum = max;
            exchangeRateOutput.Average = avgRate;
            exchangeRateOutput.BaseCurrency = currentBase;
            exchangeRateOutput.TargetCurrency = currentTarget;

            return exchangeRateOutput;
        }
    }
}