/*
 * This file is automatically generated; any changes will be lost. 
 */

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Beef;
using Beef.Entities;
using Beef.Demo.Common.Entities;
using RefDataNamespace = Beef.Demo.Common.Entities;

namespace Beef.Demo.Business.Data
{
    /// <summary>
    /// Defines the Customer group data access.
    /// </summary>
    public partial interface ICustomerGroupData
    {
        /// <summary>
        /// Gets the <see cref="CustomerGroup"/> object that matches the selection criteria.
        /// </summary>
        /// <param name="id">The <see cref="CustomerGroup"/> identifier.</param>
        /// <param name="company">The Company (see <see cref="RefDataNamespace.Company"/>).</param>
        /// <returns>The selected <see cref="CustomerGroup"/> object where found; otherwise, <c>null</c>.</returns>
        Task<CustomerGroup> GetAsync(string id, RefDataNamespace.Company company);

        /// <summary>
        /// Gets the <see cref="CustomerGroup"/> collection object that matches the selection criteria.
        /// </summary>
        /// <param name="args">The Args (see <see cref="CustomerGroupArgs"/>).</param>
        /// <param name="paging">The <see cref="PagingArgs"/>.</param>
        /// <returns>A <see cref="CustomerGroupCollectionResult"/>.</returns>
        Task<CustomerGroupCollectionResult> GetByArgsAsync(CustomerGroupArgs args, PagingArgs paging);

        /// <summary>
        /// Creates the <see cref="CustomerGroup"/> object.
        /// </summary>
        /// <param name="value">The <see cref="CustomerGroup"/> object.</param>
        /// <returns>A refreshed <see cref="CustomerGroup"/> object.</returns>
        Task<CustomerGroup> CreateAsync(CustomerGroup value);

        /// <summary>
        /// Updates the <see cref="CustomerGroup"/> object.
        /// </summary>
        /// <param name="value">The <see cref="CustomerGroup"/> object.</param>
        /// <returns>A refreshed <see cref="CustomerGroup"/> object.</returns>
        Task<CustomerGroup> UpdateAsync(CustomerGroup value);

        /// <summary>
        /// Upserts a <see cref="CustomerGroupCollection"/> as a batch.
        /// </summary>
        /// <param name="value">The Value (see <see cref="CustomerGroupCollection"/>).</param>
        Task UpdateBatchAsync(CustomerGroupCollection value);

        /// <summary>
        /// Deletes the <see cref="CustomerGroup"/> object that matches the selection criteria.
        /// </summary>
        /// <param name="id">The <see cref="CustomerGroup"/> identifier.</param>
        /// <param name="company">The Company (see <see cref="RefDataNamespace.Company"/>).</param>
        Task DeleteAsync(string id, RefDataNamespace.Company company);
    }
}
