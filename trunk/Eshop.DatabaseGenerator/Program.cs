using Eshop.Infrastructure;

namespace Eshop.DatabaseGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            var schemaGenerator = new EshopDatabaseSchemaGenerator(@"eshop_generated_database_schema.sql");
            schemaGenerator.Generate();
        }
    }
}

