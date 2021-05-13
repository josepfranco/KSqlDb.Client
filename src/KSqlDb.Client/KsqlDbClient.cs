namespace KSqlDb.Client
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using ApiModels.Requests;
    using ApiModels.Responses;

    public class KsqlDbClient : IKsqlDbClient
    {
        private readonly IKsqlDbDescribeService describeService;
        private readonly IKsqlDbExecuteService executeService;
        private readonly IKsqlDbExplainService explainService;
        private readonly IKsqlDbTablesService tablesService;

        public KsqlDbClient(IKsqlDbDescribeService describeService,
                            IKsqlDbExplainService explainService,
                            IKsqlDbExecuteService executeService,
                            IKsqlDbTablesService tablesService)
        {
            this.describeService = describeService;
            this.explainService  = explainService;
            this.executeService  = executeService;
            this.tablesService   = tablesService;
        }

        /// <inheritdoc cref="IKsqlDbDescribeService.DescribeAsync" />
        public Task<IEnumerable<DescribeResponse>> DescribeAsync(DescribeRequest request,
                                                                 CancellationToken token = default) =>
            this.describeService.DescribeAsync(request, token);

        /// <inheritdoc cref="IKsqlDbExplainService.ExplainAsync" />
        public Task<IEnumerable<ExplainResponse>> ExplainAsync(ExplainRequest request,
                                                               CancellationToken token = default) =>
            this.explainService.ExplainAsync(request, token);

        /// <inheritdoc cref="IKsqlDbExecuteService.ExecuteAsync(CommandRequest, CancellationToken)" />
        public Task<IEnumerable<CommandResponse>> ExecuteAsync(CommandRequest request,
                                                               CancellationToken token = default) =>
            this.executeService.ExecuteAsync(request, token);

        /// <inheritdoc cref="IKsqlDbExecuteService.ExecuteAsync(InsertRequest, CancellationToken)" />
        public Task<IEnumerable<CommandResponse>> ExecuteAsync(InsertRequest request,
                                                               CancellationToken token = default) =>
            this.executeService.ExecuteAsync(request, token);

        /// <inheritdoc cref="IKsqlDbTablesService.TablesAsync" />
        public Task<IEnumerable<TablesResponse>> TablesAsync(TableRequest request, CancellationToken token = default) =>
            this.tablesService.TablesAsync(request, token);
    }
}
