using AspTest.DomainClasses.Entities;

namespace AspTest.ServiceLayer.Counties.Contracts;

public interface CountyRepository
{
    Task<List<County>> GetAll();
}