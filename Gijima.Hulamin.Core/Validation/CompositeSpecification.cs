namespace Gijima.Hulamin.Core.Validation
{
    public abstract class CompositeSpecification<TEntity> : ISpecification<TEntity>
    {
        public abstract bool IsSatisfiedBy(TEntity entityCandidate);

        public ISpecification<TEntity> And(ISpecification<TEntity> other) => new AndSpecification<TEntity>(this, other);

        public ISpecification<TEntity> Or(ISpecification<TEntity> other) => new OrSpecification<TEntity>(this, other);       

        public ISpecification<TEntity> Not() => new NotSpecification<TEntity>(this);
    }
}
