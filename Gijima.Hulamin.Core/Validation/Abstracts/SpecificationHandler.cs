using Gijima.Hulamin.Core.Entities;

namespace Gijima.Hulamin.Core.Validation.Abstracts
{
    public abstract class SpecificationHandler
    {
        protected SpecificationHandler _specificationHandlerSuccessor;
       
        public SpecificationHandler(SpecificationHandler specificationHandlerSuccessor)
        {
            _specificationHandlerSuccessor = specificationHandlerSuccessor;
        }
        
        public abstract void HandleSpecificationRequest(IEntity entity);
    }
}
