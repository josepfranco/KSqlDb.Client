namespace KSqlDb.Client
{
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using ApiModels.Requests;
    using ApiModels.Responses;

    public interface IKsqlDbTablesService
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="request"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        Task<IEnumerable<TablesResponse>> TablesAsync(TableRequest request, CancellationToken token = default);
    }
}
