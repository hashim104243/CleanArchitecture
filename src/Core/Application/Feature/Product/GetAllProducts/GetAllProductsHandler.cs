using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;
using MediatR;
using Domain.Entity;
using Application.Repositores;




namespace Application.Feature.Product.GetAllProducts
{

    //private readonly IProductRepositories productRepositories;

    //public GetAllProducts(IProductRepositories productRepositories)
    //{
    //    this.productRepositories = productRepositories;
    //}

    public class GetAllProductsHander : IRequestHandler<GetAllProductRequest, List<Domain.Entity.Product>>
    {
        private readonly IProductRepositories productRepositories;

        public GetAllProductsHander(IProductRepositories productRepositories)
        {
            this.productRepositories = productRepositories;
        }



        public async Task<List<Domain.Entity.Product>> Handle(GetAllProductRequest request, CancellationToken cancellationToken)
        {
            var p = await productRepositories.GetProducts();
            return p;





        }
    }
}


