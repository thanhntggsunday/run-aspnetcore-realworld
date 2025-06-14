using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspnetRun.Shared.ViewModels.Common
{
    /// <summary>
    /// Helper class for returning paged results
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class PagedResults<T> : TransactionalInformation
    {
        public PagedResults(int totalItems,
            int pageNumber = 1,
            int pageSize = 10,
            int maxNavigationPages = 5)
        {
            // Calculate total pages
            var totalPages = (int)Math.Ceiling(totalItems / (decimal)pageSize);

            // Ensure actual page isn't out of range
            if (pageNumber < 1)
            {
                pageNumber = 1;
            }
            else if (pageNumber > totalPages)
            {
                pageNumber = totalPages;
            }

            int startPage;
            int endPage;
            if (totalPages <= maxNavigationPages)
            {
                startPage = 1;
                endPage = totalPages;
            }
            else
            {
                var maxPagesBeforeActualPage = (int)Math.Floor(maxNavigationPages / (decimal)2);
                var maxPagesAfterActualPage = (int)Math.Ceiling(maxNavigationPages / (decimal)2) - 1;
                if (pageNumber <= maxPagesBeforeActualPage)
                {
                    // Page at the start
                    startPage = 1;
                    endPage = maxNavigationPages;
                }
                else if (pageNumber + maxPagesAfterActualPage >= totalPages)
                {
                    // Page at the end
                    startPage = totalPages - maxNavigationPages + 1;
                    endPage = totalPages;
                }
                else
                {
                    // Page in the middle
                    startPage = pageNumber - maxPagesBeforeActualPage;
                    endPage = pageNumber + maxPagesAfterActualPage;
                }
            }

            // Create list of Page numbers
            var pageNumbers = Enumerable.Range(startPage, (endPage + 1) - startPage);

            StartPage = startPage;
            EndPage = endPage;
            PageNumber = pageNumber;
            PageNumbers = pageNumbers;
            PageSize = pageSize;
            TotalItems = totalItems;
            TotalPages = totalPages;

            // Initialize Items to an empty list to satisfy non-nullable property requirement
            Items = new List<T>();
        }

        public IEnumerable<T> Items { get; set; } = new List<T>();

        /// <summary>
        /// Total number of items to be paged
        /// </summary>
        public int TotalItems { get; set; }

        /// <summary>
        /// Maximum number of page navigation links to display, default is 5
        /// </summary>
        public int MaxNavigationPages { get; private set; } = 5;

        /// <summary>
        /// Current active page
        /// </summary>
        public int PageNumber { get; private set; } = 1;

        /// <summary>
        /// Number of items per page, default is 10
        /// </summary>
        public int PageSize { get; private set; } = 10;

        public int TotalPages { get; private set; }

        /// <summary>
        /// Start Page number
        /// </summary>        
        public int StartPage { get; private set; }

        /// <summary>
        /// End Page number
        /// </summary>        
        public int EndPage { get; private set; }

        /// <summary>
        /// List of page numbers that we can loop
        /// </summary>
        public IEnumerable<int> PageNumbers { get; private set; }

        /// <summary>
        /// Page name for Razer Pages
        /// </summary>
        public string RazerPageName { get; set; } = string.Empty;

        /// <summary>
        /// Generate Pagination
        /// </summary>
        /// <returns></returns>
        public string GeneratePagination()
        {
            return GeneratePagination(RazerPageName, PageNumber, TotalPages, PageNumbers.ToList());
        }

        /// <summary>
        /// Generate Pagination
        /// </summary>
        /// <param name="pageNumber"></param>
        /// <param name="totalPages"></param>
        /// <param name="pageNumbers"></param>
        /// <returns></returns>
        public static string GeneratePagination(string RazerPageName, int pageNumber, int totalPages, List<int> pageNumbers)
        {
            StringBuilder html = new StringBuilder();

            html.Append("<nav class='table-responsive'>");
            html.Append("<ul class='pagination justify-content-center d-flex flex-wrap'>");

            // First & Previous buttons
            html.Append($"<li class='page-item {(pageNumber > 1 ? "enabled" : "disabled")}'>");
            html.Append($"<a class='page-link' href='/{RazerPageName}?pageNumber=1'>First</a></li>");

            html.Append($"<li class='page-item {(pageNumber > 1 ? "enabled" : "disabled")}'>");
            html.Append($"<a class='page-link' href='/{RazerPageName}?pageNumber={pageNumber - 1}'>Prev</a></li>");

            // Page numbers
            foreach (var num in pageNumbers)
            {
                html.Append($"<li class='page-item {(num == pageNumber ? "active" : "")}'>");
                html.Append($"<a class='page-link' href='/{RazerPageName}?pageNumber={num}'>{num}</a></li>");
            }

            // Next & Last buttons
            html.Append($"<li class='page-item {(pageNumber < totalPages ? "enabled" : "disabled")}'>");
            html.Append($"<a class='page-link' href='/{RazerPageName}?pageNumber={pageNumber + 1}'>Next</a></li>");

            html.Append($"<li class='page-item {(pageNumber < totalPages ? "enabled" : "disabled")}'>");
            html.Append($"<a class='page-link' href='/{RazerPageName}?pageNumber={totalPages}'>Last</a></li>");

            html.Append("</ul>");
            html.Append("</nav>");

            return html.ToString();
        }
    }
}
