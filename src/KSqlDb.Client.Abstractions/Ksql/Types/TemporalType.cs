namespace KSqlDb.Client.Ksql.Types
{
    public record TemporalType : ColumnType
    {
        public static TemporalType Timestamp = new("TIMESTAMP");

        private TemporalType(string value) : base(value) { }

        // ReSharper disable once RedundantOverriddenMember
        /// <summary>
        ///   This seems to be needed when using records. It's not explicitly using the ColumnType's equals.
        /// </summary>
        /// <returns></returns>
        public override string ToString() => base.ToString();
    }
}
