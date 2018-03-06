using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using Gijima.Hulamin.Core.Entities;
using Gijima.Hulamin.Core.Persistence;
using Gijima.Hulamin.Core.Validation.Abstracts;
using Gijima.Hulamin.Core.Validation.Concretes;

namespace Gijima.Hulamin.Core.DomainServices
{
    public interface ISupplierService
    {
        int CreateSupplier(Supplier supplier);
        List<Supplier> GetAllSuppliers();

        Supplier GetSupplierById(int studentId);

        int UpdateSupplier(Supplier supplier);

        int DeleteSupplier(int studentId);
    }

    public class SupplierService : ISupplierService
    {
        private readonly IRepository _supplierRepository;
        private string ConnectionString => ConfigurationManager.AppSettings[nameof(ConnectionString)];


        public SupplierService()
        {
            _supplierRepository = new RepositoryFactory<Supplier>().CreateRepository(new StandardSetUpSpecificationHandler(), ConnectionString);
        }
        public SupplierService(IRepositoryFactory<Supplier> supplierRepositoryFactory, ISetUpSpecificationHandler specificationHandler)
        {
            _supplierRepository =
                (supplierRepositoryFactory ?? throw new ArgumentNullException())
                .CreateRepository(specificationHandler ?? throw new ArgumentNullException(), string.IsNullOrWhiteSpace(ConnectionString) == false ? ConnectionString : throw new ArgumentException());
        }

        public int CreateSupplier(Supplier supplier)
        {
            return _supplierRepository.Create(supplier);
        }

        public List<Supplier> GetAllSuppliers()
        {
           return _supplierRepository.GetAll<Supplier>().Select(supplier => (Supplier)supplier).ToList();
        }

        public Supplier GetSupplierById(int studentId)
        {
            return (Supplier)_supplierRepository.GetById<Supplier>(studentId);
        }

        public int UpdateSupplier(Supplier supplier)
        {
            return _supplierRepository.Update(supplier);
        }

        public int DeleteSupplier(int studentId)
        {
            return _supplierRepository.Delete<Category>(studentId);
        }
    }

   
}
