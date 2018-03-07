using Gijima.Hulamin.Core.Entities;
using Gijima.Hulamin.Core.Exceptions;
using Gijima.Hulamin.Core.Validation.Abstracts;

namespace Gijima.Hulamin.Core.Validation.Concretes
{
    public sealed class ProductSpecificationHandler : SpecificationHandler
    {
        public ProductSpecificationHandler(SpecificationHandler specificationHandlerSuccessor) 
            : base(specificationHandlerSuccessor)
        {}

        public override void HandleSpecificationRequest(IEntity entity)
        {
            base.HandleSpecificationRequest(entity);

            if (entity is Product productEntity)
            {
                bool productBusinessRulesValid = 
                    new EntityIdRequiredValidSpecification<Product>()
                    .And(new EntityNameRequiredSpecification<Product>())
                    .And(new EntityDiscontinuedRequiredSpecification<Product>())
                    .IsSatisfiedBy(productEntity);

                if (productBusinessRulesValid) return;

                // TODO: Log this as : ProductSpecificationHandler handles entity
                throw new BusinessException($"{nameof(ProductSpecificationHandler)}.{nameof(HandleSpecificationRequest)}: {nameof(BusinessException)} thrown!");
            }

            _specificationHandlerSuccessor?.HandleSpecificationRequest(entity);
        }
    }
}
