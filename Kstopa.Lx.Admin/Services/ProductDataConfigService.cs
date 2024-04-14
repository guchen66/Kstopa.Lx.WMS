﻿using Kstopa.Lx.Admin.IRepositorys;
using Kstopa.Lx.Admin.IServices;
using Kstopa.Lx.SugarDb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kstopa.Lx.Admin.Services
{
    public class ProductDataConfigService : BaseService<ProductDataConfig>, IProductDataConfigService
    {
        private readonly IBaseRepository<ProductDataConfig> _repository;
        public ProductDataConfigService(IBaseRepository<ProductDataConfig> repository) : base(repository)
        {
            _repository = repository;
        }

        public List<ProductDataConfig> GetAllProductDataConfig()
        {
            return _repository.Context.Queryable<ProductDataConfig>().ToList();
        }

        public ProductDataConfig GetProductDataConfig()
        {
           return _repository.Context.Queryable<ProductDataConfig>().Where(it=>it.IsDelete=="0"||it.IsDelete==null).First();
        }
    }
}
