using Gijima.Hulamin.Core.Validation.Abstracts;

namespace Gijima.Hulamin.Core.Validation.Concretes
{
    public class NotSpecification<TEntity> : CompositeSpecification<TEntity>
    {
        private readonly ISpecification<TEntity> _this;

        public NotSpecification(ISpecification<TEntity> other) => _this = other;

        public override bool IsSatisfiedBy(TEntity entityCandidate) => _this.IsSatisfiedBy(entityCandidate) == false;
    }
}
