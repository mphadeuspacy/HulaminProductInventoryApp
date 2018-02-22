namespace Gijima.Hulamin.Core.Validation
{
    public class AndSpecification<TEntity> : CompositeSpecification<TEntity>
    {
        private ISpecification<TEntity> _left;
        private ISpecification<TEntity> _right;

        public AndSpecification(ISpecification<TEntity> left, ISpecification<TEntity> right)
        {
            _left = left;
            _right = right;
        }

        public override bool IsSatisfiedBy(TEntity entityCandidate) => _left.IsSatisfiedBy(entityCandidate) && _right.IsSatisfiedBy(entityCandidate);
    }
}
