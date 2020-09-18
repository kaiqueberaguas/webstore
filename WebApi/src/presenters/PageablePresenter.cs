using System.Collections.Generic;
using webApi.src.models;
using WebApi.Src.Models;

namespace WebApi.Src.Presenters
{
    public class PageablePresenter<T>
    {
        public List<T> Content { get; set; }
        public int PageIndex { get; private set; }
        public int TotalPages { get; private set; }

        public PageablePresenter(int pageIndex, int totalPages)
        {
            Content = new List<T>();
            PageIndex = pageIndex;
            TotalPages = totalPages;
        }
        public PageablePresenter(int pageIndex, int totalPages, List<T> contect)
        {
            Content = contect;
            PageIndex = pageIndex;
            TotalPages = totalPages;
        }
    }
}
