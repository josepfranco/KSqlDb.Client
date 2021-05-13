namespace KSqlDb.Client.Ksql.Builders.Table
{
    using Constraints;
    using Types;

    public interface IRegularColumnExpressionBuilder
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="name"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        IRegularColumnExpressionBuilder Column(string name,
                                               ColumnType type);

        /// <summary>
        ///
        /// </summary>
        /// <param name="name"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        IWithKafkaTopicExpressionBuilder AndColumn(string name,
                                                   ColumnType type);

        /// <summary>
        ///
        /// </summary>
        /// <param name="name"></param>
        /// <param name="type"></param>
        /// <param name="constraint"></param>
        /// <returns></returns>
        IRegularColumnExpressionBuilder ColumnWithConstraint(string name,
                                                             ColumnType type,
                                                             ConstraintType constraint);

        /// <summary>
        ///
        /// </summary>
        /// <param name="name"></param>
        /// <param name="type"></param>
        /// <param name="constraint"></param>
        /// <returns></returns>
        IWithKafkaTopicExpressionBuilder AndColumnWithConstraint(string name,
                                                                 ColumnType type,
                                                                 ConstraintType constraint);
    }
}
