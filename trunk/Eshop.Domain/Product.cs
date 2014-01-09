using CoreDdd.Domain;

namespace Eshop.Domain
{
    public class Product : Entity, IAggregateRoot
    {
        protected Product() {}

        public Product(string name, string description)
        {
            Name = name;
            Description = description;
        }

        public virtual string Name { get; protected set; }
        public virtual string Description { get; protected set; }
    }
}