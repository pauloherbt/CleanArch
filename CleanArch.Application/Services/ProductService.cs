using AutoMapper;
using CleanArch.Application.Interfaces;
using CleanArch.Application.ViewModels;
using CleanArch.Domain.Entities;
using CleanArch.Domain.Interfaces;

namespace CleanArch.Application.Services
{
    public class ProductService : IProductService
    {
        private IProductRepository repository;
        private readonly IMapper mapper;
        public ProductService(IProductRepository rep, IMapper mapper) {
            this.repository = rep;
            this.mapper = mapper;
        }
        public void Add(ProductViewModel product)
        {
            var mapped = mapper.Map<Product>(product);
            repository.addProduct(mapped);
        }

        public async Task<ProductViewModel> GetById(int id)
        {
            return mapper.Map<ProductViewModel>(await repository.GetProductById(id));
        }

        public async Task<IEnumerable<ProductViewModel>> GetProducts()
        {
            return mapper.Map<IEnumerable<ProductViewModel>>(await repository.GetProducts());
        }

        public void Remove(int id)
        {
            var product = repository.GetProductById(id).Result;
            repository.DeleteProduct(product);
        }

        public void Update(ProductViewModel product)
        {
            repository.UpdateProduct(mapper.Map<Product>(product));
        }
    }
}
