﻿using CineFlex.Domain.Interfaces.Repositories;
using CineFlex.Domain.Models;
using CineFlex.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineFlex.Persistence.Repositories
{
    public class SeanceRepository : BaseRepository<Seance>, ISeanceRepository
    {
        public SeanceRepository(CineFlexDbContext context) : base(context)
        {
        }
    }
}
