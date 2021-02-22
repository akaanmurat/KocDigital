using KocDigitalPOC.Data.Entities;
using KocDigitalPOC.Data.Filters;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace KocDigitalPOC.Data.Repositories.DataFrameRepository
{
    public class DataFrameRepository : IDataFrameRepository
    {
        private readonly KocDigitalDbContext _context;

        public DataFrameRepository(KocDigitalDbContext context)
        {
            _context = context;
        }

        public async Task Add(DataFrame dataFrame)
        {
            await _context.Set<DataFrame>().AddAsync(dataFrame);

            await _context.SaveChangesAsync();
        }

        public async Task Remove(DataFrame dataFrame)
        {
            _context.Set<DataFrame>().Remove(dataFrame);

            await _context.SaveChangesAsync();
        }

        public async Task Update(DataFrame dataFrame)
        {
            _context.Set<DataFrame>().Update(dataFrame);

            await _context.SaveChangesAsync();
        }

        public async Task<List<DataFrame>> Get(Expression<Func<DataFrame, bool>> predicate)
        {
            return await _context.Set<DataFrame>().Where(predicate).ToListAsync();
        }

        public async Task<List<DataFrame>> Get(DataFrameFilter filter)
        {
            var query = _context.Set<DataFrame>().AsQueryable();
            if (filter.Id != null)
            {
                query = query.Where(x => x.Id == filter.Id);
            }

            if (filter.LocationId != null)
            {
                query = query.Where(x => x.LocationId == filter.LocationId);
            }

            if (filter.Title != null)
            {
                query = query.Where(x => x.Title == filter.Title);
            }

            if (filter.Completed != null)
            {
                query = query.Where(x => x.Completed == filter.Completed);
            }

            return await query.ToListAsync();
        }       
    }
}