namespace KSqlDb.Client.ApiModels.Requests
{
    using System.Collections.Generic;
    using Ardalis.GuardClauses;

    public record TableRequest : KsqlRequest
    {
        private TableRequest() {}

        /// <summary>
        ///
        /// </summary>
        /// <param name="ksql"></param>
        /// <param name="streamsProperties"></param>
        /// <param name="commandSequenceNumber"></param>
        /// <returns></returns>
        public static TableRequest WithKsql(string ksql,
                                            IDictionary<string, string>? streamsProperties = null,
                                            long? commandSequenceNumber = null)
        {
            Guard.Against.NullOrWhiteSpace(ksql, nameof(ksql));

            return new TableRequest
            {
                Ksql                  = ksql,
                StreamsProperties     = streamsProperties,
                CommandSequenceNumber = commandSequenceNumber
            };
        }

    }
}
