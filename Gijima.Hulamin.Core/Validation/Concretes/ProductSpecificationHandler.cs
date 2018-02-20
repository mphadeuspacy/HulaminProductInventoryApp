using Gijima.Hulamin.Core.Entities;
using Gijima.Hulamin.Core.Exceptions;
using Gijima.Hulamin.Core.Validation.Abstracts;

namespace Gijima.Hulamin.Core.Validation.Concretes
{
    public class ProductSpecificationHandler : SpecificationHandler
    {
        public ProductSpecificationHandler(SpecificationHandler specificationHandlerSuccessor) 
            : base(specificationHandlerSuccessor)
        {
        }

        public override void HandleSpecificationRequest(IEntity entity)
        {            
            if (entity is Product productEntity)
            {
                if (new EntityIdRequiredValidSpecification<Product>().And(new EntityNameRequiredSpecification<Product>()).IsSatisfiedBy(productEntity))
                {
                    // TODO: Log this as : ProductSpecificationHandler handles entity
                    return;
                }                   

                throw new BusinessException($"{nameof(ProductSpecificationHandler)}.{nameof(HandleSpecificationRequest)}: {nameof(BusinessException)} thrown!");
            }

            if (_specificationHandlerSuccessor != null)
                _specificationHandlerSuccessor.HandleSpecificationRequest(entity);
        }
    }
}
