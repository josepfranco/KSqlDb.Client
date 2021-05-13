namespace KSqlDb.Client.Ksql.Builders.Table
{
    using Properties;

    public interface IWithExpressionBuilder
    {
        IWithExpressionBuilder With(WithProperty property);

        ITableRequestBuilder AndWith(WithProperty property);
    }
}
