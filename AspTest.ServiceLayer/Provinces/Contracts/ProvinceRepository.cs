using AspTest.DomainClasses.Entities;
using AspTest.ViewModels.Provinces;

namespace AspTest.ServiceLayer.Provinces.Contracts;

public interface ProvinceRepository
{
    Task AddRange(List<Province> generatedProvinces);
    Province? FindById(int id);
    Task Add(Province province);
    Task<bool> IsNameDuplicated(string name);
    Task Delete(int id);
    Task<List<GetAllProvinceDto>> GetAll();
}
