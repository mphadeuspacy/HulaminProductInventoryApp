using Gijima.Hulamin.Core.Entities;
using Gijima.Hulamin.Core.Exceptions;
using Gijima.Hulamin.Core.Validation.Abstracts;

namespace Gijima.Hulamin.Core.Validation.Concretes
{
    public sealed class CategorySpecificationHandler : SpecificationHandler
    {
        public CategorySpecificationHandler(SpecificationHandler specificationHandlerSuccessor) 
            : base(specificationHandlerSuccessor)
        {
        }

        public override void HandleSpecificationRequest(IEntity entity)
        {
            base.HandleSpecificationRequest(entity);

            if (entity is Category categoryEntity)
            {
                if (new EntityIdRequiredValidSpecification<Category>().And(new EntityNameRequiredSpecification<Category>()).IsSatisfiedBy(categoryEntity))
                {
                    // TODO: Log this as : CategorySpecificationHandler handles entity
                    return;
                }

                throw new BusinessException($"{nameof(CategorySpecificationHandler)}.{nameof(HandleSpecificationRequest)}: {nameof(BusinessException)} thrown!");
            }

            if (_specificationHandlerSuccessor != null)
                _specificationHandlerSuccessor.HandleSpecificationRequest(entity);
        }
    }
}
