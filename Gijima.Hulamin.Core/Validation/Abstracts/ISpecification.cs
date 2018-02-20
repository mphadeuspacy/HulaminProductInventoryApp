namespace Gijima.Hulamin.Core.Validation.Abstracts
{
    public interface ISpecification<TEntity>
    {
        bool IsSatisfiedBy(TEntity entityCandidate);
        ISpecification<TEntity> And(ISpecification<TEntity> other);
        ISpecification<TEntity> Or(ISpecification<TEntity> other);
        ISpecification<TEntity> Not();
    }
}
