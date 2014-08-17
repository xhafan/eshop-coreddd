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
        private readonly bool _mapDtoAssembly = true;

        public EshopNhibernateConfigurator()
        {
#if(DEBUG)
            NHibernateProfiler.Initialize();
#endif
        }

        public EshopNhibernateConfigurator(bool mapDtoAssembly)
            : this()
        {
            _mapDtoAssembly = mapDtoAssembly;
        }

        protected override Assembly[] GetAssembliesToMap()
        {
            var assembliesToMap = new List<Assembly> { typeof(Customer).Assembly, typeof(CustomerAutoMap).Assembly };
            if (_mapDtoAssembly) assembliesToMap.AddRange(new[] { typeof(ProductSummaryDto).Assembly, typeof(ProductSummaryDtoAutoMap).Assembly });
            return assembliesToMap.ToArray();
        }

        protected override IEnumerable<Type> GetIgnoreBaseTypes()
        {
            yield return typeof (ReviewOrderDto);
        }
    }
}
