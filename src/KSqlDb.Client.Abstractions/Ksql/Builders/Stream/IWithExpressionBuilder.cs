namespace KSqlDb.Client.Ksql.Builders.Stream
{
    using Properties;

    public interface IWithExpressionBuilder
    {
        IWithExpressionBuilder With(WithProperty property);

        IStreamRequestBuilder AndWith(WithProperty property);
    }
}
