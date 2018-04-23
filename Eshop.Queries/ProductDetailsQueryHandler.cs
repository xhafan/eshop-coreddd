using CoreDdd.Nhibernate.Queries;
using Eshop.Dtos;
using NHibernate;

namespace Eshop.Queries
{
    public class ProductDetailsQueryHandler : BaseQueryOverHandler<ProductDetailsQuery>
    {
        protected override IQueryOver GetQueryOver<TResult>(ProductDetailsQuery query)
        {
            return Session.QueryOver<ProductDto>().Where(x => x.Id == query.ProductId);                          
        }
    }
}