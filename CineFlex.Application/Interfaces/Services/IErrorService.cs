using CineFlex.Application.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineFlex.Application.Interfaces.Services
{
    public interface IErrorService
    {
        void LogException(Exception ex);

        Exception GetLastException();
    }
}