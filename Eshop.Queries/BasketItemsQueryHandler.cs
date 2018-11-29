using CoreDdd.Nhibernate.Queries;
using CoreDdd.Nhibernate.UnitOfWorks;
using Eshop.Dtos;
using NHibernate;

namespace Eshop.Queries
{
    public class BasketItemsQueryHandler : BaseQueryOverHandler<BasketItemsQuery>
    {
        public BasketItemsQueryHandler(NhibernateUnitOfWork unitOfWork) 
            : base(unitOfWork)
        {
        }

        protected override IQueryOver GetQueryOver<TResult>(BasketItemsQuery query)
        {
            return Session.QueryOver<BasketItemDto>().Where(x => x.CustomerId == query.CustomerId);
        }
    }
}