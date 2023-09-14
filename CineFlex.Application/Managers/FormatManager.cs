using CineFlex.Application.Interfaces.Managers;
using CineFlex.Domain.Interfaces.Repositories;
using CineFlex.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineFlex.Application.Managers
{
    public class FormatManager : BaseManager<Format>, IFormatManager
    {
        IFormatRepository _formatRep;

        public FormatManager(IFormatRepository formatRep) : base(formatRep)
        {
            _formatRep = formatRep;
        }

        //----------//

        public bool CheckFormatNameExist(string formatName)
        {
            if (_formatRep.Any(x => x.Name.ToLower() == formatName.ToLower())) return true;
            return false;
        }
    }
}