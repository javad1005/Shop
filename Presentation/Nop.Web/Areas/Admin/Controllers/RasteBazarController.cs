using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nop.Core;
using Nop.Core.Caching;
using Nop.Core.Domain.Catalog;
using Nop.Core.Domain.Discounts;
using Nop.Services.Catalog;
using Nop.Services.Customers;
using Nop.Services.Discounts;
using Nop.Services.ExportImport;
using Nop.Services.Localization;
using Nop.Services.Logging;
using Nop.Services.Media;
using Nop.Services.Messages;
using Nop.Services.Security;
using Nop.Services.Seo;
using Nop.Services.Stores;
using Nop.Web.Areas.Admin.Factories;
using Nop.Web.Areas.Admin.Infrastructure.Mapper.Extensions;
using Nop.Web.Areas.Admin.Models.Catalog;
using Nop.Web.Framework.Controllers;
using Nop.Web.Framework.Mvc;
using Nop.Web.Framework.Mvc.Filters;
using Nop.Web.Models.Catalog;

namespace Nop.Web.Areas.Admin.Controllers
{
    public partial class RasteBazarController : BaseAdminController
    {
        #region Fields

        private readonly IPermissionService _permissionService;

        #endregion

        #region Ctor

        public RasteBazarController(IPermissionService permissionService)
        {

            _permissionService = permissionService;

        }

        #endregion

        #region Utilities


        #endregion

        #region List


        #endregion

        #region Create / Edit / Delete

        //public virtual async Task<IActionResult> Create()
        //{
        //    if (!await _permissionService.AuthorizeAsync(StandardPermissionProvider.ManageRasteBazar))
        //        return AccessDeniedView();

        //    //prepare model
        //    var model = await _categoryModelFactory.PrepareCategoryModelAsync(new CategoryModel(), null);

        //    return View(model);
        //}

        //[HttpPost, ParameterBasedOnFormName("save-continue", "continueEditing")]
        //public virtual async Task<IActionResult> Create(RasteBazarModel model, bool continueEditing)
        //{
        //    if (!await _permissionService.AuthorizeAsync(StandardPermissionProvider.ManageCategories))
        //        return AccessDeniedView();

        //    if (ModelState.IsValid)
        //    {
        //        var category = model.ToEntity<Category>();
        //        category.CreatedOnUtc = DateTime.UtcNow;
        //        category.UpdatedOnUtc = DateTime.UtcNow;
        //        await _categoryService.InsertCategoryAsync(category);

        //        //search engine name
        //        model.SeName = await _urlRecordService.ValidateSeNameAsync(category, model.SeName, category.Name, true);
        //        await _urlRecordService.SaveSlugAsync(category, model.SeName, 0);

        //        //locales
        //        await UpdateLocalesAsync(category, model);

        //        //discounts
        //        var allDiscounts = await _discountService.GetAllDiscountsAsync(DiscountType.AssignedToCategories, showHidden: true, isActive: null);
        //        foreach (var discount in allDiscounts)
        //        {
        //            if (model.SelectedDiscountIds != null && model.SelectedDiscountIds.Contains(discount.Id))
        //                await _categoryService.InsertDiscountCategoryMappingAsync(new DiscountCategoryMapping { DiscountId = discount.Id, EntityId = category.Id });
        //        }

        //        await _categoryService.UpdateCategoryAsync(category);

        //        //update picture seo file name
        //        await UpdatePictureSeoNamesAsync(category);

        //        //ACL (customer roles)
        //        await SaveCategoryAclAsync(category, model);

        //        //stores
        //        await SaveStoreMappingsAsync(category, model);

        //        //activity log
        //        await _customerActivityService.InsertActivityAsync("AddNewCategory",
        //            string.Format(await _localizationService.GetResourceAsync("ActivityLog.AddNewCategory"), category.Name), category);

        //        _notificationService.SuccessNotification(await _localizationService.GetResourceAsync("Admin.Catalog.Categories.Added"));

        //        if (!continueEditing)
        //            return RedirectToAction("List");

        //        return RedirectToAction("Edit", new { id = category.Id });
        //    }

        //    //prepare model
        //    model = await _categoryModelFactory.PrepareCategoryModelAsync(model, null, true);

        //    //if we got this far, something failed, redisplay form
        //    return View(model);
        //}

        //public virtual async Task<IActionResult> Edit(int id)
        //{
        //    if (!await _permissionService.AuthorizeAsync(StandardPermissionProvider.ManageCategories))
        //        return AccessDeniedView();

        //    //try to get a category with the specified id
        //    var category = await _categoryService.GetCategoryByIdAsync(id);
        //    if (category == null || category.Deleted)
        //        return RedirectToAction("List");

        //    //prepare model
        //    var model = await _categoryModelFactory.PrepareCategoryModelAsync(null, category);

        //    return View(model);
        //}

        //[HttpPost, ParameterBasedOnFormName("save-continue", "continueEditing")]
        //public virtual async Task<IActionResult> Edit(RasteBazarModel model, bool continueEditing)
        //{
        //    if (!await _permissionService.AuthorizeAsync(StandardPermissionProvider.ManageCategories))
        //        return AccessDeniedView();

        //    //try to get a category with the specified id
        //    var category = await _categoryService.GetCategoryByIdAsync(model.Id);
        //    if (category == null || category.Deleted)
        //        return RedirectToAction("List");

        //    if (ModelState.IsValid)
        //    {
        //        var prevPictureId = category.PictureId;

        //        //if parent category changes, we need to clear cache for previous parent category
        //        if (category.ParentCategoryId != model.ParentCategoryId)
        //        {
        //            await _staticCacheManager.RemoveByPrefixAsync(NopCatalogDefaults.CategoriesByParentCategoryPrefix, category.ParentCategoryId);
        //            await _staticCacheManager.RemoveByPrefixAsync(NopCatalogDefaults.CategoriesChildIdsPrefix, category.ParentCategoryId);
        //        }

        //        category = model.ToEntity(category);
        //        category.UpdatedOnUtc = DateTime.UtcNow;
        //        await _categoryService.UpdateCategoryAsync(category);

        //        //search engine name
        //        model.SeName = await _urlRecordService.ValidateSeNameAsync(category, model.SeName, category.Name, true);
        //        await _urlRecordService.SaveSlugAsync(category, model.SeName, 0);

        //        //locales
        //        await UpdateLocalesAsync(category, model);

        //        //discounts
        //        var allDiscounts = await _discountService.GetAllDiscountsAsync(DiscountType.AssignedToCategories, showHidden: true, isActive: null);
        //        foreach (var discount in allDiscounts)
        //        {
        //            if (model.SelectedDiscountIds != null && model.SelectedDiscountIds.Contains(discount.Id))
        //            {
        //                //new discount
        //                if (await _categoryService.GetDiscountAppliedToCategoryAsync(category.Id, discount.Id) is null)
        //                    await _categoryService.InsertDiscountCategoryMappingAsync(new DiscountCategoryMapping { DiscountId = discount.Id, EntityId = category.Id });
        //            }
        //            else
        //            {
        //                //remove discount
        //                if (await _categoryService.GetDiscountAppliedToCategoryAsync(category.Id, discount.Id) is DiscountCategoryMapping mapping)
        //                    await _categoryService.DeleteDiscountCategoryMappingAsync(mapping);
        //            }
        //        }

        //        await _categoryService.UpdateCategoryAsync(category);

        //        //delete an old picture (if deleted or updated)
        //        if (prevPictureId > 0 && prevPictureId != category.PictureId)
        //        {
        //            var prevPicture = await _pictureService.GetPictureByIdAsync(prevPictureId);
        //            if (prevPicture != null)
        //                await _pictureService.DeletePictureAsync(prevPicture);
        //        }

        //        //update picture seo file name
        //        await UpdatePictureSeoNamesAsync(category);

        //        //ACL
        //        await SaveCategoryAclAsync(category, model);

        //        //stores
        //        await SaveStoreMappingsAsync(category, model);

        //        //activity log
        //        await _customerActivityService.InsertActivityAsync("EditCategory",
        //            string.Format(await _localizationService.GetResourceAsync("ActivityLog.EditCategory"), category.Name), category);

        //        _notificationService.SuccessNotification(await _localizationService.GetResourceAsync("Admin.Catalog.Categories.Updated"));

        //        if (!continueEditing)
        //            return RedirectToAction("List");

        //        return RedirectToAction("Edit", new { id = category.Id });
        //    }

        //    //prepare model
        //    model = await _categoryModelFactory.PrepareCategoryModelAsync(model, category, true);

        //    //if we got this far, something failed, redisplay form
        //    return View(model);
        //}

        //[HttpPost]
        //public virtual async Task<IActionResult> Delete(int id)
        //{
        //    if (!await _permissionService.AuthorizeAsync(StandardPermissionProvider.ManageCategories))
        //        return AccessDeniedView();

        //    //try to get a category with the specified id
        //    var category = await _categoryService.GetCategoryByIdAsync(id);
        //    if (category == null)
        //        return RedirectToAction("List");

        //    await _categoryService.DeleteCategoryAsync(category);

        //    //activity log
        //    await _customerActivityService.InsertActivityAsync("DeleteCategory",
        //        string.Format(await _localizationService.GetResourceAsync("ActivityLog.DeleteCategory"), category.Name), category);

        //    _notificationService.SuccessNotification(await _localizationService.GetResourceAsync("Admin.Catalog.Categories.Deleted"));

        //    return RedirectToAction("List");
        //}

        //[HttpPost]
        //public virtual async Task<IActionResult> DeleteSelected(ICollection<int> selectedIds)
        //{
        //    if (!await _permissionService.AuthorizeAsync(StandardPermissionProvider.ManageCategories))
        //        return AccessDeniedView();

        //    if (selectedIds == null || selectedIds.Count == 0)
        //        return NoContent();

        //    await _categoryService.DeleteCategoriesAsync(await (await _categoryService.GetCategoriesByIdsAsync(selectedIds.ToArray())).WhereAwait(async p => await _workContext.GetCurrentVendorAsync() == null).ToListAsync());

        //    return Json(new { Result = true });
        //}

        #endregion

        #region Export / Import



        #endregion

        #region Products



        #endregion
    }
    
}
