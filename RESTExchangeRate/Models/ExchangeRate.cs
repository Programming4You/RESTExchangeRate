using Newtonsoft.Json;
using System.Collections.Generic;


namespace RESTExchangeRate.Models
{

    public class ExchangeRate
    {
        [JsonProperty("end_at")]
        public string End_at { get; set; }

        [JsonProperty("start_at")]
        public string Start_at { get; set; }

        [JsonProperty("base")]
        public string Base { get; set; }

        [JsonProperty("rates")]
        public Dictionary<string, Dictionary<string, decimal>> Rate { get; set; }

    }
}