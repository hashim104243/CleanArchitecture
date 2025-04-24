using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Repositores;
using AutoMapper;
using MediatR;

namespace Application.Feature.Product.UpdateProduct
{
    public class UpdateProductHandler : IRequestHandler<UpdateProductRequest, bool>
    {
        private readonly IProductRepositories productRepositories;
        private readonly IMapper mapper;

        public UpdateProductHandler(IProductRepositories productRepositories ,IMapper mapper)
        {
            this.productRepositories = productRepositories;
            this.mapper = mapper;
        }

        public async Task<bool> Handle(UpdateProductRequest request, CancellationToken cancellationToken)
        {
            var Product = mapper.Map<Domain.Entity.Product>(request.product);
            productRepositories.UpdateProduct(Product);
            return true;
        }
    }
}
