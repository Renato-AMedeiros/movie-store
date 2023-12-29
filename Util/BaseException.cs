using System.Net;

namespace renato_movie_store.Util
{
    public class BaseException : Exception
    {
        public bool IsObjectError { get; private set; }

        public object Error { get; private set; }

        public string Parameter { get; private set; }

        public object Extras { get; private set; }

        public List<ValidationErrorModel> ValidationErrors { get; private set; }

        public HttpStatusCode Status { get; private set; }

        public BaseException(object error)
            : base("")
        {
            Error = error;
            IsObjectError = false;
        }

        public BaseException(List<ValidationErrorModel> validationErrors)
            : base("")
        {
            IsObjectError = false;
            ValidationErrors = validationErrors;
        }

        public BaseException(HttpStatusCode status, object error)
            : base("")
        {
            Error = error;
            Status = status;
            IsObjectError = true;
        }

        public BaseException(HttpStatusCode status, string message, string parameter)
            : base(message)
        {
            Status = status;
            Parameter = parameter;
            IsObjectError = false;
        }

        public BaseException(HttpStatusCode status, string message, string parameter, object extras)
            : base(message)
        {
            Extras = extras;
            Status = status;
            Parameter = parameter;
            IsObjectError = false;
        }
    }
}
