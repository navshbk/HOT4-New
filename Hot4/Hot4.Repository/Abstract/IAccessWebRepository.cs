﻿using Hot4.DataModel.Models;
using Hot4.ViewModel.ApiModels;

namespace Hot4.Repository.Abstract
{
    public interface IAccessWebRepository
    {
        Task<AccessWebModel?> GetAccessWeb(long accessId);
        Task AddAccessWeb(AccessWeb accessWeb);
        Task UpdateAccessWeb(AccessWeb accessWeb);
    }
}
