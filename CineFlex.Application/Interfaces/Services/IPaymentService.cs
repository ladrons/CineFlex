using CineFlex.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineFlex.Application.Interfaces.Services
{
    public interface IPaymentService
    {
        Task<bool> ReceivePayment(PaymentDTO payment);
    }
}
