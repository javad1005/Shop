using System.Threading.Tasks;
using Nop.Core.Domain.Catalog;
using Nop.Core.Domain.RasteBazars;
using Nop.Web.Areas.Admin.Models.Catalog;

namespace Nop.Web.Areas.Admin.Factories
{
    /// <summary>
    /// Represents the category model factory
    /// </summary>
    public interface IRasteBazarModelFactory
    {
        /// <summary>
        /// Prepare category search model
        /// </summary>
        /// <param name="searchModel">RasteBazar search model</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the rastebazar search model
        /// </returns>
        Task<CategorySearchModel> PrepareRasteBazarSearchModelAsync(RasteBazarSearchModel searchModel);

        /// <summary>
        /// Prepare paged category list model
        /// </summary>
        /// <param name="searchModel">RasteBazar search model</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the rastebazar list model
        /// </returns>
        Task<CategoryListModel> PrepareRasteBazarListModelAsync(RasteBazarSearchModel searchModel);

        /// <summary>
        /// Prepare category model
        /// </summary>
        /// <param name="model">RasteBazar model</param>
        /// <param name="rasteBazar">RasteBazar</param>
        /// <param name="excludeProperties">Whether to exclude populating of some properties of model</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the category model
        /// </returns>
        Task<RasteBazarModel> PrepareRasteBazarModelAsync(RasteBazarModel model, RasteBazar rasteBazar, bool excludeProperties = false);

        
    }
}
