using System.Collections.Generic;
using System.Linq;

namespace Domain.Models.Base
{
    public abstract class SectionBase<T> where T : class
    {
        protected readonly List<T> Items;

        protected SectionBase(IEnumerable<T> items) =>
            Items = items.ToList();

        public IEnumerable<T> All =>
            Items.AsReadOnly();

        public virtual void Add(T item) =>
            Items.Add(item);
    }
}