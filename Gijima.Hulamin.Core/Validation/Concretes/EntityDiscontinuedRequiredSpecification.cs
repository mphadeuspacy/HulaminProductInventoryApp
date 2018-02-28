using Gijima.Hulamin.Core.Entities;
using Gijima.Hulamin.Core.Validation.Abstracts;

namespace Gijima.Hulamin.Core.Validation.Concretes
{
    public class EntityDiscontinuedRequiredSpecification<TEntity> : CompositeSpecification<TEntity>
    {
        public override bool IsSatisfiedBy(TEntity entityCandidate)
        {
            if (entityCandidate is Product entity) return entity.Discontinued != null;

            return false;
        }
    }
}
