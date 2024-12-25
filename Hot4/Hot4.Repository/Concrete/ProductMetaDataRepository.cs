﻿using Hot4.DataModel.Data;
using Hot4.DataModel.Models;
using Hot4.Repository.Abstract;
using Hot4.ViewModel.ApiModels;
using Microsoft.EntityFrameworkCore;

namespace Hot4.Repository.Concrete
{
    public class ProductMetaDataRepository : RepositoryBase<ProductMetaData>, IProductMetaDataRepository
    {
        public ProductMetaDataRepository(HotDbContext context) : base(context) { }
        public async Task<List<ProductMetaDataModel>> ListProductMetaData()
        {
            return await GetAll()
                 .Select(d => new ProductMetaDataModel
                 {
                     BrandMetaId = d.ProductMetaId,
                     ProductMetaId = d.ProductMetaId,
                     Data = d.Data,
                     ProductId = d.ProductId,
                     ProductMetaDataTypeId = d.ProductMetaDataTypeId,
                 }).ToListAsync();
        }
    }
}
