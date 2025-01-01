using NZWalks.API.Models.Domain;

namespace NZWalks.API.Repositries
{
    public interface IWalkRepository
    {
       Task<Walk> CreateAsync(Walk walk);
       Task<List<Walk>>GetAllAsync();
       Task<Walk?> GetByIdAsync(Guid id);
    }
}
