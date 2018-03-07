using System.Web.Http;
using Gijima.Hulamin.Core.DomainServices;
using Gijima.Hulamin.Core.Entities;

namespace Gijima.Hulamin.WebApi.Controllers
{
    public class SuppliersController : ApiController
    {
        private readonly ISupplierService _supplierService;

        public SuppliersController()
        {
            _supplierService = new SupplierService();
        }

        // GET api/Suppliers
        public IHttpActionResult Get()
        {
            var suppliers = _supplierService.GetAllSuppliers();

            if (suppliers == null) return NotFound();

            return Ok(suppliers);
        }

        // GET api/Suppliers/5
        public IHttpActionResult Get(int id)
        {
            var supplier = _supplierService.GetSupplierById(id);

            if (supplier == null) return NotFound();

            return Ok(supplier);
        }

        // POST api/Suppliers
        public IHttpActionResult Post(Supplier supplier)
        {
            return Ok(_supplierService.CreateSupplier(supplier));
        }

        // PUT api/Suppliers/5
        public IHttpActionResult Put(Supplier supplier)
        {
            return Ok(_supplierService.UpdateSupplier(supplier));
        }

        // DELETE api/Suppliers/5
        public IHttpActionResult Delete(int id)
        {
            return Ok(_supplierService.DeleteSupplier(id));
        }
    }
}
