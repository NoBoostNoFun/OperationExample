using System;
using Domain.Facade;
using Domain.Models;

namespace WebApp
{
    [Serializable]
    public class InitialClaim : IInitialClaim
    {
        public string ClaimText { get; set; } = default!;
        public Attachment[] Attachments { get; set; } = default!;
    }
}