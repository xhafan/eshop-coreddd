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
    public class EshopNhibernateConfigurator : NhibernateConfigurator
    {
        public EshopNhibernateConfigurator()
            : this(true)
        {
        }

        public EshopNhibernateConfigurator(bool mapDtoAssembly)
            : base(mapDtoAssembly)
        {
#if(DEBUG)
            NHibernateProfiler.Initialize();
#endif
        }

        protected override Assembly[] GetAssembliesToMap(bool mapDtoAssembly)
        {
            var assembliesToMap = new List<Assembly> { typeof(Customer).Assembly, typeof(CustomerAutoMap).Assembly };
            if (mapDtoAssembly) assembliesToMap.AddRange(new[] { typeof(ProductSummaryDto).Assembly, typeof(ProductSummaryDtoAutoMap).Assembly });
            return assembliesToMap.ToArray();
        }

        protected override IEnumerable<Type> GetIgnoreBaseTypes()
        {
            yield return typeof (ReviewOrderDto);
        }
    }
}
