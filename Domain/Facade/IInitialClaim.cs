using Domain.Models;

namespace Domain.Facade
{
    public interface IInitialClaim
    {
        public string ClaimText { get; }
        public Attachment[] Attachments { get; }
    }
}