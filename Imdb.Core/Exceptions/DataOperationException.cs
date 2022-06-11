using System;

namespace Imdb.Core.Exceptions
{
    public class DataOperationException : Exception
    {
        public DataOperationException()
        {
        }

        public DataOperationException(string message) : base(message)
        {
        }
    }
}
