using CoreDdd.Nhibernate.DatabaseSchemaGenerators;
using Eshop.Infrastructure;

namespace Eshop.DatabaseGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            var schemaGenerator = new DatabaseSchemaGenerator(
                @"..\..\..\Eshop.Database\eshop_generated_database_schema.sql",
                new EshopNhibernateConfigurator(shouldMapDtos: false)
            );
            schemaGenerator.Generate();
        }
    }
}

