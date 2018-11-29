using System;
using System.Collections.Generic;
using System.Reflection;
using CoreDdd.Nhibernate.Configurations;
using Eshop.Domain;
using Eshop.Domain.NhibernateMapping;
using Eshop.Dtos;
using Eshop.Dtos.NhibernateMapping;
using HibernatingRhinos.Profiler.Appender.NHibernate;

namespace Eshop.Infrastructure
{
    public class EshopNhibernateConfigurator : BaseNhibernateConfigurator
    {
        public EshopNhibernateConfigurator(bool shouldMapDtos = true)
            : base(shouldMapDtos)
        {
#if(DEBUG)
            NHibernateProfiler.Initialize();
#endif
        }

        protected override Assembly[] GetAssembliesToMap()
        {
            return new[]
            {
                typeof(Customer).Assembly,
                typeof(CustomerAutoMap).Assembly,
                typeof(ProductSummaryDto).Assembly,
                typeof(ProductSummaryDtoAutoMap).Assembly
            };
        }

        protected override IEnumerable<Type> GetIgnoreBaseTypes()
        {
            yield return typeof (ReviewOrderDto);
        }
    }
}
