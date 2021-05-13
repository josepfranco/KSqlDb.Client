namespace KSqlDb.Client.Ksql.Properties
{
    public abstract class WithProperty
    {
        private readonly string value;

        protected WithProperty(string value) => this.value = value;

        public override string ToString() => this.value;
    }
}
