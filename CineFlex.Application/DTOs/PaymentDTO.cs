using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#nullable disable

namespace CineFlex.Application.DTOs
{
    public class PaymentDTO
    {
        //Kullanıcı Bilgileri
        public string Fullname { get; set; }
        public string Email { get; set; }

        //Ödeme Bilgileri        
        public string CardUsername { get; set; }
        public string CardNumber { get; set; }
        public ushort SecurityNumber { get; set; }
        public int CardExpiryMonth { get; set; }
        public int CardExpiryYear { get; set; }
        public decimal Price { get; set; }
    }
}