using Mediax.BL.Services.Abstracts;
using Mediax.BL.ViewModels.AboutFeature;
using Mediax.BL.ViewModels.Category;
using Mediax.Core.Entites;
using Mediax.Dal.DAL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediax.BL.Services.Implements
{
    public class AboutFeatureService(MediaxDbContext _context) : IAboutFeatureService
    {
        public async Task<bool> Create(AboutFeatureCreateVm vm)
        {
            await _context.AboutFeatures.AddAsync(new AboutFeature
            {
                Title = vm.Title,
                Description = vm.Description,
                IconUrl=vm.AboutImg

            });
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(int? id)
        {
            var data = await _context.AboutFeatures.FirstOrDefaultAsync(c => c.Id == id);
            if (data != null)
            {
                _context.AboutFeatures.Remove(data);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<AboutFeatureCreateVm> Get(int id)
        {
            var data = await _context.AboutFeatures.FindAsync(id);
            AboutFeatureCreateVm vm = new()
            {
                Title = data!.Title,
                Description= data!.Description,
                AboutImg=data.IconUrl


            };
            return vm;
        }

        public async Task<List<AboutFeature>> GetAllAsync()
        {
            return await _context.AboutFeatures.ToListAsync();
        }

        public async Task<bool> Update(int? id, AboutFeatureCreateVm vm)
        {
            var data = await _context.AboutFeatures.FirstOrDefaultAsync();
            if (data != null)
            {
                data.Title = vm.Title;
                data.Description = vm.Description;
                data.IconUrl = vm.AboutImg;
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
