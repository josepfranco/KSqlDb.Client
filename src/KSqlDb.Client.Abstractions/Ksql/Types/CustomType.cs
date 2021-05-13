namespace KSqlDb.Client.Ksql.Types
{
    public record CustomType : ColumnType
    {
        private CustomType(string value) : base(value) { }

        public static CustomType Of(string typeName) => new(typeName);

        // ReSharper disable once RedundantOverriddenMember
        /// <summary>
        ///   This seems to be needed when using records. It's not explicitly using the ColumnType's equals.
        /// </summary>
        /// <returns></returns>
        public override string ToString() => base.ToString();
    }
}
