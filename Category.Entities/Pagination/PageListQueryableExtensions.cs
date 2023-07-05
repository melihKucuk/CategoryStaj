using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Category.Entities.Pagination
{
    public static class PageListQueryableExtensions
    {
        public static async Task<PaginationResult<T>> ToPagedListAsync<T>(
            this IQueryable<T> source,
            int pageNumber,
            int pageSize)
        {
            var count = await source.CountAsync();
            if (count > 0)
            {
                var items = await source
                    .Skip((pageNumber - 1) * pageSize)
                    .Take(pageSize)
                    .ToListAsync();

                return new(items, count, pageNumber, pageSize);
            }

            return new(null, 0, 0, 0);
        }
    }
}
