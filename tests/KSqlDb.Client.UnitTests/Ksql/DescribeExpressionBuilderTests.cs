namespace KSqlDb.Client.UnitTests.Ksql
{
    using System;
    using Client.Ksql;
    using Shouldly;
    using Xunit;

    [Trait("Unit", "Ksql/Builder/Describe")]
    public class DescribeExpressionBuilderTests
    {
        #region INVALID INPUT TESTS
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void Describe_WhenInvalidInput_ShouldThrowException(string input) =>
            Should.Throw<Exception>(() => KsqlBuilder.ForDescribeRequest.Describe(input));

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void DescribeExtended_WhenInvalidInput_ShouldThrowException(string input) =>
            Should.Throw<Exception>(() => KsqlBuilder.ForDescribeRequest.DescribeExtended(input));

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void DescribeConnector_WhenInvalidInput_ShouldThrowException(string input) =>
            Should.Throw<Exception>(() => KsqlBuilder.ForDescribeRequest.DescribeConnector(input));

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void DescribeFunction_WhenNullInput_ShouldThrowException(string input) =>
            Should.Throw<Exception>(() => KsqlBuilder.ForDescribeRequest.DescribeFunction(input));
        #endregion
    }
}
