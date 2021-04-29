using System;

namespace ePregledi.API.Exceptions
{
    public class UserException : Exception
    {
        public UserException(string message)
            : base(message)
        {

        }
    }
}
