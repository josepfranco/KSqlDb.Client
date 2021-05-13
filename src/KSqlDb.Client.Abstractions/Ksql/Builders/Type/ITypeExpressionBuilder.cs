namespace KSqlDb.Client.Ksql.Builders.Type
{
    using Types;

    public interface ITypeExpressionBuilder
    {
        ITypeRequestBuilder Create(string name, ColumnType type);
    }
}
