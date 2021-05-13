namespace KSqlDb.Client.Ksql.Types
{
    public record ArrayType : ColumnType
    {
        private ArrayType(string value) : base(value) { }

        public static ArrayType Array(ColumnType innerType) => new($"ARRAY<{innerType}>");

        // ReSharper disable once RedundantOverriddenMember
        /// <summary>
        ///   This seems to be needed when using records. It's not explicitly using the ColumnType's equals.
        /// </summary>
        /// <returns></returns>
        public override string ToString() => base.ToString();
    }
}
