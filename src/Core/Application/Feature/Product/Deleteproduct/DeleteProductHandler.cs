using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Repositores;
using MediatR;

namespace Application.Feature.Product.Deleteproduct
{
    public class DeleteProductHandler : IRequestHandler<DeleteProductRequest, bool>
    {
        private readonly IProductRepositories productRepositories;

        public DeleteProductHandler(IProductRepositories productRepositories)
        {
            this.productRepositories = productRepositories;
        }

        public async Task<bool> Handle(DeleteProductRequest request, CancellationToken cancellationToken)
        {
            var item= productRepositories.DeleteProduct(request.Id);
                return true;
        }
    }
}
