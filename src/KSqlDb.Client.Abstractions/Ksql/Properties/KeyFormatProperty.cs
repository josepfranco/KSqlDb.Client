namespace KSqlDb.Client.Ksql.Properties
{
    public class KeyFormatProperty : WithProperty
    {
        public KeyFormatProperty(string value) : base(value) { }

        public static KeyFormatProperty KeyFormat(SerializationFormat format) =>
            new($"KEY_FORMAT='{format.ToString().ToUpperInvariant()}'");
    }
}
