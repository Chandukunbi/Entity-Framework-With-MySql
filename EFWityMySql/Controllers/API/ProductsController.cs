using EFWityMySql.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EFWityMySql.Controllers.API
{
    public class ProductsController : ApiController
    {
        private static ApplicationDbContext _context;

        public ProductsController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET /api/products
        public IEnumerable<Product> GetProducts()
        {
            return _context.Products.ToList();
        }

        //GET /api/products/idf
        public Product GetProducts(int id)
        {
            return _context.Products.SingleOrDefault(p => p.Id == id);
        }
    }
}
