using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entity;
//using Application.Feature.Product.Query;

namespace Application.Repositores
{
    public interface IProductRepositories
    {
       Task<List<Domain.Entity.Product>> GetProducts();
        int CreateProduct(Product product);
        bool DeleteProduct(int id);

        bool UpdateProduct(Product product);

    }
}
