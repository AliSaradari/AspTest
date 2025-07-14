using AspTest.DataAccess.DbContexts;
using AspTest.DomainClasses.Entities;
using AspTest.ServiceLayer.Counties.Contracts;
using Microsoft.EntityFrameworkCore;

namespace AspTest.DataAccess.Repositories;

public class EFCountyRepository(EFDataContext context) : CountyRepository
{
    public async Task<List<County>> GetAll()
    {
        return await context.Set<County>().ToListAsync();
    }
}