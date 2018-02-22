namespace Gijima.Hulamin.Core.Validation
{
    public class NotSpecification<TEntity> : CompositeSpecification<TEntity>
    {
        private ISpecification<TEntity> _other;

        public NotSpecification(ISpecification<TEntity> other) => _other = other;

        public override bool IsSatisfiedBy(TEntity entityCandidate) => _other.IsSatisfiedBy(entityCandidate) == false;
    }
}
