using EShopper.WebUI.Services.CatalogServices.ProductServices;
using Microsoft.AspNetCore.Mvc;

namespace EShopper.WebUI.ViewComponents.Default
{
    public class _DefaultProductComponent : ViewComponent
    {
        private readonly IProductService _productService;

        public _DefaultProductComponent(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _productService.GetAllProductsAsync();
            return View(values);
        }

    }
}
