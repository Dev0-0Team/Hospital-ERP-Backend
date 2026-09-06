

namespace Hospital_ERP_Backend.API.Exceptions
{
    public class TooManyRequestsException : Exception
    {
        public TooManyRequestsException(string message) : base(message)
        {
            
        }
    }
}