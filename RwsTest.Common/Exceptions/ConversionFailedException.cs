using System;

namespace RwsTest.Common.Exceptions
{
    public class ConversionFailedException : Exception
    {
        public ConversionFailedException()
        {
        }

        public ConversionFailedException(string message)
            : base(message)
        {
        }

        public ConversionFailedException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
