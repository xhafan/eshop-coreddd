using CoreDdd.Nhibernate.Queries;
using CoreDdd.Nhibernate.UnitOfWorks;
using Eshop.Dtos;
using NHibernate;

namespace Eshop.Queries
{
    public class ProductDetailsQueryHandler : BaseQueryOverHandler<ProductDetailsQuery>
    {
        public ProductDetailsQueryHandler(NhibernateUnitOfWork unitOfWork) 
            : base(unitOfWork)
        {
        }

        protected override IQueryOver GetQueryOver<TResult>(ProductDetailsQuery query)
        {
            return Session.QueryOver<ProductDto>().Where(x => x.Id == query.ProductId);                          
        }
    }
}