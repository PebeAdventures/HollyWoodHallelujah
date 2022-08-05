﻿using TvSeriesApi.Data.Context;
using TvSeriesApi.Data.Entities;
using TvSeriesApi.Data.Helpers;

namespace TvSeriesApi.Data.DAL.Repositories
{
    public class GenreRepository : BaseRepository<Genre>, IGenreRepository
    {
        private readonly TvSeriesApiContext _context;

        public GenreRepository(TvSeriesApiContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Genre> GetGenreByIdAsync(int id) => await _context.Genres.Where(g => g.GenreId == id).FirstOrDefaultAsync();

        public IQueryable<Genre> GetGenresPaginated(PageParameters ownerParameters) => _context.Genres
                .OrderBy(on => on.Name)
                .Skip((ownerParameters.PageNumber - 1) * ownerParameters.PageSize)
                .Take(ownerParameters.PageSize)
                .AsQueryable();
    }
}