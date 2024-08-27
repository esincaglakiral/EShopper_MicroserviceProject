using EShopper.WebUI.Services.CatalogServices.CategoryServices;
using Microsoft.AspNetCore.Mvc;

namespace EShopper.WebUI.ViewComponents.Default
{
    public class _DefaultCategoryComponent : ViewComponent
    {
        private readonly ICategoryService _categoryService;

        public _DefaultCategoryComponent(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _categoryService.GetAllCategoriesAsync();
            return View(values);
        }
    }
}
