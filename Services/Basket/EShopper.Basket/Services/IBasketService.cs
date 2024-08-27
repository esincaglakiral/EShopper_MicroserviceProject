using EShopper.Basket.Dtos;

namespace EShopper.Basket.Services
{
    public interface IBasketService
    {
        Task<TotalBasketDto> GetBasketAsync(string userId);  // herkes kendi kullanıcı id sine göre sepet değerlerini getireilmsi için string userId
        Task SaveBasketAsync(TotalBasketDto basket); //septe ürün ekledikçe kaydedecek
        Task DeleteBasketAsync(string userId); //Kullanıcının idsine göre silme işlemi yapacak
    }
}
