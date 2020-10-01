using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Models;
using Domain.Workflow;
using Domain.Workflow.Operations.Common;
using Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using OperationMachine;

namespace WebApp
{
    [ApiController]
    [Route("claims")]
    public class ClaimController
    {
        [HttpPost, Route("")]
        public async Task<Claim> Create(InitialClaim cmd, [FromServices] ClaimWorkflow claimWorkflow) =>
            await claimWorkflow.CreateClaim(cmd);


        [HttpGet, Route("{claimId}")]
        public async Task<Claim> Get(string claimId, [FromServices] ClaimWorkflow claimWorkflow) =>
            await claimWorkflow.Get(claimId);


        [HttpGet, Route("{claimId}/operations")]
        public async Task<IEnumerable<string>> GetOperations(string claimId, [FromServices] ClaimWorkflow claimWorkflow) =>
            (await claimWorkflow.GetAllowedOperations(claimId))
            .Select(s => s.GetDescription());


        [HttpPatch, Route("{claimId}/operations/{type}")]
        public async Task<object> ExecuteOperation(
            string claimId,
            OperationType type,
            [FromBody] JToken commandJToken,
            [FromServices] ClaimWorkflow claimWorkflow)
        {
            var cmdType = type.GetCommandClassType();
            var cmd = (CmdBase)JsonSerializer
                .Create()
                .Deserialize(commandJToken.CreateReader(), cmdType) ??
                      throw new Exception();
            return await claimWorkflow.ExecuteOperation(claimId, type, cmd);
        }
    }
}
