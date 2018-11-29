using CoreDdd.Nhibernate.Queries;
using CoreDdd.Nhibernate.UnitOfWorks;
using Eshop.Dtos;
using NHibernate;

namespace Eshop.Queries
{
    public class DeliveryAddressQueryHandler : BaseQueryOverHandler<DeliveryAddressQuery>
    {
        public DeliveryAddressQueryHandler(NhibernateUnitOfWork unitOfWork) 
            : base(unitOfWork)
        {
        }

        protected override IQueryOver GetQueryOver<TResult>(DeliveryAddressQuery query)
        {
            return Session.QueryOver<DeliveryAddressDto>().Where(x => x.CustomerId == query.CustomerId);
        }
    }
}