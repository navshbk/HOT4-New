﻿using Hot4.DataModel.Data;
using Hot4.DataModel.Models;
using Hot4.Repository.Abstract;
using Hot4.ViewModel;

namespace Hot4.Repository.Concrete
{
    public class AccessWebRepository : RepositoryBase<AccessWeb>, IAccessWebRepository
    {
        public AccessWebRepository(HotDbContext context) : base(context) { }
        public async Task<AccessWebModel?> GetAccessWebById(long accessId)
        {
            var result = await GetById(accessId);
            if (result != null)
            {
                return new AccessWebModel
                {
                    AccessId = accessId,
                    AccessName = result.AccessName,
                    ResetToken = result.ResetToken,
                    SalesPassword = result.SalesPassword,
                    WebBackground = result.WebBackground,
                };
            }
            return null;
        }
        public async Task AddAccessWeb(AccessWeb accessWeb)
        {
            accessWeb.SalesPassword = true;
            await Create(accessWeb);
            await SaveChanges();
        }
        public async Task DeleteAccessWeb(AccessWeb accessWeb)
        {
            Delete(accessWeb);
            await SaveChanges();
        }
        public async Task UpdateAccessWeb(AccessWeb accessWeb)
        {
            Update(accessWeb);
            await SaveChanges();

        }

    }
}
