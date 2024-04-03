using System.Net;

namespace HoopsHelper.Exceptions
{
    public class FantasyHelperException : Exception
    {
        public FantasyHelperException()
            : base()
        {
        }

        public FantasyHelperException(string message)
            : base(message)
        {
        }
    }

    public class NbaApiServiceException : FantasyHelperException
    {
        private const string apiErrorMessage = "Error communicating with the API";
        public NbaApiServiceException(HttpStatusCode statusCode)
            : base($"{apiErrorMessage}: {statusCode}")
        {
        }

        public NbaApiServiceException(string message)
            : base($"{apiErrorMessage}: {message}")
        {
        }
    }
}
