using MarketPulse.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MarketPulse.Repository.Data
{
    public class StoreContextSeed 
    {
        public static async Task SeedAsync(StoreContext storeContext)
        {
            if (!storeContext.ProductBrands.Any())
            {
                var BrandsDate = File.ReadAllText("../MarketPulse.Repository/Data/DataSeed/brands.json");
                var brands = JsonSerializer.Deserialize<List<ProductBrand>>(BrandsDate);


                if (brands?.Count() > 0)
                {
                    await storeContext.Set<ProductBrand>().AddRangeAsync(brands);
                    await storeContext.SaveChangesAsync();

                } 
            }
            if (!storeContext.ProductCategories.Any())
            {
                var categoriesData = File.ReadAllText("../MarketPulse.Repository/Data/DataSeed/categories.json");
                var categories = JsonSerializer.Deserialize<List<ProductCategory>>(categoriesData);
                if (categories?.Count() > 0)
                {
                    await storeContext.Set<ProductCategory>().AddRangeAsync(categories);
                    await storeContext.SaveChangesAsync();

                } 
            }
            if (!storeContext.Products.Any())
            {
                var productsData = File.ReadAllText("../MarketPulse.Repository/Data/DataSeed/products.json");
                var products = JsonSerializer.Deserialize<List<Product>>(productsData);

                if (products?.Count() > 0)
                {

                    await storeContext.Set<Product>().AddRangeAsync(products);

                    await storeContext.SaveChangesAsync();


                } 
            }




        }

    }
}
