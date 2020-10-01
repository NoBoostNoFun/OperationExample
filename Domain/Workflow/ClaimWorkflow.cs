using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Facade;
using Domain.Models;
using Domain.Workflow.Operations.Common;
using Domain.Workflow.Operations.Infrastructure;
using OperationMachine;

namespace Domain.Workflow
{
    public class ClaimWorkflow
    {
        private Dictionary<OperationType, IClaimOperation> Operations { get; }
        private IClaimRepository Repository { get; }

        public ClaimWorkflow(IEnumerable<IClaimOperation> operations, IClaimRepository repository)
        {
            Repository = repository;
            Operations = operations.ToDictionary(k => k.Type, v => v);
        }

        public async Task<Claim> CreateClaim(IInitialClaim cmd)
        {
            var claim = new Claim(cmd);
            await Repository.SaveAsync(claim);
            return claim;
        }

        public async Task<Claim> Get(string claimId) =>
            await Repository.GetAsync(claimId);

        public async Task<IEnumerable<OperationType>> GetAllowedOperations(string id)
        {
            var claim = await Get(id);
            return Operations
                .Where(w => w.Value.From.Contains(claim.Status))
                .Select(s => s.Key);
        }

        public async Task<Claim> ExecuteOperation(string claimId, OperationType type, CmdBase cmd)
        {
            var claim = await Get(claimId);
            var updatedClaim = await Operations[type].SetCmd(cmd).ApplyTo(claim);
            await Repository.SaveAsync(updatedClaim);
            return updatedClaim;
        }
    }
}
