using AutoMapper;
using IdentityServer4.Models;
using JPProject.Admin.Application.AutoMapper;
using JPProject.Admin.Application.Interfaces;
using JPProject.Admin.Application.ViewModels.ApiResouceViewModels;
using JPProject.Admin.Domain.Commands.ApiResource;
using JPProject.Admin.Domain.Interfaces;
using JPProject.Domain.Core.Bus;
using JPProject.Domain.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JPProject.Admin.Application.Services
{
    public class ApiResourceAppService : IApiResourceAppService
    {
        private IMapper _mapper;
        private IEventStoreRepository _eventStoreRepository;
        private readonly IApiResourceRepository _apiResourceRepository;
        public IMediatorHandler Bus { get; set; }

        public ApiResourceAppService(
            IMediatorHandler bus,
            IEventStoreRepository eventStoreRepository,
            IApiResourceRepository apiResourceRepository)
        {
            _mapper = AdminApiResourceMapper.Mapper;
            Bus = bus;
            _eventStoreRepository = eventStoreRepository;
            _apiResourceRepository = apiResourceRepository;
        }

        public async Task<IEnumerable<ApiResourceListViewModel>> GetApiResources()
        {
            var resultado = await _apiResourceRepository.GetResources();
            return resultado.Select(s => _mapper.Map<ApiResourceListViewModel>(s)).ToList();
        }

        public Task<ApiResource> GetDetails(string name)
        {
            return _apiResourceRepository.GetResource(name);
        }

        public Task<bool> Save(ApiResource model)
        {
            var command = _mapper.Map<RegisterApiResourceCommand>(model);
            return Bus.SendCommand(command);
        }

        public Task<bool> Update(string id, ApiResource model)
        {
            var command = new UpdateApiResourceCommand(model, id);
            return Bus.SendCommand(command);

        }

        public Task<bool> Remove(RemoveApiResourceViewModel model)
        {
            var command = _mapper.Map<RemoveApiResourceCommand>(model);
            return Bus.SendCommand(command);
        }

        public Task<IEnumerable<Secret>> GetSecrets(string name)
        {
            return _apiResourceRepository.GetSecretsByApiName(name);
        }

        public Task<bool> RemoveSecret(RemoveApiSecretViewModel model)
        {
            var registerCommand = _mapper.Map<RemoveApiSecretCommand>(model);
            return Bus.SendCommand(registerCommand);
        }

        public Task<bool> SaveSecret(SaveApiSecretViewModel model)
        {
            var registerCommand = _mapper.Map<SaveApiSecretCommand>(model);
            return Bus.SendCommand(registerCommand);
        }

        public Task<IEnumerable<Scope>> GetScopes(string name)
        {
            return _apiResourceRepository.GetScopesByResource(name);
        }

        public Task<bool> RemoveScope(RemoveApiScopeViewModel model)
        {
            var registerCommand = _mapper.Map<RemoveApiScopeCommand>(model);
            return Bus.SendCommand(registerCommand);
        }


        public Task<bool> SaveScope(SaveApiScopeViewModel model)
        {
            var registerCommand = _mapper.Map<SaveApiScopeCommand>(model);
            return Bus.SendCommand(registerCommand);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}