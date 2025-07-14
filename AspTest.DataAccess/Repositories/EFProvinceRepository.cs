using AspTest.DataAccess.DbContexts;
using AspTest.DomainClasses.Entities;
using AspTest.ServiceLayer.Provinces.Contracts;
using AspTest.ViewModels.Provinces;
using Microsoft.EntityFrameworkCore;

namespace AspTest.DataAccess.Repositories;

public class EFProvinceRepository(EFDataContext context)
    : ProvinceRepository
{
    public async Task AddRange(List<Province> provinces)
    {
        await context.Set<Province>().AddRangeAsync(provinces);
    }

    public Province? FindById(int id)
    {
        return context.Set<Province>().Find(id);
    }

    public async Task Add(Province province)
    {
        await context.Set<Province>().AddAsync(province);
    }

    public async Task<bool> IsNameDuplicated(string name)
    {
        return await context.Set<Province>().AnyAsync(p => p.Name == name);
    }

    public async Task Delete(int id)
    {
        await context.Set<Province>().Where(p => p.Id == id)
            .ExecuteDeleteAsync();
    }

    public async Task<List<GetAllProvinceDto>> GetAll()
    {
        return await context.Set<Province>().Select(p =>
            new GetAllProvinceDto()
            {
                Id = p.Id,
                Name = p.Name
            }).ToListAsync();
    }
}