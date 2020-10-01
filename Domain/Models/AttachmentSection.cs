using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Models.Base;

namespace Domain.Models
{
    [Serializable]
    public class AttachmentSection : SectionBase<Attachment>
    {
        public AttachmentSection(IEnumerable<Attachment> items)
            : base(items) { }

        public static AttachmentSection Empty =>
            new AttachmentSection(Enumerable.Empty<Attachment>());
    }
}