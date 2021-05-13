namespace KSqlDb.Client.UnitTests.Ksql
{
    using System;
    using System.Globalization;
    using Client.Ksql;
    using Shouldly;
    using Xunit;

    [Trait("Ksql", "Ksql/Builder/Insert")]
    public class InsertExpressionBuilderTests
    {
        #region INVALID INPUT TESTS
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void Insert_WhenInvalidInput_ShouldThrowException(string input) =>
            Should.Throw<Exception>(() => KsqlBuilder.ForInsertRequest.Insert(input));
        #endregion

        [Fact]
        public void InsertAsKsql_WhenInsertingALotOfValues_ShouldReturnFullInsertKsqlString()
        {
            // ARRANGE
            const string tableName = "simpleTable";

            const string columnName1  = "test_col1";
            const int    columnValue1 = 10;

            const string columnName2  = "test_col2";
            const long   columnValue2 = 100_000_000L;

            const string columnName3          = "test_col3";
            const double columnValue3         = 0.95;
            var          expectedColumnValue3 = columnValue3.ToString(CultureInfo.InvariantCulture);

            const string columnName4          = "test_col4";
            const float  columnValue4         = 1.25f;
            var          expectedColumnValue4 = columnValue4.ToString(CultureInfo.InvariantCulture);

            const string columnName5  = "test_col5";
            var          columnValue5 = DateTimeOffset.Now;
            var expectedColumnValue5 = columnValue5
               .ToUnixTimeMilliseconds()
               .ToString(CultureInfo.InvariantCulture);

            const string columnName6          = "test_col6";
            const bool   columnValue6         = true;
            var          expectedColumnValue6 = columnValue6.ToString(CultureInfo.InvariantCulture).ToUpperInvariant();

            const string columnName7  = "test_col7";
            const string columnValue7 = "mega_test";

            const string columnName8  = "test_col8";
            const char   columnValue8 = 'K';

            const string columnName9  = "test_col9";
            const string columnValue9 = null;

            // ACT
            var ksql = KsqlBuilder.ForInsertRequest
               .Insert(tableName)
               .WithValue(columnName1, columnValue1)
               .WithValue(columnName2, columnValue2)
               .WithValue(columnName3, columnValue3)
               .WithValue(columnName4, columnValue4)
               .WithValue(columnName5, columnValue5)
               .WithValue(columnName6, columnValue6)
               .WithValue(columnName7, columnValue7)
               .WithValue(columnName8, columnValue8)
               .AndWithValue(columnName9, columnValue9)
               .BuildAsKsql();

            // ASSERT
            ksql.ShouldBe($"INSERT INTO {tableName} "                                                           +
                          $"( {columnName1}, {columnName2}, {columnName3}, {columnName4}, {columnName5}, "      +
                          $"{columnName6}, {columnName7}, {columnName8}, {columnName9} )"                       +
                          " VALUES "                                                                            +
                          $"( {columnValue1}, {columnValue2}, {expectedColumnValue3}, {expectedColumnValue4}, " +
                          $"{expectedColumnValue5}, {expectedColumnValue6}, '{columnValue7}', '{columnValue8}', NULL );");
        }
    }
}
