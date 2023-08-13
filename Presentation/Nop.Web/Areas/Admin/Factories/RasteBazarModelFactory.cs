using Nop.Core.Domain.RasteBazars;
using Nop.Web.Areas.Admin.Models.Catalog;
using System.Threading.Tasks;

namespace Nop.Web.Areas.Admin.Factories
{
    public class RasteBazarModelFactory : IRasteBazarModelFactory
    {
        public Task<CategoryListModel> PrepareRasteBazarListModelAsync(RasteBazarSearchModel searchModel)
        {
            throw new System.NotImplementedException();
        }

        public Task<RasteBazarModel> PrepareRasteBazarModelAsync(RasteBazarModel model, RasteBazar rasteBazar, bool excludeProperties = false)
        {
            throw new System.NotImplementedException();
        }

        public Task<CategorySearchModel> PrepareRasteBazarSearchModelAsync(RasteBazarSearchModel searchModel)
        {
            throw new System.NotImplementedException();
        }
    }
}
