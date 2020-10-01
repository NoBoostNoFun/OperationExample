using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Models.Base;

namespace Domain.Models
{
    [Serializable]
    public class ChangeSection : SectionBase<Change>
    {
        public ChangeSection(IEnumerable<Change> items)
            : base(items) { }

        public static ChangeSection Empty =>
            new ChangeSection(Enumerable.Empty<Change>());
    }
}