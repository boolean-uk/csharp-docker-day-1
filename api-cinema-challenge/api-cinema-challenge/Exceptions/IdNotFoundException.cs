﻿namespace api_cinema_challenge.Exceptions
{
    public class IdNotFoundException : ArgumentException
    {
        public IdNotFoundException() { }

        public IdNotFoundException(string? message) : base(message) { }

        public IdNotFoundException(string? message, Exception? innerException) : base(message, innerException) { }
    }
}
