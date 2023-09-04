using CineFlex.Application.DTOs;
using CineFlex.Application.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace CineFlex.Infrastructure.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly IErrorService _errorService;

        private readonly HttpClient _httpClient;

        public PaymentService(HttpClient httpClient, IErrorService errorService)
        {
            _httpClient = httpClient;

            _httpClient.BaseAddress = new Uri("https://localhost:7124/api/");
            _errorService = errorService;
        }

        public async Task<bool> ReceivePayment(PaymentDTO payment)
        {
            bool result;
            try
            {
                HttpResponseMessage response = await _httpClient.PostAsJsonAsync("Payment/ReceivePayment", payment);

                result = response.IsSuccessStatusCode ? true : false;
            }
            catch (Exception ex)
            {
                _errorService.LogException(ex);
                result = false;
            }
            return result;
        }
    }
}