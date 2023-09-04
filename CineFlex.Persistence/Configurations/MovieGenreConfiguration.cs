using CineFlex.Domain.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineFlex.Persistence.Configurations
{
    public class MovieGenreConfiguration : BaseConfiguration<MovieGenre>
    {
        public override void Configure(EntityTypeBuilder<MovieGenre> builder)
        {
            builder.Ignore(x => x.Id);

            builder.HasKey(x => new
            {
                x.MovieId,
                x.GenreId,
            });
        }
    }
}
