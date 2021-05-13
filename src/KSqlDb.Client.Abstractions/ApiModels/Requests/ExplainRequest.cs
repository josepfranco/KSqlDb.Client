namespace KSqlDb.Client.ApiModels.Requests
{
    using System.Collections.Generic;
    using Ardalis.GuardClauses;

    public record ExplainRequest : KsqlRequest
    {
        private ExplainRequest() { }

        /// <summary>
        ///
        /// </summary>
        /// <param name="ksql"></param>
        /// <param name="streamsProperties"></param>
        /// <param name="commandSequenceNumber"></param>
        /// <returns></returns>
        public static ExplainRequest WithKsql(string ksql,
                                              IDictionary<string, string>? streamsProperties = null,
                                              long? commandSequenceNumber = null)
        {
            Guard.Against.NullOrWhiteSpace(ksql, nameof(ksql));

            return new ExplainRequest
            {
                Ksql                  = ksql,
                StreamsProperties     = streamsProperties,
                CommandSequenceNumber = commandSequenceNumber
            };
        }
    }
}
