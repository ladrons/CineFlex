using CineFlex.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineFlex.Domain.Models
{
    public class Customer : BaseUser
    {
        public string Gender { get; set; }
        public DateTime BirthDate { get; set; }
        public string WorkingStatus { get; set; } //Çalışma Durumu
        public string EducationalStatus { get; set; } //Eğitim Seviyesi
        public string MaritalStatus { get; set; } //Evlilik Durumu

        public Customer()
        {
            
        }

        //Relational Properties
        public virtual ICollection<Reservation>? Reservations { get; set; }
        public virtual ICollection<SoldTicket>? SoldTickets { get; set; }
    }
}