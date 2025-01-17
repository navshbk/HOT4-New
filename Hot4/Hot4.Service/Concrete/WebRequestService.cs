﻿using AutoMapper;
using Hot4.DataModel.Models;
using Hot4.Repository.Abstract;
using Hot4.Service.Abstract;
using Hot4.ViewModel;

namespace Hot4.Service.Concrete
{
    public class WebRequestService : IWebRequestService
    {
        private IWebRequestRepository _webRequestRepository;
        private readonly IMapper Mapper;
        public WebRequestService(IWebRequestRepository webRequestRepository, IMapper mapper)
        {
            _webRequestRepository = webRequestRepository;
            Mapper = mapper;
        }
        public async Task<bool> AddWebRequest(WebRequestModel webRequest)
        {
            var model = Mapper.Map<WebRequests>(webRequest);
            return await _webRequestRepository.AddWebRequest(model);
        }

        public async Task<bool> DeleteWebRequest(long webId)
        {
            var record = await _webRequestRepository.GetWebRequestById(webId);
            if (record != null)
            {
                return await _webRequestRepository.DeleteWebRequest(record);
            }
            return false;
        }

        public async Task<WebRequestModel?> GetWebRequestById(long webId)
        {
            var record = await _webRequestRepository.GetWebRequestById(webId);
            return Mapper.Map<WebRequestModel>(record);
        }

        public async Task<List<WebRequestModel>> GetWebRequestByRefAndAccessId(string agentRef, long accessId)
        {
            var records = await _webRequestRepository.GetWebRequestByRefAndAccessId(agentRef, accessId);
            return Mapper.Map<List<WebRequestModel>>(records);
        }

        public async Task<List<WebRequestModel>> ListWebRequest(int pageNo, int pageSize)
        {
            var records = await _webRequestRepository.ListWebRequest(pageNo, pageSize);
            return Mapper.Map<List<WebRequestModel>>(records);
        }

        public async Task<bool> UpdateWebRequest(WebRequestModel webRequest)
        {
            var record = await _webRequestRepository.GetWebRequestById(webRequest.WebId);
            if (record != null)
            {
                var model = Mapper.Map(webRequest, record);
                return await _webRequestRepository.UpdateWebRequest(record);
            }
            return false;
        }
    }
}