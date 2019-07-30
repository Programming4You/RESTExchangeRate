using Newtonsoft.Json;


namespace RESTExchangeRate.Models
{
    public class ExchangeRateOutput
    {
        [JsonProperty("minimum")]
        public decimal Minimum { get; set; }

        [JsonProperty("maximum")]
        public decimal Maximum { get; set; }

        [JsonProperty("average")]
        public decimal Average { get; set; }

        [JsonProperty("basecurrency")]
        public string BaseCurrency { get; set; }

        [JsonProperty("targetcurrency")]
        public string TargetCurrency { get; set; }

        [JsonProperty("mindate")]
        public string MinDate { get; set; }

        [JsonProperty("maxdate")]
        public string MaxDate { get; set; }

    }
}