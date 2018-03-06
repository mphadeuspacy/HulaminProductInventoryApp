using Gijima.Hulamin.Core.Entities;
using Gijima.Hulamin.Core.Exceptions;

namespace Gijima.Hulamin.Core.Validation.Abstracts
{
    public abstract class SpecificationHandler
    {
        protected readonly SpecificationHandler _specificationHandlerSuccessor;

        protected SpecificationHandler(SpecificationHandler specificationHandlerSuccessor)
        {
            _specificationHandlerSuccessor = specificationHandlerSuccessor;
        }
        
        public virtual void HandleSpecificationRequest(IEntity entity)
        {
            if (entity == null) throw new BusinessException($"{nameof(SpecificationHandler)}.{nameof(HandleSpecificationRequest)}: '{nameof(entity)}' {HulaminConsts.CannotBeANull}!"); ;
        }
    }
}
