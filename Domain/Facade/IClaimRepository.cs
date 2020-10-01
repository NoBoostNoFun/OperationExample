using System.Threading.Tasks;
using Domain.Models;

namespace Domain.Facade
{
    public interface IClaimRepository
    {
        Task<Claim> GetAsync<TKey>(TKey id);
        Task SaveAsync(Claim claim);
    }
}
