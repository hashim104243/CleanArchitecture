using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Application.Feature.Product.UpdateProduct
{
    public class UpdateProductRequest : IRequest<bool>
    {
        public readonly Domain.Entity.Product product;

        public UpdateProductRequest(Domain.Entity.Product product)
        {
            this.product = product;
        }

       

    }
}
