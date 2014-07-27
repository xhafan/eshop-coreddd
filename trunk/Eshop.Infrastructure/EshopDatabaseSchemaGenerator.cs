using CoreDdd.Nhibernate.Configurations;
using CoreDdd.Nhibernate.DatabaseSchemaGenerators;

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
            return new EshopNhibernateConfigurator(false);
        }
    }
}
