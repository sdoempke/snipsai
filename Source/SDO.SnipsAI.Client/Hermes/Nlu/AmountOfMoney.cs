using Newtonsoft.Json;

namespace SDO.SnipsAI.Client.Hermes.Nlu
{
    [JsonObject]
    public class AmountOfMoney : GenericValueBase<double>
    {
        /// <summary>
        /// Amount of money (decimal or integer number + major currencies)
        /// Supported currencies: $, USD, AUD, CAD, HKD, EUR, £, GBP, CHF, KR, DKK, NOK, SEK, RUB, INR, JPY, CNY, ¥, KRW, ฿ - For currencies that share part of the name (e.g. dollars, US dollars, Hong Kong dollars), the currency is resolved as $ if there is no more info given (dollar). Otherwise US dollars is resolved as USD
        /// Supported range for en, fr, de, es, it: 0 to 999.999.999.999
        /// Supported range for ja: 0 to 99.999.999 - Decimal numbers only supported in French at the moment
        /// 
        /// </summary>
        [JsonProperty("kind")]
        public override string Kind { get; } = "AmountOfMoney";

        /// <summary>
        /// "Approximate" or "Exact"
        /// </summary>
        [JsonProperty("precision")]
        public string Precision { get; set; }

        /// <summary>
        /// Unit
        /// </summary>
        [JsonProperty("unit")]
        public string Unit { get; set; }
    }
}
