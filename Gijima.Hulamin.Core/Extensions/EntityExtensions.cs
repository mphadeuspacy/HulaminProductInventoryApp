using System.Collections.Generic;
using Gijima.Hulamin.Core.Entities;

namespace Gijima.Hulamin.Core.Extensions
{
    public static class EntityExtensions
    {
        public static Supplier ToSupplier(this IEntity entity)
        {
            return entity as Supplier;
        }
    }
}
