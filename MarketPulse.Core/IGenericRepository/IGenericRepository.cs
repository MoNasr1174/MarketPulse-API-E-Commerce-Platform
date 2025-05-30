﻿using MarketPulse.Core.Entities;
using MarketPulse.Core.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPulse.Core.IGenericRepository
{
    public interface IGenericRepository<T>  where T : BaseEntity
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T?> GetByIdAsync(int id);

        Task <IEnumerable<T>> GetAllWithSpecAsync(ISpecifications<T> spec);


        Task<T?> GetByIdWithSpecAsync(ISpecifications<T> spec); 
 

    }
}
