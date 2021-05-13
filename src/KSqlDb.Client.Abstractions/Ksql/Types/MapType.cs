namespace KSqlDb.Client.Ksql.Types
{
    public record MapType : ColumnType
    {
        private MapType(string value) : base(value) { }

        public static MapType Map(ColumnType keyType, ColumnType valueType) => new($"MAP<{keyType}, {valueType}>");

        // ReSharper disable once RedundantOverriddenMember
        /// <summary>
        ///   This seems to be needed when using records. It's not explicitly using the ColumnType's equals.
        /// </summary>
        /// <returns></returns>
        public override string ToString() => base.ToString();
    }
}
