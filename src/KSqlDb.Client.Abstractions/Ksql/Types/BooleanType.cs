namespace KSqlDb.Client.Ksql.Types
{
    public record BooleanType : ColumnType
    {
        public static BooleanType Boolean = new("BOOLEAN");

        private BooleanType(string value) : base(value) { }

        // ReSharper disable once RedundantOverriddenMember
        /// <summary>
        ///   This seems to be needed when using records. It's not explicitly using the ColumnType's equals.
        /// </summary>
        /// <returns></returns>
        public override string ToString() => base.ToString();
    }
}
