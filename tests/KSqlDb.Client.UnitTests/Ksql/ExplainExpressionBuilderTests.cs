namespace KSqlDb.Client.UnitTests.Ksql
{
    using System;
    using Client.Ksql;
    using Shouldly;
    using Xunit;

    [Trait("Unit", "Ksql/Builder/Explain")]
    public class ExplainExpressionBuilderTests
    {
        #region INVALID INPUT TESTS
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void Explain_WhenNullInput_ShouldThrowException(string input) =>
            Should.Throw<Exception>(() => KsqlBuilder.ForExplainRequest.Explain(input));
        #endregion

        [Fact]
        public void BuildKsql_WhenOneWordInput_ShouldReturnKsqlExpressionString()
        {
            // ARRANGE
            const string input = "fancyQuery";

            // ACT
            var ksql = KsqlBuilder.ForExplainRequest
               .Explain(input)
               .BuildAsKsql();

            // ASSERT
            ksql.ShouldBe("EXPLAIN fancyQuery;", StringCompareShould.IgnoreCase);
        }

        [Fact]
        public void BuildExplainRequest_WhenOneWordInput_ShouldReturnRequestInstance()
        {
            // ARRANGE
            const string input = "fancyQuery";

            // ACT
            var request = KsqlBuilder.ForExplainRequest
               .Explain(input)
               .Build();

            // ASSERT
            request.ShouldNotBeNull();
            request.Ksql.ShouldBe("EXPLAIN fancyQuery;", StringCompareShould.IgnoreCase);
        }
    }
}
