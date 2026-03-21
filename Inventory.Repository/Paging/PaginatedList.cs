using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Repository.Paging
{
    public class PaginatedList<T> : List<T>
    {

        public int PageIndex { get; private set; }
        public int TotalPages { get; private set; }
        public PaginatedList(List<T> items, int count, int pageIndex, int pageSize)
        {

            PageIndex = pageIndex;
            TotalPages = (int) Math.Ceiling(count / (double)pageSize);

            this.AddRange(items);
        }
        public bool HasPreviousPage => PageIndex > 1;
        public bool HasNextPage => PageIndex < TotalPages;
        public static async Task<PaginatedList<T>> CreateAsync(IQueryable<T> source, int pageIndex, int pageSize)
        {
            // This line detects if the source is a real DB query or just a RAM list
            var isAsync = source is Microsoft.EntityFrameworkCore.Query.Internal.EntityQueryable<T>
                          || source.Provider is Microsoft.EntityFrameworkCore.Query.Internal.EntityQueryProvider;

            int count;
            List<T> items;

            if (isAsync)
            {
                // If it's a real DB query, use the Async versions (Trainer's way)
                count = await source.CountAsync();
                items = await source.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToListAsync();
            }
            else
            {
                // If it's already a List (because of .ToList() in Repo), use Sync versions
                count = source.Count();
                items = source.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
            }

            return new PaginatedList<T>(items, count, pageIndex, pageSize);
        }
        //public static async Task<PaginatedList<T>> CreateAsync(IQueryable<T> source, int pageIndex, int pageSize)
        //{

        //    var count = await source.CountAsync();
        //    var items = await source.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToListAsync();
        //    return new PaginatedList<T>(items, count, pageIndex, pageSize);

        //}

    }
}
