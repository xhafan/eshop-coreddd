using System;
using System.Collections.Generic;
using System.Reflection;
using CoreDdd.Domain;
using CoreDdd.Infrastructure;
using Eshop.Domain;
using Eshop.Dtos;

namespace Eshop.Infrastructure
{
    public static class UnitOfWorkInitializer
    {
        public static void Initialize()
        {
            UnitOfWork.Initialize(GetNhibernateConfigurator());
        }

        public static INhibernateConfigurator GetNhibernateConfigurator(bool mapDtos = true)
        {
            var assembliesToMap = new List<Assembly> { typeof(Customer).Assembly };
            if (mapDtos) assembliesToMap.Add(typeof(ProductSummaryDto).Assembly);
            return new NhibernateConfigurator(assembliesToMap.ToArray(), new[] {typeof (Entity<>) }, new Type[0], true, null);
        }
    }
}
