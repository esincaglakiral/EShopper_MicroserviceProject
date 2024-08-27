using EShopper.WebUI.Dtos.CatalogDtos.CategoryDtos;

namespace EShopper.WebUI.Services.CatalogServices.CategoryServices
{
    public interface ICategoryService
    {
        Task<List<ResultCategoryDto>> GetAllCategoriesAsync();
        Task<ResultCategoryDto> GetCategoryByIdAsync(string id);

        Task UpdateCategoryAsync(UpdateCategoryDto updateCategoryDto);
        Task CreateCategoryAsync(CreateCategoryDto createCategoryDto);
        Task DeleteCategoryAsync(string id);
    }
}
