using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Repositores;
using Domain.Entity;
using Persistance.Context;

namespace Infrastructure.Repositories
{
    public class ProductRepositories : IProductRepositories
    {
        private readonly ApplicationDbContext applicationDbContext;

        public ProductRepositories(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }

        public int CreateProduct(Product product)
        {
            var p = new Domain.Entity.Product();
            
            p.Name = "ali";
            p.Description = "hdhfakdsjfh kjadshf lkjah dfkljadshfkljasdfh";
            p.Rate = 1000;
            var d = applicationDbContext.Products.AddAsync(product);
            applicationDbContext.SaveChanges();
            return 1;
        }

        public bool DeleteProduct(int id)
        {
            var product = applicationDbContext.Products.Where(x=>x.Id== id).FirstOrDefault();
            if (product != null)
            {
                applicationDbContext.Remove(product);
                applicationDbContext.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }


        public bool UpdateProduct(Product product)
        {
            var p = applicationDbContext.Products.Where(x=>x.Id==product.Id).FirstOrDefault();
            if (product != null)
            {
                //p.Name = product.Name;
                //p.Rate = product.Rate;
                //p.Description = product.Description;

                applicationDbContext.Update(product);
                applicationDbContext.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<List<Product>> GetProducts()
        {
            //var products = new List<Product>();

            //for (int i = 0; i < 50; i++)
            //{
            //    var p = new Product();
            //    p.Name="kdjafnak";
            //    p.Description = "akjlsdfhlakdfsjhia";
            //        p.Rate = 100+1;
            //    products.Add(p);
            //}
            var data = applicationDbContext.Products.ToList();
            return data;
        }
    }
}
