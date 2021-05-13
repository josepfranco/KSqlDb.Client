namespace KSqlDb.Client.Ksql.Constraints
{
    public class ConstraintType
    {
        private readonly string value;

        private ConstraintType(string value) => this.value = value;
        public static ConstraintType NonNull => new("NON NULL");
        public static ConstraintType Unique => new("UNIQUE");

        public override string ToString() => this.value;
    }
}
