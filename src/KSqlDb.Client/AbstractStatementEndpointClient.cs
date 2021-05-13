namespace KSqlDb.Client
{
    using System;
    using System.Net.Http;
    using System.Text;
    using System.Text.Json;
    using System.Threading;
    using System.Threading.Tasks;
    using ApiModels.Responses;
    using Ardalis.GuardClauses;
    using Constants;
    using Exceptions;

    public abstract class AbstractStatementEndpointClient
    {
        private readonly HttpClient httpClient;

        protected AbstractStatementEndpointClient(HttpClient httpClient)
        {
            this.httpClient = httpClient;

            // HTTP 1.1
            this.httpClient.DefaultRequestVersion = new Version(1, 1);
            this.httpClient.DefaultRequestHeaders.Add("Accept", "application/vnd.ksql.v1+json");
            this.httpClient.BaseAddress = new Uri($"{this.httpClient.BaseAddress}{Endpoints.Statements}");
        }

        protected async Task<TResponse?> PostAsync<TResponse, TRequest>(TRequest request,
                                                                        CancellationToken token = default)
            where TResponse : class
            where TRequest : class
        {
            Guard.Against.Null(request, nameof(request));

            using var requestMessage = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                Content = new StringContent(JsonSerializer.Serialize(request),
                                            Encoding.UTF8,
                                            "application/vnd.ksql.v1+json")
            };

            using var response = await this.httpClient.SendAsync(requestMessage, token);
            return await ToResponseOrErrorResponse<TResponse>(response, token);
        }

        private static async Task<TResponse?> ToResponseOrErrorResponse<TResponse>(HttpResponseMessage? response,
            CancellationToken token)
            where TResponse : class
        {
            Guard.Against.Null(response, nameof(response));
            Guard.Against.Null(token, nameof(token));

            var stringResponse = await response.Content.ReadAsStringAsync(token);

            if (response.IsSuccessStatusCode)
            {
                return JsonSerializer.Deserialize<TResponse>(stringResponse);
            }

            var errorResponse = JsonSerializer.Deserialize<KsqlErrorResponse>(stringResponse);
            throw new KsqlDbResponseException(response.StatusCode, errorResponse);
        }
    }
}
