namespace KSqlDb.Client.Ksql.Types
{
    using System;
    using System.Linq;

    public record StructType : ColumnType
    {
        private StructType(string value) : base(value) { }

        public static StructType Struct(params (string name, ColumnType type)[] types)
        {
            if (!types.Any())
            {
                throw new InvalidOperationException("Struct must have atleast one name & type definition.");
            }

            var formattedTypes = types.Select(x => $"{x.name} {x.type}").ToList();
            return new StructType($"STRUCT<{string.Join(", ", formattedTypes)}>");
        }

        // ReSharper disable once RedundantOverriddenMember
        /// <summary>
        ///   This seems to be needed when using records. It's not explicitly using the ColumnType's equals.
        /// </summary>
        /// <returns></returns>
        public override string ToString() => base.ToString();
    }
}
