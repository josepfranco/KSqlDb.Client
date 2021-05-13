namespace KSqlDb.Client
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using ApiModels.Requests;
    using ApiModels.Responses;

    public interface IKsqlDbExecuteService
    {
        /// <summary>
        /// </summary>
        /// <param name="request"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        Task<IEnumerable<CommandResponse>> ExecuteAsync(CommandRequest request, CancellationToken token = default);

        /// <summary>
        /// </summary>
        /// <param name="request"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        Task<IEnumerable<CommandResponse>> ExecuteAsync(InsertRequest request, CancellationToken token = default);
    }
}
