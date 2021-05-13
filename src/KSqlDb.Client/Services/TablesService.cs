namespace KSqlDb.Client.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;
    using ApiModels.Requests;
    using ApiModels.Responses;
    using Ardalis.GuardClauses;

    public class TablesService : AbstractStatementEndpointClient, IKsqlDbTablesService
    {
        public TablesService(HttpClient httpClient) : base(httpClient) {}

        public async Task<IEnumerable<TablesResponse>> TablesAsync(TableRequest request,
                                                                   CancellationToken token = default)
        {
            Guard.Against.Null(request, nameof(request));

            var response = await this
               .PostAsync<IEnumerable<TablesResponse>, TableRequest>(request, token);
            return response ?? Enumerable.Empty<TablesResponse>();
        }
    }
}
