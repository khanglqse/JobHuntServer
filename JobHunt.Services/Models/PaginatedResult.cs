using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JobHunt.Services.Models.JobHunt.Employer;

namespace JobHunt.Services.Models
{
    //https://www.snyxius.com/blog/21-best-practices-designing-launching-restful-api/#.WVxh84iGPDc
    public class PaginatedResult<T>
    {
        public PaginatedResult(int pageNumber, int pageSize, int totalCount, IEnumerable<T> items) : this(pageNumber, pageSize, totalCount, items.ToArray())
        {

        }

        public PaginatedResult(int pageNumber, int pageSize, int totalCount, T[] items)
        {
            if (pageNumber <= 0)
            {
                throw new ArgumentOutOfRangeException($"Page number ({nameof(pageNumber)}) should be at least 1.");
            }

            if (pageSize <= 0)
            {
                throw new ArgumentOutOfRangeException($"Page size ({nameof(pageSize)}) should be at least 1.");
            }

            if (totalCount < 0)
            {
                throw new ArgumentOutOfRangeException($"Total count ({nameof(totalCount)}) should not be negative.");
            }

            var totalPages = totalCount / (float)pageSize;

            PageNumber = pageNumber;
            PageSize = pageSize;
            TotalCount = totalCount;
            TotalPages = (int)Math.Ceiling(totalPages);
            //Links =  //not set yet (HATEOS)
            Items = items;
        }

        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; } //this is the total count of items in the db, not total of count in current items
        public int TotalPages { get; set; }
        public Link[] Links { get; set; }
        public T[] Items { get; set; }
    }

    public class Link
    {
        public string Rel { get; set; }
        public string Href { get; set; }
        public string Action { get; set; }
        public string[] Types { get; set; }
    }
}
