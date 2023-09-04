using AutoMapper;
using CineFlex.Application.Interfaces.Managers;
using CineFlex.WebUI.ViewModels;
using CineFlex.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace CineFlex.WebUI.Areas.Management.Controllers
{
    [Area("Management")]
    [Route("Management/[controller]")]
    public class TheaterController : Controller
    {
        private readonly IMapper _mapper;

        ITheaterManager _theaterMan;

        public TheaterController(IMapper mapper, ITheaterManager theaterMan)
        {
            _mapper = mapper;

            _theaterMan = theaterMan;
        }

        //----------//

        [Route("TheaterList")]
        public IActionResult TheaterList()
        {
            List<TheaterVM> theaterVMs = _theaterMan.Where(x => x.Status != Domain.Enums.DataStatus.Deleted).Select(theater => new TheaterVM
            {
                Id = theater.Id,
                Name = theater.Name,
                Capacity = theater.Capacity,
                ScreenType = theater.ScreenType,
            }).ToList();

            return View(theaterVMs);
        }

        //-----//

        [Route("TheaterDetails")]
        public IActionResult TheaterDetails(int id)
        {
            return BadRequest();
        }

        //-----//

        [Route("AddTheater")]
        public IActionResult AddTheater() => View();

        [HttpPost]
        [Route("AddTheater")]
        public IActionResult AddTheater(TheaterVM theater)
        {
            if (!ModelState.IsValid)
                return View();


            Theater newTheater = _mapper.Map<Theater>(theater);

            _theaterMan.Add(newTheater);
            _theaterMan.SaveChanges();

            return RedirectToAction("TheaterList");
        }

        //----------//

        #region HelperMethods
        [AcceptVerbs("GET","POST")]
        public IActionResult HasTheaterName(string Name)
        {
            var anyName = _theaterMan.Any(x => x.Name.ToLower() == Name.ToLower());

            if (anyName) return Json("Zaten bu isimde mevcut bir salon bulunmaktadır.");
            else return Json(true);
        }
        #endregion
    }
}