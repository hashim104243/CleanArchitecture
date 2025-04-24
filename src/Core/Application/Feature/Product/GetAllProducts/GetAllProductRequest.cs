using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entity;
using MediatR;

namespace Application.Feature.Product.GetAllProducts
{
    public class GetAllProductRequest : IRequest<List<Domain.Entity.Product>>
    {
    }
}
