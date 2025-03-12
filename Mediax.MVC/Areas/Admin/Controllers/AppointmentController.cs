using Mediax.Core.Enums;
using Mediax.Dal.DAL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Mediax.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = nameof(Roles.Admin))]

    public class AppointmentController(MediaxDbContext _context) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var appointments = await _context.Apointsments.OrderByDescending(a => a.CreatedTime).ToListAsync();
            return View(appointments);
        }
    }

}
