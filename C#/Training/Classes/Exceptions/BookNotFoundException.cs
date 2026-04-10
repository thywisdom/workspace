using System;

namespace Exceptions
{
    public class BookNotFoundException : Exception
    {
        public BookNotFoundException() 
            : base("Book not found.")
        {
        }


        public BookNotFoundException(string message) 
            : base(message)
        {
        }


        public BookNotFoundException(string message, Exception innerException) 
            : base(message, innerException)
        {
        }
        }
}