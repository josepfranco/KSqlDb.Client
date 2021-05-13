namespace KSqlDb.Client
{
    public interface IKsqlDbClient
        : IKsqlDbDescribeService,
            IKsqlDbExplainService,
            IKsqlDbExecuteService,
            IKsqlDbTablesService
    {
    }
}
