using System.Net;

namespace renato_movie_store.Util
{
    public class ForbiddenException : BaseException
    {
        public ForbiddenException(object error)
            : base(error)
        {
        }

        public ForbiddenException(string message, string parameter)
            : base(HttpStatusCode.Forbidden, message, parameter)
        {
        }

        public ForbiddenException(string message, string parameter, object extras)
            : base(HttpStatusCode.Forbidden, message, parameter, extras)
        {
        }
    }
}
