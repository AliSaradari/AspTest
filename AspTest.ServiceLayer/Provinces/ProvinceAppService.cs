using AspTest.Common.UnitOfWorks;
using AspTest.DomainClasses.Entities;
using AspTest.ServiceLayer.Provinces.Contracts;
using AspTest.ServiceLayer.Provinces.Exceptions;
using AspTest.ViewModels.Provinces;

namespace AspTest.ServiceLayer.Provinces;

public class ProvinceAppService(
    IUnitOfWork unitOfWork,
    ProvinceRepository repository) : ProvinceService
{
    public async Task Add(AddProvinceDto dto)
    {
        await StopIfProvinceWithThisNameIsExist(dto.Name);

        var province = new Province()
        {
            Name = dto.Name
        };
        repository.Add(province);

        await unitOfWork.Complete();
    }

    public async Task Update(int id, UpdateProvinceDto dto)
    {
        var province = repository.FindById(id);
        StopIfProvinceNotFound(province);

        await StopIfProvinceWithThisNameIsExist(dto.Name);

        province!.Name = dto.Name;

        await unitOfWork.Complete();
    }

    public async Task Delete(int id)
    {
        await repository.Delete(id);
    }

    public async Task<List<GetAllProvinceDto>> GetAll()
    {
        return await repository.GetAll();
    }

    public async Task AddRandomProvinces()
    {
        int limit = 10;
        List<Province> generatedProvinces = [];

        for (int i = 0; i <= limit; i++)
        {
            var randomProvince = new Province()
            {
                Name = GenerateRandomName()
            };

            generatedProvinces.Add(randomProvince);
        }

        repository.AddRange(generatedProvinces);
        await unitOfWork.Complete();
    }

    public async Task AddStar(int id)
    {
        var province = repository.FindById(id);

        StopIfProvinceNotFound(province);

        province!.Name += "*";
        await unitOfWork.Complete();
    }

    private async Task StopIfProvinceWithThisNameIsExist(
        string name)
    {
        if (await repository.IsNameDuplicated(name))
        {
            throw new ProvinceNameDuplicatedException();
        }
    }

    private static void StopIfProvinceNotFound(Province? province)
    {
        if (province is null)
        {
            throw new ProvinceNotFoundException();
        }
    }

    private string GenerateRandomName()
    {
        string[] prefixes =
            { "ممد", "گل", "نو", "کهکشان", "پر", "علی", "زرین" };
        string[] suffixes =
            { "شهر", "کوه", "دشت", "آباد", "ستان", "دونی" };

        var random = new Random();
        var prefix = prefixes[random.Next(prefixes.Length)];
        var suffix = suffixes[random.Next(suffixes.Length)];
        return $"{prefix}{suffix}";
    }
}