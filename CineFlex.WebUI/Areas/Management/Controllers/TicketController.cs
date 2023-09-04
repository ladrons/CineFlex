using AutoMapper;
using CineFlex.Application.Interfaces.Managers;
using CineFlex.Application.Interfaces.Services;
using CineFlex.Domain.Models;
using CineFlex.WebUI.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CineFlex.WebUI.Areas.Management.Controllers
{
    [Area("Management")]
    [Route("Management/[controller]")]
    public class TicketController : Controller
    {
        private readonly IMapper _mapper;

        ITicketManager _ticketMan;

        public TicketController(IMapper mapper, ITicketManager ticketMan)
        {
            _mapper = mapper;
            _ticketMan = ticketMan;
        }

        [Route("TicketList")]
        public IActionResult TicketList()
        {
            List<TicketVM> ticketVMs = _ticketMan.Where(x => x.Status != Domain.Enums.DataStatus.Deleted).Select(ticket => new TicketVM
            {
                Name = ticket.Name,
                Price = ticket.Price,
            }).ToList();

            return View(ticketVMs);
        }

        //----------//

        [Route("AddTicket")]
        public IActionResult AddTicket() => View();

        [HttpPost]
        [Route("AddTicket")]
        public IActionResult AddTicket(TicketVM ticketVM)
        {
            if (!ModelState.IsValid)
                return View();

            Ticket newTicket = _mapper.Map<Ticket>(ticketVM);

            try
            {
                _ticketMan.Add(newTicket);
                _ticketMan.SaveChanges();

                return RedirectToAction("TicketList");
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return RedirectToAction("Error", "Home", new { area = "Management" });
            }
        }
    }
}