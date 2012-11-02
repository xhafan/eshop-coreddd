using CoreDdd.Domain;

namespace Eshop.Domain
{
    public class Product : Entity, IAggregateRoot
    {        
        public virtual string Name { get; protected internal set; }
    }
}