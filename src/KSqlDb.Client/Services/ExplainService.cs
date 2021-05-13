namespace KSqlDb.Client.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using System.Reactive.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using ApiModels.Requests;
    using ApiModels.Responses;
    using Ardalis.GuardClauses;

    /// <inheritdoc cref="IKsqlDbExplainService" />
    public class ExplainService : AbstractStatementEndpointClient, IKsqlDbExplainService
    {
        public ExplainService(HttpClient httpClient) : base(httpClient) { }

        /// <inheritdoc cref="IKsqlDbExplainService.ExplainAsObservable" />
        public IObservable<ExplainResponse> ExplainAsObservable(ExplainRequest request)
        {
            Guard.Against.Null(request, nameof(request));

            return Observable
               .FromAsync(ct => this.ExplainAsync(request, ct))
               .SelectMany(responses => responses);
        }

        /// <inheritdoc cref="IKsqlDbExplainService.ExplainAsync" />
        public async Task<IEnumerable<ExplainResponse>> ExplainAsync(ExplainRequest request,
                                                                     CancellationToken token = default)
        {
            Guard.Against.Null(request, nameof(request));

            var response = await this.PostAsync<IEnumerable<ExplainResponse>, ExplainRequest>(request, token);
            return response ?? Enumerable.Empty<ExplainResponse>();
        }
    }
}
