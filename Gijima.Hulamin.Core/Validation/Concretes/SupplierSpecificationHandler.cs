using Gijima.Hulamin.Core.Entities;
using Gijima.Hulamin.Core.Exceptions;
using Gijima.Hulamin.Core.Validation.Abstracts;

namespace Gijima.Hulamin.Core.Validation.Concretes
{
    public class SupplierSpecificationHandler : SpecificationHandler
    {
        public SupplierSpecificationHandler(SpecificationHandler specificationHandlerSuccessor) 
            : base(specificationHandlerSuccessor)
        {
        }

        public override void HandleSpecificationRequest(IEntity entity)
        {
            if (entity is Supplier supplierEntity)
            {
                if (new EntityIdRequiredValidSpecification<Supplier>().And(new EntityNameRequiredSpecification<Supplier>()).IsSatisfiedBy(supplierEntity))
                {
                    // TODO: Log this as : SupplierSpecificationHandler handles entity
                    return;
                }

                throw new BusinessException($"{nameof(SupplierSpecificationHandler)}.{nameof(HandleSpecificationRequest)}: {nameof(BusinessException)} thrown!");
            }

            if (_specificationHandlerSuccessor != null)
                _specificationHandlerSuccessor.HandleSpecificationRequest(entity);
        }
    }
}
