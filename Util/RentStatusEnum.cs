using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace renato_movie_store.Util
{
    public class RentStatusEnum
    {
        public const string ACTIVE = "active";

        public const string CANCELED = "canceled";

        public const string INACTIVE = "inactive";

        public const string PENDING = "pending";

        public static List<string> List()
        {
            return new List<string> { "active", "canceled", "inactive", "pending" };
        }
    }
}
