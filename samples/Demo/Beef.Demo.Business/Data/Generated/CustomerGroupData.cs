/*
 * This file is automatically generated; any changes will be lost. 
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Beef;
using Beef.Business;
using Beef.Data.OData;
using Beef.Entities;
using Beef.Mapper;
using Beef.Mapper.Converters;
using Beef.Demo.Common.Entities;
using RefDataNamespace = Beef.Demo.Common.Entities;

namespace Beef.Demo.Business.Data
{
    /// <summary>
    /// Provides the Customer group data access.
    /// </summary>
    public partial class CustomerGroupData : ICustomerGroupData
    {
        #region Private

        private Func<string, RefDataNamespace.Company, IODataArgs, Task> _getOnBeforeAsync = null;
        private Func<CustomerGroup, string, RefDataNamespace.Company, Task> _getOnAfterAsync = null;
        private Action<Exception> _getOnException = null;

        private Func<IQueryable<CustomerGroup>, CustomerGroupArgs, IODataArgs, IQueryable<CustomerGroup>> _getByArgsOnQuery = null;
        private Func<CustomerGroupArgs, IODataArgs, Task> _getByArgsOnBeforeAsync = null;
        private Func<CustomerGroupCollectionResult, CustomerGroupArgs, Task> _getByArgsOnAfterAsync = null;
        private Action<Exception> _getByArgsOnException = null;

        private Func<CustomerGroup, IODataArgs, Task> _createOnBeforeAsync = null;
        private Func<CustomerGroup, Task> _createOnAfterAsync = null;
        private Action<Exception> _createOnException = null;

        private Func<CustomerGroup, IODataArgs, Task> _updateOnBeforeAsync = null;
        private Func<CustomerGroup, Task> _updateOnAfterAsync = null;
        private Action<Exception> _updateOnException = null;

        private Action<Exception> _updateBatchOnException = null;

        private Func<string, RefDataNamespace.Company, IODataArgs, Task> _deleteOnBeforeAsync = null;
        private Func<string, RefDataNamespace.Company, Task> _deleteOnAfterAsync = null;
        private Action<Exception> _deleteOnException = null;

        #endregion

        /// <summary>
        /// Gets the <see cref="CustomerGroup"/> object that matches the selection criteria.
        /// </summary>
        /// <param name="id">The <see cref="CustomerGroup"/> identifier.</param>
        /// <param name="company">The Company (see <see cref="RefDataNamespace.Company"/>).</param>
        /// <returns>The selected <see cref="CustomerGroup"/> object where found; otherwise, <c>null</c>.</returns>
        public Task<CustomerGroup> GetAsync(string id, RefDataNamespace.Company company)
        {
            return DataInvoker<CustomerGroup>.Default.InvokeAsync(this, async () =>
            {
                CustomerGroup __result = null;
                var __dataArgs = ODataMapper.Default.CreateArgs();
                if (_getOnBeforeAsync != null) await _getOnBeforeAsync(id, company, __dataArgs);
                __result = await DynamicsAx.Default.GetAsync<CustomerGroup>(__dataArgs, id, ExternalCodeConverter<RefDataNamespace.Company>.Default.ConvertToDest(company));
                if (_getOnAfterAsync != null) await _getOnAfterAsync(__result, id, company);
                return __result;
            }, new BusinessInvokerArgs { ExceptionHandler = _getOnException });
        }

        /// <summary>
        /// Gets the <see cref="CustomerGroup"/> collection object that matches the selection criteria.
        /// </summary>
        /// <param name="args">The Args (see <see cref="CustomerGroupArgs"/>).</param>
        /// <param name="paging">The <see cref="PagingArgs"/>.</param>
        /// <returns>A <see cref="CustomerGroupCollectionResult"/>.</returns>
        public Task<CustomerGroupCollectionResult> GetByArgsAsync(CustomerGroupArgs args, PagingArgs paging)
        {
            return DataInvoker<CustomerGroupCollectionResult>.Default.InvokeAsync(this, async () =>
            {
                CustomerGroupCollectionResult __result = new CustomerGroupCollectionResult(paging);
                var __dataArgs = ODataMapper.Default.CreateArgs(__result.Paging);
                if (_getByArgsOnBeforeAsync != null) await _getByArgsOnBeforeAsync(args, __dataArgs);
                __result = new CustomerGroupCollectionResult(paging);
                __result.Result = await DynamicsAx.Default.SelectQueryAsync<CustomerGroupCollection, CustomerGroup>(__dataArgs,
                    q => _getByArgsOnQuery == null ? q : _getByArgsOnQuery(q, args, __dataArgs));

                if (_getByArgsOnAfterAsync != null) await _getByArgsOnAfterAsync(__result, args);
                return __result;
            }, new BusinessInvokerArgs { ExceptionHandler = _getByArgsOnException });
        }

        /// <summary>
        /// Creates the <see cref="CustomerGroup"/> object.
        /// </summary>
        /// <param name="value">The <see cref="CustomerGroup"/> object.</param>
        /// <returns>A refreshed <see cref="CustomerGroup"/> object.</returns>
        public Task<CustomerGroup> CreateAsync(CustomerGroup value)
        {
            if (value == null)
                throw new ArgumentNullException(nameof(value));

            return DataInvoker<CustomerGroup>.Default.InvokeAsync(this, async () =>
            {
                CustomerGroup __result = null;
                var __dataArgs = ODataMapper.Default.CreateArgs();
                if (_createOnBeforeAsync != null) await _createOnBeforeAsync(value, __dataArgs);
                __result = await DynamicsAx.Default.CreateAsync<CustomerGroup>(__dataArgs, value);
                if (_createOnAfterAsync != null) await _createOnAfterAsync(__result);
                return __result;
            }, new BusinessInvokerArgs { ExceptionHandler = _createOnException });
        }

        /// <summary>
        /// Updates the <see cref="CustomerGroup"/> object.
        /// </summary>
        /// <param name="value">The <see cref="CustomerGroup"/> object.</param>
        /// <returns>A refreshed <see cref="CustomerGroup"/> object.</returns>
        public Task<CustomerGroup> UpdateAsync(CustomerGroup value)
        {
            if (value == null)
                throw new ArgumentNullException(nameof(value));

            return DataInvoker<CustomerGroup>.Default.InvokeAsync(this, async () =>
            {
                CustomerGroup __result = null;
                var __dataArgs = ODataMapper.Default.CreateArgs();
                if (_updateOnBeforeAsync != null) await _updateOnBeforeAsync(value, __dataArgs);
                __result = await DynamicsAx.Default.UpdateAsync<CustomerGroup>(__dataArgs, value);
                if (_updateOnAfterAsync != null) await _updateOnAfterAsync(__result);
                return __result;
            }, new BusinessInvokerArgs { ExceptionHandler = _updateOnException });
        }

        /// <summary>
        /// Upserts a <see cref="CustomerGroupCollection"/> as a batch.
        /// </summary>
        /// <param name="value">The Value (see <see cref="CustomerGroupCollection"/>).</param>
        public Task UpdateBatchAsync(CustomerGroupCollection value)
        {
            return DataInvoker.Default.InvokeAsync(this, () => UpdateBatchOnImplementationAsync(value),
                new BusinessInvokerArgs { ExceptionHandler = _updateBatchOnException });
        }

        /// <summary>
        /// Deletes the <see cref="CustomerGroup"/> object that matches the selection criteria.
        /// </summary>
        /// <param name="id">The <see cref="CustomerGroup"/> identifier.</param>
        /// <param name="company">The Company (see <see cref="RefDataNamespace.Company"/>).</param>
        public Task DeleteAsync(string id, RefDataNamespace.Company company)
        {
            return DataInvoker.Default.InvokeAsync(this, async () =>
            {
                var __dataArgs = ODataMapper.Default.CreateArgs();
                if (_deleteOnBeforeAsync != null) await _deleteOnBeforeAsync(id, company, __dataArgs);
                await DynamicsAx.Default.DeleteAsync<CustomerGroup>(__dataArgs, id, ExternalCodeConverter<RefDataNamespace.Company>.Default.ConvertToDest(company));
                if (_deleteOnAfterAsync != null) await _deleteOnAfterAsync(id, company);
            }, new BusinessInvokerArgs { ExceptionHandler = _deleteOnException });
        }

        /// <summary>
        /// Provides the <see cref="CustomerGroup"/> entity and OData property mapping.
        /// </summary>
        public partial class ODataMapper : ODataMapper<CustomerGroup, ODataMapper>
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="ODataMapper"/> class.
            /// </summary>
            public ODataMapper() : base("CustomerGroups")
            {
                Property(s => s.Id, "CustomerGroupId").SetUniqueKey(false);
                Property(s => s.Company, "dataAreaId").SetUniqueKey(false).SetConverter(ExternalCodeConverter<RefDataNamespace.Company>.Default);
                Property(s => s.Description);
                Property(s => s.IsSalesTaxIncludedInPrice).SetConverter(BooleanToYesNoConverter.Default);
                Property(s => s.TaxGroup, "TaxGroupId");
                ODataMapperCtor();
            }
            
            /// <summary>
            /// Enables the <see cref="ODataMapper"/> constructor to be extended.
            /// </summary>
            partial void ODataMapperCtor();
        }
    }
}
