using CineFlex.Application.Interfaces.Services;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

# nullable disable

namespace CineFlex.Infrastructure.Services
{
    public class ErrorService : IErrorService
    {
        private readonly ILogger<ErrorService> _logger;

        private Exception _lastException;

        public ErrorService(ILogger<ErrorService> logger)
        {
            _logger = logger;
        }

        //----------//

        public void LogException(Exception ex)
        {
            if (_lastException != null) _lastException = null;

            _logger.LogError($"Bir hata meydana geldi: {ex.Message}");
            _lastException = ex;
        }

        public Exception GetLastException() => _lastException;
    }    
}