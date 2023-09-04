using AutoMapper;
using CineFlex.Application.Interfaces.Managers;
using CineFlex.WebUI.ViewModels;
using CineFlex.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace CineFlex.WebUI.Areas.Management.Controllers
{
    [Area("Management")]
    [Route("Management/[controller]")]
    public class FormatController : Controller
    {
        private readonly ILogger<FormatController> _logger;
        private readonly IMapper _mapper;

        IFormatManager _formatMan;

        public FormatController(ILogger<FormatController> logger, IMapper mapper, IFormatManager formatMan)
        {
            _logger = logger;
            _mapper = mapper;
            _formatMan = formatMan;
        }

        [Route("AddFormat")]
        public IActionResult AddFormat() => View();

        [HttpPost]
        [Route("AddFormat")]
        public IActionResult AddFormat(FormatVM format)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View();

                if (_formatMan.CheckFormatNameExist(format.Name))
                {
                    ModelState.AddModelError("Name", $"{format.Name} formatı zaten kayıtlıdır.");
                    return View(format);
                }

                Format newFormat = _mapper.Map<Format>(format);

                _formatMan.Add(newFormat);
                _formatMan.SaveChanges();

                return RedirectToAction("Dashboard", "Home", new { area = "Management" });
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"## Bir hata meydana geldi: {ex.Message} ##");
                return RedirectToAction("Error", "Home");
            }
        }
    }
}