namespace KSqlDb.Client.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;
    using ApiModels.Requests;
    using ApiModels.Responses;
    using Ardalis.GuardClauses;

    /// <inheritdoc cref="IKsqlDbExecuteService" />
    public class ExecuteService : AbstractStatementEndpointClient, IKsqlDbExecuteService
    {
        public ExecuteService(HttpClient httpClient) : base(httpClient) { }

        /// <inheritdoc cref="IKsqlDbExecuteService.ExecuteAsync(CommandRequest, CancellationToken)" />
        public async Task<IEnumerable<CommandResponse>> ExecuteAsync(CommandRequest request,
                                                                     CancellationToken token = default)
        {
            Guard.Against.Null(request, nameof(request));

            var response = await this
               .PostAsync<IEnumerable<CommandResponse>, CommandRequest>(request, token);
            return response ?? Enumerable.Empty<CommandResponse>();
        }

        /// <inheritdoc cref="IKsqlDbExecuteService.ExecuteAsync(InsertRequest, CancellationToken)" />
        public async Task<IEnumerable<CommandResponse>> ExecuteAsync(InsertRequest request,
                                                                     CancellationToken token = default)
        {
            Guard.Against.Null(request, nameof(request));

            var response = await this
               .PostAsync<IEnumerable<CommandResponse>, InsertRequest>(request, token);
            return response ?? Enumerable.Empty<CommandResponse>();
        }
    }
}
