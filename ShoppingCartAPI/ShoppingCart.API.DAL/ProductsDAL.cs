using AutoMapper;
using ShoppingCartAPI.Models;
using ShoppingCartAPI.ShoppingCart.API.DTO;
using System;
using System.Threading.Tasks;

namespace ShoppingCartAPI.ShoppingCart.API.DAL
{


    public class ProductsDAL : IProductsDAL
    {
        protected readonly MyShopContext _context;
        public IMapper _mapper;
        public ProductsDAL(MyShopContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;

        }
        public async Task<Product> AddProduct(Product_DTO product)
        {
            try
            {
                var productEntity = _mapper.Map<Product>(product);
                await _context.Product.AddAsync(productEntity);
                _context.SaveChanges();
                return productEntity;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
