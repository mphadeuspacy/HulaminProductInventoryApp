using Gijima.Hulamin.Core.Validation.Abstracts;

namespace Gijima.Hulamin.Core.Validation.Concretes
{
    public class StandardSetUpSpecificationHandler : ISetUpSpecificationHandler
    {
        public SpecificationHandler SetUpChain()
        {
            return new ProductSpecificationHandler(new SupplierSpecificationHandler(new CategorySpecificationHandler(null)));
        }
    }
}
