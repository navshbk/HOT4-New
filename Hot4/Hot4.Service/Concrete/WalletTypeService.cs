﻿using AutoMapper;
using Hot4.DataModel.Models;
using Hot4.Repository.Abstract;
using Hot4.Service.Abstract;
using Hot4.ViewModel;

namespace Hot4.Service.Concrete
{
    public class WalletTypeService : IWalletTypeService
    {
        private IWalletTypeRepository _walletTypeRepository;
        private readonly IMapper Mapper;
        public WalletTypeService(IWalletTypeRepository walletTypeRepository, IMapper mapper)
        {
            _walletTypeRepository = walletTypeRepository;
            Mapper = mapper;
        }
        public async Task<bool> AddWalletType(WalletTypeModel walletType)
        {
            var model = Mapper.Map<WalletType>(walletType);
            return await _walletTypeRepository.AddWalletType(model);
        }

        public async Task<bool> DeleteWalletType(int walletTypeId)
        {
            var record = await _walletTypeRepository.GetWalletTypeById(walletTypeId);
            if (record != null)
            {
                return await _walletTypeRepository.DeleteWalletType(record);
            }
            return false;
        }

        public async Task<WalletTypeModel?> GetWalletTypeById(int walletTypeId)
        {
            var record = await _walletTypeRepository.GetWalletTypeById(walletTypeId);
            return Mapper.Map<WalletTypeModel>(record);
        }

        public async Task<List<WalletTypeModel>> ListWalletType()
        {
            var records = await _walletTypeRepository.ListWalletType();
            return Mapper.Map<List<WalletTypeModel>>(records);
        }

        public async Task<bool> UpdateWalletType(WalletTypeModel walletType)
        {
            var record = await _walletTypeRepository.GetWalletTypeById(walletType.WalletTypeId);
            if (record != null)
            {
                var model = Mapper.Map(walletType, record);
                return await _walletTypeRepository.UpdateWalletType(record);
            }
            return false;
        }
    }
}
