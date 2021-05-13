namespace KSqlDb.Client.Ksql.Types
{
    public record NumericType : ColumnType
    {
        public static NumericType Integer = new("INTEGER");
        public static NumericType BigInt = new("BIGINT");
        public static NumericType Double = new("DOUBLE");
        public static NumericType Decimal = new("DECIMAL");

        private NumericType(string value) : base(value) { }

        public static NumericType DecimalWithPrecision(int precision, int scale) =>
            new($"DECIMAL({precision},{scale})");

        // ReSharper disable once RedundantOverriddenMember
        /// <summary>
        ///   This seems to be needed when using records. It's not explicitly using the ColumnType's equals.
        /// </summary>
        /// <returns></returns>
        public override string ToString() => base.ToString();
    }
}
