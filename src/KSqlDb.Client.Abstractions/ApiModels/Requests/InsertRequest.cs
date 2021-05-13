namespace KSqlDb.Client.ApiModels.Requests
{
    using System.Collections.Generic;
    using Ardalis.GuardClauses;

    public record InsertRequest : KsqlRequest
    {
        private InsertRequest() { }

        /// <summary>
        ///
        /// </summary>
        /// <param name="ksql"></param>
        /// <param name="streamsProperties"></param>
        /// <param name="commandSequenceNumber"></param>
        /// <returns></returns>
        public static InsertRequest WithKsql(string ksql,
                                             IDictionary<string, string>? streamsProperties = null,
                                             long? commandSequenceNumber = null)
        {
            Guard.Against.NullOrWhiteSpace(ksql, nameof(ksql));

            return new InsertRequest
            {
                Ksql                  = ksql,
                StreamsProperties     = streamsProperties,
                CommandSequenceNumber = commandSequenceNumber
            };
        }
    }
}
