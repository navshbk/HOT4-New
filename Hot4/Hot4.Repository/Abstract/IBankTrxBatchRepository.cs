﻿
using Hot4.DataModel.Models;
using Hot4.ViewModel.ApiModels;

namespace Hot4.Repository.Abstract
{
    public interface IBankTrxBatchRepository
    {
        Task<long> AddBatch(BankTrxBatch bankTrxBatch);
        Task UpdateBatch(BankTrxBatch bankTrxBatch);
        Task DeleteBatch(BankTrxBatch bankTrxBatch);
        Task<List<BankBatchModel>> GetBatch_by_Bank(byte bankId);
        Task<long?> GetCurrentBatchId_by_Bank_Ref(byte bankId, string batchRef = null);
        Task<BankBatchModel?> GetCurrentBatch(byte bankId, string batchReference, string lastUser);

    }
}
