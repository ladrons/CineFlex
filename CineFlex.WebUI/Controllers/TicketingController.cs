using CineFlex.Application.DTOs;
using CineFlex.Application.Exceptions;
using CineFlex.Application.Interfaces.Managers;
using CineFlex.Application.Interfaces.Services;
using CineFlex.Domain.Models;
using CineFlex.Infrastructure.Services;
using CineFlex.WebUI.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace CineFlex.WebUI.Controllers
{
    [Route("[controller]")]
    public class TicketingController : Controller
    {
        private readonly IPaymentService _paymentService;
        private readonly IErrorService _errorService;

        ISeanceManager _seanceMan; IMovieManager _movieMan; ITicketManager _ticketMan; ISoldTicketManager _soldTicketMan;

        public TicketingController(ISeanceManager seanceMan, IMovieManager movieMan, ISoldTicketManager soldTicketMan, ITicketManager ticketMan, IPaymentService paymentService, IErrorService errorService)
        {
            _seanceMan = seanceMan;
            _movieMan = movieMan;
            _soldTicketMan = soldTicketMan;
            _ticketMan = ticketMan;
            _paymentService = paymentService;
            _errorService = errorService;
        }

        //----------//

        [Route("SelectSeance")]
        public IActionResult SelectSeance(int id)
        {
            Movie foundMovie = _movieMan.Find(id);

            TicketingVM tvm = new TicketingVM
            {
                MovieSeancesDate = _seanceMan.GetSelectedMovieSeanceDates(foundMovie, DateTime.Now),
                MovieId = id
            };
            return View(tvm);
        }

        [HttpGet]
        [Route("GetSeanceTimesByDate")]
        public List<string> GetSeanceTimesByDate(string seanceDate, int movieId)
        {
            DateTime convertedDate = Convert.ToDateTime(seanceDate);

            List<Seance> foundSeance = _seanceMan.
                Where(x => x.Status != Domain.Enums.DataStatus.Deleted &&
                    x.MovieId == movieId &&
                    x.SeanceDate == convertedDate).
                OrderBy(x => x.SeanceTime).
                ToList();

            List<string> seanceTimes = new List<string>();
            foreach (var seance in foundSeance)
            {
                if (_seanceMan.CheckSeanceTime(seance, DateTime.Now) && seance.Theater.Capacity > seance.SoldTickets.Count)
                {
                    seanceTimes.Add(seance.SeanceTime.ToShortTimeString());
                }
            }

            return seanceTimes;
        }

        [HttpPost]
        [Route("SelectSeance")]
        public IActionResult SelectSeance(TicketingVM ticketingVM)
        {
            Seance foundSeance = _seanceMan.GetSeanceByAttributes(ticketingVM.MovieId, ticketingVM.SeanceDate, ticketingVM.SeanceTime);

            Theater foundTheater = foundSeance.Theater;
            Movie foundMovie = foundSeance.Movie;

            SetObjectToSession("tempTicket", _soldTicketMan.CreateTempTicket(foundMovie, foundTheater, foundSeance));

            return RedirectToAction("SelectTicketType");
        }

        //----------//

        [Route("SelectTicketType")]
        public IActionResult SelectTicketType()
        {
            TicketingVM tvm = new TicketingVM
            {
                ActiveTickets = _ticketMan.GetActives()
            };
            return View(tvm);
        }

        [HttpPost]
        [Route("SelectTicketType")]
        public IActionResult SelectTicketType(Dictionary<int, int> ticketQuantity)
        {
            MainTicketInfoDTO tempTicket = GetObjectToSession<MainTicketInfoDTO>("tempTicket");

            tempTicket = _soldTicketMan.ProcessSelectedTickets(ticketQuantity, tempTicket, _ticketMan);

            SetObjectToSession("tempTicket", tempTicket);
            return RedirectToAction("SelectSeat");
        }

        //----------//

        [Route("SelectSeat")]
        public IActionResult SelectSeat()
        {
            MainTicketInfoDTO tempTicket = GetObjectToSession<MainTicketInfoDTO>("tempTicket");

            var soldSeats = _soldTicketMan.
               Where(x => x.SeanceId == tempTicket.SeanceId &&
                    x.Status != Domain.Enums.DataStatus.Deleted).
               Select(x => x.SeatInfo).
               ToList();

            TicketingVM tvm = new TicketingVM
            {
                TheaterCapacity = tempTicket.TheaterCapacity,
                TicketQuantity = tempTicket.TicketQuantity,
                SoldSeats = soldSeats
            };
            return View(tvm);
        }

        [HttpPost]
        [Route("SelectSeat")]
        public IActionResult SelectSeat(string[] selectedSeats)
        {
            MainTicketInfoDTO tempTicket = GetObjectToSession<MainTicketInfoDTO>("tempTicket");

            int seatIndex = 0;
            foreach (var item in tempTicket.SubTicketInfos)
            {
                item.SeatName = selectedSeats[seatIndex];
                seatIndex++;
            }
            SetObjectToSession("tempTicket", tempTicket);

            return RedirectToAction("ConfirmPayment");
        }

        //----------//

        [Route("ConfirmPayment")]
        public IActionResult ConfirmPayment()
        {
            TicketingVM tvm = new TicketingVM();
            return View(tvm);
        }

        [HttpPost]
        [Route("ConfirmPayment")]
        public async Task<IActionResult> ConfirmPayment(PaymentDTO payment)
        {
            MainTicketInfoDTO tempTicket = GetObjectToSession<MainTicketInfoDTO>("tempTicket");

            payment.Price = tempTicket.TotalPrice;

            bool paymentResult = await _paymentService.ReceivePayment(payment);
            if (paymentResult)
            {
                Customer foundCustomer = HttpContext.Items["Customer"] as Customer;

                if (await _soldTicketMan.CreateSoldTicket(tempTicket, foundCustomer))
                {
                    return RedirectToAction("Success"); //Todo: oluşturulacak.

                    //Gerekli işlemler yapıldı.
                }
                else
                {
                    //Bilet ve kullanıcı bilgileri kaydedilirken bir sorun oluştu.

                    //Bu durumda kullanıcı bilet parasını ödedi ancak bilet bilgileri oluşmadı. O yüzden yaptığı ödemenin ve biletlerinin bilgilerini bir şekilde kayıt altına almam gerek.
                }
            }
            else
            {
                Exception ex = _errorService.GetLastException();

                TempData["ErrorMessage"] = ex.Message;
                return RedirectToAction("Error", "Home");
            }

            return View();
        }

        #region HelperMethods
        private void SetObjectToSession(string jsonKey, object serializedObject)
        {
            string jsonValue = JsonSerializer.Serialize(serializedObject);
            HttpContext.Session.SetString(jsonKey, jsonValue);
        }
        private T GetObjectToSession<T>(string jsonKey)
        {
            string objectString = HttpContext.Session.GetString(jsonKey);
            T deserializedObject = JsonSerializer.Deserialize<T>(objectString);

            return deserializedObject;
        }
        #endregion
    }
}