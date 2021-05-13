namespace KSqlDb.Client.Ksql.Builders.Insert
{
    using System;

    public interface IColumnValueExpressionBuilder
    {
        IColumnValueExpressionBuilder WithValue(string columnName, string? value);

        IColumnValueExpressionBuilder WithValue(string columnName, char? value);

        IColumnValueExpressionBuilder WithValue(string columnName, bool? value);

        IColumnValueExpressionBuilder WithValue(string columnName, int? value);

        IColumnValueExpressionBuilder WithValue(string columnName, long? value);

        IColumnValueExpressionBuilder WithValue(string columnName, float? value);

        IColumnValueExpressionBuilder WithValue(string columnName, double? value);

        IColumnValueExpressionBuilder WithValue(string columnName, DateTimeOffset? value);

        IInsertRequestBuilder AndWithValue(string columnName, string? value);

        IInsertRequestBuilder AndWithValue(string columnName, char? value);

        IInsertRequestBuilder AndWithValue(string columnName, bool? value);

        IInsertRequestBuilder AndWithValue(string columnName, int? value);

        IInsertRequestBuilder AndWithValue(string columnName, long? value);

        IInsertRequestBuilder AndWithValue(string columnName, float? value);

        IInsertRequestBuilder AndWithValue(string columnName, double? value);

        IInsertRequestBuilder AndWithValue(string columnName, DateTimeOffset? value);
    }
}
