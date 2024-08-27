using EShopper.WebUI.Dtos.CatalogDtos.CategoryDtos;

namespace EShopper.WebUI.Services.CatalogServices.CategoryServices
{
    public class CategoryService : ICategoryService
    {
        private readonly HttpClient _httpClient;

        public CategoryService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreateCategoryAsync(CreateCategoryDto createCategoryDto)
        {
            await _httpClient.PostAsJsonAsync("categories",createCategoryDto);
        }

        public Task DeleteCategoryAsync(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ResultCategoryDto>> GetAllCategoriesAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<ResultCategoryDto>>("categories");
        }

        public Task<ResultCategoryDto> GetCategoryByIdAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateCategoryAsync(UpdateCategoryDto updateCategoryDto)
        {
            throw new NotImplementedException();
        }
    }
}
