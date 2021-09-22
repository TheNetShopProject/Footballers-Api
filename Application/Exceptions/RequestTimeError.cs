using System;

namespace Application.Exceptions
{
    public class RequestTimeError : Exception
    {
        public RequestTimeError(string message) : base(message)
        {
            
        }
    }
}