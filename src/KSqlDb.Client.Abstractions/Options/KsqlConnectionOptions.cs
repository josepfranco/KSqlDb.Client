namespace KSqlDb.Client.Options
{
    public record KsqlConnectionOptions
    {
        private const string DefaultHost = "localhost";
        private const int DefaultPort = 8080;
        private const int DefaultQueryMaxResultRows = 10_000;

        public string? Host { get; init; } = DefaultHost;
        public int? Port { get; init; } = DefaultPort;

        public int? QueryMaxResultRows { get; init; } = DefaultQueryMaxResultRows;

        public string? BasicAuthUsername { get; init; }
        public string? BasicAuthPassword { get; init; }

        public string? KeyStorePath { get; init; }
        public string? KeyStorePassword { get; init; }

        public string? TrustStorePath { get; init; }
        public string? TrustStorePassword { get; set; }

        public bool? UseAlpn { get; init; }
        public bool? UseTls { get; init; }
        public bool? VerifyHost { get; init; }
    }
}
