using CoreDdd.Queries;
using Eshop.Dtos;
using NHibernate;

namespace Eshop.Queries
{
    public class ProductDetailsQueryHandler : BaseQueryOverHandler<ProductDetailsQuery>
    {
        public override IQueryOver GetQueryOver<TResult>(ProductDetailsQuery query)
        {
            return Session.QueryOver<ProductDto>().Where(x => x.Id == query.ProductId);                          
        }
    }
}