using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DGG.Raffle.Business.Abstract.Builders
{
    /// <summary>
    /// Builder for http responses.
    /// </summary>
    /// <typeparam name="TData">The type of the data.</typeparam>
    public class BusinessResultBuilder<TData>
    {
        private bool success;
        private string message;
        private TData data;
        private HttpStatusCode statusCode;

        /// <summary>
        /// Initializes a new instance of the <see cref="BusinessResultBuilder{TData}"/> class.
        /// </summary>
        /// <param name="success">if set to <c>true</c> [success].</param>
        /// <param name="message">The message.</param>
        /// <param name="data">The data.</param>
        /// <param name="statusCode">The status code.</param>
        private BusinessResultBuilder(bool success, string message, TData data, HttpStatusCode statusCode)
            : this(success)
        {
            this.message = message;
            this.data = data;
            this.statusCode = statusCode;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BusinessResultBuilder{TData}"/> class.
        /// </summary>
        /// <param name="success">if set to <c>true</c> [success].</param>
        private BusinessResultBuilder(bool success)
        {
            this.success = success;
        }

        /// <summary>
        /// Creates this instance.
        /// </summary>
        /// <returns> Builder </returns>
        public static BusinessResultBuilder<TData> Create()
        {
            return new BusinessResultBuilder<TData>(true);
        }

        /// <summary>
        /// Creates the specified data.
        /// </summary>
        /// <param name="success">if set to <c>true</c> [success].</param>
        /// <param name="message">The message.</param>
        /// <param name="data">The data.</param>
        /// <returns>
        /// BizReplyResult
        /// </returns>
        public static BusinessResultBuilder<TData> Create(bool success, string message, TData data, HttpStatusCode statusCode)
        {
            return new BusinessResultBuilder<TData>(success, message, data, statusCode);
        }

        /// <summary>
        /// Withes the message.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <returns>Builder</returns>
        public BusinessResultBuilder<TData> WithMessage(string message)
        {
            this.message = message;
            return this;
        }

        /// <summary>
        /// Successes this instance.
        /// </summary>
        /// <returns>Builder</returns>
        public BusinessResultBuilder<TData> Success()
        {
            this.success = true;
            return this;
        }

        public BusinessResultBuilder<TData> IsSuccessful(bool isSuccessful)
        {
            this.success = isSuccessful;
            return this;
        }

        /// <summary>
        /// It marks as fail (success = false).
        /// </summary>
        /// <returns>Builder</returns>
        public BusinessResultBuilder<TData> Fail()
        {
            this.success = false;
            return this;
        }

        /// <summary>
        /// It marks as fail (success = false).
        /// </summary>
        /// <param name="message">The message.</param>
        /// <returns>
        /// Builder
        /// </returns>
        public BusinessResultBuilder<TData> Fail(string message, HttpStatusCode statusCode)
        {
            this.success = false;
            this.message = message;
            this.statusCode = statusCode;
            return this;
        }

        /// <summary>
        /// Withes the data.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <returns>BizReplyResult</returns>
        public BusinessResultBuilder<TData> WithData(TData data)
        {
            this.data = data;
            return this;
        }

        /// <summary>
        /// Withes the HTTP status code.
        /// </summary>
        /// <param name="statusCode">The status code.</param>
        /// <returns></returns>
        public BusinessResultBuilder<TData> WithHttpStatusCode(HttpStatusCode statusCode)
        {
            this.statusCode = statusCode;
            return this;
        }

        /// <summary>
        /// Builds the reply result instance.
        /// </summary>
        /// <returns>BizReplyResult</returns>
        public BusinessResult<TData> Build()
        {
            var replyResult = new BusinessResult<TData>
            {
                isSuccessful = success,
                Message = message,
                Data = this.data,
                StatusCode = this.statusCode
            };

            return replyResult;
        }

        /// <summary>
        /// Builds Biz result reply instance asynchronous.
        /// </summary>
        /// <returns>BizReplyResult</returns>
        public async Task<BusinessResult<TData>> BuildAsync()
        {
            return await Task.FromResult(this.Build()).ConfigureAwait(false);
        }
    }
}
