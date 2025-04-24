using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Repositores;
using AutoMapper;
using Domain.Entity;
using MediatR;

namespace Application.Feature.Product.CreateProduct
{
    public class CreateproductHandler : IRequestHandler<CreateProductRequest, int>
    {
        private readonly IProductRepositories productRepositories;
        private readonly IMapper mapper;

        public CreateproductHandler(IProductRepositories productRepositories, IMapper mapper )
        {
            this.productRepositories = productRepositories;
            this.mapper = mapper;
        }

        public async Task<int> Handle(CreateProductRequest request, CancellationToken cancellationToken)
        {
            var product =mapper.Map<Domain.Entity.Product>(request.product);
         
            var a = productRepositories.CreateProduct(request.product);

            return a;
        }
    }
}
