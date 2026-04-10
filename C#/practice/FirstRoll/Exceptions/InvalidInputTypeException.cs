using System;

namespace Exceptions
{
    class InvalidInputTypeException : Exception
    {
        public InvalidInputTypeException(){}

        public InvalidInputTypeException (string message) 
        : base(message)
        {
            
        }

        public InvalidInputTypeException (string message, Exception innerException)
        : base(message,innerException)
        {
            
        }
    }
}