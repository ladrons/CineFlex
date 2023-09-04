using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineFlex.Application.Exceptions
{
    //Veritabanı kaydı olmadığı sürece 'Id' gerekmiyor.
    public class CustomException : Exception
    {
        public string ErrorMessage { get; set; }
        public string Description { get; set; }
        public DateTime ErrorDate { get; set; }
    }
}
