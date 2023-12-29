namespace renato_movie_store.Util
{
    public class CustomerStatusEnum
    {
        public const string ACTIVE = "active";

        public const string INACTIVE = "inactive";

        public const string CANCELED = "Deleted";

        public static List<string> List()
        {
            return new List<string> { "active", "inactive", "Deleted" };
        }

    }
}
