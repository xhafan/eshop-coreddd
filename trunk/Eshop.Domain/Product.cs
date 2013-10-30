using CoreDdd.Domain;

namespace Eshop.Domain
{
    public class Product : Entity, IAggregateRoot
    {
        protected Product() {}

        public Product(string name)
        {
            Name = name;
        }

        public virtual string Name { get; protected set; }
    }
}