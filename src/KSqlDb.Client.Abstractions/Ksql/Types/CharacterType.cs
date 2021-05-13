namespace KSqlDb.Client.Ksql.Types
{
    public record CharacterType : ColumnType
    {
        public static readonly CharacterType String = new("STRING");
        public static readonly CharacterType Varchar = new("VARCHAR");

        private CharacterType(string value) : base(value) { }

        // ReSharper disable once RedundantOverriddenMember
        /// <summary>
        ///   This seems to be needed when using records. It's not explicitly using the ColumnType's equals.
        /// </summary>
        /// <returns></returns>
        public override string ToString() => base.ToString();
    }
}
