using MarketPulse.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPulse.Core.Specifications.ProductSpecifications
{
    public class ProductWithBrandandCategorySpecifications : BaseSpecification<Product>
    {
        public ProductWithBrandandCategorySpecifications() :base()
        {
            AddIncludes();
        }


        public ProductWithBrandandCategorySpecifications(int id) :base(P => P.Id == id)
        {
            AddIncludes();
        }

        private void AddIncludes()
        {
            Includes.Add(P => P.Brand);
            Includes.Add(P => P.Category);
        }
    }
}
