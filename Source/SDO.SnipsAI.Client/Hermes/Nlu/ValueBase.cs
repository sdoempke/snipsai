using JsonSubTypes;
using Newtonsoft.Json;
using System;

namespace SDO.SnipsAI.Client.Hermes.Nlu
{
    [JsonConverter(typeof(JsonSubtypes), "kind")]
    [JsonSubtypes.KnownSubType(typeof(InstantTime), "InstantTime")]
    [JsonSubtypes.KnownSubType(typeof(TimeInterval), "TimeInterval")]
    [JsonSubtypes.KnownSubType(typeof(Duration), "Duration")]
    [JsonSubtypes.KnownSubType(typeof(MusicArtist), "MusicArtist")]
    [JsonSubtypes.KnownSubType(typeof(MusicAlbum), "MusicAlbum")]
    [JsonSubtypes.KnownSubType(typeof(MusicTrack), "MusicTrack")]
    [JsonSubtypes.KnownSubType(typeof(Number), "Number")]
    [JsonSubtypes.KnownSubType(typeof(Ordinal), "Ordinal")]
    [JsonSubtypes.KnownSubType(typeof(AmountOfMoney), "AmountOfMoney")]
    [JsonSubtypes.KnownSubType(typeof(Percentage), "Percentage")]
    [JsonSubtypes.KnownSubType(typeof(Temperature), "Temperature")]
    [JsonSubtypes.KnownSubType(typeof(CustomValue), "Custom")]
    [JsonObject]
    public abstract class ValueBase : IConvertible
    {
        [JsonProperty("kind")]
        public virtual string Kind { get; }

        public abstract TypeCode GetTypeCode();
        public abstract bool ToBoolean(IFormatProvider provider);
        public abstract byte ToByte(IFormatProvider provider);
        public abstract char ToChar(IFormatProvider provider);
        public abstract DateTime ToDateTime(IFormatProvider provider);
        public abstract decimal ToDecimal(IFormatProvider provider);
        public abstract double ToDouble(IFormatProvider provider);
        public abstract short ToInt16(IFormatProvider provider);
        public abstract int ToInt32(IFormatProvider provider);
        public abstract long ToInt64(IFormatProvider provider);
        public abstract sbyte ToSByte(IFormatProvider provider);
        public abstract float ToSingle(IFormatProvider provider);
        public abstract string ToString(IFormatProvider provider);
        public abstract object ToType(Type conversionType, IFormatProvider provider);
        public abstract ushort ToUInt16(IFormatProvider provider);
        public abstract uint ToUInt32(IFormatProvider provider);
        public abstract ulong ToUInt64(IFormatProvider provider);
    }

    //{"id":"a90c496e-63f0-44bc-a1c6-03d3b69a1b70","input":"wie wird das wetter heute","intent":{"intentName":"domi:searchWeatherForecast","confidenceScore":0.96426976},"slots":[{"rawValue":"heute","value":{"kind":"InstantTime","value":"2019-05-22 00:00:00 +01:00","grain":"Day","precision":"Exact"},"range":{"start":20,"end":25},"entity":"snips/datetime","slotName":"forecast_start_date_time","confidenceScore":1.0}],"sessionId":"8a98a064-64c8-4ca4-9314-dac0a15a5bed"}


    [JsonObject]
    public class GenericValueBase<T> : ValueBase where T : IConvertible
    {
        public T Value { get; set; }

        #region IConvertible
        public override TypeCode GetTypeCode()
        {
            return Value.GetTypeCode();
        }

        public override bool ToBoolean(IFormatProvider provider)
        {
            return Value.ToBoolean(provider);
        }

        public override byte ToByte(IFormatProvider provider)
        {
            return Value.ToByte(provider);
        }

        public override char ToChar(IFormatProvider provider)
        {
            return Value.ToChar(provider);
        }

        public override DateTime ToDateTime(IFormatProvider provider)
        {
            return Value.ToDateTime(provider);
        }

        public override decimal ToDecimal(IFormatProvider provider)
        {
            return Value.ToDecimal(provider);
        }

        public override double ToDouble(IFormatProvider provider)
        {
            return Value.ToDouble(provider);
        }

        public override short ToInt16(IFormatProvider provider)
        {
            return Value.ToInt16(provider);
        }

        public override int ToInt32(IFormatProvider provider)
        {
            return Value.ToInt32(provider);
        }

        public override long ToInt64(IFormatProvider provider)
        {
            return Value.ToInt64(provider);
        }

        public override sbyte ToSByte(IFormatProvider provider)
        {
            return Value.ToSByte(provider);
        }

        public override float ToSingle(IFormatProvider provider)
        {
            return Value.ToSingle(provider);
        }

        public override string ToString(IFormatProvider provider)
        {
            return Value.ToString(provider);
        }

        public override object ToType(Type conversionType, IFormatProvider provider)
        {
            return Value.ToType(conversionType, provider);
        }

        public override ushort ToUInt16(IFormatProvider provider)
        {
            return Value.ToUInt16(provider);
        }

        public override uint ToUInt32(IFormatProvider provider)
        {
            return Value.ToUInt32(provider);
        }

        public override ulong ToUInt64(IFormatProvider provider)
        {
            return Value.ToUInt64(provider);
        }

        #endregion
    }

    //{"id":"a90c496e-63f0-44bc-a1c6-03d3b69a1b70","input":"wie wird das wetter heute","intent":{"intentName":"domi:searchWeatherForecast","confidenceScore":0.96426976},"slots":[{"rawValue":"heute","value":{"kind":"InstantTime","value":"2019-05-22 00:00:00 +01:00","grain":"Day","precision":"Exact"},"range":{"start":20,"end":25},"entity":"snips/datetime","slotName":"forecast_start_date_time","confidenceScore":1.0}],"sessionId":"8a98a064-64c8-4ca4-9314-dac0a15a5bed"}
}
