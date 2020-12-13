using System;
using System.Collections.Generic;
using webApi.src.models;

namespace WebApi.Src.Models
{
    public class Pageable<T> : List<T> where T : Entity
    {

        public int PageIndex { get; private set; }
        public int TotalPages { get; private set; }

        public Pageable(List<T> items, int totalItens, int pageIndex, int pageSize)
        {
            PageIndex = pageIndex;
            TotalPages = (int)Math.Ceiling(totalItens / (double)pageSize);
            this.AddRange(items);
        }
    }
}
