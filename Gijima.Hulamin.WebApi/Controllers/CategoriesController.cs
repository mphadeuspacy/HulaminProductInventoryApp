using System;
using System.Configuration;
using System.Web.Http;
using Gijima.Hulamin.Core.Entities;
using Gijima.Hulamin.Core.Persistence;
using Gijima.Hulamin.Core.Validation.Abstracts;

namespace Gijima.Hulamin.WebApi.Controllers
{
    public class CategoriesController : ApiController
    {
        private readonly IRepository _categoryRepository;
        private string ConnectionString => ConfigurationManager.AppSettings[nameof(ConnectionString)];

        public CategoriesController(IRepositoryFactory<Category> categoryRepositoryFactory, ISetUpSpecificationHandler specificationHandler)
        {
            _categoryRepository = 
                (categoryRepositoryFactory ?? throw new ArgumentNullException())
                .CreateRepository(specificationHandler ?? throw new ArgumentNullException(), string.IsNullOrWhiteSpace(ConnectionString) == false ? ConnectionString : throw new ArgumentException());
        }

        // GET api/values
        public IHttpActionResult Get()
        {
            var categories = _categoryRepository.GetAll<Category>();

            if (categories == null) return NotFound();

            return Ok(categories);
        }

        // GET api/values/5
        public IHttpActionResult Get(int id)
        {
            var category = _categoryRepository.GetById<Category>(id);

            if (category == null) return NotFound();

            return Ok(category);
        }

        // POST api/values
        public IHttpActionResult Post(Category category)
        {
           return Ok(_categoryRepository.Create(category));
        }

        // PUT api/values/5
        public IHttpActionResult Put(Category category)
        {
            return Ok(_categoryRepository.Update(category));
        }

        // DELETE api/values/5
        public IHttpActionResult Delete(int id)
        {
            return Ok(_categoryRepository.Delete<Category>(id));
        }
    }
}
