using System.Linq;
using System.Web.Http;
using CoreDdd.Commands;
using CoreDdd.Queries;
using Eshop.Commands;
using Eshop.Dtos;
using Eshop.Queries;

namespace Eshop.WebApi.Controllers
{
    public class DeliveryAddressController : AuthenticatedController
    {
        private readonly IQueryExecutor _queryExecutor;
        private readonly ICommandExecutor _commandExecutor;

        public DeliveryAddressController(IQueryExecutor queryExecutor, ICommandExecutor commandExecutor)
        {
            _queryExecutor = queryExecutor;
            _commandExecutor = commandExecutor;
        }

        public void SetDeliveryAddress([FromBody]string deliveryAddress)
        {
            _commandExecutor.Execute(new SetDeliveryAddressCommand
                {
                    CustomerId = SessionContext.CustomerId,
                    Address = deliveryAddress
                });
        }

        public string GetDeliveryAddress()
        {
            return _queryExecutor.Execute<DeliveryAddressQuery, DeliveryAddressDto>(new DeliveryAddressQuery { CustomerId = SessionContext.CustomerId })
                .Single().DeliveryAddress;
        }
    }
}