using IdentityServer4.Models;
using JPProject.Domain.Core.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JPProject.Admin.Domain.Interfaces
{
    public interface IIdentityResourceRepository : IRepository<IdentityResource>
    {
        Task<IdentityResource> GetByName(string name);
        Task UpdateWithChildrens(string oldName, IdentityResource irs);
        Task<IdentityResource> GetDetails(string name);
        Task<List<string>> SearchScopes(string search);
        Task<IEnumerable<IdentityResource>> All();
        Task<List<string>> ListIdentityResources();
    }
}