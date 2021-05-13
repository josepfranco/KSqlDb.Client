namespace KSqlDb.Client.Ksql.Builders
{
    using System.Collections.Generic;
    using ApiModels.Requests;

    /// <summary>
    ///
    /// </summary>
    /// <typeparam name="TKsqlRequest"></typeparam>
    public interface IKsqlRequestBuilder<out TKsqlRequest>
        where TKsqlRequest : KsqlRequest
    {
        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        TKsqlRequest Build(IDictionary<string, string>? streamsProperties = null,
                           long? commandSequenceNumber = null);

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        string BuildAsKsql();
    }
}
