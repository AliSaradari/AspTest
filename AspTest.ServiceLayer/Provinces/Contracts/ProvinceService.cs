using AspTest.ViewModels.Provinces;

namespace AspTest.ServiceLayer.Provinces.Contracts;

public interface ProvinceService
{
    Task Add(AddProvinceDto dto);
    Task Update(int id, UpdateProvinceDto dto);
    Task Delete(int id);
    Task<List<GetAllProvinceDto>> GetAll();
    Task AddRandomProvinces();
    Task AddStar(int id);
}