using System;
using Domain.Facade;
using Domain.Models.Base;
using OperationMachine;

namespace Domain.Models
{
    public class Claim : IOperable<ClaimStatus>
    {
        public string Id { get; }
        public DateTime CreationDate { get; }
        public string? Number { get; private set; }
        public string? Department { get; private set; }
        public ClaimStatus Status { get; private set; }
        public string ClaimText { get; }
        public string? Decision { get; private set; }
        public AttachmentSection Attachments { get; }
        public ChangeSection Changes { get; }

        internal Claim(IInitialClaim initialClaim)
        {
            Id = Guid.NewGuid().ToString();
            CreationDate = DateTime.UtcNow;
            Number = "";
            Status = ClaimStatus.Created;
            ClaimText = initialClaim.ClaimText;
            Attachments = new AttachmentSection(initialClaim.Attachments);
            Changes = ChangeSection.Empty;
        }

        internal Claim ApplyChange<T>(ChangeBase<T> change)
        {
            change.ApplyTo(this);
            Changes.Add(change.ToClaimChange());
            return this;
        }

        internal class StatusChange : ChangeBase<ClaimStatus>
        {
            public StatusChange(ClaimStatus value) : base(value) { }
            internal override void ApplyTo(Claim claim) => claim.Status = Value;
        }

        internal class NumberChange : ChangeBase<string>
        {
            public NumberChange(string value) : base(value) { }
            internal override void ApplyTo(Claim claim) => claim.Number = Value;
        }

        internal class DepartmentChange : ChangeBase<string>
        {
            public DepartmentChange(string value) : base(value) { }
            internal override void ApplyTo(Claim claim) => claim.Department = Value;
        }

        internal class DecisionChange : ChangeBase<string>
        {
            public DecisionChange(string value) : base(value) { }
            internal override void ApplyTo(Claim claim) => claim.Decision = Value;
        }
    }
}
