using System;

namespace RwsTest.Common.Exceptions
{
    public class RestReadFailedException : Exception
    {
        public RestReadFailedException()
        {
        }

        public RestReadFailedException(string message)
            : base(message)
        {
        }

        public RestReadFailedException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
