namespace KSqlDb.Client.Exceptions
{
    using System;
    using System.Net;
    using ApiModels.Responses;

    public class KsqlDbResponseException : Exception
    {
        public KsqlDbResponseException(HttpStatusCode statusCode, KsqlErrorResponse? response)
        {
            this.StatusCode = statusCode;
            this.Response   = response;
        }

        public KsqlDbResponseException(string? message,
                                       HttpStatusCode statusCode,
                                       KsqlErrorResponse? response) :
            base(message)
        {
            this.StatusCode = statusCode;
            this.Response   = response;
        }

        public KsqlDbResponseException(string? message,
                                       Exception? innerException,
                                       HttpStatusCode statusCode,
                                       KsqlErrorResponse? response) :
            base(message, innerException)
        {
            this.StatusCode = statusCode;
            this.Response   = response;
        }

        public HttpStatusCode StatusCode { get; }
        public KsqlErrorResponse? Response { get; }
    }
}
