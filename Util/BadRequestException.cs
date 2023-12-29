using System.Net;

namespace renato_movie_store.Util
{

    public class BadRequestException : BaseException
    {
        public BadRequestException(object error)
            : base(error)
        {
        }

        public BadRequestException(List<ValidationErrorModel> validationErrors)
            : base(validationErrors)
        {
        }

        public BadRequestException(string message, string parameter)
            : base(HttpStatusCode.BadRequest, message, parameter)
        {
        }

        public BadRequestException(string message, string parameter, object extras)
            : base(HttpStatusCode.BadRequest, message, parameter, extras)
        {
        }
    }



}
