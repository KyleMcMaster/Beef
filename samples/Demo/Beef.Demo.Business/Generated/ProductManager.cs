/*
 * This file is automatically generated; any changes will be lost. 
 */

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Beef;
using Beef.Business;
using Beef.Entities;
using Beef.Validation;
using Beef.Demo.Common.Entities;
using Beef.Demo.Business.Validation;
using Beef.Demo.Business.DataSvc;
using RefDataNamespace = Beef.Demo.Common.Entities;

namespace Beef.Demo.Business
{
    /// <summary>
    /// Provides the Product business functionality.
    /// </summary>
    public partial class ProductManager : IProductManager
    {
        #region Private

        private Func<int, Task> _getOnPreValidateAsync = null;
        private Action<MultiValidator, int> _getOnValidate = null;
        private Func<int, Task> _getOnBeforeAsync = null;
        private Func<Product, int, Task> _getOnAfterAsync = null;

        private Func<ProductArgs, PagingArgs, Task> _getByArgsOnPreValidateAsync = null;
        private Action<MultiValidator, ProductArgs, PagingArgs> _getByArgsOnValidate = null;
        private Func<ProductArgs, PagingArgs, Task> _getByArgsOnBeforeAsync = null;
        private Func<ProductCollectionResult, ProductArgs, PagingArgs, Task> _getByArgsOnAfterAsync = null;

        #endregion

        /// <summary>
        /// Gets the <see cref="Product"/> object that matches the selection criteria.
        /// </summary>
        /// <param name="id">The <see cref="Product"/> identifier.</param>
        /// <returns>The selected <see cref="Product"/> object where found; otherwise, <c>null</c>.</returns>
        public Task<Product> GetAsync(int id)
        {
            return ManagerInvoker<Product>.Default.InvokeAsync(this, async () =>
            {
                ExecutionContext.Current.OperationType = OperationType.Read;
                EntityBase.CleanUp(id);
                if (_getOnPreValidateAsync != null) await _getOnPreValidateAsync(id);

                MultiValidator.Create()
                    .Add(id.Validate(nameof(id)).Mandatory())
                    .Additional((__mv) => _getOnValidate?.Invoke(__mv, id))
                    .Run().ThrowOnError();

                if (_getOnBeforeAsync != null) await _getOnBeforeAsync(id);
                var __result = await ProductDataSvc.GetAsync(id);
                if (_getOnAfterAsync != null) await _getOnAfterAsync(__result, id);
                Cleaner.Clean(__result);
                return __result;
            });
        }

        /// <summary>
        /// Gets the <see cref="Product"/> collection object that matches the selection criteria.
        /// </summary>
        /// <param name="args">The Args (see <see cref="ProductArgs"/>).</param>
        /// <param name="paging">The <see cref="PagingArgs"/>.</param>
        /// <returns>A <see cref="ProductCollectionResult"/>.</returns>
        public Task<ProductCollectionResult> GetByArgsAsync(ProductArgs args, PagingArgs paging)
        {
            return ManagerInvoker<ProductCollectionResult>.Default.InvokeAsync(this, async () =>
            {
                ExecutionContext.Current.OperationType = OperationType.Read;
                EntityBase.CleanUp(args);
                if (_getByArgsOnPreValidateAsync != null) await _getByArgsOnPreValidateAsync(args, paging);

                MultiValidator.Create()
                    .Add(args.Validate(nameof(args)).Entity(ProductArgsValidator.Default))
                    .Additional((__mv) => _getByArgsOnValidate?.Invoke(__mv, args, paging))
                    .Run().ThrowOnError();

                if (_getByArgsOnBeforeAsync != null) await _getByArgsOnBeforeAsync(args, paging);
                var __result = await ProductDataSvc.GetByArgsAsync(args, paging);
                if (_getByArgsOnAfterAsync != null) await _getByArgsOnAfterAsync(__result, args, paging);
                Cleaner.Clean(__result);
                return __result;
            });
        }
    }
}
