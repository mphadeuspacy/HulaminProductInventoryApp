using Gijima.Hulamin.Core.Entities;
using Gijima.Hulamin.Core.Validation.Abstracts;

namespace Gijima.Hulamin.Core.Validation.Concretes
{
    public class EntityIdRequiredValidSpecification<TEntity> : CompositeSpecification<TEntity>
    {
        public override bool IsSatisfiedBy(TEntity entityCandidate)
        {
            if( entityCandidate is IEntity entity) return entity.Id > default(int);

            return false;
        }
    }
}
