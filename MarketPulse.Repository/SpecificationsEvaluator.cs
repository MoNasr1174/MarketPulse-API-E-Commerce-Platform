using MarketPulse.Core.Entities;
using MarketPulse.Core.Specifications;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPulse.Repository
{
    internal static class SpecificationsEvaluator<TEntity> where TEntity : BaseEntity
    {
        public static IQueryable<TEntity> GetQuery(IQueryable<TEntity> Inputquery, ISpecifications<TEntity> Specs)
        {
            var query = Inputquery;

            if (Specs.Criteria != null)
                query = query.Where(Specs.Criteria);


            query = Specs.Includes.Aggregate(query, (CurrentExperssion, NextExperssion) => CurrentExperssion.Include(NextExperssion));

            return query;
        }
    }
}
