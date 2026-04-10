using System;

namespace Exceptions
{
    public class InvalidAgeException : Exception
    {
        private int InvalidAge { get; }

        InvalidAgeException () {}

        public InvalidAgeException (int age, string message) 
        : base(message)
        {
            InvalidAge = age;
        }
    } 
}