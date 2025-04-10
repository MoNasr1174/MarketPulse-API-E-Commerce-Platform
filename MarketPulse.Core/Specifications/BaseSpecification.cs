using MarketPulse.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MarketPulse.Core.Specifications
{
    public class BaseSpecification<T> : ISpecifications<T> where T : BaseEntity
    {
        public Expression<Func<T, bool>> Criteria { get; set; } = null;
        public List<Expression<Func<T, object>>> Includes { get; set;} = new List<Expression<Func<T ,object>>> ();

        public BaseSpecification()
        {
            // Criteria = null ; 
        }
        public BaseSpecification (Expression<Func<T, bool>> criteria) 
        {
            this.Criteria = criteria;
        }

        
    }
}
