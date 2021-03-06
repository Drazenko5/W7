using System;
using System.Runtime.Serialization;

namespace Task_1.Utils
{
    [Serializable]
    internal class AlreadyStartedException : Exception
    {
        public AlreadyStartedException()
        {
        }

        public AlreadyStartedException(string message) : base(message)
        {
        }

        public AlreadyStartedException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected AlreadyStartedException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}