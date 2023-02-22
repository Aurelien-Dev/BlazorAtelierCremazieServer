using System.Runtime.Serialization;

namespace BlazorAtelierCremazieServer.Commmon.CustomException
{
    [Serializable]
    internal class ApiCallException : Exception
    {
        public ApiCallException()
        {
        }

        public ApiCallException(string? message) : base(message)
        {
        }

        public ApiCallException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected ApiCallException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}