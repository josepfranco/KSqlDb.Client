namespace KSqlDb.Client.UnitTests.Ksql
{
    using System;
    using Client.Ksql;
    using Client.Ksql.Constraints;
    using Client.Ksql.Types;
    using Shouldly;
    using Xunit;

    [Trait("Unit", "Ksql/Builder/Tables")]
    public class TablesExpressionBuilderTests
    {
        #region INVALID INPUT TESTS
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void CreateTable_WhenInvalidInput_ShouldThrowException(string input) =>
            Should.Throw<Exception>(() => KsqlBuilder.ForTableRequest.Create(input));

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void CreateOrReplaceTable_WhenInvalidInput_ShouldThrowException(string input) =>
            Should.Throw<Exception>(() => KsqlBuilder.ForTableRequest.CreateOrReplace(input));

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void CreateIfNotExistsTable_WhenInvalidInput_ShouldThrowException(string input) =>
            Should.Throw<Exception>(() => KsqlBuilder.ForTableRequest.CreateIfNotExists(input));

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void CreateOrReplaceIfNotExistsTable_WhenInvalidInput_ShouldThrowException(string input) =>
            Should.Throw<Exception>(() => KsqlBuilder.ForTableRequest.CreateOrReplaceIfNotExists(input));
        #endregion

        #region CREATE TABLE TESTS
        [Fact]
        public void CreateTableAsKsql_WhenSimpleTableDefinition_ShouldReturnSimpleTableKsqlString()
        {
            // ARRANGE
            const string tableName = "simpleTable";

            const string primaryKey     = "id";
            var          primaryKeyType = CharacterType.String;

            const string kafkaTopic = "simple_topic";

            // ACT
            var ksql = KsqlBuilder.ForTableRequest
               .Create(tableName)
               .AndColumnWithPrimaryKey(primaryKey, primaryKeyType)
               .AndWithKafkaTopic(kafkaTopic)
               .BuildAsKsql();

            // ASSERT
            ksql.ShouldBe($"CREATE TABLE `{tableName}` "                           +
                          $"( `{primaryKey}` {primaryKeyType} PRIMARY KEY ) WITH " +
                          $"( KAFKA_TOPIC='{kafkaTopic}' );");
        }

        [Fact]
        public void CreateTableAsKsql_WhenBigTableDefinition_ShouldReturnBigTableKsqlString()
        {
            // ARRANGE
            const string tableName = "bigTable";

            const string primaryKey     = "id";
            var          primaryKeyType = CharacterType.String;

            const string firstColumnKey     = "temporal_col";
            var          firstColumnKeyType = TemporalType.Timestamp;

            const string secondColumnKey           = "bigint_col";
            var          secondColumnKeyType       = NumericType.BigInt;
            var          secondColumnKeyConstraint = ConstraintType.Unique;

            const string thirdColumnKey     = "array_col";
            var          thirdColumnKeyType = ArrayType.Array(BooleanType.Boolean);

            const string kafkaTopic = "big_topic";

            // ACT
            var ksql = KsqlBuilder.ForTableRequest
               .Create(tableName)
               .ColumnWithPrimaryKey(primaryKey, primaryKeyType)
               .Column(firstColumnKey, firstColumnKeyType)
               .ColumnWithConstraint(secondColumnKey, secondColumnKeyType, secondColumnKeyConstraint)
               .AndColumn(thirdColumnKey, thirdColumnKeyType)
               .AndWithKafkaTopic(kafkaTopic)
               .BuildAsKsql();

            // ASSERT
            ksql.ShouldBe($"CREATE TABLE `{tableName}` "                                             +
                          $"( `{primaryKey}` {primaryKeyType} PRIMARY KEY"                           +
                          $", `{firstColumnKey}` {firstColumnKeyType}" +
                          $", `{secondColumnKey}` {secondColumnKeyType} {secondColumnKeyConstraint}" +
                          $", `{thirdColumnKey}` {thirdColumnKeyType} ) WITH "                        +
                          $"( KAFKA_TOPIC='{kafkaTopic}' );");
        }
        #endregion

        #region CREATE OR REPLACE TABLE TESTS
        [Fact]
        public void CreateOrReplaceTableAsKsql_WhenSimpleTableDefinition_ShouldReturnSimpleTableKsqlString()
        {
            // ARRANGE
            const string tableName = "simpleTable";

            const string primaryKey     = "id";
            var          primaryKeyType = CharacterType.String;

            const string kafkaTopic = "simple_topic";

            // ACT
            var ksql = KsqlBuilder.ForTableRequest
               .CreateOrReplace(tableName)
               .AndColumnWithPrimaryKey(primaryKey, primaryKeyType)
               .AndWithKafkaTopic(kafkaTopic)
               .BuildAsKsql();

            // ASSERT
            ksql.ShouldBe($"CREATE OR REPLACE TABLE `{tableName}` "                           +
                          $"( `{primaryKey}` {primaryKeyType} PRIMARY KEY ) WITH " +
                          $"( KAFKA_TOPIC='{kafkaTopic}' );");
        }

        [Fact]
        public void CreateOrReplaceTableAsKsql_WhenBigTableDefinition_ShouldReturnBigTableKsqlString()
        {
            // ARRANGE
            const string tableName = "bigTable";

            const string primaryKey     = "id";
            var          primaryKeyType = CharacterType.String;

            const string firstColumnKey     = "temporal_col";
            var          firstColumnKeyType = TemporalType.Timestamp;

            const string secondColumnKey           = "bigint_col";
            var          secondColumnKeyType       = NumericType.BigInt;
            var          secondColumnKeyConstraint = ConstraintType.Unique;

            const string thirdColumnKey     = "array_col";
            var          thirdColumnKeyType = ArrayType.Array(BooleanType.Boolean);

            const string kafkaTopic = "big_topic";

            // ACT
            var ksql = KsqlBuilder.ForTableRequest
               .CreateOrReplace(tableName)
               .ColumnWithPrimaryKey(primaryKey, primaryKeyType)
               .Column(firstColumnKey, firstColumnKeyType)
               .ColumnWithConstraint(secondColumnKey, secondColumnKeyType, secondColumnKeyConstraint)
               .AndColumn(thirdColumnKey, thirdColumnKeyType)
               .AndWithKafkaTopic(kafkaTopic)
               .BuildAsKsql();

            // ASSERT
            ksql.ShouldBe($"CREATE OR REPLACE TABLE `{tableName}` "                                             +
                          $"( `{primaryKey}` {primaryKeyType} PRIMARY KEY"                           +
                          $", `{firstColumnKey}` {firstColumnKeyType}" +
                          $", `{secondColumnKey}` {secondColumnKeyType} {secondColumnKeyConstraint}" +
                          $", `{thirdColumnKey}` {thirdColumnKeyType} ) WITH "                        +
                          $"( KAFKA_TOPIC='{kafkaTopic}' );");
        }
        #endregion
    }
}
