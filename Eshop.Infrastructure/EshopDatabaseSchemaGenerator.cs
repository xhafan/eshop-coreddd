using CoreDdd.DatabaseSchemaGenerators;
using CoreDdd.Infrastructure;

namespace Eshop.Infrastructure
{
    public class EshopDatabaseSchemaGenerator : DatabaseSchemaGenerator
    {
        private readonly string _databaseSchemaFileName;

        public EshopDatabaseSchemaGenerator(string databaseSchemaFileName)
        {
            _databaseSchemaFileName = databaseSchemaFileName;
        }


        protected override string GetDatabaseSchemaFileName()
        {
            return _databaseSchemaFileName;
        }

        protected override INhibernateConfigurator GetNhibernateConfigurator()
        {
            return UnitOfWorkInitializer.GetNhibernateConfigurator();
        }
    }
}
