﻿using AutoMapper;
using Hot4.DataModel.Models;
using Hot4.Repository.Abstract;
using Hot4.Service.Abstract;
using Hot4.ViewModel;

namespace Hot4.Service.Concrete
{
    public class SubscriberService : ISubscriberService
    {
        private ISubscriberRepository _subscriberRepository;
        private readonly IMapper Mapper;
        public SubscriberService(ISubscriberRepository subscriberRepository, IMapper mapper)
        {
            _subscriberRepository = subscriberRepository;
            Mapper = mapper;
        }
        public async Task<bool> AddSubscriber(SubscriberToDo subscriber)
        {
            var model = Mapper.Map<Subscriber>(subscriber);
            return await _subscriberRepository.AddSubscriber(model);
        }

        public async Task<bool> DeleteSubscriber(long subscriberId)
        {
            var record = await _subscriberRepository.GetSubscriberById(subscriberId);
            if (record != null)
            {
                return await _subscriberRepository.DeleteSubscriber(record);
            }
            return false;
        }

        public async Task<SubscriberModel?> GetSubscriberById(long subscriberId)
        {
            var record = await _subscriberRepository.GetSubscriberById(subscriberId);
            return Mapper.Map<SubscriberModel>(record);
        }

        public async Task<List<SubscriberModel>> ListSubscriber(int pageNo, int pageSize)
        {
            var records = await _subscriberRepository.ListSubscriber(pageNo, pageSize);
            return Mapper.Map<List<SubscriberModel>>(records);
        }

        public async Task<bool> UpdateSubscriber(SubscriberToDo subscriber)
        {
            var record = await _subscriberRepository.GetSubscriberById(subscriber.SubscriberId);
            if (record != null)
            {
                var model = Mapper.Map(subscriber, record);
                return await _subscriberRepository.UpdateSubscriber(record);
            }
            return false;
        }
    }
}
