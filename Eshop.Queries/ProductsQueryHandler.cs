using CoreDdd.Nhibernate.Queries;
using CoreDdd.Nhibernate.UnitOfWorks;
using Eshop.Dtos;
using NHibernate;

namespace Eshop.Queries
{
    public class ProductsQueryHandler : BaseQueryOverHandler<ProductsQuery>
    {
        public ProductsQueryHandler(NhibernateUnitOfWork unitOfWork) 
            : base(unitOfWork)
        {
        }

        protected override IQueryOver GetQueryOver<TResult>(ProductsQuery query)
        {
            return Session.QueryOver<ProductSummaryDto>()
                          .WhereRestrictionOn(x => x.Name).IsLike(string.Format("%{0}%", query.SearchText));
        }
    }
}