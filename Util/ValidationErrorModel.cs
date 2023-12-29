using Newtonsoft.Json;

namespace renato_movie_store.Util
{
    public class ValidationErrorModel
    {
        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("parameter")]
        public string Parameter { get; set; }

        [JsonProperty("values", NullValueHandling = NullValueHandling.Ignore)]
        public Dictionary<string, string> Values { get; set; }

        public ValidationErrorModel()
        {
        }

        public ValidationErrorModel(string message)
        {
            Message = message;
        }

        public ValidationErrorModel(string message, string parameter)
        {
            Message = message;
            Parameter = parameter;
        }

        public ValidationErrorModel(string message, string parameter, Dictionary<string, string> values)
        {
            Values = values;
            Message = message;
            Parameter = parameter;
        }
    }
}
