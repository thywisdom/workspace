using System;

namespace Exceptions
{
    class InvalidAgeException : Exception
    {
        public InvalidAgeException(){}

        public InvalidAgeException (string message) 
        : base(message)
        {
            
        }

        public InvalidAgeException (string message, Exception innerException)
        : base(message,innerException)
        {
            
        }
    }
}