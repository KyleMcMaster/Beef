/*
 * This file is automatically generated; any changes will be lost. 
 */

using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Beef.Entities;
using Beef.WebApi;
using Newtonsoft.Json.Linq;
using Beef.Demo.Common.Entities;
using RefDataNamespace = Beef.Demo.Common.Entities;

namespace Beef.Demo.Common.Agents.ServiceAgents
{
    /// <summary>
    /// Defines the Customer group Web API service agent.
    /// </summary>
    public partial interface ICustomerGroupServiceAgent
    {
        /// <summary>
        /// Gets the <see cref="CustomerGroup"/> object that matches the selection criteria.
        /// </summary>
        /// <param name="id">The <see cref="CustomerGroup"/> identifier.</param>
        /// <param name="company">The Company (see <see cref="RefDataNamespace.Company"/>).</param>
        /// <param name="requestOptions">The optional <see cref="WebApiRequestOptions"/>.</param>
        /// <returns>A <see cref="WebApiAgentResult"/>.</returns>
        Task<WebApiAgentResult<CustomerGroup>> GetAsync(string id, RefDataNamespace.Company company, WebApiRequestOptions requestOptions = null);

        /// <summary>
        /// Gets the <see cref="CustomerGroup"/> collection object that matches the selection criteria.
        /// </summary>
        /// <param name="args">The Args (see <see cref="CustomerGroupArgs"/>).</param>
        /// <param name="paging">The <see cref="PagingArgs"/>.</param>
        /// <param name="requestOptions">The optional <see cref="WebApiRequestOptions"/>.</param>
        /// <returns>A <see cref="WebApiAgentResult"/>.</returns>
        Task<WebApiAgentResult<CustomerGroupCollectionResult>> GetByArgsAsync(CustomerGroupArgs args, PagingArgs paging = null, WebApiRequestOptions requestOptions = null);

        /// <summary>
        /// Creates the <see cref="CustomerGroup"/> object.
        /// </summary>
        /// <param name="value">The <see cref="CustomerGroup"/> object.</param>
        /// <param name="company">The Company (see <see cref="RefDataNamespace.Company"/>).</param>
        /// <param name="requestOptions">The optional <see cref="WebApiRequestOptions"/>.</param>
        /// <returns>A <see cref="WebApiAgentResult"/>.</returns>
        Task<WebApiAgentResult<CustomerGroup>> CreateAsync(CustomerGroup value, RefDataNamespace.Company company, WebApiRequestOptions requestOptions = null);

        /// <summary>
        /// Updates the <see cref="CustomerGroup"/> object.
        /// </summary>
        /// <param name="value">The <see cref="CustomerGroup"/> object.</param>
        /// <param name="id">The <see cref="CustomerGroup"/> identifier.</param>
        /// <param name="company">The Company (see <see cref="RefDataNamespace.Company"/>).</param>
        /// <param name="requestOptions">The optional <see cref="WebApiRequestOptions"/>.</param>
        /// <returns>A <see cref="WebApiAgentResult"/>.</returns>
        Task<WebApiAgentResult<CustomerGroup>> UpdateAsync(CustomerGroup value, string id, RefDataNamespace.Company company, WebApiRequestOptions requestOptions = null);

        /// <summary>
        /// Upserts a <see cref="CustomerGroupCollection"/> as a batch.
        /// </summary>
        /// <param name="value">The Value (see <see cref="CustomerGroupCollection"/>).</param>
        /// <param name="company">The Company (see <see cref="RefDataNamespace.Company"/>).</param>
        /// <param name="requestOptions">The optional <see cref="WebApiRequestOptions"/>.</param>
        /// <returns>A <see cref="WebApiAgentResult"/>.</returns>
        Task<WebApiAgentResult> UpdateBatchAsync(CustomerGroupCollection value, RefDataNamespace.Company company, WebApiRequestOptions requestOptions = null);

        /// <summary>
        /// Deletes the <see cref="CustomerGroup"/> object that matches the selection criteria.
        /// </summary>
        /// <param name="id">The <see cref="CustomerGroup"/> identifier.</param>
        /// <param name="company">The Company (see <see cref="RefDataNamespace.Company"/>).</param>
        /// <param name="requestOptions">The optional <see cref="WebApiRequestOptions"/>.</param>
        /// <returns>A <see cref="WebApiAgentResult"/>.</returns>
        Task<WebApiAgentResult> DeleteAsync(string id, RefDataNamespace.Company company, WebApiRequestOptions requestOptions = null);
    }

    /// <summary>
    /// Provides the Customer group Web API service agent.
    /// </summary>
    public partial class CustomerGroupServiceAgent : WebApiServiceAgentBase<CustomerGroupServiceAgent>, ICustomerGroupServiceAgent
    {
        /// <summary>
        /// Static constructor.
        /// </summary>
        static CustomerGroupServiceAgent()
        {
            Register(() =>
            {
                var rd = WebApiServiceAgentManager.Get<CustomerGroupServiceAgent>();
                return rd == null ? null : new CustomerGroupServiceAgent(rd.Client, rd.BeforeRequest);
            }, false);
        }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerGroupServiceAgent"/> class with a <paramref name="httpClient"/>.
        /// </summary>
        /// <param name="httpClient">The <see cref="HttpClient"/>.</param>
        /// <param name="beforeRequest">The <see cref="Action{HttpRequestMessage}"/> to invoke before the <see cref="HttpRequestMessage">Http Request</see> is made (see <see cref="WebApiServiceAgentBase.BeforeRequest"/>).</param>
        public CustomerGroupServiceAgent(HttpClient httpClient = null, Action<HttpRequestMessage> beforeRequest = null) : base(httpClient, beforeRequest) { }

        /// <summary>
        /// Gets the <see cref="CustomerGroup"/> object that matches the selection criteria.
        /// </summary>
        /// <param name="id">The <see cref="CustomerGroup"/> identifier.</param>
        /// <param name="company">The Company (see <see cref="RefDataNamespace.Company"/>).</param>
        /// <param name="requestOptions">The optional <see cref="WebApiRequestOptions"/>.</param>
        /// <returns>A <see cref="WebApiAgentResult"/>.</returns>
        public Task<WebApiAgentResult<CustomerGroup>> GetAsync(string id, RefDataNamespace.Company company, WebApiRequestOptions requestOptions = null)
        {
            return base.GetAsync<CustomerGroup>("api/v1/customergroups/{company}/{id}", requestOptions: requestOptions,
                args: new WebApiArg[] { new WebApiArg<string>("id", id), new WebApiArg<RefDataNamespace.Company>("company", company) });
        }

        /// <summary>
        /// Gets the <see cref="CustomerGroup"/> collection object that matches the selection criteria.
        /// </summary>
        /// <param name="args">The Args (see <see cref="CustomerGroupArgs"/>).</param>
        /// <param name="paging">The <see cref="PagingArgs"/>.</param>
        /// <param name="requestOptions">The optional <see cref="WebApiRequestOptions"/>.</param>
        /// <returns>A <see cref="WebApiAgentResult"/>.</returns>
        public Task<WebApiAgentResult<CustomerGroupCollectionResult>> GetByArgsAsync(CustomerGroupArgs args, PagingArgs paging = null, WebApiRequestOptions requestOptions = null)
        {
            return base.GetCollectionResultAsync<CustomerGroupCollectionResult, CustomerGroupCollection, CustomerGroup>("api/v1/customergroups", requestOptions: requestOptions,
                args: new WebApiArg[] { new WebApiArg<CustomerGroupArgs>("args", args, WebApiArgType.FromUriUseProperties), new WebApiPagingArgsArg("paging", paging) });
        }

        /// <summary>
        /// Creates the <see cref="CustomerGroup"/> object.
        /// </summary>
        /// <param name="value">The <see cref="CustomerGroup"/> object.</param>
        /// <param name="company">The Company (see <see cref="RefDataNamespace.Company"/>).</param>
        /// <param name="requestOptions">The optional <see cref="WebApiRequestOptions"/>.</param>
        /// <returns>A <see cref="WebApiAgentResult"/>.</returns>
        public Task<WebApiAgentResult<CustomerGroup>> CreateAsync(CustomerGroup value, RefDataNamespace.Company company, WebApiRequestOptions requestOptions = null)
        {
            if (value == null)
                throw new ArgumentNullException("value");

            return base.PostAsync<CustomerGroup>("api/v1/customergroups/{company}", value, requestOptions: requestOptions,
                args: new WebApiArg[] { new WebApiArg<RefDataNamespace.Company>("company", company) });
        }

        /// <summary>
        /// Updates the <see cref="CustomerGroup"/> object.
        /// </summary>
        /// <param name="value">The <see cref="CustomerGroup"/> object.</param>
        /// <param name="id">The <see cref="CustomerGroup"/> identifier.</param>
        /// <param name="company">The Company (see <see cref="RefDataNamespace.Company"/>).</param>
        /// <param name="requestOptions">The optional <see cref="WebApiRequestOptions"/>.</param>
        /// <returns>A <see cref="WebApiAgentResult"/>.</returns>
        public Task<WebApiAgentResult<CustomerGroup>> UpdateAsync(CustomerGroup value, string id, RefDataNamespace.Company company, WebApiRequestOptions requestOptions = null)
        {
            if (value == null)
                throw new ArgumentNullException("value");

            return base.PutAsync<CustomerGroup>("api/v1/customergroups/{company}/{id}", value, requestOptions: requestOptions,
                args: new WebApiArg[] { new WebApiArg<string>("id", id), new WebApiArg<RefDataNamespace.Company>("company", company) });
        }

        /// <summary>
        /// Upserts a <see cref="CustomerGroupCollection"/> as a batch.
        /// </summary>
        /// <param name="value">The Value (see <see cref="CustomerGroupCollection"/>).</param>
        /// <param name="company">The Company (see <see cref="RefDataNamespace.Company"/>).</param>
        /// <param name="requestOptions">The optional <see cref="WebApiRequestOptions"/>.</param>
        /// <returns>A <see cref="WebApiAgentResult"/>.</returns>
        public Task<WebApiAgentResult> UpdateBatchAsync(CustomerGroupCollection value, RefDataNamespace.Company company, WebApiRequestOptions requestOptions = null)
        {
            return base.PutAsync("api/v1/customergroups/{company}", requestOptions: requestOptions,
                args: new WebApiArg[] { new WebApiArg<CustomerGroupCollection>("value", value), new WebApiArg<RefDataNamespace.Company>("company", company) });
        }

        /// <summary>
        /// Deletes the <see cref="CustomerGroup"/> object that matches the selection criteria.
        /// </summary>
        /// <param name="id">The <see cref="CustomerGroup"/> identifier.</param>
        /// <param name="company">The Company (see <see cref="RefDataNamespace.Company"/>).</param>
        /// <param name="requestOptions">The optional <see cref="WebApiRequestOptions"/>.</param>
        /// <returns>A <see cref="WebApiAgentResult"/>.</returns>
        public Task<WebApiAgentResult> DeleteAsync(string id, RefDataNamespace.Company company, WebApiRequestOptions requestOptions = null)
        {
            return base.DeleteAsync("api/v1/customergroups/{company}/{id}", requestOptions: requestOptions,
                args: new WebApiArg[] { new WebApiArg<string>("id", id), new WebApiArg<RefDataNamespace.Company>("company", company) });
        }
    }
}