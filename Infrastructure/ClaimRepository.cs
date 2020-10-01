using System;
using System.Threading.Tasks;
using Domain.Facade;
using Domain.Models;
using Microsoft.Extensions.Caching.Memory;

namespace Infrastructure
{
    public class ClaimRepository : IClaimRepository
    {
        private IMemoryCache Cache { get; }

        public ClaimRepository(IMemoryCache cache) =>
            Cache = cache;

        public Task<Claim> GetAsync<TKey>(TKey id)
        {
            if (Cache.TryGetValue(id, out Claim claim))
                return Task.FromResult(claim);
            throw new Exception(); 
        }

        public Task SaveAsync(Claim claim)
        {
            Cache.Set(claim.Id, claim);
            return Task.CompletedTask;
        }
    }
}