using System.Net;

namespace renato_movie_store.Util
{
    public class ConflictException : BaseException
    {
        public ConflictException(object error)
           : base(error)
        {
        }

        public ConflictException(string message, string parameter)
            : base(HttpStatusCode.Conflict, message, parameter)
        {
        }

        public ConflictException(string message, string parameter, object extras)
            : base(HttpStatusCode.Conflict, message, parameter, extras)
        {
        }
    }
}
