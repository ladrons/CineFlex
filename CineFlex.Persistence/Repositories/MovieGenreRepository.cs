﻿using CineFlex.Application.Interfaces.Repositories;
using CineFlex.Domain.Models;
using CineFlex.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineFlex.Persistence.Repositories
{
    public class MovieGenreRepository : BaseRepository<MovieGenre>, IMovieGenreRepository
    {
        public MovieGenreRepository(CineFlexDbContext context) : base(context)
        {
        }
    }
}
