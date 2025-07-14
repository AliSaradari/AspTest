using AspTest.Common.UnitOfWorks;
using AspTest.ServiceLayer.Counties.Contracts;

namespace AspTest.ServiceLayer.Counties;

public class CountyAppService(
    IUnitOfWork unitOfWork,
    CountyRepository repository) : CountyService
{
    public async Task AddStarToStartOfAllCountiesName()
    {
        var counties = await repository.GetAll();

        foreach (var county in counties)
        {
            county.Name = "*" + county.Name;
        }

        await unitOfWork.Complete();
    }
}