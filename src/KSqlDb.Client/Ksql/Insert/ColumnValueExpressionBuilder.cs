namespace KSqlDb.Client.Ksql.Insert
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using Ardalis.GuardClauses;
    using Builders.Insert;

    public class ColumnValueExpressionBuilder : IColumnValueExpressionBuilder
    {
        private readonly StringBuilder sqlExpressionBuilder;
        private readonly IList<ValueTuple<string, string>> columnValues;

        internal ColumnValueExpressionBuilder(StringBuilder sqlExpressionBuilder,
                                              IList<ValueTuple<string, string>> columnValues)
        {
            this.sqlExpressionBuilder = sqlExpressionBuilder;
            this.columnValues         = columnValues;
        }

        public IColumnValueExpressionBuilder WithValue(string columnName, string? value)
        {
            this.GuardAndGuaranteeUniqueness(columnName);
            this.AddStringColumnValue(columnName, value);
            return new ColumnValueExpressionBuilder(this.sqlExpressionBuilder, this.columnValues);
        }

        public IColumnValueExpressionBuilder WithValue(string columnName, char? value)
        {
            this.GuardAndGuaranteeUniqueness(columnName);
            this.AddCharColumnValue(columnName, value);
            return new ColumnValueExpressionBuilder(this.sqlExpressionBuilder, this.columnValues);
        }

        public IColumnValueExpressionBuilder WithValue(string columnName, bool? value)
        {
            this.GuardAndGuaranteeUniqueness(columnName);
            this.AddBoolColumnValue(columnName, value);
            return new ColumnValueExpressionBuilder(this.sqlExpressionBuilder, this.columnValues);
        }

        public IColumnValueExpressionBuilder WithValue(string columnName, int? value)
        {
            this.GuardAndGuaranteeUniqueness(columnName);
            this.AddIntColumnValue(columnName, value);
            return new ColumnValueExpressionBuilder(this.sqlExpressionBuilder, this.columnValues);
        }

        public IColumnValueExpressionBuilder WithValue(string columnName, long? value)
        {
            this.GuardAndGuaranteeUniqueness(columnName);
            this.AddLongColumnValue(columnName, value);
            return new ColumnValueExpressionBuilder(this.sqlExpressionBuilder, this.columnValues);
        }

        public IColumnValueExpressionBuilder WithValue(string columnName, float? value)
        {
            this.GuardAndGuaranteeUniqueness(columnName);
            this.AddFloatColumnValue(columnName, value);
            return new ColumnValueExpressionBuilder(this.sqlExpressionBuilder, this.columnValues);
        }

        public IColumnValueExpressionBuilder WithValue(string columnName, double? value)
        {
            this.GuardAndGuaranteeUniqueness(columnName);
            this.AddDoubleColumnValue(columnName, value);
            return new ColumnValueExpressionBuilder(this.sqlExpressionBuilder, this.columnValues);
        }

        public IColumnValueExpressionBuilder WithValue(string columnName, DateTimeOffset? value)
        {
            this.GuardAndGuaranteeUniqueness(columnName);
            this.AddDateTimeColumnValue(columnName, value);
            return new ColumnValueExpressionBuilder(this.sqlExpressionBuilder, this.columnValues);
        }

        public IInsertRequestBuilder AndWithValue(string columnName, string? value)
        {
            this.GuardAndGuaranteeUniqueness(columnName);
            this.AddStringColumnValue(columnName, value);
            this.BuildColumnNamesAndValuesExpression();
            return new InsertRequestBuilder(this.sqlExpressionBuilder);
        }

        public IInsertRequestBuilder AndWithValue(string columnName, char? value)
        {
            this.GuardAndGuaranteeUniqueness(columnName);
            this.AddCharColumnValue(columnName, value);
            this.BuildColumnNamesAndValuesExpression();
            return new InsertRequestBuilder(this.sqlExpressionBuilder);
        }

        public IInsertRequestBuilder AndWithValue(string columnName, bool? value)
        {
            this.GuardAndGuaranteeUniqueness(columnName);
            this.AddBoolColumnValue(columnName, value);
            this.BuildColumnNamesAndValuesExpression();
            return new InsertRequestBuilder(this.sqlExpressionBuilder);
        }

        public IInsertRequestBuilder AndWithValue(string columnName, int? value)
        {
            this.GuardAndGuaranteeUniqueness(columnName);
            this.AddIntColumnValue(columnName, value);
            this.BuildColumnNamesAndValuesExpression();
            return new InsertRequestBuilder(this.sqlExpressionBuilder);
        }

        public IInsertRequestBuilder AndWithValue(string columnName, long? value)
        {
            this.GuardAndGuaranteeUniqueness(columnName);
            this.AddLongColumnValue(columnName, value);
            this.BuildColumnNamesAndValuesExpression();
            return new InsertRequestBuilder(this.sqlExpressionBuilder);
        }

        public IInsertRequestBuilder AndWithValue(string columnName, float? value)
        {
            this.GuardAndGuaranteeUniqueness(columnName);
            this.AddFloatColumnValue(columnName, value);
            this.BuildColumnNamesAndValuesExpression();
            return new InsertRequestBuilder(this.sqlExpressionBuilder);
        }

        public IInsertRequestBuilder AndWithValue(string columnName, double? value)
        {
            this.GuardAndGuaranteeUniqueness(columnName);
            this.AddDoubleColumnValue(columnName, value);
            this.BuildColumnNamesAndValuesExpression();
            return new InsertRequestBuilder(this.sqlExpressionBuilder);
        }

        public IInsertRequestBuilder AndWithValue(string columnName, DateTimeOffset? value)
        {
            this.GuardAndGuaranteeUniqueness(columnName);
            this.AddDateTimeColumnValue(columnName, value);
            this.BuildColumnNamesAndValuesExpression();
            return new InsertRequestBuilder(this.sqlExpressionBuilder);
        }

        private void GuardAndGuaranteeUniqueness(string columnName)
        {
            Guard.Against.NullOrEmpty(columnName, nameof(columnName));
            var anyAlreadyExistentColumnName = this.columnValues
               .Any(x => x.Item1.Equals(columnName, StringComparison.InvariantCultureIgnoreCase));
            if (anyAlreadyExistentColumnName)
            {
                var value = this.columnValues
                   .FirstOrDefault(x => x.Item1
                                      .Equals(columnName, StringComparison.InvariantCultureIgnoreCase));
                throw new InvalidOperationException($"Column name {columnName} has already " +
                                                    $"been set for value: {value}");
            }
        }

        private void AddStringColumnValue(string columnName, string? value)
        {
            var stringValue = value is not null
                ? $"'{value}'"
                : "NULL";
            this.columnValues.Add((columnName, stringValue));
        }

        private void AddCharColumnValue(string columnName, char? value)
        {
            var stringValue = value is not null
                ? $"'{value}'"
                : "NULL";
            this.columnValues.Add((columnName, stringValue));
        }

        private void AddBoolColumnValue(string columnName, bool? value)
        {
            var stringValue = value?.ToString(CultureInfo.InvariantCulture).ToUpperInvariant() ?? "NULL";
            this.columnValues.Add((columnName, stringValue));
        }

        private void AddIntColumnValue(string columnName, int? value)
        {
            var stringValue = value?.ToString(CultureInfo.InvariantCulture) ?? "NULL";
            this.columnValues.Add((columnName, stringValue));
        }

        private void AddLongColumnValue(string columnName, long? value)
        {
            var stringValue = value?.ToString(CultureInfo.InvariantCulture) ?? "NULL";
            this.columnValues.Add((columnName, stringValue));
        }

        private void AddFloatColumnValue(string columnName, float? value)
        {
            var stringValue = value?.ToString(CultureInfo.InvariantCulture) ?? "NULL";
            this.columnValues.Add((columnName, stringValue));
        }

        private void AddDoubleColumnValue(string columnName, double? value)
        {
            var stringValue = value?.ToString(CultureInfo.InvariantCulture) ?? "NULL";
            this.columnValues.Add((columnName, stringValue));
        }

        private void AddDateTimeColumnValue(string columnName, DateTimeOffset? value)
        {
            var stringValue = value?.ToUnixTimeMilliseconds().ToString(CultureInfo.InvariantCulture) ?? "NULL";
            this.columnValues.Add((columnName, stringValue));
        }

        private void BuildColumnNamesAndValuesExpression()
        {
            var orderedColumnNames  = this.columnValues.Select(x => x.Item1).ToList();
            var orderedColumnValues = this.columnValues.Select(x => x.Item2).ToList();

            var condensedColumnNames  = string.Join(", ", orderedColumnNames);
            var condensedColumnValues = string.Join(", ", orderedColumnValues);
            this.sqlExpressionBuilder.AppendFormat("( {0} ) VALUES ( {1} )",
                                                   condensedColumnNames,
                                                   condensedColumnValues);
        }
    }
}
