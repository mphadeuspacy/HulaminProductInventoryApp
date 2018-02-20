using Gijima.Hulamin.Core.Entities;
using Gijima.Hulamin.Core.Exceptions;

namespace Gijima.Hulamin.Core.Validation.Abstracts
{
    public abstract class SpecificationHandler
    {
        protected SpecificationHandler _specificationHandlerSuccessor;
       
        public SpecificationHandler(SpecificationHandler specificationHandlerSuccessor)
        {
            _specificationHandlerSuccessor = specificationHandlerSuccessor;
        }
        
        public virtual void HandleSpecificationRequest(IEntity entity)
        {
            if (entity == null) throw new BusinessException($"{nameof(SpecificationHandler)}.{nameof(HandleSpecificationRequest)}: '{nameof(entity)}' {HulaminConsts.CannotBeANull}!"); ;
        }
    }
}
