namespace KSqlDb.Client
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using ApiModels.Requests;
    using ApiModels.Responses;

    public interface IKsqlDbDescribeService
    {
        /// <summary>
        /// </summary>
        /// <param name="request"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        Task<IEnumerable<DescribeResponse>> DescribeAsync(DescribeRequest request, CancellationToken token = default);
    }
}
