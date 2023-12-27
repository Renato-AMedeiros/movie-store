using Newtonsoft.Json.Converters;
using System.Globalization;

namespace renato_movie_store.Util
{
    public class IsoDateConverter : IsoDateTimeConverter
    {
        public IsoDateConverter()
        {
            DateTimeFormat = "yyyy-MM-dd\\THH:mm:ss\\Z";
            DateTimeStyles = DateTimeStyles.RoundtripKind;
        }
    }
}
