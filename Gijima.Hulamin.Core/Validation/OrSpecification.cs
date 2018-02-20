namespace Gijima.Hulamin.Core.Validation
{
    public class OrSpecification<TEntity> : CompositeSpecification<TEntity>
    {
        private ISpecification<TEntity> _left;
        private ISpecification<TEntity> _right;

        public OrSpecification(ISpecification<TEntity> left, ISpecification<TEntity> right)
        {
            _left = left;
            _right = right;
        }

        public override bool IsSatisfiedBy(TEntity entityCandidate)
        => _left.IsSatisfiedBy(entityCandidate) || _right.IsSatisfiedBy(entityCandidate);
    }
}
