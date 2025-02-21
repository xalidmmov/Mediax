using Mediax.BL.ViewModels.AboutFeature;
using Mediax.BL.ViewModels.Category;
using Mediax.Core.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediax.BL.Services.Abstracts
{
    public interface IAboutFeatureService
    {
        Task<List<AboutFeature>> GetAllAsync();
        Task<bool> Create(AboutFeatureCreateVm vm);
        Task<bool> Update(int? id, AboutFeatureCreateVm vm);
        Task<bool> Delete(int? id);
        Task<AboutFeatureCreateVm> Get(int id);
    }
}
