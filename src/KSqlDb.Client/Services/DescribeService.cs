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

    /// <inheritdoc cref="IKsqlDbDescribeService" />
    public class DescribeService : AbstractStatementEndpointClient, IKsqlDbDescribeService
    {
        public DescribeService(HttpClient httpClient) : base(httpClient) { }

        /// <inheritdoc cref="IKsqlDbDescribeService.DescribeAsObservable" />
        public IObservable<DescribeResponse> DescribeAsObservable(DescribeRequest request)
        {
            Guard.Against.Null(request, nameof(request));

            return Observable
               .FromAsync(ct => this.DescribeAsync(request, ct))
               .SelectMany(responses => responses);
        }

        /// <inheritdoc cref="IKsqlDbDescribeService.DescribeAsync" />
        public async Task<IEnumerable<DescribeResponse>> DescribeAsync(DescribeRequest request,
                                                                       CancellationToken token = default)
        {
            Guard.Against.Null(request, nameof(request));

            var response = await this.PostAsync<IEnumerable<DescribeResponse>, DescribeRequest>(request, token);
            return response ?? Enumerable.Empty<DescribeResponse>();
        }
    }
}
