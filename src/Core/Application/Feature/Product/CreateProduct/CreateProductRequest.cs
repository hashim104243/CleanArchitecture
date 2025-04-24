using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Application.Feature.Product.CreateProduct
{
    public class CreateProductRequest : IRequest<int>
    {
        public readonly Domain.Entity.Product product;

        public CreateProductRequest(Domain.Entity.Product product)
        {
            this.product = product;
        }

        //public string? Name { get; set; }

        //public string? Description { get; set; }
        //public Decimal Rate { get; set; }
    }
}
