﻿namespace Employee_Directory.Exceptions
{
    public class CredentialsException : Exception
    {
        public CredentialsException() { }

        public CredentialsException(string message) : base(message)
        {
        }
    }
}
